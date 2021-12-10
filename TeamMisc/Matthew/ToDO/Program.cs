using ToDo; //import namespace
using System.Collections.Generic; //Holds list collections

//To Do List
Console.WriteLine("To do:");

bool exit = false; //To exit loop
//Instantiating list of todo items
List<ToDoItem> toDoList = new List<ToDoItem>();

do{
//Ask what to do
Console.WriteLine("What task do you want to add?\n1: Create new todo item\n2: View List\n3: Complete item\nx: to exit");
//Take Input
string input = Console.ReadLine();

switch(input)
{
    case "1":
        Console.WriteLine("Enter details for new item");
        Console.WriteLine("Item Note: ");
        string newNote = Console.ReadLine(); //Take user input
        ToDoItem doItem = new ToDoItem(); //Create new obj
        doItem.Note = newNote;            //Set note data on obj to user input
        doItem.Difficulty = ((toDoList.Count)*100).ToString(); //Make each new task a harder difficulty base don how many in list
        Console.WriteLine("Show difficulty: {0}", doItem.Difficulty);
        toDoList.Add(doItem); 
        Console.WriteLine("You made this item: ");
        Console.WriteLine(doItem.Print());
        break;
    case "2":
        foreach(ToDoItem item in toDoList)
        {    
            Console.WriteLine(item.Print());
        }
        break;
    case "3":

        Console.WriteLine("Choose item to complete");
        //Show list with index
        for(int i = 0; i < toDoList.Count; i++)
        {
            Console.WriteLine($"[{i}] {toDoList[i].Print()}");
        }
        int selection = int.Parse(Console.ReadLine());
        //Console.WriteLine($"You picked {toDoList[selection].Print()}");
        toDoList[selection].CompleteItem();
        Console.WriteLine("You completed {0}",toDoList[selection].Print());
        break;
    case "x":
        Console.WriteLine("Bye");
        exit = true;
        break;
    default:
        Console.WriteLine("Please choose 1,2,3 or x");
        break;
}
}while(!exit);
// //New to do item Instantiate
// ToDoItem item = new ToDoItem();
// //Assign values to instance
// item.IsDone = false;
// item.Note = "Eat Lunch";

// Console.WriteLine(item.Print()); //Using class method

// //See list

// //Mark item done
// item.CompleteItem();

// Console.WriteLine(item.Print());
