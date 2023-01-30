using CardboardWarehouse_DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class GenericStack<T> : IStackHelper<T>
    {
        private readonly LinkedList<T> _list = new();

        public GenericStack() { }

        public GenericStack(T firstElement)
        {
            _list.AddLast(firstElement);
        }
        public int Size()
        {
            return _list.Count;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Push(T data)
        {
            _list.AddLast(data);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else
            {
                return _list.RemoveLast();
            }
        }
    }
}
