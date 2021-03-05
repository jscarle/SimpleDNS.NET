using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class StringList : List<String>, ICommittable
    {
        [JsonIgnore]
        public bool Changed { get; private set; }
        public void Commit() { Changed = false; }

        public StringList() { }
        public StringList(IEnumerable<String> collection) : base(collection) { }
        public StringList(int capacity) : base(capacity) { }
        public new int Capacity { get { return base.Capacity; } set { Changed = true; base.Capacity = value; } }
        public new int Count { get { return base.Count; } }
        public new String this[int index] { get { return base[index]; } set { Changed = true; base[index] = value; } }
        public new void Add(String item) { Changed = true; base.Add(item); }
        public new void AddRange(IEnumerable<String> collection) { Changed = true; base.AddRange(collection); }
        public new ReadOnlyCollection<String> AsReadOnly() { return base.AsReadOnly(); }
        public new int BinarySearch(int index, int count, String item, IComparer<String> comparer) { return base.BinarySearch(index, count, item, comparer); }
        public new int BinarySearch(String item) { return base.BinarySearch(item); }
        public new int BinarySearch(String item, IComparer<String> comparer) { return base.BinarySearch(item, comparer); }
        public new void Clear() { Changed = true; base.Clear(); }
        public new bool Contains(String item) { return base.Contains(item); }
        public new List<TOutput> ConvertAll<TOutput>(Converter<String, TOutput> converter) { return base.ConvertAll(converter); }
        public new void CopyTo(int index, String[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
        public new void CopyTo(String[] array) { base.CopyTo(array); }
        public new void CopyTo(String[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
        public new bool Exists(Predicate<String> match) { return base.Exists(match); }
        public new String Find(Predicate<String> match) { return base.Find(match); }
        public new List<String> FindAll(Predicate<String> match) { return base.FindAll(match); }
        public new int FindIndex(int startIndex, int count, Predicate<String> match) { return base.FindIndex(startIndex, count, match); }
        public new int FindIndex(int startIndex, Predicate<String> match) { return base.FindIndex(startIndex, match); }
        public new int FindIndex(Predicate<String> match) { return base.FindIndex(match); }
        public new String FindLast(Predicate<String> match) { return base.FindLast(match); }
        public new int FindLastIndex(int startIndex, int count, Predicate<String> match) { return base.FindLastIndex(startIndex, count, match); }
        public new int FindLastIndex(int startIndex, Predicate<String> match) { return base.FindLastIndex(startIndex, match); }
        public new int FindLastIndex(Predicate<String> match) { return base.FindLastIndex(match); }
        public new void ForEach(Action<String> action) { base.ForEach(action); }
        public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
        public new List<String> GetRange(int index, int count) { return base.GetRange(index, count); }
        public new int IndexOf(String item) { return base.IndexOf(item); }
        public new int IndexOf(String item, int index) { return base.IndexOf(item, index); }
        public new int IndexOf(String item, int index, int count) { return base.IndexOf(item, index, count); }
        public new void Insert(int index, String item) { Changed = true; base.Insert(index, item); }
        public new void InsertRange(int index, IEnumerable<String> collection) { Changed = true; base.InsertRange(index, collection); }
        public new int LastIndexOf(String item) { return base.LastIndexOf(item); }
        public new int LastIndexOf(String item, int index) { return base.LastIndexOf(item, index); }
        public new int LastIndexOf(String item, int index, int count) { return base.LastIndexOf(item, index, count); }
        public new bool Remove(String item) { Changed = true; return base.Remove(item); }
        public new int RemoveAll(Predicate<String> match) { Changed = true; return base.RemoveAll(match); }
        public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
        public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
        public new void Reverse() { Changed = true; base.Reverse(); }
        public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
        public new void Sort() { Changed = true; base.Sort(); }
        public new void Sort(IComparer<String> comparer) { Changed = true; base.Sort(comparer); }
        public new void Sort(Comparison<String> comparison) { Changed = true; base.Sort(comparison); }
        public new void Sort(int index, int count, IComparer<String> comparer) { Changed = true; base.Sort(index, count, comparer); }
        public new String[] ToArray() { return base.ToArray(); } 
        public new void TrimExcess() { Changed = true; base.TrimExcess(); } 
        public new bool TrueForAll(Predicate<String> match) { return base.TrueForAll(match); }
    }
}