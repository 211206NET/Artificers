using System.Text.Json;

namespace DL;

//This class reads and writes to the file
public class FileRepo : IRepo
{
    public FileRepo(){}

    //Subjects
    private string filePath = "../DL/Subjects.json";

    public List<Subject> GetAllSubjects()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return JsonSerializer.Deserialize<List<Subject>>(jsonString) ?? new List<Subject>();
    }

    // public Subject GetSubjectByIndex(int index)
    // {
    //     List<Subject> allSubjects = GetAllSubjects();
    //     return allSubjects[index];
    // }

    public void AddSubject(Subject restToAdd)
    {
        //First, we're going to grab all the Subjects from the file
        //Second, we'll deserialize as List<Subject>
        //Third, we'll use List's Add method to add our new Subject
        //Lastly, we'll serialize that List<Subject> and then write it to the file

        List<Subject> allSubjects = GetAllSubjects();
        allSubjects.Add(restToAdd);

        string jsonString = JsonSerializer.Serialize(allSubjects);
        File.WriteAllText(filePath, jsonString);
    }

    public void RemoveSubject(Subject subToRemove)
    {
        List<Subject> allSubjects = GetAllSubjects();
        allSubjects.Remove(subToRemove);
        string jsonString = JsonSerializer.Serialize(allSubjects);
        File.WriteAllText(filePath, jsonString);
    }

    //Questions
    private string filePathQ = "../DL/Questions.json";

    public List<Question> GetAllQuestions()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePathQ);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return JsonSerializer.Deserialize<List<Question>>(jsonString) ?? new List<Question>();
    }

    public void AddQuestion(Question questionToAdd)
    {
        List<Question> allQuestions = GetAllQuestions();
        allQuestions.Add(questionToAdd);

        string jsonString = JsonSerializer.Serialize(allQuestions);
        File.WriteAllText(filePathQ, jsonString);
    }

    public void ChangeQuestion(int indexToChange, Question questionToChange)
    {
        List<Question> allQuestions = GetAllQuestions();
        allQuestions[indexToChange] = questionToChange;

        string jsonString = JsonSerializer.Serialize(allQuestions);
        File.WriteAllText(filePathQ, jsonString);
    }

    public void RemoveQuestion(Question questToRemove)
    {
        List<Question> allQuestions = GetAllQuestions();
        allQuestions.Remove(questToRemove);
        string jsonString = JsonSerializer.Serialize(allQuestions);
        File.WriteAllText(filePathQ, jsonString);
    }
    
}