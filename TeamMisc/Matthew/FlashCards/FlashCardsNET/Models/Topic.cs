namespace Models;
public class Topic
{

    //Empty constructor
    public Topic ()
    {
        this.OverallScore = new Queue<decimal>(); 
    }

    public Topic (int topicId, string name, decimal avg)
    {
        this.OverallScore = new Queue<decimal>(); 
        this.TopicId = topicId;
        this.Name = name;
        this.AvgScore = AvgScore;
    }

    //---------------------------------------------------------------------------\\
    //                                  Fields                                   \\
    //___________________________________________________________________________\\

    //A unique identifier for the Topic, not to be confused with the index in the list
    public int TopicId { get; set; } //[PK] Maybe redundant

    //Topic, the name of the Topic 
    public string? Name { get; set; } //Referenced by Card

    //Average rate of success over last five sessions. After finishing the Topic session the score is calculated
    public Queue<decimal> OverallScore { get; set; } //Average of all answer scores for this session going back five sessions

    public decimal AvgScore { get; set; }


}