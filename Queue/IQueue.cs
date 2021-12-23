namespace DataStructure.Queue;

public interface IQueue<E>
{
    void Enqueue(E e);
    E Dequeue();

    E Peek();

    int Count { get; }

    bool IsEmpty { get; }
}