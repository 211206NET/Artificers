﻿namespace Models;
public class Card
{

    //Empty constructor
    public Card (){}

    public Card (int cardId, string topicName, string question, string answer, bool used)
    {
        this.CardId = cardId;
        this.TopicName = topicName;
        this.Question = question;
        this.Answer = answer;
        this.Used = used;
    }

    //---------------------------------------------------------------------------\\
    //                                  Fields                                   \\
    //___________________________________________________________________________\\

    //A unique identifier for the card, not to be confused with the index in the list
    public int CardId { get; set; } //[PK]

    //Topic, what topic this question fits into, this card will show up in that topic study session
    public string? TopicName { get; set; } //[FK: Topic.Name]

    //What intially shows up on a card, question to user
    public string? Question { get; set; } 

    //What the cards shows on the answer side after flipped
    public string? Answer { get; set; }

    //If this card has been used during the current practice session yet (used to order cards avoiding dupes)
    public bool Used { get; set; } //Set back to false for all cards after practice session order is established




}
