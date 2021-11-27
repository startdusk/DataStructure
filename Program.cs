using DataStructure.Array;

var array = new MyArray(20);
for (int i = 0; i < 10; i++)
{
    array.AddLast(i);
}

Console.Write(array);
array.AddFirst(100);
Console.Write(array);
array.Insert(2, 200);
Console.Write(array);
Console.WriteLine(array.GetFirst() == 100);
Console.WriteLine(array.Get(2) == 200);
array.AddLast(1000);
Console.WriteLine(array.GetLast() == 1000);

Console.Write(array);
array.RemoveAt(2);
Console.Write(array);
array.RemoveFirst();
Console.Write(array);
array.RemoveLast();
Console.Write(array);

array.Remove(9);
Console.Write(array);

for (int i = 0; i < 4; i++)
{
    array.RemoveLast();
    Console.Write(array);
}
for (int i = 0; i < 16; i++)
{
    array.AddLast(i * 10);
    Console.Write(array);
}