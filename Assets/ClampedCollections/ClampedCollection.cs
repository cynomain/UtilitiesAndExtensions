using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CynoMain.ClampedCollections
{
    public class ClampedList<T> : IList<T>
    {
        private List<T> _list;

        public T this[int index] { get => GetAtIndex(index); set => SetAtIndex(index, value); }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public ClampedList()
        {
            _list = new List<T>();
            ClampedList<int> ci = new ClampedList<int>();
        }

        public ClampedList(IList<T> collection)
        {
            _list = (List<T>)collection;
        }

        public ClampedList(IEnumerable<T> enumerable)
        {
            _list = (List<T>)enumerable;
        }

        public ClampedList(int capacity)
        {
            _list = new List<T>(capacity);
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            if (_list.Count < 1) //Empty
            {
                throw new IndexOutOfRangeException();
            }
            int clamped = Clamp(index, 0, MaxIndex);
            _list.RemoveAt(clamped);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }

        public int MaxIndex => _list.Count - 1;

        T GetAtIndex(int index)
        {
            if (_list.Count < 1) //Empty
            {
                throw new IndexOutOfRangeException();
            }
            int clamped = Clamp(index, 0, MaxIndex);
            return _list[clamped];
        }

        void SetAtIndex(int index, T value)
        {
            if (_list.Count < 1) //Empty
            {
                throw new IndexOutOfRangeException();
            }
            int clamped = Clamp(index, 0, MaxIndex);
            _list[clamped] = value;
        }

        int Clamp(int value,int min, int max)
        {
            if (value >= min && value <= max) //min - val - max
            {
                return value;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return min;
            }
        }

        public static implicit operator List<T>(ClampedList<T> list)
        {
            return list._list;
        }      
    }
}