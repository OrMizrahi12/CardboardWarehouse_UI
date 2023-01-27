using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CardboardWarehouse_DS
{
    public class DoubleHash<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {

                Value = value;
                Next = null!;
            }
        }
        private int _size;
        private Node[] _buckets;

        public DoubleHash(int size = 4)
        {
            _size = size;
            _buckets = new Node[size];
        }

        public int GetHashCode(T item)
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

        public void Add(T value)
        {
            var index = GetHashCode(value);
            var newNode = new Node(value);
            var current = _buckets[index];

            // Check if the value already exists in the hash table
            while (current != null)
            {
                if (current!.Value!.Equals(value))
                {
                    return; // Value already exists, do not add it
                }
                current = current.Next;
            }

            // Add the new value to the hash table
            if (_buckets[index] == null)
            {
                _buckets[index] = newNode;
            }
            else
            {
                current = _buckets[index];
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }


        public T Get(T value)
        {
            var index = GetHashCode(value);
            var current = _buckets[index];

            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    return current.Value;
                }
                current = current.Next;
            }

            throw new KeyNotFoundException();
        }
        public void Remove(T value)
        {
            var index = GetHashCode(value);
            var current = _buckets[index];
            Node previous = null!;

            while (current != null)
            {
                if (current.Value!.Equals(value))
                {
                    if (previous == null)
                    {
                        _buckets[index] = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    return;
                }
                previous = current;
                current = current.Next;
            }
            throw new KeyNotFoundException();
        }

        public void LoadDataToGrid(DataGrid dataGrid)
        {
            foreach (var item in _buckets)
            {
                if(item != null)
                dataGrid.Items.Add(item.Value);
            }
        }

    }
}
