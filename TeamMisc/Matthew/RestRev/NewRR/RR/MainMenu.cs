using Models;
//using DL;
using BL;

namespace UI;

//using RestaurantReviews;
//using Models;
//In .NET 6 I don't need using generic collections here

//List<Rest> allRests = new List<Rest>();
public class MainMenu {

//public List<Rest> allRests = new List<Rest>();
private RRBL _bl;

public MainMenu()
{
    _bl = new RRBL();
}

public void Start(){


bool exit = false;
// Restaurant Review
Console.WriteLine("Restaurant Review");

while(!exit)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1.) Create a new Restaurant!");//1.)
    Console.WriteLine("2.) View all Restaurants");//2.) 
    Console.WriteLine("3.) Leave a Review");//3.) 
    Console.WriteLine("x.) Exit");//x.) 
    string inputX = Console.ReadLine();

    switch(inputX)
    {
        case "1":
            //Rest newRestro = new Rest();

            Console.WriteLine("Add new restaurant");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("State: ");
            string state = Console.ReadLine();

            Rest newRest = new Rest{
                Name = name,
                City = city,
                State = state
            };

            //StaticStorage.allRests.Add(newRest);
            _bl.AddRest(newRest);
            break;
        case "2":
            Console.WriteLine("Add one");
            foreach(Rest resto in _bl.GetAllRest())//Just made up resto right here
            {
                Console.WriteLine($"Restaurant: {resto.Name} \n"+
                $"City: {resto.City}\nState: {resto.State}");
                Console.WriteLine("=======Reviews========");
                foreach(Review review in resto.Reviews)
                {
                    Console.WriteLine($"Rating: {review.Rating} \t Note: {review.Note}");
                }
            }
            break;
        case "3":
            List<Rest> allRestaurants = _bl.GetAllRest();
            Console.WriteLine("Pick a restaurant to review: ");
            for(int i = 0; i < allRestaurants.Count; i++)
            {
                Console.WriteLine($"Restaurant: [{i}] Name: {allRestaurants[i].Name} \n"+
                $"City: {allRestaurants[i].City}\nState: {allRestaurants[i].State}");
            }
            int select = Int32.Parse(Console.ReadLine());
            //Rest selectR = StaticStorage.allRests[select];

            //Now collect info
            Console.WriteLine("Rating: ");
            int rate = Int32.Parse(Console.ReadLine()); //Bug?
            Console.WriteLine("Leave Review: ");
            string rev = Console.ReadLine();

            Review reviewOne = new Review(rate, rev);

            //selectR.Reviews.Add(reviewOne);
            _bl.AddReview(select, reviewOne);
            Console.WriteLine("Your review was added");

            break;
        case "x":
            exit = true;
            break;
        default:
            Console.WriteLine("Input 1,2,3 or x...");
            break;
    }

    Console.WriteLine("Add another? [y/n]");
    string input = Console.ReadLine();
    if(input == "n")
    {
        exit = true;
    }

    // Restaurant newRest = new Restaurant();
    // newRest.Name = name;
    // newRest.City = city;
    // newRest.State = state;
}

}

}
// // newRestro.SetName("Duff's Wings");
// newRestro.Name = "Duff's Wings!";
// newRestro.City = "Buffalo";
// newRestro.State = "NY";

// //Console.WriteLine(newRestro.GetName());

//dotnet new sln
//dotnet sln add ./NewRR

//Dictionary organized based on key (key value pairs) hash
//--------------------------------------------------------
//collection is data structure
//c# has 2 generic non generic

//array 1d 2d jagged(array in array), size can't be changed later

//list auto resize as needed double each time it gets full

//array belongs to system namespace
//the rest belong to collection

//ICollection which is from IEnumerable is root of collections?

//IEnumerable interface can supports generic or non generic collection

//Array can't be resized after initialized array list can

//stack is lifo: last in first out
//queue is fifo:  first in first out
