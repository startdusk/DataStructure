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
}