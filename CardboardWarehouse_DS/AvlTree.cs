using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardboardWarehouse_DS
{

    //public class AvlTree
    //{

        
        
    //    Carton ? root = GeneralTreeInstance.GeneralRoot;
    //    public AvlTree()
    //    {

    //    }
    //    public Carton ? Root { get { return root; } set { } }



    //    public void Add(Carton newCarton)
    //    {

    //        if (root == null)
    //        {
    //            root = newCarton;
    //        }
    //        else
    //        {
    //            root = RecursiveInsert(root, newCarton);
    //        }
    //    }
    //    private Carton RecursiveInsert(Carton current, Carton n)
    //    {
    //        if (current == null)
    //        {
    //            current = n;
    //            return current;
    //        }

    //        else if (current.CompareTo(n) == 1)
    //        {
    //            current.Left = RecursiveInsert(current.Left, n);
    //            current = balance_tree(current);
    //        }
    //        else if (current.CompareTo(n) == -1)
    //        {
    //            current.Right = RecursiveInsert(current.Right, n);
    //            current = balance_tree(current);
    //        }
    //        return current;
    //    }
    //    private Carton balance_tree(Carton current)
    //    {
    //        int b_factor = balance_factor(current);
    //        if (b_factor > 1)
    //        {
    //            if (balance_factor(current.Left) > 0)
    //            {
    //                current = RotateLL(current);
    //            }
    //            else
    //            {
    //                current = RotateLR(current);
    //            }
    //        }
    //        else if (b_factor < -1)
    //        {
    //            if (balance_factor(current.Right) > 0)
    //            {
    //                current = RotateRL(current);
    //            }
    //            else
    //            {
    //                current = RotateRR(current);
    //            }
    //        }
    //        return current;
    //    }
    //    public void Delete(Carton  target)
    //    {//and here
    //        root = Delete(root, target);
    //    }
    //    private Carton Delete(Carton current, Carton target)
    //    {
    //        Carton parent;
    //        if (current == null)
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            //left subtree
    //            if (current.CompareTo(target) == 1)
    //            {
    //                current.Left = Delete(current.Left, target);
    //                if (balance_factor(current) == -2)//here
    //                {
    //                    if (balance_factor(current.Right) <= 0)
    //                    {
    //                        current = RotateRR(current);
    //                    }
    //                    else
    //                    {
    //                        current = RotateRL(current);
    //                    }
    //                }
    //            }
    //            //right subtree
    //            else if (current.CompareTo(target) == -1)
    //            {
    //                current.Right = Delete(current.Right, target);
    //                if (balance_factor(current) == 2)
    //                {
    //                    if (balance_factor(current.Left) >= 0)
    //                    {
    //                        current = RotateLL(current);
    //                    }
    //                    else
    //                    {
    //                        current = RotateLR(current);
    //                    }
    //                }
    //            }
    //            //if target is found
    //            else
    //            {
    //                if (current.Right != null)
    //                {
    //                    //delete its inorder successor
    //                    parent = current.Right;
    //                    while (parent.Left != null)
    //                    {
    //                        parent = parent.Left;
    //                    }
    //                    current = parent;
    //                    current.Right = Delete(current.Right, parent);
    //                    if (balance_factor(current) == 2)//rebalancing
    //                    {
    //                        if (balance_factor(current.Left) >= 0)
    //                        {
    //                            current = RotateLL(current);
    //                        }
    //                        else { current = RotateLR(current); }
    //                    }
    //                }
    //                else
    //                {   //if current.left != null
    //                    return current.Left;
    //                }
    //            }
    //        }
    //        return current;
    //    }


    //    public Carton Find(Carton key)
    //    {
    //        return Find(root, key);
    //    }

    //    private Carton Find(Carton travel, Carton target)
    //    {
    //        if (travel == null)
    //        {
    //            return default!;
    //        }
    //        else if (CheckRremainder(travel, target))
    //        {
    //            return travel;
    //        }

    //        Carton left = Find(travel.Left, target);

    //        if (left != null)
    //        {
    //            return left;
    //        }
    //        else
    //        {
    //            return Find(travel.Right, target); ;
    //        }
    //    }

    //    public Carton Get(Carton key)
    //    {
    //        return Get(root, key);
    //    }

    //    private Carton Get(Carton root, Carton key)
    //    {
    //        if (root == null)
    //        {
    //            return default!;
    //        }
    //        else
    //        {
    //            if (root.CompareTo(key) == 1)
    //            {
    //                return Get(root.Left, key);
    //            }
    //            else if (root.CompareTo(key) == -1)
    //            {
    //                return Get(root.Right, key);
    //            }
    //            else
    //            {
    //                return root;
    //            }
    //        }
    //    }

 

    //    public void UpdateStocK(bool increment, Carton carton)
    //    {
    //        carton = Get(carton);

    //        if (increment)
    //        {
    //            carton.Count++;
    //        }
    //        else
    //        {
    //            if(carton.Count > 1)
    //            {
    //                carton.Count--;
    //            }
    //            else if(carton.Count == 1)
    //            {
    //                Delete(carton);
    //            }
                
    //        }
    //    }

    //    public bool CheckRremainder(Carton travel, Carton target)
    //    {
    //        return (travel.X - target.X > 0 && travel.X - target.X <= 10) && (travel.Y - target.Y > 0 && travel.Y - target.Y <= 10);
    //    }

    //    public void DisplayTree()
    //    {
    //        if (root == null)
    //        {
    //            Console.WriteLine("Tree is empty");
    //            return;
    //        }
    //        InOrderDisplayTree(root);
    //        Console.WriteLine();
    //    }
    //    private void InOrderDisplayTree(Carton current)
    //    {
    //        if (current != null)
    //        {
    //            InOrderDisplayTree(current.Left);
    //            Console.Write(current + " ");
    //            InOrderDisplayTree(current.Right);
    //        }
    //    }
    //    private int max(int l, int r)
    //    {
    //        return l > r ? l : r;
    //    }
    //    private int getHeight(Carton current)
    //    {
    //        int height = 0;
    //        if (current != null)
    //        {
    //            int l = getHeight(current.Left);
    //            int r = getHeight(current.Right);
    //            int m = max(l, r);
    //            height = m + 1;
    //        }
    //        return height;
    //    }
    //    private int balance_factor(Carton current)
    //    {
    //        int l = getHeight(current.Left);
    //        int r = getHeight(current.Right);
    //        int b_factor = l - r;
    //        return b_factor;
    //    }
    //    private Carton RotateRR(Carton parent)
    //    {
    //        Carton pivot = parent.Right;
    //        parent.Right = pivot.Left;
    //        pivot.Left = parent;
    //        return pivot;
    //    }
    //    private Carton RotateLL(Carton parent)
    //    {
    //        Carton pivot = parent.Left;
    //        parent.Left = pivot.Right;
    //        pivot.Right = parent;
    //        return pivot;
    //    }
    //    private Carton RotateLR(Carton parent)
    //    {
    //        Carton pivot = parent.Left;
    //        parent.Left = RotateRR(pivot);
    //        return RotateLL(parent);
    //    }
    //    private Carton RotateRL(Carton parent)
    //    {
    //        Carton pivot = parent.Right;
    //        parent.Right = RotateLL(pivot);
    //        return RotateRR(parent);
    //    }
    //}
}
