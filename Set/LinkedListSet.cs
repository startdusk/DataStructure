namespace DataStructure.Set;

// 基于无序链表集合
public class LinkedListSet<E> : ISet<E>
{
    private LinkedList<E> list;

    public LinkedListSet()
    {
        list = new LinkedList<E>();
    }
    public int Count { get { return list.Count; } }

    public bool IsEmpty { get { return list.IsEmpty; } }

    public void Add(E e)
    {
        if (!this.Contains(e))
            list.AddLast(e); 
    }

    public bool Contains(E e)
    {
        return list.Contains(e); // O(n)
    }

    public void Remove(E e)
    {
        list.Remove(e); // O(n)
    }
}