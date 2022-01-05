namespace UI;
public class MakeCourse : IMenu {
private IBL _bl;

public MakeCourse(IBL bl)
{
    _bl = bl;
}

public void Start() {


    bool exit = false;
    string? inputName = ""; //Name of the subject that all questions will fall under
    string? inputConceptWalk = ""; //Add a description of the subject will all data/keywords the user needs to know
    const int Q = 3; //Subjects will have three questions/answers each
    //JSON doesn't like it
    //string[,] qA = new string[4, 2]; //String array to store QA recording from test maker, array length is fixed, so no need for a List<>
    string? q1 = ""; string? q2 = ""; string? q3 = ""; string? a1 = ""; string? a2 = ""; string? a3 = "";

while(!exit)
{
    //Name Course
    Console.WriteLine("Start to make new course!\n");
    Console.WriteLine("Add a name for your new course:");
    inputName = Console.ReadLine();

    int id = 0;
    List<Subject> allSubjects = _bl.GetAllSubjects();
    if(allSubjects.Count > 0){id = allSubjects.Count;}else{id = 0;}
    //Save changes to Subject
    Subject newSubject = new Subject {
        Id = id,
        SubjectName = inputName,
        LastScore = 0,
        HighScore = 0
    };
    _bl.AddSubject(newSubject);

    //Build Concept
    bool addQuestionExit = false;
    while(!addQuestionExit){

    Console.WriteLine("Add the concept walk (mini-lecture) that explains your concept in one or two sentences.\n"+
    "Questions will be based on this and the one word answer for each question will be from this as well.\n"+
    "Think of the answers as the bullet points you want to remember to jog your memory in a QA interview scenario.\n");
    inputConceptWalk = Console.ReadLine();
    if(inputConceptWalk == "x"){addQuestionExit = true; exit = true; break;}//Done adding concepts

    int qAon = 0; //What out of three QA the user is one. 0 = Q1, 1 = Q2
    while(qAon < 3){
        Console.WriteLine($"Add your question number {qAon+1} for the current concept:");
        if(qAon == 0){q1 = Console.ReadLine();}
        if(qAon == 1){q2 = Console.ReadLine();}
        if(qAon == 2){q3 = Console.ReadLine();}
        //qA[qAon,0] = Console.ReadLine();
        Console.WriteLine($"Add your one word number to question {qAon+1}:");
        if(qAon == 0){a1 = Console.ReadLine();}
        if(qAon == 1){a2 = Console.ReadLine();}
        if(qAon == 2){a3 = Console.ReadLine();}
        //qA[qAon,1] = Console.ReadLine();
        qAon++;
    }

    //Save changes to Questions
    Question newQuestion = new Question {
        SubjectID = id,
        ConceptWalk = inputConceptWalk,
        Q1 = q1,
        Q2 = q2,
        Q3 = q3,
        A1 = a1,
        A2 = a2,
        A3 = a3
    };
    //QA = qA  NOPE
    _bl.AddQuestion(newQuestion);
    }

}





}//End Start/Class
}