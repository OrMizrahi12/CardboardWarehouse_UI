using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    public class GenericStack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        // Create an enprt stack
        public GenericStack() { }

        // Create stack with inital element
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

        // Push item to the top of the stack
        public void Push(T data)
        {
            _list.AddLast(data);
        }

        // Remove the top element in the stack
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

     

        public void PrintStack()
        {
            _list.PrintList();
        }

    }
}
