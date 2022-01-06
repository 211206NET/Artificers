using Models;
using DL;
using BL;

namespace UI;

public class MainMenu : IMenu
{
    private IBL _bl;

    public MainMenu()
    {
    }

    public MainMenu(IBL bl)
    {
        //example of dependency injection
        _bl = bl;
    }

    public void Start()
    {
        List<Store> allStores = _bl.GetAllStores();


        bool exit = false;
        bool credentialsRight = false;
        bool manager = false;
        string existingUsername = "";
        string existingPassword = "";
        string input = "0";

        while (!exit)
        {
            switch (input)
            {
                case "0":
                    Console.WriteLine($"credentialsRight:{credentialsRight}");
                    Console.WriteLine("Welcome to our Sports Store");
                    if (credentialsRight == false)
                    {
                        Console.WriteLine("1. Log in to Profile (Existing Users)");
                    }
                    Console.WriteLine("2. Sign Up as a New User");
                    Console.WriteLine("3. Employees Log in Here");
                    Console.WriteLine("4. Select a Store");
                    Console.WriteLine("5. View our Store Inventory");
                    Console.WriteLine("6. Exit");
                    input = Console.ReadLine();

                    break;

                case "1":
                    Console.WriteLine("Log in to Profile (Existing Users) ");
                    // searching database for existing customers, by username and password
                    // ask for username and password from users
                    // search collection of users for authenticated existing users
                    // if credentials are wrong -> try again or do you want to sign up as new user
                    // if credentials are right -> user can view order history or order existing inventory
                    // user can select which store they want to browse
                    Console.WriteLine("Enter Existing Username");
                    existingUsername = Console.ReadLine();
                    Console.WriteLine("Enter your Password");
                    existingPassword = Console.ReadLine();

                    foreach (User existingUser in StaticStorage.GetAllUsers())
                    {
                        if (existingUsername == existingUser.Username && existingPassword == existingUser.Password)
                        {

                            credentialsRight = true;
                            break;
                        }
                    }
                    if (credentialsRight == true)
                    {
                        // you are logged in
                        Console.WriteLine("You Are Logged In");
                        input = "0";
                        // if credentials are right -> user can view order history or order existing inventory
                    }
                    else
                    {

                        // if credentials are wrong -> try again or do you want to sign up as new user
                        Console.WriteLine("Please Try Again");

                    }

                    break;

                case "2":
                    Console.WriteLine("Sign Up as a New User");
                    // prompt user to enter a username -> check the collection if username already exists -> return null
                    // if collections returns that same name, prompt user that name has already been taken and to create a different one
                    // if collections returns nulls, username does not exists and user can create a password
                    // save username and password in collection database
                    // redirect them to log-in page
                    Console.WriteLine("Enter a New Username");
                    string newUsername = Console.ReadLine();
                    Console.WriteLine("Create a New Password");
                    string newPassword = Console.ReadLine();
                    User newCustomer = new User
                    {
                        Username = newUsername,
                        Password = newPassword
                    };

                    StaticStorage.AddUser(newCustomer);
                    credentialsRight = true;
                    existingUsername = newUsername;
                    existingPassword = newPassword;
                    input = "0";


                    break;


                case "3":
                    Console.WriteLine("Employers and Employees Log in Here");
                    //prompt employee to enter their username -> search database for existing employees
                    //search collection of users for authenticated existing users
                    // if credentials are wrong -> tell user that credentials not found/ ask them to contact their company
                    // if credentials are right -> user can view store inventory, order inventory for store and customers,
                    // - continued from above - and view order histories for store and customers
                    Console.WriteLine("Enter Employee Username");
                    string empUsername = Console.ReadLine();
                    Console.WriteLine("Enter Employee Password");
                    string empPassword = Console.ReadLine();

                    foreach (User existingUser in StaticStorage.GetAllUsers())
                    {
                        Console.Write($"{existingUsername}");
                        if (existingUsername == existingUser.Username && existingPassword == existingUser.Password)
                        {

                            credentialsRight = true;
                            if (existingPassword.IndexOf("123", 2) > 0) { manager = true; } else { manager = false; }
                            Console.WriteLine($"{manager}");
                            break;
                        }
                    }
                    if (credentialsRight == true && manager == true)
                    {
                        // if credentials are right -> user can view order history or order existing inventory
                        ManagementMenu menu = new ManagementMenu(_bl);
                        menu.Start();
                    }
                    else
                    {

                        // if credentials are wrong -> try again or do you want to sign up as new user
                        Console.WriteLine("Please Try Again or Contact HR for Credentials");
                    }
                    break;


                // extend 4 and 5 for store selection
                case "4":
                    // List<Store> stores = new List<Store>();
                    allStores = _bl.GetAllStores();
                    Console.WriteLine("Please select a store to shop from \n");
                    if (allStores.Count > 0)
                    {
                        // for (int i = 0; i < stores.Count; i++)
                        // {
                        //     Console.WriteLine($"[{i}], StoreNumber: {StaticStorage.GetAllStores()[i].StoreNumber}" +
                        // $", StoreName: {StaticStorage.GetAllStores()[i].StoreName}, City: {StaticStorage.GetAllStores()[i].City}," +
                        // $"State: {StaticStorage.GetAllStores()[i].State}");
                        // }

                        foreach (Store store in allStores)
                        {
                            System.Console.WriteLine(store);
                        }
                    }

                    Console.ReadLine();
                    break;

                // option to view store inventory
                case "5":
                    Console.WriteLine("Welcome to Store Inventory. Please select a Store");

                    //For now, we can have a prefilled list of stores with inventories to stub data out until we get our DB going
                    allStores = _bl.GetAllStores();
                    Console.WriteLine($"{allStores.Count}");
                    for (int i = 0; i < allStores.Count; i++)
                    {
                        Console.WriteLine($"[{i}], {allStores[i].StoreName}");
                    }
                    string choice = Console.ReadLine();
                    int a = 0;    // int a used for tryparse below
                    bool res = false;  // used to check for true/false
                    res = Int32.TryParse(choice, out a);   //checks if string value is integer
                    if (res == true)   //it is numeric
                    {
                        Console.WriteLine($"You chose number {choice}, Please choose a Product");
                        // here the customer will browse inventory
                        int choiceInt = Int32.Parse(choice);
                        for (int i = 0; i < allStores[choiceInt].Inventories.Count; i++)
                        {
                            Console.WriteLine($"[{i}], {allStores[choiceInt].Inventories[i].ProductName}," +
                            $"\n {allStores[choiceInt].Inventories[i].Description}" +
                            $"\n {allStores[choiceInt].Inventories[i].Price}");
                        }
                        choice = Console.ReadLine();
                    }
                    else
                    {           // user types something other than number
                        Console.WriteLine("Invalid Input");
                    }


                    //later, i'm going to replace this with query to DB to get all stores
                    // for (int i = 1; i < allStores.Count; i++)
                    // {
                    //     Store storeToAdd = new Store();
                    //     storeToAdd.StoreName = "Store " + i;
                    //     storeToAdd.StoreID = i;
                    //     //storeToAdd.Inventories = new List<Inventory>();


                    //     for (int j = 0; j < 4; j++)
                    //     {
                    //         Product prod = new Product();
                    //         prod.ProductName = "Product " + j;
                    //         prod.Price = 9.99M;
                    //         prod.Description = "product " + j + " description";

                    //         Inventory inven = new Inventory();
                    //         inven.Item = prod;
                    //         inven.Quantity = 10;

                    //         //storeToAdd.Inventories.Add(inven);
                    //     }

                    //     allStores.Add(storeToAdd);
                    // }
                    //At the end of this loop, we should have 5 stores in our allStores List with 4 products in its inventory each


                    break;

                case "6":
                    exit = true;
                    Console.WriteLine("Thank you. Please come again.");

                    break;

                default:
                    Console.WriteLine("Please Enter a Number Between 1-6");
                    input = "0";
                    break;
            }
        }
        // end of start below
    }
}


