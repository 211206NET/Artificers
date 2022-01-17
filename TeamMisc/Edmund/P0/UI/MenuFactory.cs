using DL;
using BL;
using Models;

namespace UI;

public static class MenuFactory
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();


        //next, I instantiated RRBL (an implementation of IBL) and then injected IRepo implementation for IBL/RRBL
        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);

        IBL bl = new SBL(repo);

        //Finally, I instantiate RestaurantMenu that needs an instance that implements Business Logic class
        switch (menuString)
        {
            case "main":
                return new MainMenu(bl);

            case "management":
                return new ManagementMenu(bl);

            default:
                return new MainMenu(bl);
        }
    }
}