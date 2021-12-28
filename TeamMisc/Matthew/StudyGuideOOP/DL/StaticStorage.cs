namespace DL;
public class StaticStorage : IRepo
{
    private static List<Subject> _allSubjects = new List<Subject>();

    public List<Subject> GetAllSubjects()
    {
        return StaticStorage._allSubjects;
    }

    public void AddSubject(Subject SubjectToAdd)
    {
        StaticStorage._allSubjects.Add(SubjectToAdd);
    }

    private static List<Question> _allQuestions = new List<Question>();

    public List<Question> GetAllQuestions()
    {
        return StaticStorage._allQuestions;
    }

    public void AddQuestion(Question questionToAdd)
    {
        StaticStorage._allQuestions.Add(questionToAdd);
        //StaticStorage._allSubjects[SubjectIndex].Questions.Add(QuestionToAdd);
    }
}
