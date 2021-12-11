using System;

namespace NewGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool again = true;
            int randomNum;
            int guess;
            int guesses;
            String response;

            while (again)
            {
                guess = 0;
                guesses = 0;
                response = "";
                randomNum = random.Next(0, 101);

                while (guess != randomNum)
                {
                    Console.WriteLine("Guess a number between 0 and 100!");
                    guess = Convert.ToInt32(Console.ReadLine());

                    if (guess > randomNum)
                    {
                        Console.WriteLine("Too high, try again.");
                    }
                    else if (guess < randomNum)
                    {
                        Console.WriteLine("Too low, try again.");
                    }
                    guesses++;
                }

                Console.WriteLine("Correct! It took you " + guesses + " tries.");
                Console.WriteLine("Play again (Y/N): ");
                response = Console.ReadLine();
                response = response.ToUpper();

                if (response == "Y")
                {
                    again = true;
                }
                else
                {
                    again = false;
                }
            }

            Console.WriteLine("GG! Press any key to quit.");
            Console.ReadKey();
        }
    }
}