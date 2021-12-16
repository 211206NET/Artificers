using Models;
using BL;
using DL;

namespace UI;

public class RestMenu
{
    //private RRBL _bl;
    private IBL _bl;
    
    public RestMenu(IBL bl) 
    {
        //_bl = new RRBL(new FileRepo());
        _bl = bl;
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("This is the Restaurant Menu");
            Console.WriteLine("[1] Create Restaurant");
            Console.WriteLine("[2] Views all");
            Console.WriteLine("[x] Go back");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
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

                    _bl.AddRest(newRest);
                break;

                case "2":
                    
                    List<Rest> allRestaurants = _bl.GetAllRest();
                    
                    //there is no restaurants stored anywhere
                    if(allRestaurants.Count == 0)
                    {
                        Console.WriteLine("No restaurants found :/");
                    }
                    else
                    {
                        Console.WriteLine("Here are the Restaurants");
                        foreach(Rest resto in _bl.GetAllRest())//Just made up resto right here
                        {
                            Console.WriteLine($"\nRestaurant: {resto.Name} \n"+
                            $"City: {resto.City}\nState: {resto.State}");
                            if(resto.Reviews != null && resto.Reviews.Count > 0)
                            {
                                Console.WriteLine("=======Reviews========");
                                foreach(Review review in resto.Reviews)
                                {
                                    Console.WriteLine($"Rating: {review.Rating} \t Note: {review.Note}");
                                }
                            } 
                            else
                            {
                                Console.WriteLine("No Reviews :'(");
                            }
                        }
                    }
                break;

                case "x":
                    exit = true;
                break;
                default:
                    Console.WriteLine("Enter correct value");
                break;
            }

        }
    }
}