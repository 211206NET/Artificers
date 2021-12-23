using Models;
using DL;

namespace UI;

public class ManagementMenu
{
public void Start(){

bool exit= false;
string input = "0";

while(!exit)
{
    switch (input)
    {
        case "0":
        Console.WriteLine("Employer Menu");
        Console.WriteLine("1. Add Store");
        Console.WriteLine("2. Add New Inventory");

    // view customer and store's order history 
        Console.WriteLine("3. Manage Existing Inventory");
        Console.WriteLine("4. Exit");
        input = Console.ReadLine();

        break;
    }
}

//end of class and start brackets
}}
