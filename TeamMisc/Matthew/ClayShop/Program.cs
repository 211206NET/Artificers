//Clay Shop! Matthew Wiese: P0
Console.WriteLine("Welcome to the plasticine clay shop.\n" +
"Here we have the best clay for claymation.");

// - Workflow of Viewing StoreFront Inventory
// 1. I want to hide this functionality unless they're logged in
//     - Check if they're logged in or not
//     - Have currentCustomer set to a default, that will be null before 
        //they log in (So once they 'login', the current customer is not 
        //null, and has current customer info)
//     - And then once I know that it's not null, then I'll display this menu

// 2. Prompt the user to log in (if they haven't)
//     - I need to go back to the log in menu (of a sort)
//     - And then give them log in screen again

// 3. Prompt them to select which storefront to browse
//     - First, I need to grab all storefronts
//     - Iterate through the stores and display them
//     - Once they select the storefront, save it somewhere so I can query the inventory 
        //of the store

// 4. Once they select a storefront, query the inventory of the storefront
//     a. Find all inventory that belongs to the storefront
//     b. Then iterate through that list and display the inventory accordingly

// 5. Display the storefront inventory with (its quantity, maybe?)
bool exit = false;
int pos = 0; //Position, where the user is currently in the application

while(!exit)
{

    switch(pos)
    {
        //Login
        case 0:
            Console.WriteLine("Login Here: (Place holder: Enter any value to continue)");
            Console.ReadLine();
            pos = 1;
        break;

        //Select Store
        case 1:
            Console.WriteLine("Choose which store you want: (Place holder: Enter any value to continue)");
            Console.ReadLine();
            pos = 2;
        break;

        //Store Main Menu
        case 2:
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.) View Clays");//1.)
            Console.WriteLine("2.) View Professional Clay Tools");//2.) 
            Console.WriteLine("3.) View Claymation Studio Accessories");//3.) 
            Console.WriteLine("4.) Return to Store Selection");//4.) 
            Console.WriteLine("x.) Exit");//x.) 

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    //View Clays
                    pos = 3;
                break;
                case "2":
                    //View Tools
                    pos = 4;
                break;
                case "3":
                    //View Studio Equipment
                    pos = 5;
                break;
                case "4":
                    //Return to Store Selection
                    pos = 1;
                break;
                case "x":
                    //Exit App
                    exit = true;
                break;
                default:
                    Console.WriteLine("Please enter 1,2,3,4 or x");
                break;
        }//End Check pos == 2 (Main Menu)
        break;

        //Display Clay Inventory
        case 3:
            Console.WriteLine("Clay Inventory");
            pos = 2; //Return to main Menu
        break;

        //Display Tool Inventory
        case 4:
            Console.WriteLine("Tool Inventory");
            pos = 2; //Return to main Menu
        break;

        //Display Studio Equipment Inventory
        case 5:
            Console.WriteLine("Studio Equipment Inventory");
            pos = 2; //Return to main Menu
        break;

        //Display Clay Product Info
        case 6:
            Console.WriteLine("Clay Product Info");
            pos = 2; //Return to main Menu
        break;

        //pos var is set wrong
        default:
            Console.WriteLine("ERROR: pos is set to invalid value somehow");
            pos = 2; //Return to main Menu
        break;

    }//End Master Case

}