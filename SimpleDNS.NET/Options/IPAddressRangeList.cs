﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options;

public class IpAddressRangeList : List<IpAddressRange>, ICommittable
{
    [JsonIgnore]
    public bool Changed { get; private set; }
    public void Commit() { Changed = false; }

    public IpAddressRangeList() { }
    public IpAddressRangeList(IEnumerable<IpAddressRange> collection) : base(collection) { }
    public IpAddressRangeList(int capacity) : base(capacity) { }
    public new int Capacity { get => base.Capacity;
        set { Changed = true; base.Capacity = value; } }
    public new int Count => base.Count;
    public new IpAddressRange this[int index] { get => base[index];
        set { Changed = true; base[index] = value; } }
    public new void Add(IpAddressRange item) { Changed = true; base.Add(item); }
    public new void AddRange(IEnumerable<IpAddressRange> collection) { Changed = true; base.AddRange(collection); }
    public new ReadOnlyCollection<IpAddressRange> AsReadOnly() { return base.AsReadOnly(); }
    public new int BinarySearch(int index, int count, IpAddressRange item, IComparer<IpAddressRange> comparer) { return base.BinarySearch(index, count, item, comparer); }
    public new int BinarySearch(IpAddressRange item) { return base.BinarySearch(item); }
    public new int BinarySearch(IpAddressRange item, IComparer<IpAddressRange> comparer) { return base.BinarySearch(item, comparer); }
    public new void Clear() { Changed = true; base.Clear(); }
    public new bool Contains(IpAddressRange item) { return base.Contains(item); }
    public new List<TOutput> ConvertAll<TOutput>(Converter<IpAddressRange, TOutput> converter) { return base.ConvertAll(converter); }
    public new void CopyTo(int index, IpAddressRange[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
    public new void CopyTo(IpAddressRange[] array) { base.CopyTo(array); }
    public new void CopyTo(IpAddressRange[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
    public new bool Exists(Predicate<IpAddressRange> match) { return base.Exists(match); }
    public new IpAddressRange Find(Predicate<IpAddressRange> match) { return base.Find(match); }
    public new List<IpAddressRange> FindAll(Predicate<IpAddressRange> match) { return base.FindAll(match); }
    public new int FindIndex(int startIndex, int count, Predicate<IpAddressRange> match) { return base.FindIndex(startIndex, count, match); }
    public new int FindIndex(int startIndex, Predicate<IpAddressRange> match) { return base.FindIndex(startIndex, match); }
    public new int FindIndex(Predicate<IpAddressRange> match) { return base.FindIndex(match); }
    public new IpAddressRange FindLast(Predicate<IpAddressRange> match) { return base.FindLast(match); }
    public new int FindLastIndex(int startIndex, int count, Predicate<IpAddressRange> match) { return base.FindLastIndex(startIndex, count, match); }
    public new int FindLastIndex(int startIndex, Predicate<IpAddressRange> match) { return base.FindLastIndex(startIndex, match); }
    public new int FindLastIndex(Predicate<IpAddressRange> match) { return base.FindLastIndex(match); }
    public new void ForEach(Action<IpAddressRange> action) { base.ForEach(action); }
    public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
    public new List<IpAddressRange> GetRange(int index, int count) { return base.GetRange(index, count); }
    public new int IndexOf(IpAddressRange item) { return base.IndexOf(item); }
    public new int IndexOf(IpAddressRange item, int index) { return base.IndexOf(item, index); }
    public new int IndexOf(IpAddressRange item, int index, int count) { return base.IndexOf(item, index, count); }
    public new void Insert(int index, IpAddressRange item) { Changed = true; base.Insert(index, item); }
    public new void InsertRange(int index, IEnumerable<IpAddressRange> collection) { Changed = true; base.InsertRange(index, collection); }
    public new int LastIndexOf(IpAddressRange item) { return base.LastIndexOf(item); }
    public new int LastIndexOf(IpAddressRange item, int index) { return base.LastIndexOf(item, index); }
    public new int LastIndexOf(IpAddressRange item, int index, int count) { return base.LastIndexOf(item, index, count); }
    public new bool Remove(IpAddressRange item) { Changed = true; return base.Remove(item); }
    public new int RemoveAll(Predicate<IpAddressRange> match) { Changed = true; return base.RemoveAll(match); }
    public new void RemoveAt(int index) { Changed = true; base.RemoveAt(index); }
    public new void RemoveRange(int index, int count) { Changed = true; base.RemoveRange(index, count); }
    public new void Reverse() { Changed = true; base.Reverse(); }
    public new void Reverse(int index, int count) { Changed = true; base.Reverse(index, count); }
    public new void Sort() { Changed = true; base.Sort(); }
    public new void Sort(IComparer<IpAddressRange> comparer) { Changed = true; base.Sort(comparer); }
    public new void Sort(Comparison<IpAddressRange> comparison) { Changed = true; base.Sort(comparison); }
    public new void Sort(int index, int count, IComparer<IpAddressRange> comparer) { Changed = true; base.Sort(index, count, comparer); }
    public new IpAddressRange[] ToArray() { return base.ToArray(); }
    public new void TrimExcess() { Changed = true; base.TrimExcess(); }
    public new bool TrueForAll(Predicate<IpAddressRange> match) { return base.TrueForAll(match); }
}