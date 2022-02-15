namespace UI;
public class MainMenu : IMenu {
private IBL _bl;

public MainMenu(IBL bl)
{
    _bl = bl;
}

public void Start() {

bool exit = false; //Exit main loop


//First ensure each topic has a score json
// List<Score> allScores = _bl.GetAllScores();
// List<Topic> allTopic = _bl.GetAllTopics();


Console.WriteLine("Welcome to Flip Cards NET!\nTest your memory and study here.");

while(!exit)//Main Loop
{

//Main Menu 
Console.WriteLine("[1] Select a topic to study");
Console.WriteLine("[2] Build a new topic with topic building wizard");
Console.WriteLine("[3] Review a topic to update it");
Console.WriteLine("[x] Exit the program");

string? choose = Console.ReadLine();
switch(choose)
{
    //Select a topic
    case "1":
        MenuFactory.GetMenu("studyroom").Start();
    break;

    //Build a new topic
    case "2":    
        MenuFactory.GetMenu("maketopic").Start();
    break;

    //Update a topic
    case "3":
        MenuFactory.GetMenu("edittopic").Start();
    break;

    default:
        Console.WriteLine("Cya!");  
        exit = true;
    break;
}

}//End Main While loop
}//End Start
}//End class