

namespace UI;

public class StudyRoom : IMenu
{

private IBL _bl;

public StudyRoom(IBL bl) 
{
    //example of dependency injection
    _bl = bl;
}


public void Start()
{

List<Topic> allTopic = _bl.GetAllTopics();
List<Card> allCards = _bl.GetAllCards();
bool exit = false; //To terminate main loop
int topicIndex = -1;
bool siegeMode = false; //Only show questions that have a score below 80
while(!exit) //Main Loop
{
    allTopic = _bl.GetAllTopics();
    allCards = _bl.GetAllCards();
    //Study menu
    Console.WriteLine("Choose a topic from the list, to 'b' to exit");
    for(int i = 0; i < allTopic.Count; i++){
        //Show Topic Choice
        Console.WriteLine($"[{i}] {allTopic[i].Name}, Score: {Math.Round(allTopic[i].AvgScore*100,0)}/100");
    }

    string choose = Console.ReadLine() ?? "";//User input choice

    bool res = false; int a = 0; //Check that an integer was entered
    res = Int32.TryParse(choose, out a);
    if(res)
    {
        topicIndex = Int32.Parse(choose);
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

    //Prep the test:
    //Put cards in random order
    int[] testOrder = new int[allCards.Count]; //Make an int array the length of the cards stack

    //C# seems to lack a shuffle method because some dude in stack overflow decided nobody needed one
    //I will build my own here
    var rand = new Random();
    bool put = false; int randHold = 0;
    //Console.WriteLine($"testOrder.Length: {testOrder.Length}"); //DEBUG
    for(int i = 0; i < testOrder.Length; i++)
    {
        //Console.WriteLine($"put: {put}"); //DEBUG
        while(!put)
        {
            randHold = rand.Next(1, testOrder.Length);
            if(testOrder[randHold] == 0){testOrder[randHold] = i; put = true; 
            //Console.WriteLine($"i: {i}, testOrder: {testOrder[randHold]}, randHold: {randHold}"); //DEBUG
            }
        }
        put = false;
    }

    
    //Set Siege Mode!
    siegeMode = false;
    Console.WriteLine("[y/n] Do you only want to focus on cards that you scored less than 80 on?");
    choose = Console.ReadLine() ?? "";
    if(choose == "y")
    {siegeMode = true;}

    decimal studySuccess = 0;
    bool gradeGood = false; int sI = 0;
    //Study time!  topicIndex  by testOrder
    //foreach(Card crd in allCards)
    for(int i = 0; i < testOrder.Length; i++)
    {
        sI = testOrder[i]; //First random number in random array
        if(allCards[sI].TopicName == allTopic[topicIndex].Name && (siegeMode == false || (siegeMode == true && allCards[sI].AvgScore < 0.8m))){

        Console.WriteLine($"\nQuestion: {allCards[sI].Question}\n");
        Console.WriteLine($"Take time to answer the question from memory, press anything to flip the card. Current score: {allCards[sI].AvgScore}\n");
        Console.ReadLine();
        Console.WriteLine($"Answer: {allCards[sI].Answer}\n");
        
        Console.WriteLine("How did you do? 'a' = perfect, 'b' = good, 'c' = ok, 'd' = not so well, 'f' = need to study\n");
        
        string? grade = "";

        while(!gradeGood)
        {
            grade = Console.ReadLine() ?? "";
            switch(grade)
            {
                case "a":
                    studySuccess = 1; gradeGood = true;
                break;

                case "b":
                    studySuccess = 0.75m; gradeGood = true;
                break;

                case "c":
                    studySuccess = 0.5m; gradeGood = true;
                break;

                case "d":
                    studySuccess = 0.25m; gradeGood = true;
                break;

                case "f":
                    studySuccess = 0; gradeGood = true;
                break;
                
                default:
                    Console.WriteLine("That was not a letter grade, try again");
                break;
            }
        }

        //Console.WriteLine($"crd.CardId: {crd.CardId}, studySuccess: {studySuccess}"); //DEBUG
        //Update card with changes
        gradeGood = false;
        //Console.WriteLine($"crd.Success.Count: {crd.Success.Count}, crd.CardId: {crd.CardId}"); //DEBUG
        //Console.ReadLine(); //DEBUG
        //crd.Success.Dequeue(); //DEBUG
        //Console.WriteLine($"crd.Success.Count: {crd.Success.Count}, crd.CardId: {crd.CardId}"); //DEBUG
        //Console.ReadLine(); //DEBUG
        _bl.ChangeCard(allCards[sI].CardId, studySuccess);
        //allCards = _bl.GetAllCards(); //DEBUG
        }

    }//End Study Session

    //Tally score
    decimal runningAvg = 0; decimal whatPeek = 0; decimal totalRunning = 0; int cardsInDeck = 0;
    Queue<decimal> dumpQueue;
    foreach(Card cardScore in allCards)
    {
        //Each card
        if(cardScore.TopicName == allTopic[topicIndex].Name && (siegeMode == false || (siegeMode == true && cardScore.AvgScore < 0.8m))){
            cardsInDeck += 1;
            dumpQueue = cardScore.Success;
            //Console.WriteLine($"dumpQueue.Count: {dumpQueue.Count}, cardScore.CardId: {cardScore.CardId}, cardScore.Success.Count: {cardScore.Success.Count}"); //DEBUG
            for(int i = 0; i < 5; i++)
            {
                //Console.WriteLine($"i: {i}"); //DEBUG
                whatPeek = dumpQueue.Peek(); //No more queue empty exceptions!!!!!!!!!!
                runningAvg += whatPeek;
                dumpQueue.Dequeue();
            }
            runningAvg = (runningAvg/5); //Set the average score for the card

        //Add card to deck stats
        _bl.TallyCard(cardScore.CardId, runningAvg);
        //Console.WriteLine($"totalRunning: {runningAvg}"); //DEBUG
        totalRunning += runningAvg;
        runningAvg = 0;
        }
    }

    //Console.WriteLine($"cardsInDeck: {cardsInDeck}, allTopic[topicIndex].TopicId: {allTopic[topicIndex].TopicId}"); //DEBUG

    //Finalize average for deck this session
    
    //Console.WriteLine($"totalRunning: {totalRunning}, cardsInDeck: {cardsInDeck}"); //DEBUG
    if(cardsInDeck>0){totalRunning = Math.Round(totalRunning/cardsInDeck, 2);}else{totalRunning = 1;}
    //Console.WriteLine($"totalRunning: {totalRunning}"); //DEBUG

    //Return average overall score for this deck
    //Tally score

    dumpQueue = allTopic[topicIndex].OverallScore; //Setting Queue to queue


    //Console.WriteLine($"allTopic[topicIndex].OverallScore.Count: {allTopic[topicIndex].OverallScore.Count}"); //DEBUG
    //Console.ReadLine(); //DEBUG

    for(int i = 0; i < 5; i++)
    {
        whatPeek = dumpQueue.Peek();
        //Console.WriteLine($"i: {i}, whatPeek: {whatPeek}"); //DEBUG
        runningAvg += whatPeek;
        dumpQueue.Dequeue();
    }
    
    //Console.WriteLine($"runningAvg: {runningAvg}"); //DEBUG
    runningAvg = ((totalRunning+runningAvg)/6); //Set the average score for the card
        

    //Add card to deck stats
    _bl.TallyTopic(allTopic[topicIndex].TopicId, Math.Round(totalRunning,2), Math.Round(runningAvg,2));
   
    //Reset
    cardsInDeck = 0;

    Console.WriteLine("Finished!\n");





}//End Main While Loop
}//End Start
}//End of Class