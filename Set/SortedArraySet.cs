namespace DataStructure.Set;

public class SortedArraySet<Key> : ISet<Key> where Key : IComparable<Key>
{
    private SortedArray<Key> s;
    public SortedArraySet()
    {
        s = new SortedArray<Key>();
    }
    public SortedArraySet(int capacity)
    {
        s = new SortedArray<Key>(capacity);
    }
    public int Count { get { return s.Count; } }

    public bool IsEmpty { get { return s.IsEmpty; } }

    public void Add(Key e)
    {
        s.Add(e);
    }

    public bool Contains(Key e)
    {
        return s.Contains(e);
    }

    public void Remove(Key e)
    {
        s.Remove(e);
    }
}