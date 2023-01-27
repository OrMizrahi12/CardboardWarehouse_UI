using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{
    class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }

    class LinkedList<T>
    {
        Node<T> head;
        private int _count;

        public int Count { get { return _count; } }
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.next = head;
            head = newNode;
            _count++;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                _count++;
                return;
            }
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
            _count++;
        }
        public T RemoveLast()
        {
            if (head == null)
            {
                return default!;
            }
            else if (head.next == null)
            {
                T data = head.data;
                head = null!;
                _count--;
                return data;
            }
            Node<T> current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            T lastData = current.next.data;
            _count--;
            current.next = null;
            return lastData;
        }

        public void PrintList()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }
    }

}
