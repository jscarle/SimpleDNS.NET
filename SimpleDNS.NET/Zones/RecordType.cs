using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Zones;

[JsonConverter(typeof(StringEnumConverter))]
public enum RecordType
{
    A,
    Aaaa,
    Afsdb,
    Alias,
    Atma,
    Caa,
    Cert,
    Cname,
    Dname,
    Ds,
    Hinfo,
    Isdn,
    Loc,
    Mb,
    Mg,
    Minfo,
    Mr,
    Mx,
    Naptr,
    Ns,
    Nsap,
    Ptr,
    Rp,
    Rt,
    Soa,
    Srv,
    Tlsa,
    Txt,
    Unknown,
    X25
}