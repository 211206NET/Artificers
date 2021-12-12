using ToDo; 
using System.Collections.Generic; 

//To Do List
Console.WriteLine("To do:");

bool exit = false; 

List<ToDoItem> toDoList = new List<ToDoItem>();

do{
Console.WriteLine("What's on the agenda?"); 
Console.WriteLine("1: Create a new todo item");
Console.WriteLine("2: View List");
Console.WriteLine("3: Complete an item");
Console.WriteLine("x: to exit");
string input = Console.ReadLine();

switch(input)
{
    case "1":
        Console.WriteLine("Enter details for new item");
        Console.WriteLine("Item Note: ");
        string newNote = Console.ReadLine(); 
        
        ToDoItem doItem = new ToDoItem(); 
        doItem.Note = newNote;            

        toDoList.Add(doItem); 
        Console.WriteLine("New created item: ");
        Console.WriteLine(doItem.Print());
        break;
    case "2":
        foreach(ToDoItem item in toDoList)
        {    
            Console.WriteLine(item.Print());
        }
        break;
    case "3":

        Console.WriteLine("Choose an what to complete");

        for(int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"[{i}] {toDoList[i].Print()}");
        }
        int selection = int.Parse(Console.ReadLine());

        toDoList[selection].CompleteItem();
        Console.WriteLine("You completed {0}",toDoList[selection].Print());
        break;
    case "x":
        Console.WriteLine("Good Bye!");
        exit = true;
        break;
    default:
        Console.WriteLine("Please choose 1,2,3 or x");
        break;
}
}while(!exit);