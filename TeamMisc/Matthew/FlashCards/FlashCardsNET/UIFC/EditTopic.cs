namespace UI;

public class EditTopic : IMenu
{

private IBL _bl;

public EditTopic(IBL bl) 
{
    //example of dependency injection
    _bl = bl;
}


public void Start()
{

List<Topic> allTopic = _bl.GetAllTopics();
List<Card> allCards = _bl.GetAllCards();
bool exit = false; //To terminate main loop
bool exit2 = true; //To exit nested loop
int topicIndex = -1;
bool goodToGo = false; //If choices entered is ok

while(!exit) //Main Loop
{
    goodToGo = false;
    allTopic = _bl.GetAllTopics();
    allCards = _bl.GetAllCards();
    //Study topic to edit
    Console.WriteLine("Choose a topic from the list, or 'b' to exit");
    for(int i = 0; i < allTopic.Count; i++){

        //Show Topic Choice
        Console.WriteLine($"[{i}] {allTopic[i].Name}");
    }

    string choose = Console.ReadLine() ?? "";//User input choice

    bool res = false; int a = 0; //Check that an integer was entered
    res = Int32.TryParse(choose, out a);
    if(res)
    {
        topicIndex = Int32.Parse(choose);

        //Validate choice
        if(allTopic.Count >= topicIndex+1){goodToGo = true;}

        if(goodToGo == true)
        {
            exit2 = false; //Proceed
        }
    }
    else
    {
        if(choose != "b")
        {
            Console.WriteLine("Invalid input"); //Wrong input
        }
        else
        {exit = true; break;}//Return to main menu
    }

    string topName = allTopic[topicIndex].Name ?? "";
    //Edit Topic Menu
    while(!exit2){
    Console.WriteLine($"You chose topicIndex: {topName} to edit\n<>--------------------------------------------------------------<>");// 
    Console.WriteLine($"[1] Make a list of all flashcards in the deck to choose which one to edit from");// 
    Console.WriteLine($"[2] Go through each question one by one");// 
    Console.WriteLine($"[3] Add cards to topic");// 
    Console.WriteLine($"[4] Reset score of topic and all cards to 0");// 
    Console.WriteLine($"[5] Set score of topic and all cards to 1 (mark as finished)");// 
    Console.WriteLine($"[delete] Type delete to permanently remove entire topic and all cards within it");// 
    Console.WriteLine($"[b] Return to main menu\n");// 

    choose = Console.ReadLine() ?? "";

    switch(choose)
    {
        case "1":
            MakeCardList(topName);
        break;

        case "2":
            IterateThroughCards(topName);
        break;

        case "3":
            AddMoreCards(topName);
        break;

        case "4":
            SetTopicScore(topName, 0);
        break;

        case "5":
            SetTopicScore(topName, 1);
        break;

        case "delete":
            DeleteTopic(topicIndex);
            exit2 = true;
        break;

        case "b":
            exit = true;
            exit2 = true;
        break;

        default:
            Console.WriteLine("Wrong Input.");
        break;
    }

    }//End Exit 2 check loop



}//End Main While Loop


}//End Start

void MakeCardList(string topNameVar)
{
    List<Topic> allTopic = _bl.GetAllTopics();
    List<Card> allCards = _bl.GetAllCards();
    int cardIndex = -1;
    string? keepQuestion = "";
    string? keepAnswer = "";
    Console.WriteLine("\n");
    for(int i = 0; i < allCards.Count; i++){
        //Show Card Choice
        if(allCards[i].TopicName == topNameVar){
        Console.WriteLine($"[{i}] ----------------------------------------------------------<"+
        $"\nQ: {allCards[i].Question}\nA: {allCards[i].Answer}");}
    }
    string choose = Console.ReadLine() ?? "";    
    bool res = false; int a = 0; //Check that an integer was entered
    res = Int32.TryParse(choose, out a);
    if(res)
    {
        cardIndex = Int32.Parse(choose);
    }
    else
    {
        Console.WriteLine("Wrong input, returning to previous menu.");
    }

    //A valid choice was made
    if(cardIndex> -1)
    { 
        keepQuestion = allCards[cardIndex].Question;
        keepAnswer = allCards[cardIndex].Answer;
        Console.WriteLine($"Retype the question or enter nothing to skip changes to question."+
        $"\nQ: {allCards[cardIndex].Question}");
        choose = Console.ReadLine() ?? "";
        if(choose != "")
        {
            //Change was made to question
            keepQuestion = choose;
        }

        Console.WriteLine($"Retype the answer or enter nothing to skip changes to answer."+
        $"\nA: {allCards[cardIndex].Answer}");
        choose = Console.ReadLine() ?? "";
        if(choose != "")
        {
            //Change was made to answer
            keepAnswer = choose;
        }

        //Save changes
        Card saveCard = new Card{
            CardId = allCards[cardIndex].CardId,
            Question = keepQuestion,
            Answer = keepAnswer
        };
        _bl.EditCard(saveCard);
    }

}

void IterateThroughCards(string topNameVar)
{
    List<Card> allCards = _bl.GetAllCards();
    string? keepQuestion = "";
    string? keepAnswer = "";
    string? choose = "";

    foreach(Card cardy in allCards)
    {
        if(cardy.TopicName == topNameVar){
        //Make changes to card
        keepQuestion = cardy.Question;
        keepAnswer = cardy.Answer;
        Console.WriteLine($"Retype the question or enter nothing to skip changes to question."+
        $"\nQ: {cardy.Question}");
        choose = Console.ReadLine() ?? "";
        if(choose != "")
        {
            //Change was made to question
            keepQuestion = choose;
        }

        Console.WriteLine($"Retype the answer or enter nothing to skip changes to answer."+
        $"\nA: {cardy.Answer}");
        choose = Console.ReadLine() ?? "";
        if(choose != "")
        {
            //Change was made to answer
            keepAnswer = choose;
        }

        //Save changes
        Card saveCard = new Card{
            CardId = cardy.CardId,
            Question = keepQuestion,
            Answer = keepAnswer
        };
        _bl.EditCard(saveCard);
        }//End check deck
    }//End loop

}

void AddMoreCards(string topNameVar)
{
    //Add a new card to topic
    List<Card> allCards = _bl.GetAllCards();
    string? choose = "";
    bool exit = false;
    string? q = "";
    string? a = "";
    int deckCount = 1;
    //Get Deck Count
    foreach(Card countCard in allCards){deckCount++;}

    while(!exit){
        
        foreach(Card countCard in allCards)
        {if(countCard.CardId == deckCount){deckCount++;}}//Again loop to check Id is unique

        Console.WriteLine("Enter a new question for card");
        q = Console.ReadLine();
        Console.WriteLine("Enter an answer for the question you just made");
        a = Console.ReadLine();

        //Add the new card to the topic
        Card cardAdd = new Card{
            CardId = deckCount,
            TopicName = topNameVar,
            Question = q,
            Answer = a,
            Used = false
        };
        _bl.AddCard(cardAdd);

        Score scoreAdd = new Score{
            CardId = deckCount,
            ParentId = topNameVar,
            CardScore = true,
            Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),//{}//(new int[] {0,0,0,0,0}) //(0,0,0,0,0)//{0,0,0,0,0}
            AvgScore = 0
        };
        _bl.AddScore(scoreAdd);

        Console.WriteLine($"[y/n] Make another card for this topic {topNameVar}?");
        choose = Console.ReadLine();
        if(choose != "y"){exit = true;}
    }

}

