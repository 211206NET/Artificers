using RestaurantReviews;
//In .NET 6 I don't need using generic collections here

List<Rest> allRests = new List<Rest>();
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

            allRests.Add(newRest);
            break;
        case "2":
            Console.WriteLine("Add one");
            foreach(Rest resto in allRests)//Just made up resto right here
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
            Console.WriteLine("Pick a restaurant to review: ");
            //foreach(Restaurant resto in allRests)//Just made up resto right here
            //int i = 0;
            for(int i = 0; i < allRests.Count; i++)
            {
                Console.WriteLine($"Restaurant: [{i}] Name: {allRests[i].Name} \n"+
                $"City: {allRests[i].City}\nState: {allRests[i].State}");
            }
            int select = Int32.Parse(Console.ReadLine());
            Rest selectR = allRests[select];

            //Now collect info
            Console.WriteLine("Rating: ");
            int rate = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Leave Review: ");
            string rev = Console.ReadLine();

            Review reviewOne = new Review(rate, rev);

            selectR.Reviews.Add(reviewOne);
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

// // newRestro.SetName("Duff's Wings");
// newRestro.Name = "Duff's Wings!";
// newRestro.City = "Buffalo";
// newRestro.State = "NY";

// //Console.WriteLine(newRestro.GetName());