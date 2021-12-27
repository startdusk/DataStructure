namespace DataStructure.Queue;

public class LinkedListQueue<E> : IQueue<E>
{
    private LinkedList<E> list;
    public int Count { get { return list.Count; } }

    public bool IsEmpty { get { return list.IsEmpty; } }

    public E Dequeue()
    {
        return list.RemoveLast(); // O(n)
    }

    public void Enqueue(E e)
    {
        list.AddFirst(e);
    }

    public E Peek()
    {
        return list.GetFirst();
    }

    public override string ToString()
    {
        return "Queue:  front " + list.ToString() + " tail";
    }
}