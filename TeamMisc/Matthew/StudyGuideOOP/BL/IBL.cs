namespace BL;

public interface IBL
{
    // Subject SearchSubject(string searchString);

    List<Subject> GetAllSubjects();
    void AddSubject(Subject subjectToAdd);
    void RemoveSubject(Subject subToRemove);
    List<Question> GetAllQuestions();
    void AddQuestion(Question questionToAdd);
    void ChangeQuestion(int indexToChange, Question questionToChange);
    void RemoveQuestion(Question questToRemove);
}