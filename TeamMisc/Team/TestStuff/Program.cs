using System.Collections.Generic;
using System.Collections;

//A safe zone to make huge mistakes
Console.WriteLine("Test stuff here");

//4 mod 3 -> 1 G ???
double testDub = 99.67;
string elevenlttrs = "eleven_lttrs";
Console.WriteLine($"elevenlttrs: {elevenlttrs.Length} what is the 6th letter in the string {elevenlttrs[5]}");
Console.WriteLine(elevenlttrs[0]);

//Find the string "lttrs" withing the string elevenlttrs and replace with "letters"
/*
String str = "1 2 3 4 5 6 7 8 9";
Console.WriteLine("Original string: \"{0}\"", str);
Console.WriteLine("CSV string:      \"{0}\"", str.Replace(' ', ','));
*/

if (elevenlttrs.Contains("lttrs"))
{
    Console.WriteLine($"\nelevenlttrs does contain \"lttrs\" its value is {elevenlttrs}");

    elevenlttrs = elevenlttrs.Replace("lttrs","letters");
    //elevenlttrs = "eleven_letters";

    Console.WriteLine($"Now elevenlttrs's value is {elevenlttrs}\n");
}

if (elevenlttrs.StartsWith("ele"))
{
    Console.WriteLine("It does start with that");
}


Console.WriteLine("\n");

//Loops
/*
*/

//Standard Loop
int m = 0;
for(m = 0; m < 10; m+=1) //+=1  same as ++
{
    Console.Write(m);
}

Console.WriteLine("\n");

//For Each Loop
string myAnimal = "Buffalo";
foreach(char c in myAnimal)
{
    Console.Write($"{c}, ");
}

Console.WriteLine("\n");

List<string> ReviewList = new List<string>();
ReviewList.Add("Dog");
ReviewList.Add("Cat");
ReviewList.Add("Bird");
foreach(string rl in ReviewList)
{
    Console.WriteLine(rl);
}

Console.WriteLine("\n");

//While Loop
bool exit = false;
int countDown = 5;
while(exit != true)//exit == false same as !exit same as exit != true
{
    Console.WriteLine($"countDown: {countDown}");
    countDown--;
    if(countDown < 1)
    {
        Console.WriteLine($"Blast off!");
        exit = true;
    }
}

Console.WriteLine("\n");

//Do-While Loop
exit = true;
countDown = 5;
do
{
    Console.WriteLine($"countDown: {countDown}");
    countDown--;
    if(countDown < 1)
    {
        Console.WriteLine($"Blast off!");
        exit = true;
    }
}while(!exit);

Console.WriteLine("\n");


//Sorting an Array
int[] nums = {1, 2, 3, 4, 0, 0, 0, 2, 3};

Array.Sort(nums);

foreach(int i in nums)
{
    Console.Write(i + " ");
}

Console.WriteLine("\n");


Console.ReadLine();


//Practice Question
List<string> PracticeList = new List<string>();
List<string> TempList = new List<string>();
PracticeList.Add("Jonathon");
PracticeList.Add("Trevor");
PracticeList.Add("Stacy");
PracticeList.Add("Adam");
PracticeList.Add("Brandon");
PracticeList.Add("Tracy");
/*

    Go through all name sin the list and any that are 
    over the length of the shortest name
    change to be the same length as the shortest name

*/


    int shortest = 0; 
    foreach(string n in PracticeList){
        if(shortest > 0){ // lenght of name stored as shortest already
            if(n.Length < shortest){
                shortest = n.Length;
            }

        }
        else{
            shortest = n.Length;
        }
    }

    foreach(string strT in PracticeList)
    {
        TempList.Add(strT); 
    }

    Console.WriteLine($"TempList: {TempList.Count}");
    string tempString = ""; 
    int interateIt = 0;
    foreach(string nm in PracticeList){
        
        Console.WriteLine($"Got here {interateIt}");
        if(nm.Length > shortest){
            tempString = Char.ToString(nm[0])  +  Char.ToString(nm[1])  +  Char.ToString(nm[2])  +  Char.ToString(nm[3]); 
            //Now set the new value of this nm
            TempList[interateIt] = tempString;
        }
        
        interateIt++;
    }

    foreach(string strP in TempList)
    {
        PracticeList.Add(strP); 
    }

    foreach(string strP in PracticeList)
    {
        Console.WriteLine($"PracticeList: {strP}");
    }



Console.ReadLine();


//============= THE SIGNAL PROBLEM =============\\
//Set a string list for light problem R>G>B>R every minute lights change...
List<string> colors = new List<string>{"R","G","B"};//gives us numbers for color
//colors[0] -> "R", colors[1] -> G, colors[2] -> B
string signals = "RGGB"; //returns BRRG
int numMinPassed = 2;
string newSignals = ""; //Result

for(int i = 0; i< signals.Length; i++)
{
    int currColor = colors.IndexOf(signals[i].ToString());
                    //( 0     +     2 )    %  3
    int newColor = (currColor + numMinPassed) % 3; //% modulate it, add minutes and get remainder or something
    string newSignalColor = colors[newColor];
    newSignals += newSignalColor;
}

Console.WriteLine(newSignals);

Console.WriteLine($"2%3: {2 % 3}"); //modulate test   2%3 = 2, 3%3 = 0, 4%3 = 1

Console.ReadLine(); //Pause after test



//============= STRING SPLIT =============\\
//Change a string to a string array with a space between?
string returnInt = "3 5"; 
string[] tokens = returnInt.Split(' ');
Console.WriteLine($"tokens: {tokens[0]} {tokens[1]}");


Console.ReadLine(); //Pause after test



//============= NEXT =============\\


Console.ReadLine(); //Pause after test