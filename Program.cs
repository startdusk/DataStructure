using System.Collections;
using System.Diagnostics;


// var array = new DataStructure.Array.Array<int>(20);
// for (int i = 0; i < 10; i++)
// {
//     array.AddLast(i);
// }

// Console.Write(array);
// array.AddFirst(100);
// Console.Write(array);
// array.Insert(2, 200);
// Console.Write(array);
// Console.WriteLine(array.GetFirst() == 100);
// Console.WriteLine(array.Get(2) == 200);
// array.AddLast(1000);
// Console.WriteLine(array.GetLast() == 1000);

// Console.Write(array);
// array.RemoveAt(2);
// Console.Write(array);
// array.RemoveFirst();
// Console.Write(array);
// array.RemoveLast();
// Console.Write(array);

// array.Remove(9);
// Console.Write(array);

// for (int i = 0; i < 4; i++)
// {
//     array.RemoveLast();
//     Console.Write(array);
// }
// for (int i = 0; i < 16; i++)
// {
//     array.AddLast(i * 10);
//     Console.Write(array);
// }

// var n = 10000000;
// var t1 = new Stopwatch();
// Console.WriteLine("测试值类型对象int");
// t1.Start();
// var l = new List<int>();
// for (int i = 0; i < n; i++)
// {
//     l.Add(i); // 不发生装箱
//     int x = l[i]; // 不发生拆箱
// }
// t1.Stop();
// Console.WriteLine("测试值类型对象int 耗时" + t1.ElapsedMilliseconds + "ms");
// var t2 = new Stopwatch();
// Console.WriteLine("测试引用类型对象int");
// t2.Start();
// var l1 = new ArrayList();
// for (int i = 0; i < n; i++)
// {
//     l1.Add(i); // 发生装箱
//     int x = (int)l1[i]; // 发生拆箱
// }
// t2.Stop();
// Console.WriteLine("测试引用类型对象int 耗时" + t2.ElapsedMilliseconds + "ms");


// var t3 = new Stopwatch();
// Console.WriteLine("测试引用类型对象string");
// t3.Start();
// var l2 = new List<string>();
// for (int i = 0; i < n; i++)
// {
//     l2.Add("x"); // 不发生装箱
//     string x = l2[i]; // 不发生拆箱
// }
// t3.Stop();
// Console.WriteLine("测试引用类型对象string 耗时" + t3.ElapsedMilliseconds + "ms");
// var t4 = new Stopwatch();
// Console.WriteLine("测试引用类型对象string");
// t4.Start();
// var l3 = new ArrayList();
// for (int i = 0; i < n; i++)
// {
//     // string是引用类型
//     l3.Add("x"); // 不发生装箱
//     string x = (string)l3[i]; // 不发生拆箱
// }
// t4.Stop();
// Console.WriteLine("测试引用类型对象string 耗时" + t4.ElapsedMilliseconds + "ms");

// // LinkedList
// var list = new DataStructure.LinkedList.LinkedList<int>();
// for (int i = 0; i < 10; i++)
// {
//     list.AddFirst(i);
//     Console.WriteLine(list);
// }
// list.AddLast(400);
// Console.WriteLine(list);
// list.Add(2, 999);
// Console.WriteLine(list);
// list.Set(2, 1000);
// Console.WriteLine(list);

// // 9->8->1000->7->6->5->4->3->2->1->0->400->Null

// list.RemoveAt(2);
// // 9->8->7->6->5->4->3->2->1->0->400->Null
// Console.WriteLine(list);

// list.RemoveFirst();
// // 8->7->6->5->4->3->2->1->0->400->Null
// Console.WriteLine(list);

// list.RemoveLast();
// // 8->7->6->5->4->3->2->1->0->Null
// Console.WriteLine(list);
// list.Remove(0);
// // 8->7->6->5->4->3->2->1->Null
// Console.WriteLine(list);

var arrayStack = new DataStructure.Stack.ArrayStack<int>(10);
for (int i = 0; i < 5; i++)
{
    arrayStack.Push(i);
}
Console.WriteLine(arrayStack);
Console.WriteLine(arrayStack.Peek());
arrayStack.Pop();
Console.WriteLine(arrayStack);

var linkedListStack = new DataStructure.Stack.LinkedListStack<int>();
for (int i = 0; i < 5; i++)
{
    linkedListStack.Push(i);
}
Console.WriteLine(linkedListStack);
Console.WriteLine(linkedListStack.Peek());
linkedListStack.Pop();
Console.WriteLine(linkedListStack);


var N = 10000000;
var arrStack = new DataStructure.Stack.ArrayStack<int>();
var llStack = new DataStructure.Stack.LinkedListStack<int>();
var t1 = Test.TestStack(arrayStack, N);
Console.WriteLine("ArrayStack time: " + t1 + "ms");
var t2 = Test.TestStack(llStack, N);
Console.WriteLine("LinkedListStack time: " + t2 + "ms");

class Test
{
    public static long TestStack(DataStructure.Stack.IStack<int> stack, int N)
    {
        Stopwatch t = new Stopwatch();
        t.Start();
        for (var i = 0; i < N; i++)
        {
            stack.Push(i);
        }
        for (var i = 0; i < N; i++)
        {
            stack.Pop();
        }
        t.Stop();
        return t.ElapsedMilliseconds;
    }
}