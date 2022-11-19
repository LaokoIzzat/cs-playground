using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedList
{
    public sealed class SinglyLinkedList<T> : ISinglyLinkedList<T>, IEnumerable<T>
    {
        public SLLNode<T> Head { get; private set; }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(SLLNode<T> node)
        {
            Head = node;
        }

        public SLLNode<T> GetLastNode()
        {
            SLLNode<T> temp = Head;
            while (temp.Next != null) { temp = temp.Next; }
            return temp;
        }

        public void InsertAtFront(T data)
        {
            SLLNode<T> new_node = new SLLNode<T>(data);
            new_node.Next = Head;
            Head = new_node;
        }

        public void InsertAtBack(T data)
        {
            SLLNode<T> new_node = new SLLNode<T>(data);
            if (Head == null) { Head = new_node; return; }
            SLLNode<T> lastNode = GetLastNode();
            lastNode.Next = new_node;
        }

        public void InsertAfterNode(SLLNode<T> given_node, T data)
        {
            if (given_node == null) { Console.WriteLine("Given node cannot be null."); return; }
            SLLNode<T> new_node = new SLLNode<T>(data);
            new_node.Next = given_node.Next;
            given_node.Next = new_node;
        }

        public void RemoveFirstNode()
        {
            if (Head is not null) Head = Head.Next;
            else Console.WriteLine("No elements removed (List already empty).");
        }

        public void Reverse()
        {
            SLLNode<T> prev = null;
            SLLNode<T> current = Head;
            SLLNode<T> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            Head = prev;
        }

        public void Print()
        {

            if (Head == null) { Console.WriteLine("Empty list."); }

            string output = $"{Head.Data.ToString()}";
            SLLNode<T> temp = Head.Next;
            while (temp != null)
            {
                output += $", {temp.Data.ToString()}";
                temp = temp.Next;
            }
            Console.WriteLine(output);
        }

        public IEnumerator<T> GetEnumerator()
        {
            SLLNode<T> temp = Head;
            while (temp != null)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
