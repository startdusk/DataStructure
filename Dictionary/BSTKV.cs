namespace DataStructure.Dictionary;

public class BSTKV<Key, Value> where Key : IComparable<Key>
{
    private class Node
    {
        public Key key;
        public Value value;
        public Node left;
        public Node right;

        public Node(Key key, Value value)
        {
            this.key = key;
            this.value = value;
            left = null;
            right = null;
        }
    }

    private Node root;
    private int N;

    public BSTKV()
    {
        root = null;
        N = 0;
    }

    public int Count { get { return N; } }

    public bool IsEmpty { get { return N == 0; } }

    // 非递归方式添加node
    public void add(Key key, Value value)
    {
        if (root == null)
        {
            root = new Node(key, value);
            N++;
            return;
        }
        Node pre = null;
        Node cur = root;

        // 循环遍历，找到该node应该放到那个父亲的节点下
        while (cur != null)
        {
            // 节点已存在，跳过
            if (key.CompareTo(cur.key) == 0)
            {
                return;
            }

            pre = cur;
            if (key.CompareTo(cur.key) < 0)
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
        cur = new Node(key, value);
        if (key.CompareTo(cur.key) < 0)
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
    public void Add(Key key, Value value)
    {
        root = Add(root, key, value);
    }

    // 以node为根的树添加元素e, 添加后返回根节点node
    private Node Add(Node node, Key key, Value value)
    {
        if (node == null)
        {
            N++;
            return new Node(key, value);
        }

        if (key.CompareTo(node.key) < 0)
        {
            node.left = Add(node.left, key, value);
        }
        else if (key.CompareTo(node.key) > 0)
        {
            node.right = Add(node.right, key, value);
        }
        else
        {
            node.value = value;
        }

        return node;
    }

    // public bool Contains(Key key)
    // {
    //     return Contains(root, key);
    // }

    // 以node为根的树是包含元素e
    private bool Contains(Node node, Key key)
    {
        if (node == null)
        {
            return false;
        }
        if (key.CompareTo(node.key) < 0)
        {
            return Contains(node.left, key);
        }
        else if (key.CompareTo(node.key) > 0)
        {
            return Contains(node.right, key);
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

        Console.WriteLine(node.key);

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
        Console.WriteLine(node.key);
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
        Console.WriteLine(node.key);
    }

    // 层序遍历
    public void LevelOrder()
    {
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            Node cur = q.Dequeue();
            Console.WriteLine(cur.key);

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
    public Key Min()
    {
        if (IsEmpty)
        {
            throw new ArgumentException("empty tree");
        }
        var node = Min(root);
        return node.key;
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
    public Key Max()
    {
        if (IsEmpty)
        {
            throw new ArgumentException("empty tree");
        }
        var node = Max(root);
        return node.key;
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
    public Key RemoveMin()
    {
        Key ret = Min();
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
    public Key RemoveMax()
    {
        Key ret = Max();
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
    public void Remove(Key key)
    {
        root = Remove(root, key);
    }

    // 删除掉以node为根的二叉树中值为e的节点
    // 返回删除节点后新的二叉查找树的根
    private Node Remove(Node node, Key key)
    {
        if (node == null)
            return null;

        if (key.CompareTo(node.key) < 0)
        {
            node.left = Remove(node.left, key);
            return node;
        }
        else if (key.CompareTo(node.key) > 0)
        {
            node.right = Remove(node.right, key);
            return node;
        }
        else // key.CompareTo(node.key) == 0 找到要删除的节点
        {
            if (node.right == null) // 如果要删除的节点没有右孩子，那么就返回左孩子
            {
                N--;
                return node.left;
            }
            if (node.left == null) // 如果要删除的节点没有左孩子，那么就返回右孩子
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

    // 获取这个二叉树的最大高度
    public int MaxHeight()
    {
        return MaxHeight(root);
    }
    private int MaxHeight(Node node)
    {
        if (node == null) return 0;

        int l = MaxHeight(node.left);
        int r = MaxHeight(node.right);
        return Math.Max(l, r) + 1;
    }

    // 返回以node为根节点的二叉查找树中，key所在的节点
    private Node GetNode(Node node, Key key)
    {
        if (node == null) return null;
        if (key.Equals(node.key))
        {
            return node;
        }
        else if (key.CompareTo(node.key) < 0)
        {
            return GetNode(node.left, key);
        }
        else // key.CompareTo(node.key) > 0 
        {
            return GetNode(node.right, key);
        }
    }

    public bool Contains(Key key)
    {
        return GetNode(root, key) != null;
    }

    public Value Get(Key key)
    {
        Node node = GetNode(root, key);
        if (node == null)
        {
            throw new ArgumentException("键" + key + "不存在, 无法获取对应值");
        }
        else
        {
            return node.value;
        }
    }

    public void Set(Key key, Value newValue)
    {
        Node node = GetNode(root, key);
        if (node == null)
        {
            throw new ArgumentException("键" + key + "不存在, 无法更新对应值");
        }
        else
        {
            node.value = newValue;
        }
    }
}