namespace StoreQA;

public class StoredQA {

    //Empty Constructor
    public StoredQA() {}

    //this is called automatic property
    public int qOrder { get; set; } //What order this question will appear on the test
    public int whatQ { get; set; } //What question this is
    public bool used { get; set; }//This question was answered already
    string[,] q = new string[35,5];//2D array with 30 questions and 4 answers each    
    public int correct; //Which answer is the correct one
    int[] aOrder = new int[5];//Stores order of questions
    bool canSet = true;
    public bool error { get; set; }//If true, this question was answered wrong
    int i;
    int j;
    int k; //Help set string arrays
    public void InitIt () {
    //Default aOrder to 0
    if(this.canSet == true)
    {
        for (i = 1; i < 5; i++)
        { this.aOrder[i]=0;}
        this.canSet = false;

        //Storage of all questions and answers:
        k=1;
        this.q[k,0] = "What is .NET?"; 
        this.q[k,1] = ".NET is a free, open-source development platform for building many \nkinds of apps, such as console apps, web apps, games, etc\n"; 
        this.q[k,2] = ".NET is a open-source cloud based network for building search engines \nand a number of apps such as such as console apps, web apps, games, etc\n"; 
        this.q[k,3] = ".NET is system made by microsoft for programmers to access digital \nlibraries on a system 2.0 platform and query parsed data from json and xml.\n"; 
        this.q[k,4] = ".NET is a free, development platform that allows using a set of languages \ntogether to make programs that will convert xeno code to C type.\n";
        k=2;
        this.q[k,0] = "What is C#?"; 
        this.q[k,1] = "C# is a modern, object-oriented, and type-safe programming language."; 
        this.q[k,2] = "C# is the free edition version of C++ but has less features."; 
        this.q[k,3] = "C# is an old language used to make basic video games and websites mainly. It is still used today."; 
        this.q[k,4] = "C# is an amalgamation of VB .NET and C that results in a procedural language using a strong typing syntax.";
        k=3;
        this.q[k,0] = "What is OOP?"; 
        this.q[k,1] = "Object Oriented Programming"; this.q[k,2] = "Optimal Ontime Procedural"; 
        this.q[k,3] = "Objective Oriented Programming"; this.q[k,4] = "Object Ontime Programming";
        k=4;
        this.q[k,0] = "What is type safety?"; 
        this.q[k,1] = "The compiler will validate types either at run time or dynamically to show potential errors."; 
        this.q[k,2] = "When the user wraps their code in a try/catch to catch errors."; 
        this.q[k,3] = "Limiting what code the user can type when it will result in a stack overflow by deleting old lines of code."; 
        this.q[k,4] = "Type safety is the practice of maintining a proper posture and hand position when typing to avoid common wrist injuries.";
        k=5;
        this.q[k,0] = "What does separation of concerns mean?"; 
        this.q[k,1] = "The concept of organizing your code such that logic that follows a certain theme"; 
        this.q[k,2] = "The concept of making your code such that logic that follows a first in, first out logic"; 
        this.q[k,3] = "To write your code so that others can add to it without changing your work."; 
        this.q[k,4] = "Seperating team members into groups each with their own concern.";
        k=6;
        this.q[k,0] = "What are classes?"; 
        this.q[k,1] = "They are the blueprints to the actual objects that you process in your program"; 
        this.q[k,2] = "They combines different scripts to one project file"; 
        this.q[k,3] = "They write to the json file to keep changes to the methods and return an integer value."; 
        this.q[k,4] = "Classes are the folders that project files are stored within.";
        k=7;
        this.q[k,0] = "What are namespaces?"; 
        this.q[k,1] = "Allow you to utilize the classes located in a different namespace, use the using keyword"; 
        this.q[k,2] = "A namespace has no function other than to title a class for ease of organization."; 
        this.q[k,3] = "Namespaces introduced by .NET4 allow a script to encapsulate fragmented streams to an output."; 
        this.q[k,4] = "They allow you to send your files to another compiler even if it's in another language. This is polymorphism.";
        k=8;
        this.q[k,0] = "How many projects can be included in a solution?"; 
        this.q[k,1] = "All the related projects can be in the solution."; this.q[k,2] = "No more than 3."; 
        this.q[k,3] = "No more than 4"; this.q[k,4] = "Five projects total can be in a solution unless a project file contains no scripts.";
        k=9;
        this.q[k,0] = "What are projects?"; 
        this.q[k,1] = "A project contains all files that are compiled into an executable, library, or website."; 
        this.q[k,2] = "They are the blueprints to the actual objects that you process in your program"; 
        this.q[k,3] = "Final packaging of your application";  
        this.q[k,4] = "Projects are assignments that your teacher gives you, they are just an abstract concept."; 
        k=10;
        this.q[k,0] = "What is a data type?"; 
        this.q[k,1] = "Data types are what structures a program; "; 
        this.q[k,2] = "Data type refers to the language of code you are using: C#, C++, Java, F#, Etc.."; 
        this.q[k,3] = "Data type is the way in which data has been encapsulated to interface with abstract jsons."; 
        this.q[k,4] = "An event in which data has been typed either implicity or explicity, eg. Console.ReadLine();";
        k=11;
        this.q[k,0] = "What are the different data types in C#?"; 
        this.q[k,1] = "String, Number, Boolean, Array, Object, Date, Bytes, File, Null..."; 
        this.q[k,2] = "C#, C++, F#, Java, Python..."; 
        this.q[k,3] = "txt, cs, csproj, exe, json..."; 
        this.q[k,4] = "C# uses git bash, nano and vim as data types, but has others too.";
        k=12;
        this.q[k,0] = "Value types vs reference types?"; 
        this.q[k,1] = "Value types (Structs and Enums) store is Stack not Heap, \nReference types (class, string, delegate, array, interface, or record) are stored in Heap"; 
        this.q[k,2] = "Value types (class, string, delegate, array, interface, or record) store is Stack not Heap, \nReference types (Structs and Enums) are stored in Heap"; 
        this.q[k,3] = "Value types (Structs and Enums) store is Heap not Stack, \nReference types (class, string, delegate, array, interface, or record) are stored in Stack"; 
        this.q[k,4] = "Value types (Structs and string) store is Stack or heap, \nReference types (class, enums, delegate, array, interface, or record) are stored in heap only";
        k=13;
        this.q[k,0] = "What is the CTS?"; 
        this.q[k,1] = "Common Type System: standard definition of the types in .NET compliant languages."; 
        this.q[k,2] = "Common Type Syntax: special definition of the types in .NET core languages."; 
        this.q[k,3] = "C Type System: standard definition of the types in C type languages. (C, C#, C++, etc)"; 
        this.q[k,4] = "Common Tertiary System: standard definition of the types in .NET compliant languages after secondary languages.";
        k=14;
        this.q[k,0] = "What is language interoperability?"; 
        this.q[k,1] = "In one solution, your projects can be written in multiple .NET compliant language."; 
        this.q[k,2] = "In multiple solutions, your projects can be written in one .NET compliant language."; 
        this.q[k,3] = "In multiple solutions, your projects can be written in F# only."; 
        this.q[k,4] = "In one solution, your projects can be written in Fortran, still the best programming language.";
        k=15;
        this.q[k,0] = "What is the CLS? How is it related to the CTS?"; 
        this.q[k,1] = "Common Language Specification: a subset of CTS, It defines a set of rules and restrictions for .NET"; 
        this.q[k,2] = "Compile Language Sorting: It defines a set of rules and script length for .NET"; 
        this.q[k,3] = "Collaterial Library Signage: this is what is required for anything to run on .NET, it is free for download."; 
        this.q[k,4] = "Common Library Sorting: This takes all data from collections and sorts them for more efficient access.";
        k=16;
        this.q[k,0] = "What is an SDK?"; //
        this.q[k,1] = "Software Development Kit: includes everything you need to build and run .NET Core applications."; 
        this.q[k,2] = "Software Development Kit: An extra program that checks your code for a monthly fee, not recommended for begginers."; 
        this.q[k,3] = "Software Data Kit: A group of files shared on a server."; 
        this.q[k,4] = "SDK refers to Solution Data Kit and is an obsolete method of compiling code.";
        k=17;
        this.q[k,0] = "What’s the role of the CLR?"; 
        this.q[k,1] = "Common Language Runtime: runs the code and provides services that make the development process easier."; 
        this.q[k,2] = "Common Library Routine: saves the code and provides services that make the opening a process easier."; 
        this.q[k,3] = "Common Library Runtime: runs the library and provides services that make open the development process."; 
        this.q[k,4] = "Common Language Runtime: stores the code and provides services that make the compiler loop.";
        k=18;
        this.q[k,0] = "What’s the role of the BCL?"; 
        this.q[k,1] = "Base Class Library: provides classes and types that are helpful in performing day to day operations."; 
        this.q[k,2] = "Base Class Language: provides compile time resources and types that are helpful in performing fast operations."; 
        this.q[k,3] = "Base Class Language: provides classes and types that are used in post proessessing if they return null."; 
        this.q[k,4] = "Base Common Language: This is the language that the compiler natively uses, in the case of .NET it is C#.";
        k=19;
        this.q[k,0] = "What is managed code?"; 
        this.q[k,1] = "Code whose execution is managed by a runtime"; this.q[k,2] = "Code that the programmer must manage before \"dotnet run\"."; 
        this.q[k,3] = "Code that requires an administrator login to access."; this.q[k,4] = "Code that is connected to a VPN.";
        k=20;
        this.q[k,0] = "What is unmanaged code?"; 
        this.q[k,1] = "Code that is developed outside .NET and does not have memory management."; this.q[k,2] = "Code that is ready to compile."; 
        this.q[k,3] = "Code that doesn't require an administrator login to access."; this.q[k,4] = "Code that is not connected to a VPN.";
        k=21;
        this.q[k,0] = "What’s the garbage collection process?"; 
        this.q[k,1] = "It checks for objects in the managed heap that are no longer being used."; 
        this.q[k,2] = "When code that is unreachable is removed or commented out."; 
        this.q[k,3] = "When temp files are deleted after turning off your computer."; 
        this.q[k,4] = "Runs the code and provides services that make the development process easier.";
        k=22;
        this.q[k,0] = "What are collections?"; //
        this.q[k,1] = "A collection is a data structure that can hold one or more items"; this.q[k,2] = "All the lines of code in a script."; 
        this.q[k,3] = "A group of projects."; this.q[k,4] = "Everything that is stored into a json, but not in an XML.";
        k=23;
        this.q[k,0] = "What is the root interface of the collections hierarchy?"; 
        this.q[k,1] = "IEnumerable"; this.q[k,2] = "ICollection"; 
        this.q[k,3] = ".Interface"; this.q[k,4] = "IList<>";
        k=24;
        this.q[k,0] = "What is the IEnumerable for?"; 
        this.q[k,1] = "Exposes an enumerator. Supports a simple iteration over a non-generic/generic collection..."; 
        this.q[k,2] = "IEnumerable is for storing collections in to keep organized."; 
        this.q[k,3] = "Uses the IComparer interface to sort a string array."; 
        this.q[k,4] = "Defines methods to support the comparison of objects for equality.";
        k=25;
        this.q[k,0] = "Arrays vs ArrayList vs List<T>?"; 
        this.q[k,1] = "Arrays belong in the System namespace (Non generic), List<T> is a generic class. Regular Arrays are set with fixed length."; 
        this.q[k,2] = "Arrays belong in the System namespace (Generic), List<T> is a non generic class. Lists are set with fixed length."; 
        this.q[k,3] = "Arrays belong in the System namespace (Non generic), List<T> is a generic class. Array List are set with fixed length."; 
        this.q[k,4] = "Arrays belong in the System namespace (Generic), List<T> is a non generic class. Regular Arrays are set with fixed length.";
        k=26;
        this.q[k,0] = "What is a dictionary?"; 
        this.q[k,1] = "Represents a collection of key/value pairs that are organized based on the key."; 
        this.q[k,2] = "Used to list all value types in a .NET environment before compiling."; 
        this.q[k,3] = "A dictionary is for storing collections in to keep organized."; 
        this.q[k,4] = "A dictionary defines methods to support the comparison of objects for equality.";
        k=27;
        this.q[k,0] = "Stack vs queue?"; 
        this.q[k,1] = "A stack uses the LIFO method, while Queue uses FIFO"; this.q[k,2] = "The only difference is syntax, they are the same."; 
        this.q[k,3] = "Stack can overflow while queues are protected by their access modifier."; this.q[k,4] = "Stack is 32 bytes more than Queue.";
        k=28;
        this.q[k,0] = "What is serialization?"; //
        this.q[k,1] = "Process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file"; 
        this.q[k,2] = "Process of adding an object into a stream of bits to store the object in stack overflow memory, a nethub, or a directory"; 
        this.q[k,3] = "Process of compiling an object into a data-stream of megabytes to store the object in the heap memory."; 
        this.q[k,4] = "Process of converting a script into a stream of bytes to store the object or transmit it to a json.";
        k=29;
        this.q[k,0] = "What are some use cases of serialization?"; 
        this.q[k,1] = "Reading and writing to a Json or XML file."; 
        this.q[k,2] = "Adding a serial number to lines of code for easier reading."; 
        this.q[k,3] = "Initializes a new instance of the CollectionBase class."; 
        this.q[k,4] = "Allows the implementation of customized equality comparison for collections. ";
        k=30;
        this.q[k,0] = "What are exceptions? How are they different from errors?"; //
        this.q[k,1] = "Exceptions occur at runtime. They can be caught, errors cannot."; 
        this.q[k,2] = "Exceptions are created by the programmer to debug code, while errors are unexpected."; 
        this.q[k,3] = "Exceptions break the application but errors can be caught."; 
        this.q[k,4] = "Exceptions are from the ICollections system, while errors are non-generic.";
        k=31;
        this.q[k,0] = "Why handle exceptions?"; 
        this.q[k,1] = "To allow a program to continue without crashing and to detect exceptions for debugging."; 
        this.q[k,2] = "Because they will crash your computer if you don't handle them and delete all of your code."; 
        this.q[k,3] = "You don't have to handle them, the garbage collector does automatically."; 
        this.q[k,4] = "When your code has exceptions you need to handle them or errors will occur next.";
        k=32;
        this.q[k,0] = "How do you handle exceptions?"; 
        this.q[k,1] = "Exceptions are handled using a try-catch block."; 
        this.q[k,2] = "Exceptions are handled by closing and re-opening your IDE."; 
        this.q[k,3] = "Exceptions cannot be handled, only errors can."; 
        this.q[k,4] = "Exceptions are automatically handled.";
        k=33;
        this.q[k,0] = "Why throw exceptions?"; 
        this.q[k,1] = "To allow a catch statement to respond to the exception."; 
        this.q[k,2] = "To force the program to remove the errors at runtime.";
        this.q[k,3] = "To bypass the exception and return to the main script."; 
        this.q[k,4] = "To indicate that the method or property does not contain implementation.";
        k=34;
        this.q[k,0] = "What is the exception hierarchy?"; 
        this.q[k,1] = "To catch exceptions from the most specific derived class down to the most base."; 
        this.q[k,2] = "The order of exceptions from most important to least.";
        this.q[k,3] = "A compiler warning alerts you to any async methods that don't contain await statements, \nbecause that situation might indicate an error."; 
        this.q[k,4] = "The structure and flow of control between an async event handler";
        
    }
    }

