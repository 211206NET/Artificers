Console.WriteLine("FizzBuzz");
Console.WriteLine("Enter a positive integer");

string input = Console.ReadLine();

//We are taking whatever user inputed and printing it back out to the console
Console.WriteLine("You entered " + input);


//Next, we are parsing string input into number so we can do arithmetic on it
int number = int.Parse(input);
Console.WriteLine("We parsed your input to " + number);

while (number <= 0)
{
    Console.WriteLine("The number should be greater than 0");
    Console.WriteLine("ENter a positive number");
    input = Console.ReadLine();
    number = int.Parse(input);
}
