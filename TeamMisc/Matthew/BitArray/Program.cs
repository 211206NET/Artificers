using System.Collections;
//BitArray due Dec 17th, 10 to 15 minute presentation each person speaks, some kind of visual material (power point), Demo that shows different unique function
//Google uses for bit arrays
//List in our worlds talking points
//Maybe make unity project for bitarray

//===========================================<>  Bit Array  <>===========================================\\
/*Why bit array is used?
Bit array is used to achieve bit-level parallelism in processing executions. It is a kind of parallel computing based on increasing 
word size of the processor which reduces the number of instructions for the processor. It allows the execution of operations to 
occur quickly. As a result of bit level parallelism, Bit array allows small array of bits to be stored and manipulated in the register 
set for long period of time.*/
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