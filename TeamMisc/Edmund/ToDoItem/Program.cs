using ToDo;
using System.Collections.Generic;
bool exit = false;
List<ToDoItem> toDoList = new List<ToDoItem>();
do
{ 
Console.WriteLine("Welcome to ToDoList");
Console.Write("What would you like to do today?");
Console.Write("1. Create a new todo Item");
Console.Write("2. View my List");
Console.Write("3. Complete an Item");
Console.Write("x: Exit");
string input = Console.ReadLine();

// ToDoItem item = new ToDoItem();
// item.IsDone = false;
// item.Note = "Drink Coffee";

// Console.Write(item.Print());

// item.CompleteItem();

// Console.Write(item.Print());

switch(input)
{
    case "1":
        Console.WriteLine("Enter details for the new todo item");
        Console.Write("Item Note: ");
        string newNote = Console.ReadLine();

        ToDoItem newItem = new ToDoItem();
        newItem.IsDone = false;
        newItem.Note = newNote;

        toDoList.Add(newItem);
        Console.Write("You created the following item: ");
        Console.Write(newItem.Print());
        break;
    case "2":
        foreach(ToDoItem item in toDoList)
        {
            Console.Write(Item.Print());
        }
    break;
    case "3":
        Console.Write("Choose an item to complete");
        for(int i = 0; i < toDoList.Count; i++)
        {
            Console.Write($"[{i}] {toDoList[i].Print()}");
        }
        int selection = int.Parse(Console.ReadLine());
        itemToComplete.CompleteItem();
        Console.Write($"You completed {itemToComplete.Print()}");
    break;
    case "x":
        Console.Write(Goodbye!");
        exit = true;
    default:
        Console.Write("I'm not sure what that was");
        break;
    }
} while(!exit);
