namespace DataStructure.Queue;

// 循环队列入队和出队操作都是O(1)的时间复杂度
public class LoopArrayQueue<E> : IQueue<E>
{
    private LoopArray<E> arr;
    public LoopArrayQueue()
    {
        arr = new LoopArray<E>();
    }
    public LoopArrayQueue(int capacity)
    {
        arr = new LoopArray<E>(capacity);
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