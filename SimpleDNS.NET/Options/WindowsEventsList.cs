using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class WindowsEventsList : List<WindowsEvents>, ICommittable
{
    [JsonIgnore]
    public bool Changed { get; private set; }
    public void Commit() { Changed = false; }

    public WindowsEventsList() { }
    public WindowsEventsList(IEnumerable<WindowsEvents> collection) : base(collection) { }
    public WindowsEventsList(int capacity) : base(capacity) { }
    public new int Capacity { get => base.Capacity;
        set { Changed = true; base.Capacity = value; } }
    public new int Count => base.Count;
    public new WindowsEvents this[int index] { get => base[index];
        set { Changed = true; base[index] = value; } }
    public new void Add(WindowsEvents item) { Changed = true; base.Add(item); }
    public new void AddRange(IEnumerable<WindowsEvents> collection) { Changed = true; base.AddRange(collection); }
    public new ReadOnlyCollection<WindowsEvents> AsReadOnly() { return base.AsReadOnly(); }
    public new int BinarySearch(int index, int count, WindowsEvents item, IComparer<WindowsEvents> comparer) { return base.BinarySearch(index, count, item, comparer); }
    public new int BinarySearch(WindowsEvents item) { return base.BinarySearch(item); }
    public new int BinarySearch(WindowsEvents item, IComparer<WindowsEvents> comparer) { return base.BinarySearch(item, comparer); }
    public new void Clear() { Changed = true; base.Clear(); }
    public new bool Contains(WindowsEvents item) { return base.Contains(item); }
    public new List<TOutput> ConvertAll<TOutput>(Converter<WindowsEvents, TOutput> converter) { return base.ConvertAll(converter); }
    public new void CopyTo(int index, WindowsEvents[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
    public new void CopyTo(WindowsEvents[] array) { base.CopyTo(array); }
    public new void CopyTo(WindowsEvents[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
    public new bool Exists(Predicate<WindowsEvents> match) { return base.Exists(match); }
    public new WindowsEvents Find(Predicate<WindowsEvents> match) { return base.Find(match); }
    public new List<WindowsEvents> FindAll(Predicate<WindowsEvents> match) { return base.FindAll(match); }
    public new int FindIndex(int startIndex, int count, Predicate<WindowsEvents> match) { return base.FindIndex(startIndex, count, match); }
    public new int FindIndex(int startIndex, Predicate<WindowsEvents> match) { return base.FindIndex(startIndex, match); }
    public new int FindIndex(Predicate<WindowsEvents> match) { return base.FindIndex(match); }
    public new WindowsEvents FindLast(Predicate<WindowsEvents> match) { return base.FindLast(match); }
    public new int FindLastIndex(int startIndex, int count, Predicate<WindowsEvents> match) { return base.FindLastIndex(startIndex, count, match); }
    public new int FindLastIndex(int startIndex, Predicate<WindowsEvents> match) { return base.FindLastIndex(startIndex, match); }
    public new int FindLastIndex(Predicate<WindowsEvents> match) { return base.FindLastIndex(match); }
    public new void ForEach(Action<WindowsEvents> action) { base.ForEach(action); }
    public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
    public new List<WindowsEvents> GetRange(int index, int count) { return base.GetRange(index, count); }
    public new int IndexOf(WindowsEvents item) { return base.IndexOf(item); }
    public new int IndexOf(WindowsEvents item, int index) { return base.IndexOf(item, index); }
    public new int IndexOf(WindowsEvents item, int index, int count) { return base.IndexOf(item, index, count); }
    public new void Insert(int index, WindowsEvents item) { Changed = true; base.Insert(index, item); }
    public new void InsertRange(int index, IEnumerable<WindowsEvents> collection) { Changed = true; base.InsertRange(index, collection); }
    public new int LastIndexOf(WindowsEvents item) { return base.LastIndexOf(item); }
    public new int LastIndexOf(WindowsEvents item, int index) { return base.LastIndexOf(item, index); }
    public new int LastIndexOf(WindowsEvents item, int index, int count) { return base.LastIndexOf(item, index, count); }
    public new bool Remove(WindowsEvents item) { Changed = true; return base.Remove(item); }
    public new int RemoveAll(Predicate<WindowsEvents> match) { Changed = true; return base.RemoveAll(match); }
    public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
    public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
    public new void Reverse() { Changed = true; base.Reverse(); }
    public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
    public new void Sort() { Changed = true; base.Sort(); }
    public new void Sort(IComparer<WindowsEvents> comparer) { Changed = true; base.Sort(comparer); }
    public new void Sort(Comparison<WindowsEvents> comparison) { Changed = true; base.Sort(comparison); }
    public new void Sort(int index, int count, IComparer<WindowsEvents> comparer) { Changed = true; base.Sort(index, count, comparer); }
    public new WindowsEvents[] ToArray() { return base.ToArray(); }
    public new void TrimExcess() { Changed = true; base.TrimExcess(); }
    public new bool TrueForAll(Predicate<WindowsEvents> match) { return base.TrueForAll(match); }
}