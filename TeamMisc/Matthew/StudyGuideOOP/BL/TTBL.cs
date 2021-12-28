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

    public void AddSubject(Subject SubjectToAdd)
    {
        _dl.AddSubject(SubjectToAdd);
    }

    public void AddQuestion(Question questionToAdd)
    {
        _dl.AddQuestion(questionToAdd);
    }
}