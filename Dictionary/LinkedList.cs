using System.Text;

namespace DataStructure.Dictionary;

public class LinkedList<Key, Value>
{
    private Node head;
    private int N;

    public LinkedList()
    {
        head = null;
        N = 0;
    }

    public int Count { get { return N; } }
    public bool IsEmpty { get { return N == 0; } }

    private Node GetNode(Key key)
    {
        Node cur = head;
        while (cur != null)
        {
            if (cur.key.Equals(key))
            {
                return cur;
            }
            cur = cur.next;
        }
        return null;
    }

    public void Add(Key key, Value value)
    {
        Node node = GetNode(key);
        if (node == null)
        {
            head = new Node(key, value, head);
            N++;
        }
        else
        {
            node.value = value;
        }
    }

    public bool Contains(Key key)
    {
        return GetNode(key) != null;
    }

    public Value Get(Key key)
    {
        Node node = GetNode(key);
        if (node == null)
        {
            throw new ArgumentException("键[" + key + "]不存在");
        }
        else
        {
            return node.value;
        }
    }

    public void Set(Key key, Value value)
    {
        Node node = GetNode(key);
        if (node == null)
        {
            throw new ArgumentException("键[" + key + "]不存在");
        }
        else
        {
            node.value = value;
        }
    }

    public void Remove(Key key)
    {
        if (head == null)
        { return; }

        if (head.key.Equals(key))
        {
            head = head.next;
        }
        else
        {
            Node pre = null;
            var cur = head;
            while (cur != null)
            {
                if (cur.key.Equals(key))
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
    private class Node
    {
        public Key key;
        public Value value;
        public Node next;

        public Node(Key key, Value value, Node next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }


        public override string ToString()
        {
            return key.ToString() + ": " + value.ToString();
        }
    }
}
