using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2
{
    public class GenericList<X> : IGenericList<X>
    {
        private const int DefaultStorageSize = 4;
        private X[] _internalStorage;
        private int _count;

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
                throw new IndexOutOfRangeException("Size of the list must no be negative!");
            _internalStorage = new X[initialSize];
            _count = 0;
        }

        public GenericList()
        {
            _internalStorage = new X[DefaultStorageSize];
            _count = 0;
        }

        public void Add(X item)
        {
            if (_count == _internalStorage.Length)
            {
                var tmpInternalStorage = new X[_count * 2];
                for (var i = 0; i < _count; i++)
                {
                    tmpInternalStorage[i] = GetElement(i);
                }
                _internalStorage = tmpInternalStorage;
            }
            _internalStorage[_count] = item;
            _count++;
        }

        public bool Remove(X item)
        { 
            for (var i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                {
                    RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            for (var i = index; i < _count - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _count--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (var i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                    return i;
            }
            return -1;
        }

        public int Count => _count;

        public void Clear()
        {
            _internalStorage = new X[DefaultStorageSize];
            _count = 0;
        }

        public bool Contains(X item)
        {
            for (var i = 0; i < _count; i++)
            {
                if (item.Equals(GetElement(i)))
                    return true;
            }
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}