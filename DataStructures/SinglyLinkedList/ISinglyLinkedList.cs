namespace DataStructures.SinglyLinkedList
{
    public interface ISinglyLinkedList<T>
    {
        SLLNode<T> Head { get; }

        SLLNode<T> GetLastNode();
        void InsertAfterNode(SLLNode<T> given_node, T data);
        void InsertAtBack(T data);
        void InsertAtFront(T data);
        void Print();
        void Reverse();
    }
}