using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomListExample
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(T item)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = item; 
        }

        public bool Find(T item)
        {
            foreach (T current in _items)
            {
                if (current.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            foreach (T item in _items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public bool Remove(T item)
        {
            bool found = false;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    found = true;
                    for (int j = i; j < _items.Length - 1; j++)
                    {
                        _items[j] = _items[j + 1];
                    }
                    Array.Resize(ref _items, _items.Length - 1);
                    break;
                }
            }
            return found;
        }

        public void RemoveAll()
        {
            Array.Resize(ref _items, 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}