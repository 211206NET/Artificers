namespace Models;
public class Topic
{

    //Empty constructor
    public Topic (){}

    public Topic (int topicId, string name)
    {
        this.TopicId = topicId;
        this.Name = name;
    }

    //---------------------------------------------------------------------------\\
    //                                  Fields                                   \\
    //___________________________________________________________________________\\

    //A unique identifier for the Topic, not to be confused with the index in the list
    public int TopicId { get; set; } //[PK] Maybe redundant

    //Topic, the name of the Topic 
    public string? Name { get; set; } //Referenced by Card

}