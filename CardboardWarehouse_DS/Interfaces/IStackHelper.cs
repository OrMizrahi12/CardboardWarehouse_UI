using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS.Interfaces
{
    public interface IStackHelper<T>
    {
        public int Size();
        public bool IsEmpty();
        public void Push(T data);

        public T Pop();

    }
}
