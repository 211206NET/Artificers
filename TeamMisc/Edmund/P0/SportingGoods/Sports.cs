Using SportingGoods;

List<SportsStore> SportsInventory = new List<SportsStore>();
bool exit= false;
Console.Write("Welcome to the Sports Store");

while(!exit)
{
    Console.Write("Welcome to our Sports Store");
    Console.Write("1. Log in to Profile");
    Console.Write("2. Sign Up as a New User");
    Console.Write("x. Exit");
    string input = Console.Readline();

    switch (input)
    {
        case "1":
        Console.Write("Log in to Profile ");

        break;

        case "2":
        Console.Write("Sign Up as a New User");


        break;
        case "x":
            exit = true;
            Console.Write("Thank you. Please come again.");
        break;
    

    }
}


