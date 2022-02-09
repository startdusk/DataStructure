namespace DataStructure.Set;

public class BSTSet<E> : ISet<E> where E : IComparable<E>
{
    private BST<E> bst;

    public BSTSet()
    {
        bst = new BST<E>();
    }
    public int Count { get { return bst.Count; } }

    public bool IsEmpty { get { return bst.IsEmpty; } }

    public void Add(E e)
    {
        bst.Add(e);
    }

    public bool Contains(E e)
    {
        return bst.Contains(e);
    }

    public void Remove(E e)
    {
        bst.Remove(e);
    }
}