namespace Models;
public class Score
{

    //Empty constructor
    public Score ()
    {
        this.Success = new Queue<decimal>();
    }

    public Score (int cardId, string parentId, bool cardScore, decimal avg)
    {
        this.CardId = cardId;//For card
        this.ParentId = parentId;//For topic
        this.CardScore = cardScore;
        this.Success = new Queue<decimal>(); 
        this.AvgScore = avg;
    }

    public int CardId { get; set; } //If score for a card, store card Id

    public string ParentId { get; set; }

    public bool CardScore { get; set; } //True = score for card, false = score for topic

    //Average rate of success over last five sessions. After flipping the card the user chooses I was right, close, or I was wrong
    public Queue<decimal> Success { get; set; } //1 = pass question, 0.5 = partial credit, 0 = fail question, average shown above question

    public decimal AvgScore { get; set; }

}