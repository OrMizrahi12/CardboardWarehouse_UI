using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS.Interfaces
{
    public interface IHashHelper<T>
    {
        public int GetIndex(T item);
        public void Add(T item);
        public void Resize(int newSize);
        public T Get(T element);
        public T Remove(T item);
        public bool HashNotFull();

    }
}
