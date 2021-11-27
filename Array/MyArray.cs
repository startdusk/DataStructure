using System.Text;

namespace DataStructure.Array;

public class MyArray
{
    private int[] data;
    private int count;

    public MyArray(int capactity)
    {
        data = new int[capactity];
        count = 0;
    }

    public MyArray() : this(10) { }
    public void Set(int index, int newE)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }
        data[index] = newE;
    }
    public bool Contains(int e)
    {
        foreach (var item in data)
        {
            if (item == e)
            {
                return true;
            }
        }
        return false;
    }
    public int IndexOf(int e)
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i] == e)
            {
                return i;
            }
        }

        return -1;
    }
    public void Remove(int e)
    {
        var index = IndexOf(e);
        if (index != -1)
        {
            RemoveAt(index);
        }
    }
    public int RemoveAt(int index)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }
        var del = data[index];
        for (int i = index + 1; i <= count - 1; i++)
        {
            data[i - 1] = data[i];
        }
        count--;
        data[count] = default(int);
        return del;
    }
    public int RemoveFirst()
    {
        return RemoveAt(0);
    }
    public int RemoveLast()
    {
        return RemoveAt(count - 1);
    }
    public int Get(int index)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }
        return data[index];
    }
    public int GetFirst()
    {
        return Get(0);
    }
    public int GetLast()
    {
        return Get(count - 1);
    }
    public void AddFirst(int e)
    {
        Insert(0, e);
    }
    public void AddLast(int e)
    {
        Insert(count, e);
    }
    public void Insert(int index, int e)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }

        if (count == data.Length)
        {
            throw new ArgumentException("数组已满");
        }
        for (int i = count - 1; i >= index; i--)
        {
            data[i + 1] = data[i];
        }
        data[index] = e;
        count++;
    }

    public int Capacity
    {
        get
        {
            return data.Length;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return count == 0;
        }
    }

    public override string ToString()
    {
        var res = new StringBuilder();
        res.Append(string.Format("MyArray: count={0} capacity={1}\n", count, data.Length));
        res.Append("[");
        for (int i = 0; i < count; i++)
        {
            res.Append(data[i]);
            if (i != count - 1)
            {
                res.Append(", ");
            }
        }
        res.Append("]\n");
        return res.ToString();
    }
}