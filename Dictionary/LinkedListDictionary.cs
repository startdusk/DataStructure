namespace DataStructure.Dictionary;

public class LinkedListDictionary<Key, Value> : IDictionary<Key, Value>
{
    private LinkedList<Key, Value> list;

    public LinkedListDictionary()
    {
        list = new LinkedList<Key, Value>();
    }
    public int Count { get { return list.Count; } }

    public bool IsEmpty { get { return list.IsEmpty; } }

    public void Add(Key key, Value value)
    {
        list.Add(key, value);
    }

    public bool ContainsKey(Key key)
    {
        return list.Contains(key);
    }

    public Value Get(Key key)
    {
        return list.Get(key);
    }

    public void Remove(Key key)
    {
        list.Remove(key);
    }

    public void Set(Key key, Value newValue)
    {
        list.Set(key, newValue);
    }
}