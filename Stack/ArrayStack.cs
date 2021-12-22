
namespace DataStructure.Stack;

public class ArrayStack<E> : IStack<E>
{
    private Array<E> arr;
    public ArrayStack()
    {
        arr = new Array<E>();
    }
    public ArrayStack(int capacity)
    {
        arr = new Array<E>(capacity);
    }
    public int Count { get { return arr.Count; } }

    public bool IsEmpty { get { return arr.IsEmpty; } }

    public E Peek()
    {
        return arr.GetLast();
    }

    public E Pop()
    {
        return arr.RemoveLast();
    }

    public void Push(E e)
    {
        // 用数组的尾部代表栈顶
        // 数组尾部添加是O(1)操作
        arr.AddLast(e);
    }

    public override string ToString()
    {
        return "Stack: " + arr.ToString() + " top";
    }
}