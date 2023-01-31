using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CardboardWarehouse_DS
{


    public class AVLNode<TKey, TValue>
    {
        public AVLNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.LeftChild = null!;
            this.RightChild = null!;
            this.Parent = null!;
            this.Balance = 0;
        }

        public AVLNode(TKey key, TValue value, AVLNode<TKey, TValue> parent)
            : this(key, value)
        {
            this.Parent = parent;
        }

        public AVLNode(AVLNode<TKey, TValue> node)
            : this(node.Key, node.Value, node.Parent)
        {
            this.LeftChild = node.LeftChild;
            this.RightChild = node.RightChild;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public AVLNode<TKey, TValue> Parent { get; set; }
        public AVLNode<TKey, TValue> LeftChild { get; set; }
        public AVLNode<TKey, TValue> RightChild { get; set; }
        public int Balance { get; set; }


        public override int GetHashCode()
        {
            return (this.Key!.GetHashCode() << 16) | (this.Value!.GetHashCode() & 0xFFFF);
        }

        //Two nodes are equal if their both keys and values match.
        public override bool Equals(object obj)
        {
            AVLNode<TKey, TValue> ? node = obj as AVLNode<TKey, TValue>;
            if (node == null)
            {
                return false;
            }
            else
            {
                if (this.Key!.Equals(node.Key) && this.Value!.Equals(node.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("({0} {1})", this.Key, this.Value);
        }
    }
    public class AVLTree<TKey, TValue> : IEnumerable<AVLNode<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private AVLNode<TKey, TValue> root;

        public AVLTree()
        {
            this.root = null!;
        }
        public void Insert(TKey key, TValue value)
        {
            if (this.root == null)
            {
                this.root = new AVLNode<TKey, TValue>(key, value);
            }
            else
            {
                AVLNode<TKey, TValue> currentNode = root;
                while (currentNode != null)
                {
                    if (currentNode.Key.CompareTo(key) == -1)
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = new AVLNode<TKey, TValue>(key, value, currentNode);
     
                            InsertBalanceTree(currentNode, -1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else if (currentNode.Key.CompareTo(key) == 1)
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = new AVLNode<TKey, TValue>(key, value, currentNode);
                            InsertBalanceTree(currentNode, 1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else
                    {
                        currentNode.Value = value;
                        break;
                    }
                }
            }
        }
        private void InsertBalanceTree(AVLNode<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                node.Balance += addBalance;

                if (node.Balance == 0)
                {
                    break;
                }
                else if (node.Balance == 2)
                {
                    if (node.LeftChild.Balance == 1)
                    {
                        RotateLeftLeft(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                    break;
                }
                else if (node.Balance == -2)
                {
                    if (node.RightChild.Balance == -1)
                    {
                        RotateRightRight(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                    break;
                }

                if (node.Parent != null)
                {

                    if (node.Parent.LeftChild == node)
                    {
                        addBalance = 1;
                    }
                    else
                    {
                        addBalance = -1;
                    }
                }
                node = node.Parent!;
            }
        }

        private void RotateRightRight(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> rightChild = node.RightChild;
            AVLNode<TKey, TValue> rightLeftChild = null!;
            AVLNode<TKey, TValue> parent = node.Parent;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
                rightChild.Parent = parent;
                rightChild.LeftChild = node;
                rightChild.Balance++;
                node.Balance = -rightChild.Balance;
            }

            node.RightChild = rightLeftChild!;
            node.Parent = rightChild!;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
            }
            if (node == this.root)
            {
                this.root = rightChild!;
            }
            else if (parent.RightChild == node)
            {
                parent.RightChild = rightChild!;
            }
            else
            {
                parent.LeftChild = rightChild!;
            }
        }

        private void RotateLeftLeft(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> leftChild = node.LeftChild;
            AVLNode<TKey, TValue> leftRightChild = null!;
            AVLNode<TKey, TValue> parent = node.Parent;

            if (leftChild != null)
            {
                leftRightChild = leftChild.RightChild;
                leftChild.Parent = parent;
                leftChild.RightChild = node;
                leftChild.Balance--;
                node.Balance = -leftChild.Balance;
            }

            node.Parent = leftChild!;
            node.LeftChild = leftRightChild;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
            }

            if (node == this.root)
            {
                this.root = leftChild!;
            }
            else if (parent.LeftChild == node)
            {
                parent.LeftChild = leftChild!;
            }
            else
            {
                parent.RightChild = leftChild!;
            }

        }

        private void RotateRightLeft(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> rightChild = node.RightChild;
            AVLNode<TKey, TValue> rightLeftChild = null!;
            AVLNode<TKey, TValue> rightLeftRightChild = null!;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
            }
            if (rightLeftChild != null)
            {
                rightLeftRightChild = rightLeftChild.RightChild;
            }

            node.RightChild = rightLeftChild!;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
                rightLeftChild.RightChild = rightChild!;
                rightLeftChild.Balance--;
            }

            if (rightChild != null)
            {
                rightChild.Parent = rightLeftChild!;
                rightChild.LeftChild = rightLeftRightChild;
                rightChild.Balance--;
            }

            if (rightLeftRightChild != null)
            {
                rightLeftRightChild.Parent = rightChild!;
            }

            RotateRightRight(node);
        }

        private void RotateLeftRight(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> leftChild = node.LeftChild;
            AVLNode<TKey, TValue> leftRightChild = leftChild.RightChild;
            AVLNode<TKey, TValue> leftRightLeftChild = null!;
            if (leftRightChild != null)
            {
                leftRightLeftChild = leftRightChild.LeftChild;
            }

            node.LeftChild = leftRightChild!;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
                leftRightChild.LeftChild = leftChild;
                leftRightChild.Balance++;
            }

            if (leftChild != null)
            {
                leftChild.Parent = leftRightChild!;
                leftChild.RightChild = leftRightLeftChild;
                leftChild.Balance++;
            }

            if (leftRightLeftChild != null)
            {
                leftRightLeftChild.Parent = leftChild!;
            }

            RotateLeftLeft(node);
        }

        public void Delete(TKey key)
        {
            AVLNode<TKey, TValue> current = this.root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else //Found the key.
                {
                    if (current.LeftChild == null && current.RightChild == null)
                    {
                        if (current == root)
                        {
                            root = null!;
                        }
                        else if (current.Parent.RightChild == current)
                        {
                            current.Parent.RightChild = null!;
                            DeleteBalanceTree(current.Parent, 1);
                        }
                        else
                        {
                            current.Parent.LeftChild = null!;
                            DeleteBalanceTree(current.Parent, -1);
                        }
                    }
                    else if (current.LeftChild != null) //Get the biggest node from the left subtree.
                    {
                        AVLNode<TKey, TValue> rightMost = current.LeftChild;
                        while (rightMost.RightChild != null)
                        {
                            rightMost = rightMost.RightChild;
                        }

                        ReplaceNodes(current, rightMost);
                        DeleteBalanceTree(rightMost.Parent, 1);
                    }
                    else //Get the smallest node from the right subtree.
                    {
                        AVLNode<TKey, TValue> leftMost = current.RightChild;
                        while (leftMost.LeftChild != null)
                        {
                            leftMost = leftMost.LeftChild;
                        }

                        ReplaceNodes(current, leftMost);
                        DeleteBalanceTree(leftMost.Parent, -1);
                    }
                    break;
                }
            }
        }

        private void ReplaceNodes(AVLNode<TKey, TValue> sourceNode, AVLNode<TKey, TValue> subtreeNode)
        {
            sourceNode.Key = subtreeNode.Key;
            sourceNode.Value = subtreeNode.Value;

            if (subtreeNode.Parent != null)
            {
                if (subtreeNode.LeftChild != null)
                {
                    subtreeNode.LeftChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.LeftChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.LeftChild;
                    }
                }
                else if (subtreeNode.RightChild != null)
                {
                    subtreeNode.RightChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.RightChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.RightChild;
                    }
                }
                else
                {
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = null!;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = null!;
                    }
                }
            }
        }
        private void DeleteBalanceTree(AVLNode<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                node.Balance += addBalance;
                addBalance = node.Balance;

                if (node.Balance == 2)
                {
                    if (node.LeftChild != null && node.LeftChild.Balance >= 0)
                    {
                        RotateLeftLeft(node);

                        if (node.Balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                }
                else if (node.Balance == -2)
                {
                    if (node.RightChild != null && node.RightChild.Balance <= 0)
                    {
                        RotateRightRight(node);

                        if (node.Balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                }
                else if (node.Balance != 0)
                {
                    return;
                }

                AVLNode<TKey, TValue> parent = node.Parent;

                if (parent != null)
                {
                    if (parent.LeftChild == node)
                    {
                        addBalance = -1;
                    }
                    else
                    {
                        addBalance = 1;
                    }
                }
                node = parent!;
            }
        }
        public bool TryGetValue(TKey key, out TValue result)
        {
            AVLNode<TKey, TValue> current = root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else
                {
                    result = current.Value;
                    return true;
                }
            }
            result = default!;
            return false;
        }

        public IEnumerator<AVLNode<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            Print(root);
        }
        public void Print(AVLNode<TKey, TValue> root)
        {
            if (root == null)
            {
                return;
            }
            Print(root.LeftChild);
            Console.WriteLine(root.Value);
            Print(root.RightChild);
        }
    }
}
