using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class StringList : List<string>, ICommittable
{
    [JsonIgnore]
    public bool Changed { get; private set; }
    public void Commit() { Changed = false; }

    public StringList() { }
    public StringList(IEnumerable<string> collection) : base(collection) { }
    public StringList(int capacity) : base(capacity) { }
    public new int Capacity { get => base.Capacity;
        set { Changed = true; base.Capacity = value; } }
    public new int Count => base.Count;
    public new string this[int index] { get => base[index];
        set { Changed = true; base[index] = value; } }
    public new void Add(string item) { Changed = true; base.Add(item); }
    public new void AddRange(IEnumerable<string> collection) { Changed = true; base.AddRange(collection); }
    public new ReadOnlyCollection<string> AsReadOnly() { return base.AsReadOnly(); }
    public new int BinarySearch(int index, int count, string item, IComparer<string> comparer) { return base.BinarySearch(index, count, item, comparer); }
    public new int BinarySearch(string item) { return base.BinarySearch(item); }
    public new int BinarySearch(string item, IComparer<string> comparer) { return base.BinarySearch(item, comparer); }
    public new void Clear() { Changed = true; base.Clear(); }
    public new bool Contains(string item) { return base.Contains(item); }
    public new List<TOutput> ConvertAll<TOutput>(Converter<string, TOutput> converter) { return base.ConvertAll(converter); }
    public new void CopyTo(int index, string[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
    public new void CopyTo(string[] array) { base.CopyTo(array); }
    public new void CopyTo(string[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
    public new bool Exists(Predicate<string> match) { return base.Exists(match); }
    public new string Find(Predicate<string> match) { return base.Find(match); }
    public new List<string> FindAll(Predicate<string> match) { return base.FindAll(match); }
    public new int FindIndex(int startIndex, int count, Predicate<string> match) { return base.FindIndex(startIndex, count, match); }
    public new int FindIndex(int startIndex, Predicate<string> match) { return base.FindIndex(startIndex, match); }
    public new int FindIndex(Predicate<string> match) { return base.FindIndex(match); }
    public new string FindLast(Predicate<string> match) { return base.FindLast(match); }
    public new int FindLastIndex(int startIndex, int count, Predicate<string> match) { return base.FindLastIndex(startIndex, count, match); }
    public new int FindLastIndex(int startIndex, Predicate<string> match) { return base.FindLastIndex(startIndex, match); }
    public new int FindLastIndex(Predicate<string> match) { return base.FindLastIndex(match); }
    public new void ForEach(Action<string> action) { base.ForEach(action); }
    public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
    public new List<string> GetRange(int index, int count) { return base.GetRange(index, count); }
    public new int IndexOf(string item) { return base.IndexOf(item); }
    public new int IndexOf(string item, int index) { return base.IndexOf(item, index); }
    public new int IndexOf(string item, int index, int count) { return base.IndexOf(item, index, count); }
    public new void Insert(int index, string item) { Changed = true; base.Insert(index, item); }
    public new void InsertRange(int index, IEnumerable<string> collection) { Changed = true; base.InsertRange(index, collection); }
    public new int LastIndexOf(string item) { return base.LastIndexOf(item); }
    public new int LastIndexOf(string item, int index) { return base.LastIndexOf(item, index); }
    public new int LastIndexOf(string item, int index, int count) { return base.LastIndexOf(item, index, count); }
    public new bool Remove(string item) { Changed = true; return base.Remove(item); }
    public new int RemoveAll(Predicate<string> match) { Changed = true; return base.RemoveAll(match); }
    public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
    public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
    public new void Reverse() { Changed = true; base.Reverse(); }
    public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
    public new void Sort() { Changed = true; base.Sort(); }
    public new void Sort(IComparer<string> comparer) { Changed = true; base.Sort(comparer); }
    public new void Sort(Comparison<string> comparison) { Changed = true; base.Sort(comparison); }
    public new void Sort(int index, int count, IComparer<string> comparer) { Changed = true; base.Sort(index, count, comparer); }
    public new string[] ToArray() { return base.ToArray(); } 
    public new void TrimExcess() { Changed = true; base.TrimExcess(); } 
    public new bool TrueForAll(Predicate<string> match) { return base.TrueForAll(match); }
}