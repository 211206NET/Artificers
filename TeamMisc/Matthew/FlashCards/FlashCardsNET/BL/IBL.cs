namespace BL;

public interface IBL
{
 
    //Topics
    List<Topic> GetAllTopics();
    Topic GetTopicByIndex(int index);
    void AddTopic(Topic topicToAdd);
    //void TallyTopic(int topicId, decimal curAvg, decimal avg);
    void DestroyTopic(string topicName);
    void OrderTopics();


    //Cards
    List<Card> GetAllCards();
    Card GetCardByIndex(int index);
    void AddCard(Card cardToAdd);
    //void ChangeCard(int cardId, decimal success);
    //void TallyCard(int cardId, decimal avg);
    void DestroyCard(string topicName);
    void EditCard(Card cardInfo);
    //void CardScoreSet(Card set);

    //Scores
    List<Score> GetAllScores();
    void TopicScoreSet(Score set);
    void AddScore(Score scoreToAdd);
    void ChangeScore(int scoreId, decimal success);
    void TallyCardScore(int cardId, decimal avg);
    void TallyTopic(string topicName, decimal curAvg, decimal avg);
    void DestroyScore(string topicName);

    //Omni
    void ChangeTopicName(string topName, string newName);

}