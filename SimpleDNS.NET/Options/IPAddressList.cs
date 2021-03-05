using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class IPAddressList : List<IPAddress>, ICommittable
    {
        [JsonIgnore]
        public bool Changed { get; private set; }
        public void Commit() { Changed = false; }

        public IPAddressList() { }
        public IPAddressList(IEnumerable<IPAddress> collection) : base(collection) { }
        public IPAddressList(int capacity) : base(capacity) { }
        public new int Capacity { get { return base.Capacity; } set { Changed = true; base.Capacity = value; } }
        public new int Count { get { return base.Count; } }
        public new IPAddress this[int index] { get { return base[index]; } set { Changed = true; base[index] = value; } }
        public new void Add(IPAddress item) { Changed = true; base.Add(item); }
        public new void AddRange(IEnumerable<IPAddress> collection) { Changed = true; base.AddRange(collection); }
        public new ReadOnlyCollection<IPAddress> AsReadOnly() { return base.AsReadOnly(); }
        public new int BinarySearch(int index, int count, IPAddress item, IComparer<IPAddress> comparer) { return base.BinarySearch(index, count, item, comparer); }
        public new int BinarySearch(IPAddress item) { return base.BinarySearch(item); }
        public new int BinarySearch(IPAddress item, IComparer<IPAddress> comparer) { return base.BinarySearch(item, comparer); }
        public new void Clear() { Changed = true; base.Clear(); }
        public new bool Contains(IPAddress item) { return base.Contains(item); }
        public new List<TOutput> ConvertAll<TOutput>(Converter<IPAddress, TOutput> converter) { return base.ConvertAll(converter); }
        public new void CopyTo(int index, IPAddress[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
        public new void CopyTo(IPAddress[] array) { base.CopyTo(array); }
        public new void CopyTo(IPAddress[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
        public new bool Exists(Predicate<IPAddress> match) { return base.Exists(match); }
        public new IPAddress Find(Predicate<IPAddress> match) { return base.Find(match); }
        public new List<IPAddress> FindAll(Predicate<IPAddress> match) { return base.FindAll(match); }
        public new int FindIndex(int startIndex, int count, Predicate<IPAddress> match) { return base.FindIndex(startIndex, count, match); }
        public new int FindIndex(int startIndex, Predicate<IPAddress> match) { return base.FindIndex(startIndex, match); }
        public new int FindIndex(Predicate<IPAddress> match) { return base.FindIndex(match); }
        public new IPAddress FindLast(Predicate<IPAddress> match) { return base.FindLast(match); }
        public new int FindLastIndex(int startIndex, int count, Predicate<IPAddress> match) { return base.FindLastIndex(startIndex, count, match); }
        public new int FindLastIndex(int startIndex, Predicate<IPAddress> match) { return base.FindLastIndex(startIndex, match); }
        public new int FindLastIndex(Predicate<IPAddress> match) { return base.FindLastIndex(match); }
        public new void ForEach(Action<IPAddress> action) { base.ForEach(action); }
        public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
        public new List<IPAddress> GetRange(int index, int count) { return base.GetRange(index, count); }
        public new int IndexOf(IPAddress item) { return base.IndexOf(item); }
        public new int IndexOf(IPAddress item, int index) { return base.IndexOf(item, index); }
        public new int IndexOf(IPAddress item, int index, int count) { return base.IndexOf(item, index, count); }
        public new void Insert(int index, IPAddress item) { Changed = true; base.Insert(index, item); }
        public new void InsertRange(int index, IEnumerable<IPAddress> collection) { Changed = true; base.InsertRange(index, collection); }
        public new int LastIndexOf(IPAddress item) { return base.LastIndexOf(item); }
        public new int LastIndexOf(IPAddress item, int index) { return base.LastIndexOf(item, index); }
        public new int LastIndexOf(IPAddress item, int index, int count) { return base.LastIndexOf(item, index, count); }
        public new bool Remove(IPAddress item) { Changed = true; return base.Remove(item); }
        public new int RemoveAll(Predicate<IPAddress> match) { Changed = true; return base.RemoveAll(match); }
        public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
        public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
        public new void Reverse() { Changed = true; base.Reverse(); }
        public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
        public new void Sort() { Changed = true; base.Sort(); }
        public new void Sort(IComparer<IPAddress> comparer) { Changed = true; base.Sort(comparer); }
        public new void Sort(Comparison<IPAddress> comparison) { Changed = true; base.Sort(comparison); }
        public new void Sort(int index, int count, IComparer<IPAddress> comparer) { Changed = true; base.Sort(index, count, comparer); }
        public new IPAddress[] ToArray() { return base.ToArray(); }
        public new void TrimExcess() { Changed = true; base.TrimExcess(); }
        public new bool TrueForAll(Predicate<IPAddress> match) { return base.TrueForAll(match); }
    }
}