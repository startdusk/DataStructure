using System.Text;

namespace DataStructure.Stack;

public class Array<E>
{
    private E[] data;
    private int count;

    public Array(int capactity)
    {
        data = new E[capactity];
        count = 0;
    }

    public Array() : this(10) { }
    public void Set(int index, E newE)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }
        data[index] = newE;
    }
    public bool Contains(E e)
    {
        foreach (var item in data)
        {
            if (item.Equals(e))
            {
                return true;
            }
        }
        return false;
    }
    public int IndexOf(E e)
    {
        for (int i = 0; i < count; i++)
        {
            if (data[i].Equals(e))
            {
                return i;
            }
        }

        return -1;
    }
    public void Remove(E e)
    {
        var index = IndexOf(e);
        if (index != -1)
        {
            RemoveAt(index);
        }
    }
    public E RemoveAt(int index)
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
        data[count] = default(E);
        if (data.Length / 4 == count)
        {
            ResetCapacity(data.Length / 2);
        }
        return del;
    }
    public E RemoveFirst()
    {
        return RemoveAt(0);
    }
    public E RemoveLast()
    {
        return RemoveAt(count - 1);
    }
    public E Get(int index)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }
        return data[index];
    }
    public E GetFirst()
    {
        return Get(0);
    }
    public E GetLast()
    {
        return Get(count - 1);
    }
    public void AddFirst(E e)
    {
        Insert(0, e);
    }
    public void AddLast(E e)
    {
        Insert(count, e);
    }
    public void Insert(int index, E e)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentException("数组索引越界");
        }

        if (count == data.Length)
        {
            ResetCapacity(data.Length * 2);
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
        // res.Append(string.Format("Array: count={0} capacity={1}\n", count, data.Length));
        res.Append("[");
        for (int i = 0; i < count; i++)
        {
            res.Append(data[i]);
            if (i != count - 1)
            {
                res.Append(", ");
            }
        }
        res.Append("]");
        return res.ToString();
    }

    private void ResetCapacity(int newCapacity)
    {
        var newData = new E[newCapacity];
        for (int i = 0; i < count; i++)
        {
            newData[i] = data[i];
        }
        data = newData;
    }
}