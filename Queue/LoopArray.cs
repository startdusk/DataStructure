using System.Text;

namespace DataStructure.Queue;

// 循环数组
public class LoopArray<E>
{
    private E[] data;
    private int first;
    private int last;
    private int N;

    public LoopArray(int capacity)
    {
        data = new E[capacity];
        first = 0;
        last = 0;
        N = 0;
    }

    public LoopArray() : this(10)
    {

    }

    public int Count { get { return N; } }

    public bool IsEmpty { get { return N == 0; } }


    public void AddLast(E e)
    {
        if (N == data.Length)
        {
            ResetCapacity(data.Length * 2);
        }
        data[last] = e;
        last = (last + 1) % data.Length;
        N++;
    }

    public E RemoveFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("数组元素为空");
        }

        if (N == data.Length / 4)
        {
            ResetCapacity(data.Length / 2);
        }

        var ret = data[first];
        data[first] = default(E);
        first = (first + 1) % data.Length;
        N--;
        return ret;
    }

    public E GetFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("数组元素为空");
        }

        return data[first];
    }

    private void ResetCapacity(int newCapacity)
    {
        var newData = new E[newCapacity];
        for (int i = 0; i < newCapacity; i++)
        {
            newData[i] = data[(first + 1) % data.Length];
        }
        data = newData;
        first = 0;
        last = N;
    }

    public override string ToString()
    {
        StringBuilder res = new StringBuilder();
        res.Append("[");
        for (int i = 0; i < N; i++)
        {
            res.Append(data[(first + i) % data.Length]);
            if ((first + i + 1) % data.Length != last)
            {
                res.Append(",");
            }
        }
        res.Append("]");
        return res.ToString();
    }
}