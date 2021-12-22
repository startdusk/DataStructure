using System.Text;

namespace DataStructure.Stack;

public class LinkedList<E>
{
    private Node head;
    private int N;

    public LinkedList()
    {
        head = null;
        N = 0;
    }

    public void Add(int index, E e)
    {
        if (index < 0 || index > N)
        {
            throw new ArgumentException("非法索引");
        }

        // 头部插入
        if (index == 0)
        {
            // 注释的是具体步骤
            // Node node = new Node(e);
            // node.next = head;
            // head = node;
            head = new Node(e, head);
        }
        else
        {
            Node pre = head;
            for (int i = 0; i < index - 1; i++)
            {
                pre = pre.next;
            }
            // 注释的是具体步骤
            // 一定是先插入的节点指向下一个节点，然后才是插入位置上一个节点指向这个插入的节点
            // Node node = new Node(e);
            // node.next = pre.next;
            // pre.next = node;

            pre.next = new Node(e, pre.next);
        }
        N++;
    }

    public E Get(int index)
    {
        if (index < 0 || index > N)
        {
            throw new ArgumentException("非法索引");
        }

        Node cur = head;
        for (int i = 0; i < index; i++)
        {
            cur = cur.next;
        }
        return cur.e;
    }

    public E GetFirst()
    {
        return Get(0);
    }

    public E GetLast()
    {
        return Get(N - 1);
    }

    public void Set(int index, E newE)
    {
        if (index < 0 || index > N)
        {
            throw new ArgumentException("非法索引");
        }

        Node cur = head;
        for (int i = 0; i < index; i++)
        {
            cur = cur.next;
        }
        cur.e = newE;
    }

    public bool Contains(E e)
    {
        Node cur = head;
        while (cur != null)
        {
            if (cur.e != null && cur.e.Equals(e))
            {
                return true;
            }
            cur = cur.next;
        }
        return false;
    }


    public void AddFirst(E e)
    {
        Add(0, e);
    }
    public void AddLast(E e)
    {
        Add(N, e);
    }
    public E RemoveAt(int index)
    {
        if (index < 0 || index > N)
        {
            throw new ArgumentException("非法索引");
        }
        // 删除第一个节点
        if (index == 0)
        {
            var delNode = head;
            head = head.next;
            N--;
            return delNode.e;
        }
        else
        {
            var pre = head;
            for (int i = 0; i < index - 1; i++)
            {
                pre = pre.next;
            }

            var delNode = pre.next;
            pre.next = delNode.next;
            N--;
            return delNode.e;
        }
    }
    public E RemoveFirst()
    {
        return RemoveAt(0);
    }
    public E RemoveLast()
    {
        return RemoveAt(N - 1);
    }

    public void Remove(E e)
    {
        if (head == null)
        { return; }

        if (head.e.Equals(e))
        {
            head = head.next;
        }
        else
        {
            Node pre = null;
            var cur = head;
            while (cur != null)
            {
                if (cur.e.Equals(e))
                {
                    break;
                }

                pre = cur;
                cur = cur.next;
            }
            if (cur != null)
            {
                pre.next = pre.next.next;
                N--;
            }
        }
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
