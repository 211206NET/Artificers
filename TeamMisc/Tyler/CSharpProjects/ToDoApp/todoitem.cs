namespace ToDo;

//This is a class, Class = blueprint for obj
//It's a data type, has members
//1. Constructor - this special method creates obj with 'shape'
//2. Fields - hold values that pertains to class
//3. Properties - wrapper around fields to make more secure
//4. Methods - define behaviors (fns that belong in class)
//classes have access modifiers - controls access to paticular class
//public - anyone can access class
public class ToDoItem {

    //Empty Constructor
    public ToDoItem() {}

    //this is called automatic property
    public bool IsDone { get; set; }
    public string Note { get; set; }

    //Method
    //This method does not take arguments
    public void CompleteItem () {
        //'this' keyword refers to paticular instance of the class
        this.IsDone = true; //Only job is to set this obj to true
    }

    //Method signature: Access mod, return type, method name, parameters/arguments
    public string Print()
    {
        //return "Done" + this.IsDone + " Note: " + this.Note; //Same
        return $"Note: {this.Note} Done: {this.IsDone}";
    }


}