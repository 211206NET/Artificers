using System.Collections;
//Array, Array List, BitArray due Dec 17th, 10 to 15 minute presentation each person speaks, 
//Some kind of visual material (power point), Demo that shows different unique function
//Google uses for bit arrays
//List in our worlds talking points


Console.WriteLine("//===================================<>  Bit Array  <>====================================//\n");
/*Why bit array is used?
Bit array is used to achieve bit-level parallelism in processing executions. It is a kind of parallel computing based 
on increasing word size of the processor which reduces the number of instructions for the processor. It allows the 
execution of operations to occur quickly. As a result of bit level parallelism, Bit array allows small array of bits to 
be stored and manipulated in the register set for long period of time.

Because of their compactness, bit arrays have a number of applications in areas where space or efficiency is at a premium. 
Most commonly, they are used to represent a simple group of boolean flags or an ordered sequence of boolean values.
Bitarray takes 1/8 the space as bool
*/

//Non Generic

//creating two  bit arrays of size 8
BitArray ba1 = new BitArray(8);
BitArray ba2 = new BitArray(8);
byte[] a = { 60 };
byte[] b = { 13 };

//storing the values 60, and 13 into the bit arrays
ba1 = new BitArray(a);
ba2 = new BitArray(b);

//content of ba1
Console.WriteLine("Bit array ba1: " + "60\n");

for (int i = 0; i < ba1.Count; i++)
{
    Console.Write("{0, -6} \n", ba1[i]);
}
Console.WriteLine();

//content of ba2
Console.WriteLine("Bit array ba2: " + "13\n");

for (int i = 0; i < ba2.Count; i++)
{
    Console.Write("{0, -6} \n", ba2[i]);
}
Console.WriteLine();
BitArray ba3 = new BitArray(8);
ba3 = ba1.And(ba2);

//content of ba3
Console.WriteLine("Bit array ba3 after AND operation: 12\n");

for (int i = 0; i < ba3.Count; i++)
{
    Console.Write("{0, -6} \n", ba3[i]);
}
Console.WriteLine();
ba3 = ba1.Or(ba2);

//content of ba3
Console.WriteLine("Bit array ba3 after OR operation: 61\n");

for (int i = 0; i < ba3.Count; i++)
{
    Console.Write("{0, -6} \n", ba3[i]);
}
Console.WriteLine();

//Bit Array Sample, Demo that shows different unique function:

//BitArray Array to compare to Bool Array
//Unlike Bool, bitarray has bitwise methods (.Or, .Xor...)
//BitArray is a memory optimization over bool[], but there's no point in using it unless memory is sparse.
BitArray biArray = new BitArray(8);
biArray[4] = true;

//Bool Array to Compare to BitArray
bool[] boArray = new bool[8];
boArray[4] = true;

Console.WriteLine();

Console.WriteLine("//===================================<>  Array List   <>===================================//\n");
ArrayList asl = new ArrayList();
asl.Add("One");
asl.Add("Two");
asl.Add("Three");
asl.Add("Four");

ArrayList al = new ArrayList();
Console.WriteLine();
Console.WriteLine("Adding some numbers to Array List:");
al.Add(45);
al.Add(78);
al.Add(33);
al.Add(56);
al.Add(12);
al.Add(23);
al.Add(9);

Console.WriteLine("Capacity: {0} ", al.Capacity);
Console.WriteLine("Count: {0}", al.Count);

Console.Write("Content: ");
foreach (int i in al)
{
    Console.Write(i + " ");
}

Console.WriteLine();
Console.Write("Content of ASL: ");
foreach (string i in asl)
{
    Console.Write(i + " ");
}

Console.WriteLine();
Console.Write("Sorted Content: ");
al.Sort();
foreach (int i in al)
{
    Console.Write(i + " ");
}

Console.WriteLine("\n");

Console.WriteLine("//===================================<>  Standard Array   <>===================================//\n");
object[] myArr = new object[5];
for(int i = 0; i < myArr.Length; i++)
{
    myArr[i] = i*10;
    Console.Write("Standard Array "+i+": "+myArr[i] + "\n");
}

Console.WriteLine();

object[] myArr2 = {"a","b","c"};
for(int i = 0;i < myArr2.Length; i++)
{
    Console.Write("Second Standard Array " + i + ": " + myArr2[i]+"\n");
}

Console.WriteLine();

int[,] table = new int[10, 10];
for(int i = 1; i <= table.GetLength(0); ++i)//++ before 'i' means value is added before line compiles
{
    for (int j = 1; j <= table.GetLength(1); ++j)
    {
        table[i - 1, j - 1] = i * j;
        Console.Out.Write(table[i - 1, j -1] + " ");
    }
}

Console.WriteLine("\n");