using System.Collections.Generic;
using System.Collections;
//using TestThingsAndStuff;
//namespace TestThingsAndStuff;

//A safe zone to make huge mistakes
Console.WriteLine("Test stuff here");
Console.WriteLine("\n");//Spacer





//============= CAFFEINE =============\\

/*Caffeine use causes sleep deprivation, and sleep deprivation causes sleepiness the subsequent day, 
which in turn causes an increased need to consume more caffeine in order to cope with the sleepiness. 
Even with increased caffeine consumption, sleep deprivation catches up

If 100mg of caffeine consumed in one day can compromise good REM sleep by 1 hour a night and every 
additional 50mg will increase the sleep loss by a factor of 20%, return how much caffeine is needed 
to completely destroy your ability to sleep a standard 8 hour session.*/

int caffeineMG = 100; //The amount of caffeine consumed in one day
float compoundLoss = 0.0f; //The additional penalty for every 50 mg after the first 100 mg
//Console.WriteLine($"{caffeineMG+(caffeineMG*compoundLoss)}");
const int sleepNeeded = 8; //A constant value of how much sleep one needs in a night to be healthy
int remainingSegments = 0; //How many half hours 50mg attack segments exists after the first hour?

//Get value of remainingSegments after first hour
remainingSegments = ((sleepNeeded*100)-100)/50;

//Determine the rate of compound sleep loss from excessive caffeine
for(int i = 1; i<remainingSegments; i++)
{
    if((compoundLoss*caffeineMG)+caffeineMG < sleepNeeded*100)
    {
        //Set the caffeine needed
        caffeineMG += 50;
        compoundLoss = compoundLoss+(0.2f); //Compound the loss factor
        
        //Console.WriteLine($"(compoundLoss*caffeineMG)+caffeineMG: {(compoundLoss*caffeineMG)+caffeineMG}, compoundLoss: {compoundLoss}, caffeineMG: {caffeineMG}");
    }else{break;}
}

Console.WriteLine($"{caffeineMG}mg of caffeine a day is needed to destroy all of your sleep"); //Returns 400mg


Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine(); //Pause after test



//============= CASTING PRACTICE =============\\
//Converting value types
double testDub = 99.67;
/*
    In C#, there are two types of casting:

    Implicit Casting (automatically) - converting a smaller type to a larger type size
    char -> int -> long -> float -> double
    Implicit casting is done automatically when passing a smaller size type to a larger size type:
    double testDub = myInt;

    Explicit Casting (manually) - converting a larger type to a smaller size type
    double -> float -> long -> int -> char
    Explicit casting must be done manually by placing the type in parentheses in front of the value:
    int myInt = (int) testDub;  
*/

//Some Casting
Console.WriteLine($"initial testDub: {testDub}");
int myInt = (int) testDub; //Will round the double to a whole number
Console.WriteLine($"myInt: value from double: {myInt}");
testDub = myInt; //Will implicitly set the double value to the int
Console.WriteLine($"testDub: value back from int: {testDub}");
float myFloat = (float) testDub; 
Console.WriteLine($"myFloat: value taken from double: {myFloat}");
myFloat += 0.4f; //When changing values to a float, you must add f at the end
testDub = myFloat; //The double accepts the float value no problem as double is a larger type
Console.WriteLine($"testDub: value taken from modified float: {testDub}");

//Store the int equivalent of each char into an int array
int[] alphaInt = new int[26];

//Store the alphabet into a char array
string abc = "a b c d e f g h i j k l m n o p q r s t u v w x y z"; //The given input for the alphabet
//Add the alphabet string to a string array, this treats each space in the given string as a new position int he array
string[] tokensABC = abc.Split(' '); 
char[] alphaChar = new char[26]; //This is the char array that will store the letters from the string array
for(int i = 0; i < 26; i++) //Loop 26 times for each letter in alphabet
{
    alphaChar[i] = Convert.ToChar(tokensABC[i]); //set chararray to string array values by converting to char 
    Console.Write($"{alphaChar[i]} "); 
    alphaInt[i] = alphaChar[i];  //Finally set the int array from the char array
    Console.Write($"{alphaInt[i]} "); //Returns a line with each letter followed by char numeric value
    //Because char to int is smaller to larger size value type conversion this is implicit casting with no data loss
}


Console.WriteLine("\n\nEnter anything to continue test results\n");//Spacer
Console.ReadLine(); //Stop results until something is entered

//============= STRING PRACTICE =============\\
//String Stuff
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


Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine();

//============= LOOPS =============\\
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

Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine();

//============= PRACTICE QUESTION: NAME EQUITY =============\\
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


Console.WriteLine("\n\nEnter anything to continue test results\n");
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

Console.WriteLine("\n\nEnter anything to continue test results\n");//Spacer
Console.ReadLine(); //Stop results until something is entered



//============= STRING SPLIT =============\\
//Change a string to a string array with a space between?
string returnInt = "3 5"; 
string[] tokens = returnInt.Split(' ');
Console.WriteLine($"tokens: {tokens[0]} {tokens[1]}");

Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine(); //Pause after test



//============= Modulus =============\\
//4 mod 3 -> 1 G ???

//Input a number to change the seasons, 1 = one season change
List<string> seasons = new List<string>{"Spring","Summer","Fall","Winter"};//Gives us numbers for color
int curSeason = 3;
int seasonChange = 2;

Console.WriteLine($"The season begins as {seasons[curSeason]} and it will now move forward {seasonChange} seasons");
//Console.WriteLine($"5%4: {5 % 4}"); //Returns 1 //modulate test   2%3 = 2, 3%3 = 0, 4%3 = 1
Console.WriteLine($"The resulting season is now {seasons[(curSeason+seasonChange)%4]}");//Useful for looping through an array with cyclic data

Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine(); //Pause after test


//============= NEXT =============\\





Console.WriteLine("\n\nEnter anything to continue test results\n");
Console.ReadLine(); //Pause after test



