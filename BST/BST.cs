namespace DataStructure.BST;

public class BST<E> where E : IComparable<E>
{
    private class Node
    {
        public E e;
        public Node left;
        public Node right;

        public Node(E e)
        {
            this.e = e;
            left = null;
            right = null;
        }
    }

    private Node root;
    private int N;

    public BST()
    {
        root = null;
        N = 0;
    }

    public int Count { get { return N; } }

    public bool IsEmpty { get { return N == 0; } }

    // 非递归方式添加node
    public void add(E e)
    {
        if (root == null)
        {
            root = new Node(e);
            N++;
            return;
        }
        Node pre = null;
        Node cur = root;

        // 循环遍历，找到该node应该放到那个父亲的节点下
        while (cur != null)
        {
            // 节点已存在，跳过
            if (e.CompareTo(cur.e) == 0)
            {
                return;
            }

            pre = cur;
            if (e.CompareTo(cur.e) < 0)
            {
                // 左孩子
                cur = cur.left;
            }
            else
            {
                // 右孩子
                cur = cur.right;
            }
        }
        cur = new Node(e);
        if (e.CompareTo(cur.e) < 0)
        {
            pre.left = cur;
        }
        else
        {
            pre.right = cur;
        }

        N++;
    }

    // 递归添加元素
    public void Add(E e)
    {
        Add(root, e);
    }

    // 以node为根的树添加元素e, 添加后返回根节点node
    private Node Add(Node node, E e)
    {
        if (node == null)
        {
            N++;
            return new Node(e);
        }

        if (e.CompareTo(node.e) < 0)
        {
            node.left = Add(node.left, e);
        }
        else if (e.CompareTo(node.e) > 0)
        {
            node.right = Add(node.right, e);
        }

        return node;
    }
}