using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace SimpleDNS.Options
{
    public class UpdateKeyList : List<UpdateKey>, ICommittable
    {
        [JsonIgnore]
        public bool Changed
        {
            get
            {
                foreach (UpdateKey item in this)
                    changed |= item.Changed;

                return changed;
            }
        }
        private bool changed;
        public void Commit()
        {
            changed = false;

            foreach (UpdateKey item in this)
                item.Commit();
        }

        public UpdateKeyList() { }
        public UpdateKeyList(IEnumerable<UpdateKey> collection) : base(collection) { }
        public UpdateKeyList(int capacity) : base(capacity) { }
        public new int Capacity { get { return base.Capacity; } set { changed = true; base.Capacity = value; } }
        public new int Count { get { return base.Count; } }
        public new UpdateKey this[int index] { get { return base[index]; } set { changed = true; base[index] = value; } }
        public new void Add(UpdateKey item) { changed = true; base.Add(item); }
        public new void AddRange(IEnumerable<UpdateKey> collection) { changed = true; base.AddRange(collection); }
        public new ReadOnlyCollection<UpdateKey> AsReadOnly() { return base.AsReadOnly(); }
        public new int BinarySearch(int index, int count, UpdateKey item, IComparer<UpdateKey> comparer) { return base.BinarySearch(index, count, item, comparer); }
        public new int BinarySearch(UpdateKey item) { return base.BinarySearch(item); }
        public new int BinarySearch(UpdateKey item, IComparer<UpdateKey> comparer) { return base.BinarySearch(item, comparer); }
        public new void Clear() { changed = true; base.Clear(); }
        public new bool Contains(UpdateKey item) { return base.Contains(item); }
        public new List<TOutput> ConvertAll<TOutput>(Converter<UpdateKey, TOutput> converter) { return base.ConvertAll(converter); }
        public new void CopyTo(int index, UpdateKey[] array, int arrayIndex, int count) { base.CopyTo(index, array, arrayIndex, count); }
        public new void CopyTo(UpdateKey[] array) { base.CopyTo(array); }
        public new void CopyTo(UpdateKey[] array, int arrayIndex) { base.CopyTo(array, arrayIndex); }
        public new bool Exists(Predicate<UpdateKey> match) { return base.Exists(match); }
        public new UpdateKey Find(Predicate<UpdateKey> match) { return base.Find(match); }
        public new List<UpdateKey> FindAll(Predicate<UpdateKey> match) { return base.FindAll(match); }
        public new int FindIndex(int startIndex, int count, Predicate<UpdateKey> match) { return base.FindIndex(startIndex, count, match); }
        public new int FindIndex(int startIndex, Predicate<UpdateKey> match) { return base.FindIndex(startIndex, match); }
        public new int FindIndex(Predicate<UpdateKey> match) { return base.FindIndex(match); }
        public new UpdateKey FindLast(Predicate<UpdateKey> match) { return base.FindLast(match); }
        public new int FindLastIndex(int startIndex, int count, Predicate<UpdateKey> match) { return base.FindLastIndex(startIndex, count, match); }
        public new int FindLastIndex(int startIndex, Predicate<UpdateKey> match) { return base.FindLastIndex(startIndex, match); }
        public new int FindLastIndex(Predicate<UpdateKey> match) { return base.FindLastIndex(match); }
        public new void ForEach(Action<UpdateKey> action) { base.ForEach(action); }
        public new Enumerator GetEnumerator() { return base.GetEnumerator(); }
        public new List<UpdateKey> GetRange(int index, int count) { return base.GetRange(index, count); }
        public new int IndexOf(UpdateKey item) { return base.IndexOf(item); }
        public new int IndexOf(UpdateKey item, int index) { return base.IndexOf(item, index); }
        public new int IndexOf(UpdateKey item, int index, int count) { return base.IndexOf(item, index, count); }
        public new void Insert(int index, UpdateKey item) { changed = true; base.Insert(index, item); }
        public new void InsertRange(int index, IEnumerable<UpdateKey> collection) { changed = true; base.InsertRange(index, collection); }
        public new int LastIndexOf(UpdateKey item) { return base.LastIndexOf(item); }
        public new int LastIndexOf(UpdateKey item, int index) { return base.LastIndexOf(item, index); }
        public new int LastIndexOf(UpdateKey item, int index, int count) { return base.LastIndexOf(item, index, count); }
        public new bool Remove(UpdateKey item) { changed = true; return base.Remove(item); }
        public new int RemoveAll(Predicate<UpdateKey> match) { changed = true; return base.RemoveAll(match); }
        public new void RemoveAt(int index) { changed = true; base.RemoveAt(index); }
        public new void RemoveRange(int index, int count) { changed = true; base.RemoveRange(index, count); }
        public new void Reverse() { changed = true; base.Reverse(); }
        public new void Reverse(int index, int count) { changed = true; base.Reverse(index, count); }
        public new void Sort() { changed = true; base.Sort(); }
        public new void Sort(IComparer<UpdateKey> comparer) { changed = true; base.Sort(comparer); }
        public new void Sort(Comparison<UpdateKey> comparison) { changed = true; base.Sort(comparison); }
        public new void Sort(int index, int count, IComparer<UpdateKey> comparer) { changed = true; base.Sort(index, count, comparer); }
        public new UpdateKey[] ToArray() { return base.ToArray(); }
        public new void TrimExcess() { changed = true; base.TrimExcess(); }
        public new bool TrueForAll(Predicate<UpdateKey> match) { return base.TrueForAll(match); }
    }
}