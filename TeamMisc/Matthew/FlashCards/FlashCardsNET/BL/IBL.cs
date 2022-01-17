namespace BL;

public interface IBL
{
 
    //Topics
    List<Topic> GetAllTopics();
    Topic GetTopicByIndex(int index);
    void AddTopic(Topic topicToAdd);
    void TallyTopic(int topicId, decimal curAvg, decimal avg);
    void DestroyTopic(string topicName);
    void TopicScoreSet(Topic set);


    //Cards
    List<Card> GetAllCards();
    Card GetCardByIndex(int index);
    void AddCard(Card cardToAdd);
    void ChangeCard(int cardId, decimal success);
    void TallyCard(int cardId, decimal avg);
    void DestroyCard(string topicName);
    void EditCard(Card cardInfo);
    void CardScoreSet(Card set);

}