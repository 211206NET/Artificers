using System.Text.Json;

namespace DL;

//This class reads and writes to the file
public class FileRepo : IRepo
{
    public FileRepo()
    { }

    //=================== TOPICS
    private string filePathT = "../DL/Topics.json";
    
    /// <summary>
    /// Gets all topics
    /// </summary>
    /// <returns>List of topics</returns>
    public List<Topic> GetAllTopics()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePathT);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return JsonSerializer.Deserialize<List<Topic>>(jsonString) ?? new List<Topic>();
    }

    /// <summary>
    /// Returns topic by index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Topic GetTopicByIndex(int index)
    {  
        List<Topic> allTopics = GetAllTopics();
        return allTopics[index];
    }

    /// <summary>
    /// Add a new topic
    /// </summary>
    /// <param name="topicToAdd"></param>
    public void AddTopic(Topic topicToAdd)
    {
        //First, we're going to grab all the Topics from the file
        //Second, we'll deserialize as List<Topic>
        //Third, we'll use List's Add method to add our new Topic
        //Lastly, we'll serialize that List<Topic> and then write it to the file

        List<Topic> allTopics = GetAllTopics();
        allTopics.Add(topicToAdd);

        string jsonString = JsonSerializer.Serialize(allTopics);
        File.WriteAllText(filePathT, jsonString);
    }

    //For changes done at end of study session
    public void TallyTopic(int topicId, decimal curAvg, decimal avg)
    {
        List<Topic> allTopics = GetAllTopics();
        foreach(Topic topico in allTopics)
        {
            if(topico.TopicId == topicId)
            {
                topico.OverallScore.Dequeue(); //Remove an old result
                topico.OverallScore.Enqueue(curAvg);
                topico.AvgScore = avg;
                break;
            }
        }

        string jsonString = JsonSerializer.Serialize(allTopics);
        File.WriteAllText(filePathT, jsonString);
    }

    //Removes topic
    public void DestroyTopic(string topicName)
    {
        List<Topic> allTopics = GetAllTopics();
        for(int i = allTopics.Count-1; i > -1; i--)
        {
            if(allTopics[i].Name == topicName)
            {
                allTopics.Remove(allTopics[i]);
            }
        }

        string jsonString = JsonSerializer.Serialize(allTopics);
        File.WriteAllText(filePathT, jsonString);
    }

    //Set the topic to a score
    public void TopicScoreSet(Topic set)
    {
        List<Topic> allTopics = GetAllTopics();
        for(int i = allTopics.Count-1; i > -1; i--)
        {
            if(allTopics[i].Name == set.Name)
            {
                allTopics[i].OverallScore = set.OverallScore;
                allTopics[i].AvgScore = set.AvgScore;
            }
        }

        string jsonString = JsonSerializer.Serialize(allTopics);
        File.WriteAllText(filePathT, jsonString);
    }




    //===================  CARDS
    private string filePath = "../DL/Cards.json";

    /// <summary>
    /// Gets all Cards from a file
    /// </summary>
    /// <returns>List of all Cards</returns>
    public List<Card> GetAllCards()
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

        return JsonSerializer.Deserialize<List<Card>>(jsonString) ?? new List<Card>();
    }

    /// <summary>
    /// Finds and returns Card by its index in the list
    /// </summary>
    /// <param name="index">index to search Card for</param>
    /// <returns>Card object</returns>
    public Card GetCardByIndex(int index)
    {
        List<Card> allCards = GetAllCards();
        return allCards[index];
    }

    /// <summary>
    /// Adds a Card to the list and then writes to a file
    /// </summary>
    /// <param name="cardToAdd">Card object to be added</param>
    public void AddCard(Card cardToAdd)
    {
        //First, we're going to grab all the Cards from the file
        //Second, we'll deserialize as List<Card>
        //Third, we'll use List's Add method to add our new Card
        //Lastly, we'll serialize that List<Card> and then write it to the file

        List<Card> allCards = GetAllCards();
        allCards.Add(cardToAdd);

        string jsonString = JsonSerializer.Serialize(allCards);
        File.WriteAllText(filePath, jsonString);
    }

    //For changes done during study session
    public void ChangeCard(int cardId, decimal success)
    {
        List<Card> allCards = GetAllCards();
        foreach(Card cardo in allCards)
        {
            if(cardo.CardId == cardId)
            {
                //Shift old scores
                //crd.Success.Peek();
                cardo.Success.Dequeue();//Remove oldest element from Queue
                //Console.WriteLine($"cardo.Success.Count: {cardo.Success.Count}, cardo.CardId: {cardo.CardId}, cardId: {cardId}"); //DEBUG
                cardo.Used = true; 
                cardo.Success.Enqueue(success);
                //cardo.Success = success;
                // for(int i = 0; i < 6; i++)
                // {
                //     cardo.Success[i] = success[i];
                // }
                // cardo.Success[0] = success[0];
                // cardo.Success[1] = success[1];
                // cardo.Success[2] = success[2];
                // cardo.Success[3] = success[3];
                // cardo.Success[4] = success[4];
                break;
            }
        }

        string jsonString = JsonSerializer.Serialize(allCards);
        File.WriteAllText(filePath, jsonString);
    }

    //For changes done at end of study session
    public void TallyCard(int cardId, decimal avg)
    {
        List<Card> allCards = GetAllCards();
        foreach(Card cardo in allCards)
        {
            if(cardo.CardId == cardId)
            {
                cardo.AvgScore = avg;
                break;
            }
        }

        string jsonString = JsonSerializer.Serialize(allCards);
        File.WriteAllText(filePath, jsonString);
    }

    //Removes card from deck one by one when deleteing a topic
    public void DestroyCard(string topicName)
    {
        List<Card> allCards = GetAllCards();
        for(int i = allCards.Count-1; i > -1; i--)
        {
            if(allCards[i].TopicName == topicName)
            {
                allCards.Remove(allCards[i]);
            }
        }

        string jsonString = JsonSerializer.Serialize(allCards);
        File.WriteAllText(filePath, jsonString);
    }

    //For changes done to update a topic's questions
    public void EditCard(Card cardInfo)
    {
        List<Card> allCards = GetAllCards();
        foreach(Card cardo in allCards)
        {
            if(cardo.CardId == cardInfo.CardId)
            {
                cardo.Question = cardInfo.Question;
                cardo.Answer = cardInfo.Answer;
                break;
            }
        }

        string jsonString = JsonSerializer.Serialize(allCards);
        File.WriteAllText(filePath, jsonString);
    }

    //Set the card to a score
    public void CardScoreSet(Card set)
    {
        List<Card> allcards = GetAllCards();
        for(int i = allcards.Count-1; i > -1; i--)
        {
            if(allcards[i].TopicName == set.TopicName)
            {
                allcards[i].Success = set.Success;
                allcards[i].AvgScore = set.AvgScore;
            }
        }

        string jsonString = JsonSerializer.Serialize(allcards);
        File.WriteAllText(filePath, jsonString);
    }

    
}