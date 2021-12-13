using RestaurantReviews;
//In .NET 6 I don't need using generic collections here

List<Restaurant> allRests = new List<Restaurant>();

// Restaurant Review
Console.WriteLine("Restaurant Review");

Restaurant newRestro = new Restaurant();

bool exit = false;
while(!exit)
{
    //1.) Create Restaurant
    Console.WriteLine("Create a new Restaurant!");

    Console.WriteLine("Name");
    string name = Console.ReadLine();

    Console.WriteLine("City");
    string city = Console.ReadLine();

    Console.WriteLine("State");
    string state = Console.ReadLine();

    // Restaurant newRest = new Restaurant();
    // newRest.Name = name;
    // newRest.City = city;
    // newRest.State = state;

    Restaurant newRest = new Restaurant{
        Name = name,
        City = city,
        State = state
    };

    allRests.Add(newRest);

    Console.WriteLine("Add one");
    foreach(Restaurant resto in allRests)//Just made up resto right here
    {
        Console.WriteLine($"Restaurant: {newRestro.Name} \n"+
        $"City: {newRestro.City}\nState: {newRestro.State}");
    }

    Console.WriteLine("Add another? [y/n]");
    string input = Console.ReadLine();
    if(input == "n")
    {
        exit = true;
    }
}

// // newRestro.SetName("Duff's Wings");
// newRestro.Name = "Duff's Wings!";
// newRestro.City = "Buffalo";
// newRestro.State = "NY";

// //Console.WriteLine(newRestro.GetName());