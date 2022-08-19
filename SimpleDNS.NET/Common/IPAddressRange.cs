using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text.RegularExpressions;
#if NET48
using System.Runtime.Serialization;
#endif

namespace SimpleDNS.Common
{

    // Based on https://github.com/jsakamoto/ipaddressrange version 4.1.3 released on 2021-02-24
#if NET48
    [Serializable]
    public class IPAddressRange : ISerializable, IEnumerable<IPAddress>, IReadOnlyDictionary<string, string>, IEquatable<IPAddressRange>
#else
    public class IpAddressRange : IEnumerable<IPAddress>, IReadOnlyDictionary<string, string>, IEquatable<IpAddressRange>
#endif
    {
        // Pattern 1. CIDR range: "192.168.0.0/24", "fe80::%lo0/10"
        private static readonly Regex CidrPattern = new(@"^(?<adr>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))[ \t]*/[ \t]*(?<maskLen>\d+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Pattern 2. Uni address: "127.0.0.1", "::1%eth0"
        private static readonly Regex UnicastPattern = new(@"^(?<adr>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Pattern 3. First last range: "169.254.0.0-169.254.0.255", "fe80::1%23-fe80::ff%23"
        //            also shortcut notation: "192.168.1.1-7" (IPv4 only)
        private static readonly Regex RangePattern = new(@"^(?<first>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))[ \t]*[\-–][ \t]*(?<last>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Pattern 4. Bit mask range: "192.168.0.0/255.255.255.0"
        private static readonly Regex SubnetMaskPattern = new(@"^(?<adr>([\d.]+)|([\da-f:]+(:[\d.]+)?(%\w+)?))[ \t]*/[ \t]*(?<bitmask>[\da-f\.:]+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private IPAddress _first;
        public IPAddress First
        {
            get => _first;
            set { _first = value; _operator = null; }
        }

        private IPAddress _last;
        public IPAddress Last
        {
            get => _last;
            set { _last = value; _operator = null; }
        }

        private IRangeOperator _operator;
        private IRangeOperator Operator => _operator ??= RangeOperatorFactory.Create(this);

        /// <summary>
        /// Creates an empty range object, equivalent to "0.0.0.0/0".
        /// </summary>
        public IpAddressRange() : this(new IPAddress(0L)) { }

        /// <summary>
        /// Creates a new range with the same start/last address (range of one)
        /// </summary>
        /// <param name="singleAddress"></param>
        public IpAddressRange(IPAddress singleAddress)
        {
            if (singleAddress == null)
                throw new ArgumentNullException(nameof(singleAddress));

            First = Last = singleAddress;
        }

        /// <summary>
        /// Create a new range from a first and last address.
        /// Throws an exception if First comes after Last, or the
        /// addresses are not in the same family.
        /// </summary>
        public IpAddressRange(IPAddress first, IPAddress last)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));

            if (last == null)
                throw new ArgumentNullException(nameof(last));

            var firstBytes = first.GetAddressBytes();
            var lastBytes = last.GetAddressBytes();
            First = new IPAddress(firstBytes);
            Last = new IPAddress(lastBytes);

            if (First.AddressFamily != Last.AddressFamily) throw new ArgumentException("Elements must be of the same address family", nameof(last));

            if (!Bits.GtECore(lastBytes, firstBytes)) throw new ArgumentException("First must be smaller than the Last", nameof(first));
        }

        /// <summary>
        /// Creates a range from a base address and mask bits.
        /// This can also be used with maskLength to create a
        /// range based on a subnet mask.
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="maskLength"></param>
        public IpAddressRange(IPAddress baseAddress, int maskLength)
        {
            if (baseAddress == null)
                throw new ArgumentNullException(nameof(baseAddress));

            var baseAdrBytes = baseAddress.GetAddressBytes();
            if (baseAdrBytes.Length * 8 < maskLength) throw new FormatException();
            var maskBytes = Bits.GetBitMask(baseAdrBytes.Length, maskLength);
            baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);

            First = new IPAddress(baseAdrBytes);
            Last = new IPAddress(Bits.Or(baseAdrBytes, Bits.Not(maskBytes)));
        }

#if NET48
        protected IPAddressRange(SerializationInfo info, StreamingContext context)
        {
            List<string> names = new List<string>();
            foreach (SerializationEntry item in info) names.Add(item.Name);

            IPAddress deserialize(string name) => names.Contains(name) ?
                 IPAddress.Parse(info.GetValue(name, typeof(object)).ToString()) :
                 new IPAddress(0L);

            First = deserialize("First");
            Last = deserialize("Last");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            info.AddValue("First", First != null ? First.ToString() : "");
            info.AddValue("Last", Last != null ? Last.ToString() : "");
        }
#endif

        public bool Contains(IPAddress ipAddress)
        {
            if (ipAddress == null) throw new ArgumentNullException(nameof(ipAddress));

            var rangeOperator = Operator;
            return ipAddress.AddressFamily == First.AddressFamily && rangeOperator.Contains(ipAddress);
        }

        public bool Contains(IpAddressRange range)
        {
            if (range == null) throw new ArgumentNullException(nameof(range));

            var rangeOperator = Operator;
            return First.AddressFamily == range.First.AddressFamily && rangeOperator.Contains(range);
        }

        public static IpAddressRange Parse(string ipRangeString)
        {
            if (ipRangeString == null) throw new ArgumentNullException(nameof(ipRangeString));

            // trim white spaces.
            ipRangeString = ipRangeString.Trim();

            // Pattern 1. CIDR range: "192.168.0.0/24", "fe80::/10%eth0"
            var m1 = CidrPattern.Match(ipRangeString);
            if (m1.Success)
            {
                var baseAdrBytes = IPAddress.Parse(StripScopeId(m1.Groups["adr"].Value)).GetAddressBytes();
                var maskLen = int.Parse(m1.Groups["maskLen"].Value);
                if (baseAdrBytes.Length * 8 < maskLen) throw new FormatException();
                var maskBytes = Bits.GetBitMask(baseAdrBytes.Length, maskLen);
                baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);
                return new IpAddressRange(new IPAddress(baseAdrBytes), new IPAddress(Bits.Or(baseAdrBytes, Bits.Not(maskBytes))));
            }

            // Pattern 2. Uni address: "127.0.0.1", ":;1"
            var m2 = UnicastPattern.Match(ipRangeString);
            if (m2.Success)
            {
                return new IpAddressRange(IPAddress.Parse(StripScopeId(ipRangeString)));
            }

            // Pattern 3. First last range: "169.254.0.0-169.254.0.255"
            var m3 = RangePattern.Match(ipRangeString);
            if (m3.Success)
            {
                // if the left part contains dot, but the right one does not, we treat it as a shortuct notation
                // and simply copy the part before last dot from the left part as the prefix to the right one
                var first = m3.Groups["first"].Value;
                var last = m3.Groups["last"].Value;
                if (!first.Contains('.') || last.Contains('.'))
                    return new IpAddressRange(first: IPAddress.Parse(StripScopeId(first)), last: IPAddress.Parse(StripScopeId(last)));
                if (last.Contains('%'))
                    throw new FormatException("The last of IPv4 range shortcut notation contains scope id.");

                var lastDotAt = first.LastIndexOf('.');
                last = first[..(lastDotAt + 1)] + last;

                return new IpAddressRange(first: IPAddress.Parse(StripScopeId(first)), last: IPAddress.Parse(StripScopeId(last)));
            }

            // Pattern 4. Bit mask range: "192.168.0.0/255.255.255.0"
            var m4 = SubnetMaskPattern.Match(ipRangeString);
            if (m4.Success)
            {
                var baseAdrBytes = IPAddress.Parse(StripScopeId(m4.Groups["adr"].Value)).GetAddressBytes();
                var maskBytes = IPAddress.Parse(m4.Groups["bitmask"].Value).GetAddressBytes();
                ValidateSubnetMaskIsLinear(maskBytes);
                baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);
                return new IpAddressRange(new IPAddress(baseAdrBytes), new IPAddress(Bits.Or(baseAdrBytes, Bits.Not(maskBytes))));
            }

