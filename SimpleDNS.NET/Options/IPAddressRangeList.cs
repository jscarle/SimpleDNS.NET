using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options
{
    public class IPAddressRangeList : List<IPAddressRange>, ICommittable
    {
        [JsonIgnore]
        public bool Changed { get; private set; }
        public void Commit() { Changed = false; }

        public IPAddressRangeList() { }
        public IPAddressRangeList(IEnumerable<IPAddressRange> collection) : base(collection) { }
        public IPAddressRangeList(int capacity) : base(capacity) { }
        public new int Capacity { get { return base.Capacity; } set { Changed = true; base.Capacity = value; } }
        public new int Count { get { return base.Count; } }
        public new IPAddressRange this[int index] { get { return base[index]; } set { Changed = true; base[index] = value; } }
        public new void Add(IPAddressRange item) { Changed = true; base.Add(item); }
        public new void AddRange(IEnumerable<IPAddressRange> collection) { Changed = true; base.AddRange(collection); }
        public new ReadOnlyCollection<IPAddressRange> AsReadOnly() { return base.AsReadOnly(); }
        public new int BinarySearch(int index, int count, IPAddressRange item, IComparer<IPAddressRange> comparer) { return base.BinarySearch(index, count, item, comparer); }
        public new int BinarySearch(IPAddressRange item) { return base.BinarySearch(item); }
        public new int BinarySearch(IPAddressRange item, IComparer<IPAddressRange> comparer) { return base.BinarySearch(item, comparer); }
        public new void Clear() { Changed = true; base.Clear(); }
        public new bool Contains(IPAddressRange item) { return base.Contains(item); }
        public new List<TOutput> ConvertAll<TOutput>(Converter<IPAddressRange, TOutput> converter) { return base.ConvertAll(converter); }
        public new void CopyTo(int index, IPAddressRange[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
        public new void CopyTo(IPAddressRange[] array) { base.CopyTo(array); }
        public new void CopyTo(IPAddressRange[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
        public new bool Exists(Predicate<IPAddressRange> match) { return base.Exists(match); }
        public new IPAddressRange Find(Predicate<IPAddressRange> match) { return base.Find(match); }
        public new List<IPAddressRange> FindAll(Predicate<IPAddressRange> match) { return base.FindAll(match); }
        public new int FindIndex(int startIndex, int count, Predicate<IPAddressRange> match) { return base.FindIndex(startIndex, count, match); }
        public new int FindIndex(int startIndex, Predicate<IPAddressRange> match) { return base.FindIndex(startIndex, match); }
        public new int FindIndex(Predicate<IPAddressRange> match) { return base.FindIndex(match); }
        public new IPAddressRange FindLast(Predicate<IPAddressRange> match) { return base.FindLast(match); }
        public new int FindLastIndex(int startIndex, int count, Predicate<IPAddressRange> match) { return base.FindLastIndex(startIndex, count, match); }
        public new int FindLastIndex(int startIndex, Predicate<IPAddressRange> match) { return base.FindLastIndex(startIndex, match); }
        public new int FindLastIndex(Predicate<IPAddressRange> match) { return base.FindLastIndex(match); }
        public new void ForEach(Action<IPAddressRange> action) { base.ForEach(action); }
        public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
        public new List<IPAddressRange> GetRange(int index, int count) { return base.GetRange(index, count); }
        public new int IndexOf(IPAddressRange item) { return base.IndexOf(item); }
        public new int IndexOf(IPAddressRange item, int index) { return base.IndexOf(item, index); }
        public new int IndexOf(IPAddressRange item, int index, int count) { return base.IndexOf(item, index, count); }
        public new void Insert(int index, IPAddressRange item) { Changed = true; base.Insert(index, item); }
        public new void InsertRange(int index, IEnumerable<IPAddressRange> collection) { Changed = true; base.InsertRange(index, collection); }
        public new int LastIndexOf(IPAddressRange item) { return base.LastIndexOf(item); }
        public new int LastIndexOf(IPAddressRange item, int index) { return base.LastIndexOf(item, index); }
        public new int LastIndexOf(IPAddressRange item, int index, int count) { return base.LastIndexOf(item, index, count); }
        public new bool Remove(IPAddressRange item) { Changed = true; return base.Remove(item); }
        public new int RemoveAll(Predicate<IPAddressRange> match) { Changed = true; return base.RemoveAll(match); }
        public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
        public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
        public new void Reverse() { Changed = true; base.Reverse(); }
        public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
        public new void Sort() { Changed = true; base.Sort(); }
        public new void Sort(IComparer<IPAddressRange> comparer) { Changed = true; base.Sort(comparer); }
        public new void Sort(Comparison<IPAddressRange> comparison) { Changed = true; base.Sort(comparison); }
        public new void Sort(int index, int count, IComparer<IPAddressRange> comparer) { Changed = true; base.Sort(index, count, comparer); }
        public new IPAddressRange[] ToArray() { return base.ToArray(); }
        public new void TrimExcess() { Changed = true; base.TrimExcess(); }
        public new bool TrueForAll(Predicate<IPAddressRange> match) { return base.TrueForAll(match); }
    }
}