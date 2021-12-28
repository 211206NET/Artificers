namespace UI;
public class Test : IMenu {
private IBL _bl;

public Test(IBL bl)
{
    _bl = bl;
}

public void Start() {
    bool exit = false;

    while(!exit)
    {
        Console.WriteLine("Test start");

        string? input = Console.ReadLine();

    }





}//End Start/Class
}