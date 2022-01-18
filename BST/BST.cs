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
        root = Add(root, e);
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

    public bool Contains(E e)
    {
        return Contains(root, e);
    }

    // 以node为根的树是包含元素e
    private bool Contains(Node node, E e)
    {
        if (node == null)
        {
            return false;
        }
        if (e.CompareTo(node.e) < 0)
        {
            return Contains(node.left, e);
        }
        else if (e.CompareTo(node.e) > 0)
        {
            return Contains(node.right, e);
        }

        return true;
    }

    // 前序遍历
    // 前序遍历对于每一个节点都遵循根节点->左节点->右节点的顺序访问
    public void PreOrder()
    {
        PreOrder(root);
    }

    private void PreOrder(Node node)
    {
        if (node == null)
            return;

        Console.WriteLine(node.e);

        PreOrder(node.left);
        PreOrder(node.right);
    }

    // 中序遍历
    // 中序遍历对于每一个节点都遵循左节点->根节点->右节点的顺序访问
    public void InOrder()
    {
        InOrder(root);
    }

    private void InOrder(Node node)
    {
        if (node == null)
            return;
        InOrder(node.left);
        Console.WriteLine(node.e);
        InOrder(node.right);
    }

    // 后序遍历
    // 后序遍历对于每一个节点都遵循左节点->右节点->根节点的顺序访问
    public void PostOrder()
    {
        PostOrder(root);
    }

    private void PostOrder(Node node)
    {
        if (node == null)
            return;

        PostOrder(node.left);
        PostOrder(node.right);
        Console.WriteLine(node.e);
    }

    // 层序遍历
    public void LevelOrder()
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            Node cur = q.Dequeue();
            Console.WriteLine(cur.e);

            if (cur.left != null)
            {
                q.Enqueue(cur.left);
            }

            if (cur.right != null)
            {
                q.Enqueue(cur.right);
            }
        }
    }
    // 返回以node为根的二叉树的最小值所在的节点
    public E Min()
    {
        if (IsEmpty)
        {
            throw new ArgumentException("empty tree");
        }
        var node = Min(root);
        return node.e;
    }

    private Node Min(Node node)
    {
        if (node.left == null)
        {
            return node;
        }

        return Min(node.left);
    }

    // 返回以node为根的二叉树的最大值所在的节点
    public E Max()
    {
        if (IsEmpty)
        {
            throw new ArgumentException("empty tree");
        }
        var node = Max(root);
        return node.e;
    }

    private Node Max(Node node)
    {
        if (node.right == null)
        {
            return node;
        }
        return Max(node.right);
    }
    // 删除掉以node为根的二叉树中最小的节点
    public E RemoveMin()
    {
        E ret = Min();
        root = RemoveMin(root);
        return ret;
    }
    private Node RemoveMin(Node node)
    {
        if (node.left == null)
        {
            N--;
            return node.right;
        }

        // 删除并挂接上去
        node.left = RemoveMin(node.left);
        return node;
    }

    // 删除掉以node为根的二叉树中最大的节点
    public E RemoveMax()
    {
        E ret = Max();
        root = RemoveMax(root);
        return ret;
    }

    private Node RemoveMax(Node node)
    {
        if (node.right == null)
        {
            N--;
            return node.left;
        }

        // 删除并挂接上去
        node.right = RemoveMax(node.right);
        return node;
    }

    // 删除掉以node为根的二叉树中值为e的节点
    // 返回删除节点后新的二叉查找树的根
    public void Remove(E e)
    {
        root = Remove(root, e);
    }

    // 删除掉以node为根的二叉树中值为e的节点
    // 返回删除节点后新的二叉查找树的根
    private Node Remove(Node node, E e)
    {
        if (node == null)
            return null;

        if (e.CompareTo(node.e) < 0)
        {
            node.left = Remove(node.left, e);
            return node;
        }
        else if (e.CompareTo(node.e) > 0)
        {
            node.right = Remove(node.right, e);
            return node;
        }
        else // e.CompareTo(node.e) == 0
        {
            if (node.right == null)
            {
                N--;
                return node.left;
            }
            if (node.left == null)
            {
                N--;
                return node.right;
            }

            // 要删除的节点左右都有孩子
            // 找到比待删除的节点大的最小节点，即待删除右子树的最小节点
            // 用这个节点顶替待删除节点的位置
            Node s = Min(node.right);
            s.right = RemoveMin(node.right);
            s.left = node.left;
            return s;
        }
    }
}