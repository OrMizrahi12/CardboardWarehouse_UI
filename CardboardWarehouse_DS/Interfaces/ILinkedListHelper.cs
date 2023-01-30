using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS.Interfaces
{
    public interface ILinkedListHelper<T>
    {
        public void AddFirst(T data);
        public void AddLast(T data);
        public T RemoveLast();
        public void PrintList();
    }
}