    //Method
    //This method does not take arguments
    public void RandIt () 
    {
        int rand; 
        bool reTry = false;//Number already used, true=get another?
        //'this' keyword refers to paticular instance of the class
        //Set order of multiple choice questions to random
        for (i = 1; i < 5; i++)//Second number non-inclusive
        {   
            while(this.aOrder[i] == 0)//Keep looking for random numbers until value is set
            {
                reTry = false;
                //Console.WriteLine("Maybe after a while?"+i);
                Random randA = new Random();
                rand = randA.Next(1,5);//random 1 to 4
                //Go down and set all values in each array position
                for (j = 1; j < 5; j++)//Cycle second time to check arrays already set
                {  
                    if(this.aOrder[j] == rand)//Confirm value is not already used
                    {
                        reTry = true; //Value already taken break j loop
                    }
                }

                //Value was not used yet
                if(reTry == false)
                {
                    this.aOrder[i] = rand;
                    if(rand==1){this.correct=i;}//Store which answer the correct answer was moved to  
                } 
            }
        }
        //Console.WriteLine("aOrder[1]: {0}\naOrder[2]: {1}\naOrder[3]: {2}\naOrder[4]: {3}",
        //this.aOrder[1],this.aOrder[2],this.aOrder[3],this.aOrder[4]);
   
    }

    //Method signature: Access mod, return type, method name, parameters/arguments
    public string Print()
    {
        //return questions and multiple choices
        return $" {this.q[this.whatQ,0]}\n"+
        $"1.): {this.q[this.whatQ,this.aOrder[1]]}\n"+
        $"2.): {this.q[this.whatQ,this.aOrder[2]]}\n"+
        $"3.): {this.q[this.whatQ,this.aOrder[3]]}\n"+
        $"4.): {this.q[this.whatQ,this.aOrder[4]]}\n";
    }



}