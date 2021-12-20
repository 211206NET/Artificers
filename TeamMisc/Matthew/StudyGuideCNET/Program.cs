using StoreQA;

// Study Guide
string topic = "[Git and Shell Scripting]";
Console.WriteLine("\nWelcome to the {0} study guide! \nThis guide is built to learn definitions.\n\n", topic);

int qDone = 0; //How many Questions answered out of total

//int tLen = 4;
int[,] qCheckOff = new int[35,2];//Stores index list of questions, tracks what was already asked 0/1
int i; 
for (i = 1; i < 35; i++)//Second value non-inclusive
{
    qCheckOff[i,1]=0;
}

int goodA = 0; //Answered correctly
int badA = 0; //Answered Incorrectly

int nxtQ = 0; //Choose next question
int rand = 0;
string input; //Player answer
int rightA;

while(qDone < 34)
{
    while(nxtQ == 0)//Keep looking for random numbers until value is set
    {
        Random randA = new Random();
        rand = randA.Next(1,35);
        if(qCheckOff[rand,1] == 0)
        {
            //Value was not used yet
            nxtQ = rand; //Set next question to this randomly selected value
            qCheckOff[rand,1] = 1;//Set this value in the question array to show it has already been asked
        }   
    }
    
    StoredQA getQ = new StoredQA(); //Make new question
    getQ.InitIt(); //Have question initialize variables and string values
    getQ.RandIt(); //Have question randomize question order
    getQ.whatQ = nxtQ; //Set what question the question will be
    Console.WriteLine("Q: "+getQ.Print());//Write question to screen
    rightA = getQ.correct; //Get correct answer location of questions

    //User input
    input = Console.ReadLine();
    switch(input)
    {
        case "1":
            if(rightA == 1)
            {
                Console.WriteLine("Correct!\n"); goodA++;
            }
            else
            {
                Console.WriteLine("Incorrect.\n"); badA++;
            }
            break;
        case "2":
            if(rightA == 2)
            {
                Console.WriteLine("Correct!\n"); goodA++;
            }
            else
            {
                Console.WriteLine("Incorrect.\n"); badA++;
            }
            break;
        case "3":
            if(rightA == 3)
            {
                Console.WriteLine("Correct!\n"); goodA++;
            }
            else
            {
                Console.WriteLine("Incorrect.\n"); badA++;
            }
            break;
        case "4":
            if(rightA == 4)
            {
                Console.WriteLine("Correct!\n"); goodA++;
            }
            else
            {
                Console.WriteLine("Incorrect.\n"); badA++;
            }
            break;
        default:
            break;
    }

    qDone+=1;
    nxtQ = 0; //Reset for next question
    input = "";
}//End While qDone loop

Console.WriteLine("You answered {0} question(s) correctly\nYou answered {1} incorrectly.",goodA,badA);





