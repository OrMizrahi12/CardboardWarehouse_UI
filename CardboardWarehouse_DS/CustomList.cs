using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class CustomList<T>
    {
        private T[] _items = new T[0];
        public event EventHandler? OnAdd;
        public event EventHandler? OnRemove;

        public int Count => _items.Length;
        public T[] Items { get => _items;  set { } }

        public CustomList()
        {
          
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return _items[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }

            set => _items[index] = value;
        }

        public void Add(T item)
        {
            Array.Resize(ref _items, _items.Length + 1);
            _items[_items.Length - 1] = item;
            OnAdd?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveAt(int index)
        {
            _items = _items.Where((val, idx) => idx != index).ToArray();
            OnRemove?.Invoke(this, EventArgs.Empty);
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(_items, item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool Contain(T element)
        {
            foreach (var item in _items)
            {
                if (item!.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _items = new T[0];
        }
        public void Print()
        {
            foreach (var item in _items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
