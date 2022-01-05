namespace UI;
public class ChangeCourse : IMenu {
private IBL _bl;

public ChangeCourse (IBL bl)
{
    _bl = bl;
}

public void Start() {
//Allow user to review the course contents and make changes to it

bool exit = false;
string? choose = "";
int subjectToEdit = -1;
int subjectId = -1;
int questionIndex = -1;
bool keepGoing = true; //To keep checking a concept or go to next one
bool exit2 = false; //To loop through questions on a subject
int sameID = 0;
string? newCW = ""; string? newQ1 = ""; string? newQ2 = ""; string? newQ3 = ""; string? newA1 = ""; string? newA2 = ""; string? newA3 = "";
while(!exit)
{

List<Subject> allSubjects = _bl.GetAllSubjects();
List<Question> allQuestions = _bl.GetAllQuestions();
List<int> questionsThis = new List<int>(); //List of indexes of questions on this subject, to loop through questions later
Console.WriteLine("Choose what subject you want to change"); //Count > 0 already checked prior to this class called
for(int i = 0; i < allSubjects.Count; i++)
{
    Console.WriteLine($"[{i}] {allSubjects[i].SubjectName}");
}
choose = Console.ReadLine();
int selection;
bool parseSuccess = Int32.TryParse(choose, out selection); //Check that input is an int
if(parseSuccess && selection >= 0 && selection < allSubjects.Count)//Check that chosen int is in list range
{
    //Select the subject to edit
    subjectToEdit = Int32.Parse(choose ?? "");
}
else{Console.WriteLine("Invalid input!");}

//Loop through all change requests
while(!exit2){

//Return Subject Id
for(int i = 0; i < allSubjects.Count; i++)
{
    subjectId = allSubjects[subjectToEdit].Id;
}

//Console.WriteLine($"questionIndex: {questionIndex} allQuestions.Count: {allQuestions.Count}, subjectId: {subjectId}");
//Return question index
//foreach(Question quest in allQuestions)
if(allQuestions.Count > 0){
for(int i = 0; i < allQuestions.Count; i++)
{
    if(allQuestions[i].SubjectID == subjectId)
    {
        questionsThis.Add(i); //Add the int to the list
        //questionIndex = i;
        //break;
    }
}
if(questionsThis.Count>0){questionIndex = questionsThis[0];}//Thread the needle with first question

//First store default values so skipping doesn't save 0 values to json
sameID = allQuestions[questionIndex].SubjectID; newCW = allQuestions[questionIndex].ConceptWalk;
newQ1 = allQuestions[questionIndex].Q1; newQ2 = allQuestions[questionIndex].Q2; newQ3 = allQuestions[questionIndex].Q3;
newA1 = allQuestions[questionIndex].A1; newA2 = allQuestions[questionIndex].A2; newA3 = allQuestions[questionIndex].A3;
}

//Subject chosen
if(subjectToEdit > -1)
{
    Console.WriteLine($"You have chosen {allSubjects[subjectToEdit].SubjectName} to review and edit.");

    //Decide to change or add
    Console.WriteLine("[a] add new concept to subject");
    Console.WriteLine("[e] edit the existing concepts of subject");
    Console.WriteLine("[x] escape to main menu.");
    choose = Console.ReadLine(); //Input to retype of concept, skip, or delete whole concept

    //Add a new concept
    if(choose == "x")
    {
        exit = true; exit2 = true; break;
    }

    if(choose == "a")
    {
        int qAon = 0; //What out of three QA the user is on. 0 = Q1, 1 = Q2
        while(qAon < 3){
            if(qAon == 0){Console.WriteLine($"Add your question number {qAon+1} for the current concept:");
            newCW = Console.ReadLine();}

            Console.WriteLine($"Add your question number {qAon+1} for the current concept:");
            if(qAon == 0){newQ1 = Console.ReadLine();}
            if(qAon == 1){newQ2 = Console.ReadLine();}
            if(qAon == 2){newQ3 = Console.ReadLine();}

            Console.WriteLine($"Add your one word number to question {qAon+1}:");
            if(qAon == 0){newA1 = Console.ReadLine();}
            if(qAon == 1){newA2 = Console.ReadLine();}
            if(qAon == 2){newA3 = Console.ReadLine();}
            qAon++;
        }
    }
    else
    {

    while(questionIndex < questionsThis.Count-1){

    //if(questionsThis.Count>0){questionIndex = questionsThis[0];}//Thread the needle with first question
    //Start changing a concept
    Console.WriteLine("Each concept will show you the concept walk, then each answer and question.\n"+
    "Retype the string to replace the existing string."+
    "[\"\"] Just press enter with no input to make no changes.\n"+
    "[del] to remove the whole concept from the subject."+
    "[x] to stop making changes to subject and return to main menu.");
    Console.WriteLine($"{allQuestions[questionIndex].ConceptWalk} \n[type 'del' to remove this concept from the subject]");
    choose = Console.ReadLine(); //Input to retype of concept, skip, or delete whole concept
    switch(choose)
    {
        case "del":
            //Delete concept
            _bl.RemoveQuestion(allQuestions[questionIndex]);
            keepGoing = false;
        break;

        case "":
            //Skip concept and leave as is
            keepGoing = true;
        break;

        case "x":
            //Stop making changes to the subject
            exit = true;
            keepGoing = false;
        break;

        default:
            //Replace concept string
            newCW = choose;
            keepGoing = true;
        break;
    }
    
    if(keepGoing)//Keep checking the rest of the concept questions and answers
    { 
        Console.WriteLine($"{allQuestions[questionIndex].Q1} \n[type new question or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of question, or skip
        if(choose != ""){newQ1 = choose;} choose = "";
        Console.WriteLine($"{allQuestions[questionIndex].A1} \n[type new answer or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of answer, or skip
        if(choose != ""){newA1 = choose;} choose = "";
        Console.WriteLine($"{allQuestions[questionIndex].Q2} \n[type new question or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of question, or skip
        if(choose != ""){newQ2 = choose;} choose = "";
        Console.WriteLine($"{allQuestions[questionIndex].A2} \n[type new answer or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of answer, or skip
        if(choose != ""){newA2 = choose;} choose = "";
        Console.WriteLine($"{allQuestions[questionIndex].Q3} \n[type new question or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of question, or skip
        if(choose != ""){newQ3 = choose;} choose = "";
        Console.WriteLine($"{allQuestions[questionIndex].A3} \n[type new answer or leave blank to skip]");
        choose = Console.ReadLine(); //Input to retype of answer, or skip
        if(choose != ""){newA3 = choose;} choose = "";

        keepGoing = false;
    }
        questionIndex += 1;
        Console.WriteLine($"questionIndex: {questionIndex}, questionsThis.Count-1: {questionsThis.Count-1}");
    }//End while loop through all questions of a concept
        

    }//End change concept
    
    //Save changes to Questions
    Question newQuestion = new Question {
        SubjectID = sameID,
        ConceptWalk = newCW,
        Q1 = newQ1,
        Q2 = newQ2,
        Q3 = newQ3,
        A1 = newA1,
        A2 = newA2,
        A3 = newA3
    };

    if(choose != "a"){_bl.ChangeQuestion(sameID, newQuestion); if(questionIndex > questionsThis.Count-1){exit2 = true;}}
    if(choose == "a"){_bl.AddQuestion(newQuestion);}
}

}//End exit 2

exit = true;
}//End main exit while loop
}//End Start/Class
}