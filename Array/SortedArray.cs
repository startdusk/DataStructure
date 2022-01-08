using System.Text;

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

        return l; // 为什么返回l？因为需要知道该元素可能会被放到什么位置
    }

    public void Add(Key key)
    {
        int l = Rank(key);

        // 去重
        if (l < N && keys[l].CompareTo(key) == 0)
        {
            return;
        }

        if (N == keys.Length)
        {
            ResetCapacity(keys.Length * 2);
        }
        for (int i = N - 1; i >= l; i--)
        {
            keys[i + 1] = keys[i];
        }
        keys[l] = key;
        N++;
    }

    public void Remove(Key key)
    {
        if (IsEmpty)
        {
            return;
        }
        int i = Rank(key);
        if (i == N || keys[i].CompareTo(key) != 0)
        {
            return;
        }

        for (int j = i + 1; j <= N - 1; j--)
        {
            keys[j - 1] = keys[j];
        }
        N--;
        keys[N] = default(Key);

        if (keys.Length / 4 == N)
        {
            ResetCapacity(keys.Length / 2);
        }
    }


    public override string ToString()
    {
        var res = new StringBuilder();
        res.Append(string.Format("Array: count={0} capacity={1}\n", N, keys.Length));
        res.Append("[");
        for (int i = 0; i < N; i++)
        {
            res.Append(keys[i]);
            if (i != N - 1)
            {
                res.Append(", ");
            }
        }
        res.Append("]\n");
        return res.ToString();
    }
    private void ResetCapacity(int newCapacity)
    {
        var newData = new Key[newCapacity];
        for (int i = 0; i < N; i++)
        {
            newData[i] = keys[i];
        }
        keys = newData;
    }
}