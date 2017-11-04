using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> _genericList;
        private int _position;

        public GenericListEnumerator(GenericList<T> genericList)
        {
            _genericList = genericList;
            _position = -1;
        }

        public T Current
        {
            get
            {
                try
                {
                    return _genericList.GetElement(_position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _genericList.Count);
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}