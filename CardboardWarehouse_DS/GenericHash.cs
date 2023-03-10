using CardboardWarehouse_DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardboardWarehouse_DS
{
    public class GenericHash<T> : IHashHelper<T>
    {
        private T[] _table;
        private int _size;
        private int _itensCount;
       

        public int ItemCount { get { return _itensCount; } }
        public T[] Table { get { return _table; } set { } }


        public GenericHash(int size)
        {
            _size =size;
            _table = new T[size];
        }

        // O(1)
        public int GetIndex(T item)
        {
 
            string key = item?.ToString()!;
            byte[] byteKey = Encoding.UTF8.GetBytes(key);
            byte[] hash;
            
            using (var sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(byteKey);
            }
            
            int index = 0;
            
            for (int i = 0; i < 4; i++)
            {
                index += hash[i] << (i * 8);
            }

            return Math.Abs(index % _size);
        }
        

        // O(1)
        public void Add(T item)
        {
            if (HashNotFull())
            {
                int index = GetIndex(item);
                Console.WriteLine(index);

                if (_table[index] == null)
                {
                    _itensCount++;
                    _table[index] = item;
                }
            }
            else
            {
                Console.WriteLine("FULL");
            }
        }

        public void Resize(int newSize)
        {
            if (!HashNotFull())
            {
                T[] newTable = new T[newSize];
                Array.Copy(_table, newTable, Math.Min(_size, newSize));
                _table = newTable;
                _size = newSize;
            }
        }

        // O(1)
        public T Get(T element)
        {
            int index = GetIndex(element);

            if (_table[index] != null)
            {
                return _table[index];
            }
            else
            {
                return default!;
            }
        }

        // O(1)
        public T Remove(T item)
        {
            int index = GetIndex(item);

            if (_table[index] != null)
            {
                T deletedItem = _table[index];
                _table[index] = default!;
                _itensCount--;
                return deletedItem;
            }
            else
            {
                return default!;
            }

        }
     
        // O(1)
        public bool HashNotFull()
        {
            return _itensCount < _size - 1;
        }

        // O(n)
        public void LoadDataToGrid(DataGrid dataGrid)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_table[i] != null)
                {
                    dataGrid.Items.Add(_table[i]);
                }
            }
        }

        
    }
}