            throw new FormatException("Unknown IP range string.");
        }

        private static string StripScopeId(string ipAddressString) => ipAddressString.Split('%')[0];

        private static void ValidateSubnetMaskIsLinear(IReadOnlyList<byte> maskBytes)
        {
            var f = maskBytes[0] & 0x80; // 0x00: The bit should be 0, 0x80: The bit should be 1
            for (var i = 0; i < maskBytes.Count; i++)
            {
                var maskByte = maskBytes[i];
                for (var b = 0; b < 8; b++)
                {
                    var bit = maskByte & 0x80;
                    switch (f)
                    {
                        case 0x00:
                            if (bit != 0x00) throw new FormatException("The subnet mask is not linear.");
                            break;
                        case 0x80:
                            if (bit == 0x00) f = 0x00;
                            break;
                        default: throw new Exception();
                    }
                    maskByte <<= 1;
                }
            }
        }

        public static bool TryParse(string ipRangeString, out IpAddressRange ipRange)
        {
            try
            {
                ipRange = Parse(ipRangeString);
                return true;
            }
            catch (Exception)
            {
                ipRange = null;
                return false;
            }
        }

        public IEnumerator<IPAddress> GetEnumerator()
        {
            return Operator.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the range in the format "first-last", or 
        /// as a single address if Last is the same as First.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Equals(First, Last))
                return First.ToString();
            return Prefix > 0 ? $"{First}/{Prefix}" : $"{First}-{Last}";
        }

        public bool Equals(IpAddressRange other)
        {
            return other != null && First.Equals(other.First) && Last.Equals(other.Last);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != GetType()) return false;
            return ReferenceEquals(this, obj) || Equals((IpAddressRange)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(First, Last);
        }

        public int Prefix
        {
            get
            {
                var byteFirst = First.GetAddressBytes();

                // Handle single IP
                if (First.Equals(Last))
                    return byteFirst.Length * 8;

                var length = byteFirst.Length * 8;

                for (var i = 0; i < length; i++)
                {
                    var mask = Bits.GetBitMask(byteFirst.Length, i);
                    if (new IPAddress(Bits.And(byteFirst, mask)).Equals(First) && new IPAddress(Bits.Or(byteFirst, Bits.Not(mask))).Equals(Last))
                        return i;
                }

                return 0;
            }
        }

        public bool IsPrivate()
        {
            var privateRanges = new List<IpAddressRange>();
            switch (First.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    privateRanges.Add(Parse("10.0.0.0/8"));
                    privateRanges.Add(Parse("172.16.0.0/12"));
                    privateRanges.Add(Parse("192.168.0.0/16"));
                    break;
                case AddressFamily.InterNetworkV6:
                    privateRanges.Add(Parse("fd00::/8"));
                    break;
            }

            return privateRanges.Any(privateRange => privateRange.Contains(First) || privateRange.Contains(Last));
        }

        public bool IsReserved()
        {
            var reservedRanges = new List<IpAddressRange>();
            switch (First.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    reservedRanges.Add(Parse("0.0.0.0/8"));
                    reservedRanges.Add(Parse("10.0.0.0/8"));
                    reservedRanges.Add(Parse("100.64.0.0/10"));
                    reservedRanges.Add(Parse("127.0.0.0/8"));
                    reservedRanges.Add(Parse("169.254.0.0/16"));
                    reservedRanges.Add(Parse("172.16.0.0/12"));
                    reservedRanges.Add(Parse("192.0.0.0/24"));
                    reservedRanges.Add(Parse("192.0.2.0/24"));
                    reservedRanges.Add(Parse("192.88.99.0/24"));
                    reservedRanges.Add(Parse("192.168.0.0/16"));
                    reservedRanges.Add(Parse("198.18.0.0/15"));
                    reservedRanges.Add(Parse("198.51.100.0/24"));
                    reservedRanges.Add(Parse("203.0.113.0/24"));
                    reservedRanges.Add(Parse("224.0.0.0/4"));
                    reservedRanges.Add(Parse("240.0.0.0/4"));
                    reservedRanges.Add(Parse("255.255.255.255/32"));
                    break;
                case AddressFamily.InterNetworkV6:
                    reservedRanges.Add(Parse("::/0"));
                    reservedRanges.Add(Parse("::/128"));
                    reservedRanges.Add(Parse("::1/128"));
                    reservedRanges.Add(Parse("::ffff:0:0/96"));
                    reservedRanges.Add(Parse("::ffff:0:0:0/96"));
                    reservedRanges.Add(Parse("64:ff9b::/96"));
                    reservedRanges.Add(Parse("100::/64"));
                    reservedRanges.Add(Parse("2001::/32"));
                    reservedRanges.Add(Parse("2001:20::/28"));
                    reservedRanges.Add(Parse("2001:db8::/32"));
                    reservedRanges.Add(Parse("2002::/16"));
                    reservedRanges.Add(Parse("fc00::/7"));
                    reservedRanges.Add(Parse("fe80::/10"));
                    reservedRanges.Add(Parse("ff00::/8"));
                    break;
            }

            return reservedRanges.Any(reservedRange => reservedRange.Contains(First) || reservedRange.Contains(Last));
        }

        #region JSON.NET Support by implement IReadOnlyDictionary<string, string>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IpAddressRange(IEnumerable<KeyValuePair<string, string>> items)
        {
            var keyValuePairs = items.ToList();
            First = IPAddress.Parse(TryGetValue(keyValuePairs, nameof(First), out var value1) ? value1 : throw new KeyNotFoundException());
            Last = IPAddress.Parse(TryGetValue(keyValuePairs, nameof(Last), out var value2) ? value2 : throw new KeyNotFoundException());
        }

        /// <summary>
        /// Returns the input typed as IEnumerable&lt;IPAddress&gt;
        /// </summary>
        public IEnumerable<IPAddress> AsEnumerable() => Operator;

        private IEnumerable<KeyValuePair<string, string>> GetDictionaryItems()
        {
            return new[] {
                new KeyValuePair<string,string>(nameof(First), First.ToString()),
                new KeyValuePair<string,string>(nameof(Last), Last.ToString()),
            };
        }

        private bool TryGetValue(string key, out string value) => TryGetValue(GetDictionaryItems(), key, out value);

        private bool TryGetValue(IEnumerable<KeyValuePair<string, string>> items, string key, out string value)
        {
            items ??= GetDictionaryItems();
            var foundItem = items.FirstOrDefault(item => item.Key == key);
            value = foundItem.Value;
            return foundItem.Key != null;
        }

        IEnumerable<string> IReadOnlyDictionary<string, string>.Keys => GetDictionaryItems().Select(item => item.Key);

        IEnumerable<string> IReadOnlyDictionary<string, string>.Values => GetDictionaryItems().Select(item => item.Value);

        int IReadOnlyCollection<KeyValuePair<string, string>>.Count => GetDictionaryItems().Count();

        string IReadOnlyDictionary<string, string>.this[string key] => TryGetValue(key, out var value) ? value : throw new KeyNotFoundException();

        bool IReadOnlyDictionary<string, string>.ContainsKey(string key) => GetDictionaryItems().Any(item => item.Key == key);

        bool IReadOnlyDictionary<string, string>.TryGetValue(string key, out string value) => TryGetValue(key, out value);

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator() => GetDictionaryItems().GetEnumerator();

        #endregion

        #region Helper classes

        private static class Bits
        {
            internal static byte[] Not(byte[] bytes)
            {
                var result = (byte[])bytes.Clone();
                for (var i = 0; i < result.Length; i++)
                {
                    result[i] = (byte)~result[i];
                }
                return result;
            }

            internal static byte[] And(byte[] a, byte[] b)
            {
                var result = (byte[])a.Clone();
                for (var i = 0; i < a.Length; i++)
                {
                    result[i] &= b[i];
                }
                return result;
            }

            internal static byte[] Or(byte[] a, byte[] b)
            {
                var result = (byte[])a.Clone();
                for (var i = 0; i < a.Length; i++)
                {
                    result[i] |= b[i];
                }
                return result;
            }

            internal static bool GtECore(byte[] a, byte[] b, int offset = 0)
            {
                var length = a.Length;
                if (length > b.Length) length = b.Length;
                for (var i = offset; i < length; i++)
                {
                    if (a[i] != b[i]) return a[i] >= b[i];
                }
                return true;
            }

            internal static byte[] GetBitMask(int sizeOfBuff, int bitLen)
            {
                var maskBytes = new byte[sizeOfBuff];
                var bytesLen = bitLen / 8;
                var bitsLen = bitLen % 8;
                for (var i = 0; i < bytesLen; i++)
                {
                    maskBytes[i] = 0xff;
                }
                if (bitsLen > 0) maskBytes[bytesLen] = (byte)~Enumerable.Range(1, 8 - bitsLen).Select(n => 1 << n - 1).Aggregate((a, b) => a | b);
                return maskBytes;
            }
        }

        private class Pv4RangeOperator : IRangeOperator
        {
            private uint First { get; }

            private uint Last { get; }

            internal Pv4RangeOperator(IpAddressRange range)
            {
                First = IpAddressToUInt32(range.First);
                Last = IpAddressToUInt32(range.Last);
            }

            private bool Contains(IPAddress ipaddress)
            {
                var address = IpAddressToUInt32(ipaddress);
                return First <= address && address <= Last;
            }

            public bool Contains(IpAddressRange range)
            {
                var rangeFirst = IpAddressToUInt32(range.First);
                var rangeLast = IpAddressToUInt32(range.Last);
                return First <= rangeFirst && rangeLast <= Last;
            }

            public IEnumerator<IPAddress> GetEnumerator()
            {
                for (var adr = First; adr <= Last; adr++)
                {
                    yield return UInt32ToIPv4Address(adr);
                }
            }

            int ICollection<IPAddress>.Count => (int)(Last - First + 1);

            bool ICollection<IPAddress>.IsReadOnly => true;

            void ICollection<IPAddress>.Add(IPAddress item) => throw new InvalidOperationException();

            void ICollection<IPAddress>.Clear() => throw new InvalidOperationException();

            bool ICollection<IPAddress>.Contains(IPAddress item)
            {
                return Contains(item);
            }

            void ICollection<IPAddress>.CopyTo(IPAddress[] array, int arrayIndex)
            {
                if (array.Length - arrayIndex < (this as ICollection<IPAddress>).Count) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

                foreach (var ipAddress in this)
                {
                    array[arrayIndex++] = ipAddress;
                }
            }

            bool ICollection<IPAddress>.Remove(IPAddress item) => throw new InvalidOperationException();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class Pv6RangeOperator : IRangeOperator
        {
            private BigInteger First { get; }

            private BigInteger Last { get; }

            internal Pv6RangeOperator(IpAddressRange range)
            {
                First = IpAddressToBigInteger(range.First);
                Last = IpAddressToBigInteger(range.Last);
            }

            private bool Contains(IPAddress ipAddress)
            {
                var address = IpAddressToBigInteger(ipAddress);
                return First <= address && address <= Last;
            }

            public bool Contains(IpAddressRange range)
            {
                var rangeFirst = IpAddressToBigInteger(range.First);
                var rangeLast = IpAddressToBigInteger(range.Last);
                return First <= rangeFirst && rangeLast <= Last;
            }

            public IEnumerator<IPAddress> GetEnumerator()
            {
                for (var adr = First; adr <= Last; adr++)
                {
                    yield return BigIntegerToIPv6Address(ref adr);
                }
            }

            int ICollection<IPAddress>.Count => (int)(Last - First + 1);

            bool ICollection<IPAddress>.IsReadOnly => true;

            void ICollection<IPAddress>.Add(IPAddress item) => throw new InvalidOperationException();

            void ICollection<IPAddress>.Clear() => throw new InvalidOperationException();

            bool ICollection<IPAddress>.Contains(IPAddress item)
            {
                return Contains(item);
            }

            void ICollection<IPAddress>.CopyTo(IPAddress[] array, int arrayIndex)
            {
                if (array.Length - arrayIndex < (this as ICollection<IPAddress>).Count) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

                foreach (var ipAddress in this)
                {
                    array[arrayIndex++] = ipAddress;
                }
            }

            bool ICollection<IPAddress>.Remove(IPAddress item) => throw new InvalidOperationException();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private interface IRangeOperator : ICollection<IPAddress>
        {
            bool Contains(IpAddressRange range);
        }

        private static class RangeOperatorFactory
        {
            internal static IRangeOperator Create(IpAddressRange range)
            {
                if (range.First.AddressFamily != range.Last.AddressFamily) throw new InvalidOperationException("Both First and Last properties must be of the same address family");

                var firstBytes = range.First.GetAddressBytes();
                var lastBytes = range.Last.GetAddressBytes();
                if (!Bits.GtECore(lastBytes, firstBytes)) throw new InvalidOperationException("First must be smaller than the Last");

                return range.First.AddressFamily == AddressFamily.InterNetwork ?
                    new Pv4RangeOperator(range) :
                    new Pv6RangeOperator(range);
            }
        }

        #endregion

        #region Conversion Helpers

        private static uint IpAddressToUInt32(IPAddress ipAddress)
        {
            var addressBytes = ipAddress.GetAddressBytes();
            Array.Reverse(addressBytes);
            return BitConverter.ToUInt32(addressBytes, 0);
        }

        private static BigInteger IpAddressToBigInteger(IPAddress ipAddress)
        {
            var addressBytes = ipAddress.GetAddressBytes();
            Array.Reverse(addressBytes);
            Array.Resize(ref addressBytes, addressBytes.Length + 1);
            return new BigInteger(addressBytes);
        }

        private static IPAddress UInt32ToIPv4Address(uint value)
        {
            var addressBytes = BitConverter.GetBytes(value);
            Array.Reverse(addressBytes);
            return new IPAddress(addressBytes);
        }

        private static IPAddress BigIntegerToIPv6Address(ref BigInteger value)
        {
            var addressBytes = value.ToByteArray();
            Array.Resize(ref addressBytes, 16);
            Array.Reverse(addressBytes);
            return new IPAddress(addressBytes);
        }

        #endregion
    }

    public static class IpAddressRangeExtensions
    {
        public static bool IsPrivate(this IPAddress ipAddress) => new IpAddressRange(ipAddress).IsPrivate();

        public static bool IsReserved(this IPAddress ipAddress) => new IpAddressRange(ipAddress).IsReserved();
    }
}
