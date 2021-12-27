namespace DataStructure.Queue;

public class TailLinkedListQueue<E> : IQueue<E>
{
    private TailLinkedList<E> list;
    public TailLinkedListQueue()
    {
        list = new TailLinkedList<E>();
    }
    public int Count { get { return list.Count; } }

    public bool IsEmpty { get { return list.IsEmpty; } }

    public E Dequeue()
    {
        return list.RemoveFirst(); // 尾指针的linkedlist O(1)
    }

    public void Enqueue(E e)
    {
        list.AddLast(e);
    }

    public E Peek()
    {
        return list.GetFirst();
    }
}