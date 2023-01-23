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
        private Carton[]  table = GeneralTreeInstance.Cartons;
        private int size =  GeneralTreeInstance.Cartons.Length;
        private int[] keys;
        private int _itensCount;
        public int ItemCount { get { return _itensCount; } }
        public Carton[] cartons { get { return table; } set { } }
        public HashTable()
        {
            size = table.Length;
            keys = new int[table.Length];
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

            return Math.Abs(index % size);
        }

        public void Add(Carton carton)
        {
            if (HashNotFull())
            {
                int index = GetIndex(carton.X, carton.Y);
                Console.WriteLine(index);

                if (table[index] == null)
                {
                    _itensCount++;
                }

                table[index] = carton;

                keys[index] = carton.X + carton.Y;


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
                Array.Copy(table, newTable, Math.Min(size, newSize));
                table = newTable;
                size = newSize;
            }
        }

        public Carton Get(int x, int y)
        {
            int index = GetIndex(x, y);

            if (table[index] != null)
            {
                return table[index];
            }
            else
            {
                return null!;
            }
        }

        public Carton Remove(Carton carton)
        {
            int index = GetIndex(carton.X, carton.Y);

            if (keys?[index] != null)
            {
                Carton deletedCarton = table[index];
                table[index] = null!;
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
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    if (table[i].X > x && table[i].X - x <= 10 && table[i].Y > y && table[i].Y - y <= 10)
                    {
                        if (closestCarton.X + closestCarton.Y > table[i].X + table[i].Y)
                        {
                            closestCarton = table[i];
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
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    Console.WriteLine("X: " + table[i].X + ", Y: " + table[i].Y);
                }
            }
        }

        public bool HashNotFull()
        {
            return _itensCount < size - 1;
        }

        public void LoadDataToGrid(DataGrid dataGrid)
        {
            for (int i = 0; i < size; i++)
            {
                if (table[i] != null)
                {
                    dataGrid.Items.Add(table[i]); 
                }
            }
        }

    }
}
