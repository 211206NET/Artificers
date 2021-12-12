// See https://aka.ms/new-console-template for more information

Random rand = new Random();
int randomNum;
randomNum = rand.Next(1, 101);



Console.WriteLine(randomNum);
Console.WriteLine("Guess a number");
string input = Console.ReadLine();
int guessNum = int.Parse(input); 
int counter = 1;

int diff = Math.Abs( guessNum - randomNum );
do
{

    if ( guessNum < randomNum )
    {
        Console.WriteLine("Too Low. Off by " + diff);
    }

    if ( guessNum > randomNum )
    {
        Console.WriteLine("Too High. Off by " + diff);
    }
    Console.WriteLine("Guess Again");
    input = Console.ReadLine();
    guessNum = int.Parse(input);
    diff = Math.Abs( guessNum - randomNum );
    counter++;
} while ( guessNum != randomNum );

Console.WriteLine("Correct! It took you " + counter + " guesses");
