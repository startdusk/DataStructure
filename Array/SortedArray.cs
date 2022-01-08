namespace DataStructure.Array;

// 有序数组
public class SortedArray<Key> where Key : IComparable<Key>
{
    private Key[] keys;
    private int N;

    public SortedArray(int capacity)
    {
        keys = new Key[capacity];
    }

    public SortedArray() : this(10) { }

    public int Count { get { return N; } }
    public bool IsEmpty { get { return N == 0; } }

    // 在数组里面查找key的索引位置
    public int Rank(Key key)
    {
        int l = 0;
        int r = keys.Length - 1;
        while (l <= r)
        {
            int mid = l + (r - l) / 2;
            if (key.CompareTo(keys[mid]) > 0)
            {
                r = mid - 1;
            }
            else if (key.CompareTo(keys[mid]) < 0)
            {
                l = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}