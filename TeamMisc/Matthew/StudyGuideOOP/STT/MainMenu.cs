namespace UI;
public class MainMenu : IMenu {
private IBL _bl;

public MainMenu(IBL bl)
{
    _bl = bl;
}

public void Start() {
    bool exit = false;
    string choose = "";
    while(!exit)
    {
        List<Subject> allSubjects = _bl.GetAllSubjects();
        Console.WriteLine("Add a new study subject course or choose from an existing one: \n");
        Console.WriteLine("[a] Add new subject.\n");
        //Get list of subject
        if(allSubjects.Count > 0){
        for(int i = 0; i < allSubjects.Count; i++)
        {
            Console.WriteLine($"[{i}] {allSubjects[i].SubjectName}");
        }
        string? input = Console.ReadLine();
        }else{Console.WriteLine("There are no subjects available, press 'a' to add one...");}
        choose = Console.ReadLine();//First check for input "a"
        if(choose == "a")
        {
            //Make new subject!
            MenuFactory.GetMenu("makecourse").Start();
        }
        else
        {
            int selection;
            bool parseSuccess = Int32.TryParse(choose, out selection); //Check that input is an int
            if(parseSuccess && selection >= 0 && selection < allSubjects.Count)//Check that chosen int is in list range
            {
                //Launch the selected subject!
                MenuFactory.GetMenu("test").Start();
            }
            else{Console.WriteLine("Invalid input!");}
        }
        exit = true;
    }

}//End Start/Class
}