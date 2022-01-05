namespace Models;
public class Question
{
    public int SubjectID { get; set; } //What subject this questions belongs to
    public string? ConceptWalk { get; set; } //A brief explanation fo the current concept

    //public string[,] QA { get; set; } //Store data of questions and answers, DOESN'T JSON WELL

    public string? Q1 { get; set; }
    public string? Q2 { get; set; }
    public string? Q3 { get; set; }
    public string? A1 { get; set; }
    public string? A2 { get; set; }
    public string? A3 { get; set; }

}