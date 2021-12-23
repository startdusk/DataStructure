namespace DataStructure.Queue;

public class ArrayQueue<E> : IQueue<E>
{
    private Array<E> arr;
    public ArrayQueue()
    {
        arr = new Array<E>();
    }
    public ArrayQueue(int capacity)
    {
        arr = new Array<E>(capacity);
    }
    public int Count { get { return arr.Count; } }

    public bool IsEmpty { get { return arr.IsEmpty; } }

    public E Dequeue()
    {
        return arr.RemoveFirst();
    }

    public void Enqueue(E e)
    {
        arr.AddLast(e);
    }

    public E Peek()
    {
        return arr.GetFirst();
    }


    public override string ToString()
    {
        return "Queue:  front " + arr.ToString() + " tail";
    }
}