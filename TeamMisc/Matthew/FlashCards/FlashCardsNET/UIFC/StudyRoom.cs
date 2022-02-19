

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
List<Score> allScores = _bl.GetAllScores();
bool exit = false; //To terminate main loop
int topicIndex = -1;
bool siegeMode = false; //Only show questions that have a score below 80
while(!exit) //Main Loop
{
    allTopic = _bl.GetAllTopics();
    allCards = _bl.GetAllCards();
    allScores = _bl.GetAllScores();
    //Study menu
    Console.WriteLine("Choose a topic from the list, to 'b' to exit");
    decimal getScore = 0.0m;
    decimal getCardScore = 0.0m;
    bool makeIt = false;
    for(int i = 0; i < allTopic.Count; i++){
        //Get score
        for(int j = 0; j < allScores.Count; j++){
            if(allScores[j].ParentId == allTopic[i].Name)
            {getScore = Math.Round(allScores[j].AvgScore*100,0);}
        }
        //Show Topic Choice
        Console.WriteLine($"[{i}] {allTopic[i].Name}, Score: {getScore}/100");
        //Check Topic has score
        if(allScores.Count > 0)
        {
            //Check all scores
            if(allScores[allTopic[i].TopicId] != null)
            {
                //Console.WriteLine("Found score");
            }
            else
            {makeIt = true; Console.WriteLine("Didn't find score");}
        }
        else
        {
            //If not found make
            makeIt = true;
        }

        if(makeIt){
            Score scoreAdd = new Score{
                CardId = allTopic[i].TopicId,
                ParentId = allTopic[i].Name,
                CardScore = false,
                Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),
                AvgScore = 0
            };
            _bl.AddScore(scoreAdd);
            makeIt = false;
        }
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

        //Get score for card
        // for(int j = 0; j < allScores.Count; j++){
        //     if(allScores[j].ParentId == allCards[sI].TopicName)
        //     {}
        // }
        if(allScores.Count > 0 && allScores[sI] != null){getCardScore = Math.Round(allScores[sI].AvgScore*100,0);}
        else
        {
            //Add new Score entry
            Score scoreAdd = new Score{
                CardId = allCards[sI].CardId,
                ParentId = allCards[sI].TopicName,
                CardScore = true,
                Success = new Queue<decimal>(new decimal[] { 0, 0, 0, 0, 0 }),//{}//(new int[] {0,0,0,0,0}) //(0,0,0,0,0)//{0,0,0,0,0}
                AvgScore = 0
            };
            _bl.AddScore(scoreAdd);
            getCardScore = 0;
        }

        if(allCards[sI].TopicName == allTopic[topicIndex].Name && (siegeMode == false || (siegeMode == true && getCardScore < 0.8m))){
        
        Console.WriteLine("-------------------------------------------------------------------------------------");
        Console.WriteLine($"Question: {allCards[sI].Question}\n");
        Console.WriteLine($"\tTake time to answer the question from memory, press anything to flip the card. Current score: {getCardScore}\n");
        Console.ReadLine();
        Console.WriteLine($"Answer: {allCards[sI].Answer}\n");
        
        Console.WriteLine("\tHow did you do? 'a' = perfect, 'b' = good, 'c' = ok, 'd' = not so well, 'f' = need to study\n");
        
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
        _bl.ChangeScore(allCards[sI].CardId, studySuccess);
        //allCards = _bl.GetAllCards(); //DEBUG
        }

    }//End Study Session

    //Tally score
    decimal runningAvg = 0; decimal whatPeek = 0; decimal totalRunning = 0; int cardsInDeck = 0;
    Queue<decimal> dumpQueue;
    foreach(Score cardScore in allScores)
    {
        //Each card
        if(cardScore.ParentId == allTopic[topicIndex].Name && (siegeMode == false || (siegeMode == true && cardScore.AvgScore < 0.8m))){
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
        _bl.TallyCardScore(cardScore.CardId, runningAvg);
        //Console.WriteLine($"totalRunning: {runningAvg}"); //DEBUG
        totalRunning += runningAvg;
        runningAvg = 0;
        }
    }

    //Console.WriteLine($"cardsInDeck: {cardsInDeck}, allTopic[topicIndex].TopicId: {allTopic[topicIndex].TopicId}"); //DEBUG
    //Finalize average for deck this session
    //Console.WriteLine($"totalRunning: {totalRunning}, cardsInDeck: {cardsInDeck}"); //DEBUG
    if(cardsInDeck>0){totalRunning = Math.Round(totalRunning/cardsInDeck, 2);}else{totalRunning = 1;}
    //Console.WriteLine($"totalRunning after calc: {totalRunning}"); //DEBUG

    //Return average overall score for this deck
    //Tally score

    //pass pk/fk to score
    int passInt = allTopic[topicIndex].TopicId;
    //Console.WriteLine($"passInt: {passInt}");
    //Console.ReadLine();
    if(allScores.Count > 0){
    dumpQueue = allScores[passInt].Success; //Setting Queue to queue
    
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
    _bl.TallyTopic(allTopic[topicIndex].Name, Math.Round(totalRunning,2), Math.Round(runningAvg,2));

    }//End check scores exist

    //Reset
    cardsInDeck = 0;

    Console.WriteLine("Finished!\n");



}//End Main While Loop
}//End Start
}//End of Class