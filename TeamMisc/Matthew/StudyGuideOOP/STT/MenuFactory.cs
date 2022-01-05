using DL;

namespace UI;
public static class MenuFactory
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();
        //This is full dep injection
        // new SubjectMenu(new RRBL(new FileRepo())).Start();
        
        //Here, I instantiated an implementation of IRepo (FileRepo)
        IRepo repo = new FileRepo();
        //next, I instantiated TTBL (an implementation of IBL) and then injected IRepo implementation for IBL/RRBL
        IBL bl = new TTBL(repo);
        //Finally, I instantiate SubjectMenu that needs an instance that implements Business Logic class
        switch (menuString)
        {
            case "main":
                return new MainMenu(bl);
            
            case "test":
                return new Test(bl);
            
            case "makecourse":
                return new MakeCourse(bl);
            
            case "changecourse":
                return new ChangeCourse(bl);
            
            default:
                return new MainMenu(bl);
        }
    }
}