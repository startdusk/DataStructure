namespace DataStructure.Stack;

public class LinkedListStack<E> : IStack<E>
{
    private LinkedList<E> linkedList;
    public LinkedListStack()
    {
        linkedList = new LinkedList<E>();
    }
    public int Count { get { return linkedList.Count; } }

    public bool IsEmpty { get { return linkedList.IsEmpty; } }

    public E Peek()
    {
        return linkedList.GetLast();
    }

    public E Pop()
    {
        return linkedList.RemoveLast();
    }

    public void Push(E e)
    {
        linkedList.AddLast(e);
    }


    public override string ToString()
    {
        return "Stack: " + linkedList.ToString() + " top";
    }
}