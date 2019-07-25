using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 

namespace Xamabrouk.Entities
{
    public class XMDataCollection<T> : IList<XMDataCollectionItem<T>>, ICollection<XMDataCollectionItem<T>>
    {
        public virtual List<XMDataCollectionItem<T>> Items { get; set; }
        public virtual XMDataCollectionItem<T> this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public virtual int Count => Items?.Count ?? 0;

        public virtual bool IsReadOnly { get; set; }


        public XMDataCollection()
        {
            Items = new List<XMDataCollectionItem<T>>();
        }

        public XMDataCollection(IEnumerable<T> source)
        {
            Items = source?.Select(s => new XMDataCollectionItem<T>(s))?.ToList() ?? new List<XMDataCollectionItem<T>>();
        }

        public XMDataCollection(IEnumerable<XMDataCollectionItem<T>> source)
        {
            Items = source?.ToList() ?? new List<XMDataCollectionItem<T>>();
        }

        public virtual void Add(XMDataCollectionItem<T> item)
        {
            Items?.Add(item);
        }

        public virtual void Add(T item)
        {
            Items?.Add(new XMDataCollectionItem<T>(item));
        }

        public virtual void Clear()
        {
            Items?.Clear();
        }

        public virtual bool Contains(XMDataCollectionItem<T> item)
        {
            return Items?.Contains(item) ?? false;
        }

        public virtual bool Contains(Predicate<XMDataCollectionItem<T>> predicate)
        {
            return Items?.Exists(predicate) ?? false;
        }

        public virtual void CopyTo(XMDataCollectionItem<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerator<XMDataCollectionItem<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual int IndexOf(XMDataCollectionItem<T> item)
        {
            return Items?.IndexOf(item) ?? -1;
        }

        public virtual void Insert(int index, XMDataCollectionItem<T> item)
        {
            Items?.Insert(index, item);
        }

        public virtual bool Remove(XMDataCollectionItem<T> item)
        {
            return Items?.Remove(item) ?? false;
        }

        public virtual void RemoveAt(int index)
        {
            Items?.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

       
    }
}