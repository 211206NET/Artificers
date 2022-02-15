namespace UI;

public class MakeTopic : IMenu
{

private IBL _bl;

public MakeTopic(IBL bl) 
{
    //example of dependency injection
    _bl = bl;
}

public void Start()
{

bool exit = false; //To terminate main loop
while(!exit) //Main Loop
{

//Make Topic
Console.WriteLine("[1] Start building a new topic");
Console.WriteLine("[b] Exit to Main Menu");

string? choose = Console.ReadLine();
switch(choose)
{
    //Start to build
    case "1":
        BuildTopic();
    break;

    //Back to main
    case "b":
        exit = true;
    break;

    default:
        Console.WriteLine("Wrong input.");
    break;
}//End Switch

}//End Main While Loop
}//End Start

//Build the new topic
void BuildTopic()
{
    //Get list of topics and cards that already exist
    List<Topic> allTopics = _bl.GetAllTopics(); //TopicId, Name, OverallScore
    List<Card> allCards = _bl.GetAllCards(); //CardId, TopicName, Question, Answer, Used, Success
    bool exit = false; //For card add loop
    string? q = "";
    string? a = "";
    int makeCardId = 0;

    //Ask for input for topic name
    Console.WriteLine("Choose a name for the new topic");
    string? choose = Console.ReadLine();

    //Produce unique topic id
    int makeTopicId = 0;
    makeTopicId = allTopics.Count+1;
    foreach(Topic tp in allTopics)
    {
        //Input validation NoDuplicate Id or name
        if(tp.TopicId == makeTopicId){makeTopicId++;}

        while(tp.Name == choose)
        {
            Console.WriteLine("A topic with this name already exists, enter a new name:");
            choose = Console.ReadLine();
        }
    }

    //Add the new topic
    Topic makeTopic = new Topic{
        TopicId = makeTopicId,
        Name = choose,
        // OverallScore = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),
        // AvgScore = 0
    };
    _bl.AddTopic(makeTopic);

    Score scoreAdd = new Score{
        CardId = makeTopicId,
        ParentId = choose,
        CardScore = false,
        Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),//{}//(new int[] {0,0,0,0,0}) //(0,0,0,0,0)//{0,0,0,0,0}
        AvgScore = 0
    };
    _bl.AddScore(scoreAdd);

    while(!exit){
        //Ask for input for card
        Console.WriteLine("Enter a question for a card, or enter nothing to stop adding cards.");
        q = Console.ReadLine();
        if(q == "")
        {
            exit = true;
            break;
        }
        else
        { 
            while(a == "")
            {
                Console.WriteLine("Enter the answer for the question");
                a = Console.ReadLine();
            }     
        }

        //Produce unique topic id
        makeCardId = 0;
        makeCardId = allCards.Count+1;
        foreach(Card cd in allCards)
        {
            if(cd.CardId == makeCardId){makeCardId++;}
        }

        //Add the new card to the topic
        Card makeCard = new Card{
            CardId = makeCardId,
            TopicName = choose,
            Question = q,
            Answer = a,
            Used = false,
            // Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),//{}//(new int[] {0,0,0,0,0}) //(0,0,0,0,0)//{0,0,0,0,0}
            // AvgScore = 0
        };
        _bl.AddCard(makeCard);

        Score scoreAdd2 = new Score{
            CardId = makeCardId,
            ParentId = choose,
            CardScore = true,
            Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),//{}//(new int[] {0,0,0,0,0}) //(0,0,0,0,0)//{0,0,0,0,0}
            AvgScore = 0
        };
        _bl.AddScore(scoreAdd2);  
        
        q = "";
        a = "";
        allCards = _bl.GetAllCards();
    }

}//End Build Topic


}//End of Class

