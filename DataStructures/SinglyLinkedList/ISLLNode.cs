namespace DataStructures.SinglyLinkedList
{
    public interface ISLLNode<T>
    {
        T Data { get; set; }
        SLLNode<T> Next { get; set; }
    }
}