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
        {exit = true;}//Return to main menu
    }


    //Edit Topic Menu
    while(!exit2){
    Console.WriteLine($"You chose topicIndex: {allTopic[topicIndex].Name} to edit\n<>--------------------------------------------------------------<>");// 
    Console.WriteLine($"[1] Make a list of all flashcards in the deck to choose which one to edit from");// 
    Console.WriteLine($"[2] Go through each question one by one");// 
    Console.WriteLine($"[delete] Type delete to permanently remove entire topic and all cards within it");// 
    Console.WriteLine($"[b] Return to main menu\n");// 

    choose = Console.ReadLine() ?? "";

    switch(choose)
    {
        case "1":
            MakeCardList(allTopic[topicIndex].Name);
        break;

        case "2":
            IterateThroughCards(allTopic[topicIndex].Name);
        break;

        case "delete":
            DeleteTopic(topicIndex);
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