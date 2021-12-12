using StoreQA;

// Study Guide
string topic = "[Git and Shell Scripting]";
Console.WriteLine("Welcome to the {0} study guide! \nThis guide is built to learn definitions.", topic);

int qDone = 0; //How many Questions answered out of total

//int tLen = 4;
int[,] qCheckOff = new int[5,2];//Stores index list of questions, tracks what was already asked 0/1
int i; 
for (i = 1; i < 5; i++)//Second value non-inclusive
{
    qCheckOff[i,1]=0;
}

int nxtQ = 0; //Choose next question

int rand = 0;

while(qDone < 3)
{
    
    while(nxtQ == 0)//Keep looking for random numbers until value is set
    {
        
        Random randA = new Random();
        rand = randA.Next(1,4);
        if(qCheckOff[rand,1] == 0)
        {
            //Value was not used yet
            nxtQ = rand; //Set next question to this randomly selected value
            qCheckOff[rand,1] = 1;//Set this value in the question array to show it has already been asked
        }   
    }
    
    Console.WriteLine("Umm...");
    StoredQA getQ = new StoredQA(); //Make new question
    getQ.InitIt(); //Have question initialize variables and string values
    getQ.RandIt(); //Have question randomize question order
    getQ.whatQ = nxtQ; //Set what question the question will be
    Console.WriteLine("Q: "+getQ.Print());//Write question to screen
    

    qDone=3;


}//End While qDone loop

//Reset vars
qDone = 0;