void SetTopicScore(string topNameVar, int score)
{
    // List<Topic> allTopic = _bl.GetAllTopics();
    // List<Card> allCards = _bl.GetAllCards();
    List<Score> allScores = _bl.GetAllScores();
    
    Score tp = new Score
    {
        ParentId = topNameVar,
        Success = new Queue<decimal>(new decimal[] { score, score, score, score, score }),
        AvgScore = score
    };
    
    _bl.TopicScoreSet(tp);
    Console.WriteLine($"Score for {topNameVar} set to {score}");
}

void DeleteTopic(int topIndex)
{
    List<Topic> allTopic = _bl.GetAllTopics();
    string nameTarget = allTopic[topIndex].Name ?? "";
    Console.WriteLine($"[y/n] Are you sure you want to delete the whole topic {nameTarget}?");
    string chooseD = Console.ReadLine() ?? "";
    switch(chooseD)
    {
        case "y":
            Console.WriteLine($"{nameTarget} has been removed.");
            _bl.DestroyTopic(nameTarget);
            _bl.DestroyCard(nameTarget);
            _bl.DestroyScore(nameTarget);
        break;

        case "n":
            Console.WriteLine("Returning to previous menu.");
        break;

        default:
            Console.WriteLine("You don't seem to be sure, returning to previous menu.");
        break;
    }

    Console.WriteLine("\n");
}




}//End of Class