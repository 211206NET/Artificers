
using System.Text.RegularExpressions;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Guess Game!");

Random rand = new Random(); //C# requires an object made for random
int randomNum;              //int that stores the random result
randomNum = rand.Next(1, 101); //Initial random result
int diff=1; //difference between guess and random
int lastDiff=0; //Previous guess user made to compare if they got closer or not
int count=1;   //How many tries the user made
string guessS; //User guess returned as string
int guess;     //The guess the user made converted to int
string[] honing = new string[] { "very hot!", "hot.", "warm.", "cold.", "freezing cold!"};
int wtHone; //What position of hone to use
string choose; //At end the user can choose if to continue

//Cheat answer
//Console.WriteLine("{0}", randomNum); 

//The main loop
while( diff != 0 )
{
    Console.WriteLine("Guess a number from 1 to 100");
    guessS = Console.ReadLine();
    guess = int.Parse(guessS);

    //return difference between values MATH.ABS
    diff=Math.Abs(guess - randomNum);
    //Console.WriteLine("{0}",diff); 

    //Set how close hint valueswitch (measurement)
    switch (diff)
    {
        case < 10:
            wtHone = 0;
            break;
        case int n when (n >= 10 && n < 20):
            wtHone = 1;
            break;
        case int n when (n >= 20 && n < 30):
            wtHone = 2;
            break;
        case int n when (n >= 30 && n < 40):
            wtHone = 3;
            break;
        default:
            wtHone = 4;
            break;
    }

    if ( guess == randomNum ) //diff =  0
    {
        Console.WriteLine("That is correct!");
    }
    else
    {
        if ( lastDiff != 0 )
        {
            if ( lastDiff < diff )
            {
                Console.WriteLine("Incorrect, you are {1} You tried {0} times, you are getting colder, you want to try again? 'y' or 'n", count.ToString(), honing[wtHone]); 
            }else{
                Console.WriteLine("Incorrect, you are {1} You tried {0} times, but you are getting warmer, you want to try again? 'y' or 'n'", count.ToString(), honing[wtHone]); 
            }
        }
        else
        {
            Console.WriteLine("Incorrect, you want to try again? 'y' or 'n'");
        }

        lastDiff=diff;
        count=count+1;
        choose = Console.ReadLine();
        //if(Regex.IsMatch(choose, @"^\d+$"))//Check if result was numeric, Requires System.Text.RegularExpressions;
        //{
        //    choose = "n";
        //}

        if ( choose == "n" )
        {
            break;
        }else{
            Console.WriteLine("Keep going!"); 
        }
    }
}
