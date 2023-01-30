using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS.Interfaces
{
    public interface IListHelper<T>
    {
        public void Add(T item);
        public void RemoveAt(int index);
        public T Remove(T item);
        public bool Contain(T element);
        public void Clear();
    }
}
