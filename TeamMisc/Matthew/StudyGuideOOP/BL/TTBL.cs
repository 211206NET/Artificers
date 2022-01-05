namespace BL;
public class TTBL : IBL
{
    private IRepo _dl;

    public TTBL(IRepo repo)
    {
        _dl = repo;
    }

    public List<Subject> GetAllSubjects()
    {
        return _dl.GetAllSubjects();
    }

    public void AddSubject(Subject subjectToAdd)
    {
        _dl.AddSubject(subjectToAdd);
    }
    public void RemoveSubject(Subject subToRemove)
    {
        _dl.RemoveSubject(subToRemove);
    }
    public List<Question> GetAllQuestions()
    {
        return _dl.GetAllQuestions();
    }

    public void AddQuestion(Question questionToAdd)
    {
        _dl.AddQuestion(questionToAdd);
    }

    public void ChangeQuestion(int indexToChange, Question questionToChange)
    {
        _dl.ChangeQuestion(indexToChange, questionToChange);
    }

    public void RemoveQuestion(Question questToRemove)
    {
        _dl.RemoveQuestion(questToRemove);
    }
}