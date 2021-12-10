
using System.Text.RegularExpressions;

Console.WriteLine("Guess Game!");

Random rand = new Random(); //C# requires an object made for random
int randomNum;              //int that stores the random result
randomNum = rand.Next(1, 101); //Initial random result
int diff=1; //difference between guess and random
int lastDiff=0; //Previous guess user made to compare if they got closer or not
int count=1;   //How many tries the user made
string guessS; //User guess returned as string
int guess;     //The guess the user made converted to int
//0, 1, 
string[] honing = new string[] { "very hot!", "hot.", "warm.", "cold.", "freezing cold!"};
int[] intArray = new int[5];
int wtHone; //What position of hone to use
string choose; //At end the user can choose if to continue

//The main loop
while( diff != 0 )
{
    Console.WriteLine("Guess a number from 1 to 100");
    guessS = Console.ReadLine();
    guess = int.Parse(guessS);

    //return difference between values MATH.ABS
    diff=Math.Abs(guess - randomNum);

    //Set how close hint 
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

    if ( guess == randomNum ) //or diff ==  0
    {
        Console.WriteLine("That is correct!");
    }
    else
    {
        if ( lastDiff != 0 )
        {
            if ( lastDiff < diff )
            {
                Console.WriteLine("Incorrect, you are {0} You tried {1} times, \n" +
                "you are getting colder, you want to try again? 'y' or 'n", honing[wtHone], count.ToString()); 
            }else{
                Console.WriteLine("Incorrect, you are {0} You tried {1} times, \n" +
                "but you are getting warmer, you want to try again? 'y' or 'n'", honing[wtHone], count.ToString()); 
            }
        }
        else
        {
            Console.WriteLine("Incorrect, but this was only your first try. Do you want to try again? 'y' or 'n'");
        }

        lastDiff=diff;
        count=count+1;
        choose = Console.ReadLine();
        //if(Regex.IsMatch(choose, @"^\d+$")){choose = "n";}//Check if result was numeric, Requires System.Text.RegularExpressions;
        if ( choose == "n" ){break;}
        else{Console.WriteLine("Keep going!");}
    }
}
