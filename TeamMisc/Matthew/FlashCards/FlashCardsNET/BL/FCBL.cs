namespace BL;
public class FCBL : IBL
{
    private IRepo _dl;

    public FCBL(IRepo repo)
    {
        _dl = repo;
    }

    //TOPICS

    /// <summary>
    /// Gets all Topics
    /// </summary>
    /// <returns></returns>
    public List<Topic> GetAllTopics()
    {
        return _dl.GetAllTopics();
    }

    /// <summary>
    /// Gets all Topics by index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Topic GetTopicByIndex(int index)
    {
        return _dl.GetTopicByIndex(index);
    }

    /// <summary>
    /// Add new topic
    /// </summary>
    /// <param name="topicToAdd"></param>
    public void AddTopic(Topic topicToAdd)
    {
        _dl.AddTopic(topicToAdd);
    }

    // public void TallyTopic(int topicId, decimal curAvg, decimal avg)
    // {
    //     _dl.TallyTopic(topicId, curAvg, avg);
    // }
    public void DestroyTopic(string topicName)
    {
        _dl.DestroyTopic(topicName);
    }

    public void OrderTopics()
    {
        _dl.OrderTopics();
    }

    //CARDS

    /// <summary>
    /// Gets all Cards
    /// </summary>
    /// <returns>list of all Cards</returns>
    public List<Card> GetAllCards()
    {
        return _dl.GetAllCards();
    }

    /// <summary>
    /// Returns a card by its index
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Card GetCardByIndex(int index)
    {
        return _dl.GetCardByIndex(index);
    }

    /// <summary>
    /// Adds a new Card to the list
    /// </summary>
    /// <param name="cardToAdd">Card object to add</param>
    public void AddCard(Card cardToAdd)
    {
        _dl.AddCard(cardToAdd);
    }

    /// <summary>
    /// Change card from study session
    /// </summary>
    /// <param name="cardId"></param>
    /// <param name="success"></param>
    // public void ChangeCard(int cardId, decimal success)
    // {
    //     _dl.ChangeCard(cardId, success);
    // }

    // public void TallyCard(int cardId, decimal avg)
    // {
    //     _dl.TallyCard(cardId,avg);
    // }

    public void DestroyCard(string topicName)
    {
        _dl.DestroyCard(topicName);
    }

    public void EditCard(Card cardInfo)
    {
        _dl.EditCard(cardInfo);
    }

    // public void CardScoreSet(Card set)
    // {
    //     _dl.CardScoreSet(set);
    // }


    //SCORES
    public List<Score> GetAllScores()
    {
        return _dl.GetAllScores();
    }

    public void TopicScoreSet(Score set)
    {
        _dl.TopicScoreSet(set);
    }

    public void AddScore(Score scoreToAdd)
    {
        _dl.AddScore(scoreToAdd);
    }

    public void ChangeScore(int scoreId, decimal success)
    {
        _dl.ChangeScore(scoreId, success);
    }

    public void TallyCardScore(int cardId, decimal avg)
    {
        _dl.TallyCardScore(cardId,avg);
    }

    public void TallyTopic(string topicName, decimal curAvg, decimal avg)
    {
        _dl.TallyTopic(topicName,curAvg,avg);
    }

    public void DestroyScore(string topicName)
    {
        _dl.DestroyScore(topicName);
    }

    //OMNI
    public void ChangeTopicName(string topName, string newName)
    {
        _dl.ChangeTopicName(topName,newName);
    }
}