using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmDotnet
{
    public class BST<T> where T:IComparable
    {
        public Node<T> Root { get; set; }

        public void Insert(T key, object value)
        {
            Root = Put(Root, key, value);
        }

        private Node<T> Put(Node<T> node, T key, object value)
        {
            if (node == null) 
                node= new Node<T>() {Key = key, Value = value};
            else
            {
                if (node.Key.CompareTo(key) == 0)
                    node.Value = value;
                else if (node.Key.CompareTo(key) < 0)
                    node.Right = Put(node.Right, key, value);
                else
                    node.Left = Put(node.Left, key, value);
            }
            return node;
        } 

        public Node<T> Search(T key)
        {
            return Search(Root, key);
        }

        private Node<T> Search(Node<T> node, T key)
        {
            if (node == null)
                return null;
            else if (node.Key.CompareTo(key) == 0)
                return node;
            else if (node.Key.CompareTo(key) < 0)
                return Search(node.Left, key);
            else
                return Search(node.Right, key);
        }
        
        public void Delete(T key)
        {
            Root = Delete(Root, key);
        }

        public Node<T> Delete(Node<T> node, T key)
        {
            if (node == null) return null;
            if (node.Key.CompareTo(key) == 0)
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                var tmp = node;
                node = Min(node.Right);
                node.Right = DeleteMin(tmp.Right);
                node.Left = tmp.Left;
            }
            else if (node.Key.CompareTo(key) > 0)
                node.Left= Delete(node.Left, key);
            else
            {
                node.Right= Delete(node.Right, key);
            }
            return node;
        }


        public Node<T> Min(Node<T> node)
        {
            if (node == null) return null;
            if (node.Left == null) return node;
            return Min(node.Left);
        } 

        public Node<T> DeleteMin()
        {
            return DeleteMin(Root);
        }

        private Node<T> DeleteMin(Node<T> node)  //Return End Result of the Binary Tree 
        {
            if (node == null) return node;
            if (node.Left == null) return node.Right;
            node.Left = DeleteMin(node.Left);
            return node;
        } 

        public void Print()
        {
            PrintRecursive(Root);
        }

        private void PrintRecursive(Node<T> node)
        {
            if (node == null) return;
            PrintRecursive(node.Left);
            Console.Write(string.Format("{0}-{1}\t", node.Key.ToString(), node.Value==null?"Null": node.Value.ToString()));
            PrintRecursive(node.Right);
        }

        public void PrintBreathFirst()
        {
            Queue<Node<T>> tmpQueue = new Queue<Node<T>>();
            tmpQueue.Enqueue(Root);

            while (tmpQueue.Count>0)
            {
                var top = tmpQueue.Dequeue();
                Console.WriteLine(string.Format("{0}-{1}", top.Key.ToString(), top.Value.ToString()));
                if(top.Left!=null)
                    tmpQueue.Enqueue(top.Left);
                if(top.Right!=null)
                    tmpQueue.Enqueue(top.Right);
            }
        }
    }

    public class Node<T> where T:IComparable
    {
        public T Key { get; set; }
        public object Value { get; set; }

        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public int GetChildCount()
        {
            return (Left==null?0:1+Left.GetChildCount())+ (Right==null?0:1+Right.GetChildCount());
        }
    }

}
