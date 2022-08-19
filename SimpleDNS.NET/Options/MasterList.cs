﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class MasterList : List<Master>, ICommittable
{
    [JsonIgnore]
    public bool Changed
    {
        get
        {
            foreach (var item in this)
                _changed |= item.Changed;

            return _changed;
        }
    }
    private bool _changed;
    public void Commit()
    {
        _changed = false;

        foreach (var item in this)
            item.Commit();
    }

    public MasterList() { }
    public MasterList(IEnumerable<Master> collection) : base(collection) { }
    public MasterList(int capacity) : base(capacity) { }
    public new int Capacity { get => base.Capacity;
        set { _changed = true; base.Capacity = value; } }
    public new int Count => base.Count;
    public new Master this[int index] { get => base[index];
        set { _changed = true; base[index] = value; } }
    public new void Add(Master item) { _changed = true; base.Add(item); }
    public new void AddRange(IEnumerable<Master> collection) { _changed = true; base.AddRange(collection); }
    public new ReadOnlyCollection<Master> AsReadOnly() { return base.AsReadOnly(); }
    public new int BinarySearch(int index, int count, Master item, IComparer<Master> comparer) { return base.BinarySearch(index, count, item, comparer); }
    public new int BinarySearch(Master item) { return base.BinarySearch(item); }
    public new int BinarySearch(Master item, IComparer<Master> comparer) { return base.BinarySearch(item, comparer); }
    public new void Clear() { _changed = true; base.Clear(); }
    public new bool Contains(Master item) { return base.Contains(item); }
    public new List<TOutput> ConvertAll<TOutput>(Converter<Master, TOutput> converter) { return base.ConvertAll(converter); }
    public new void CopyTo(int index, Master[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
    public new void CopyTo(Master[] array) { base.CopyTo(array); }
    public new void CopyTo(Master[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
    public new bool Exists(Predicate<Master> match) { return base.Exists(match); }
    public new Master Find(Predicate<Master> match) { return base.Find(match); }
    public new List<Master> FindAll(Predicate<Master> match) { return base.FindAll(match); }
    public new int FindIndex(int startIndex, int count, Predicate<Master> match) { return base.FindIndex(startIndex, count, match); }
    public new int FindIndex(int startIndex, Predicate<Master> match) { return base.FindIndex(startIndex, match); }
    public new int FindIndex(Predicate<Master> match) { return base.FindIndex(match); }
    public new Master FindLast(Predicate<Master> match) { return base.FindLast(match); }
    public new int FindLastIndex(int startIndex, int count, Predicate<Master> match) { return base.FindLastIndex(startIndex, count, match); }
    public new int FindLastIndex(int startIndex, Predicate<Master> match) { return base.FindLastIndex(startIndex, match); }
    public new int FindLastIndex(Predicate<Master> match) { return base.FindLastIndex(match); }
    public new void ForEach(Action<Master> action) { base.ForEach(action); }
    public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
    public new List<Master> GetRange(int index, int count) { return base.GetRange(index, count); }
    public new int IndexOf(Master item) { return base.IndexOf(item); }
    public new int IndexOf(Master item, int index) { return base.IndexOf(item, index); }
    public new int IndexOf(Master item, int index, int count) { return base.IndexOf(item, index, count); }
    public new void Insert(int index, Master item) { _changed = true; base.Insert(index, item); }
    public new void InsertRange(int index, IEnumerable<Master> collection) { _changed = true; base.InsertRange(index, collection); }
    public new int LastIndexOf(Master item) { return base.LastIndexOf(item); }
    public new int LastIndexOf(Master item, int index) { return base.LastIndexOf(item, index); }
    public new int LastIndexOf(Master item, int index, int count) { return base.LastIndexOf(item, index, count); }
    public new bool Remove(Master item) { _changed = true; return base.Remove(item); }
    public new int RemoveAll(Predicate<Master> match) { _changed = true; return base.RemoveAll(match); }
    public new void RemoveAt(int index) { _changed = true; base.RemoveAt(index); }
    public new void RemoveRange(int index, int count) { _changed = true; base.RemoveRange(index, count); }
    public new void Reverse() { _changed = true; base.Reverse(); }
    public new void Reverse(int index, int count) { _changed = true; base.Reverse(index, count); }
    public new void Sort() { _changed = true; base.Sort(); }
    public new void Sort(IComparer<Master> comparer) { _changed = true; base.Sort(comparer); }
    public new void Sort(Comparison<Master> comparison) { _changed = true; base.Sort(comparison); }
    public new void Sort(int index, int count, IComparer<Master> comparer) { _changed = true; base.Sort(index, count, comparer); }
    public new Master[] ToArray() { return base.ToArray(); }
    public new void TrimExcess() { _changed = true; base.TrimExcess(); }
    public new bool TrueForAll(Predicate<Master> match) { return base.TrueForAll(match); }
}