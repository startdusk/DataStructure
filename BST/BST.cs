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
}