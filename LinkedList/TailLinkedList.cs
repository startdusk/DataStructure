using System.Text;

namespace DataStructure.LinkedList;

// 尾链表
public class TailLinkedList<E>
{
    private Node head;
    private Node tail;
    private int N;

    public TailLinkedList()
    {
        head = null;
        tail = null;
        N = 0;
    }

    public E GetFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("链表为空");
        }
        return head.e;
    }

    public void AddLast(E e)
    {
        Node node = new Node(e);
        if (IsEmpty)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.next = node;
            tail = node;
        }
        N++;
    }

    public E RemoveFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("链表为空");
        }

        E e = head.e;
        head = head.next;
        N--;
        if (head == null)
        {
            tail = null;
        }
        return e;
    }


    public int Count
    {
        get { return N; }
    }
    public bool IsEmpty
    {
        get { return N == 0; }
    }

    public override string ToString()
    {
        StringBuilder res = new StringBuilder();
        Node cur = head;
        while (cur != null)
        {
            res.Append(cur + "->");
            cur = cur.next;
        }
        res.Append("Null");

        return res.ToString();
    }
    private class Node
    {
        public E e;
        public Node next;

        public Node(E e, Node next)
        {
            this.e = e;
            this.next = next;
        }

        public Node(E e) : this(e, null)
        {
        }

        public override string ToString()
        {
            return e.ToString();
        }
    }
}