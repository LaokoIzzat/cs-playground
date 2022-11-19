using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SinglyLinkedList
{
    public sealed class SLLNode<T> : ISLLNode<T>
    {
        public T Data { get; set; }
        public SLLNode<T> Next { get; set; }

        public SLLNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
