using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Controls;
using CardboardWarehouse_DB;

namespace CardboardWarehouse_DS
{
    public class HashTable
    {
        private Carton[] _table;
        private int _size;
        private int _itensCount;

        public int ItemCount { get { return _itensCount; } }
        public Carton[] Cartons { get { return _table; } set { } }
        public HashTable()
        {
            _size = GeneralTreeInstance.Cartons!.Length;
            _table = GeneralTreeInstance.Cartons!;
        }
        public int GetIndex(int x, int y)
        {
            string key = $"{x}{y}";
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

        public void Add(Carton carton)
        {
            if (HashNotFull())
            {
                int index = GetIndex(carton.X, carton.Y);
                Console.WriteLine(index);

                if (_table[index] == null)
                {
                    _itensCount++;
                }

                _table[index] = carton;
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
                Carton[] newTable = new Carton[newSize];
                Array.Copy(_table, newTable, Math.Min(_size, newSize));
                _table = newTable;
                _size = newSize;
            }
        }

        public Carton Get(int x, int y)
        {
            int index = GetIndex(x, y);

            if (_table[index] != null)
            {
                return _table[index];
            }
            else
            {
                return null!;
            }
        }

        public Carton Remove(Carton carton)
        {
            int index = GetIndex(carton.X, carton.Y);

            if (_table?[index] != null)
            {
                Carton deletedCarton = _table[index];
                _table[index] = null!;
                _itensCount--;
                return deletedCarton;
            }
            else
            {
                return null!;
            }

        }

        public Carton GetClosestCarton(int x, int y)
        {
            Carton closestCarton = new Carton(short.MaxValue, short.MaxValue, 0);
            for (int i = 0; i < _table.Length; i++)
            {
                if (_table[i] != null)
                {
                    if (_table[i].X > x && _table[i].X - x <= 10 && _table[i].Y > y && _table[i].Y - y <= 10)
                    {
                        if (closestCarton.X + closestCarton.Y > _table[i].X + _table[i].Y)
                        {
                            closestCarton = _table[i];
                        }
                    }
                }
            }

            if (closestCarton.X == short.MaxValue)
            {
                return null!;
            }
            else
            {
                return closestCarton;
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < _table.Length; i++)
            {
                if (_table[i] != null)
                {
                    Console.WriteLine("X: " + _table[i].X + ", Y: " + _table[i].Y);
                }
            }
        }

        public bool HashNotFull()
        {
            return _itensCount < _size - 1;
        }

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
