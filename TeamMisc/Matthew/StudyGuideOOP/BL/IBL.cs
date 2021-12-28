namespace BL;

public interface IBL
{
    // Subject SearchSubject(string searchString);

    List<Subject> GetAllSubjects();

    void AddSubject(Subject SubjectToAdd);

    void AddQuestion(Question questionToAdd);
}