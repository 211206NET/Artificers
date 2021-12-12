namespace StoreQA;

public class StoredQA {

    //Empty Constructor
    public StoredQA() {}

    //this is called automatic property
    public int qOrder { get; set; } //What order this question will appear on the test
    public int whatQ { get; set; } //What question this is
    public bool used { get; set; }//This question was answered already
    string[,] q = new string[4,5];//2D array with 30 questions and 4 answers each    
    public int correct; //Which answer is the correct one
    int[] aOrder = new int[5];//Stores order of questions
    bool canSet = true;
    public bool error { get; set; }//If true, this question was answered wrong
    int i;
    int j;

    public void InitIt () {
    //Default aOrder to 0
    if(this.canSet == true)
    {
        for (i = 1; i < 5; i++)
        { this.aOrder[i]=0;}
        this.canSet = false;

        //Storage of all questions and answers:
        this.q[1,0] = "What is 1 plus 1?"; 
        this.q[1,1] = "2"; this.q[1,2] = "100"; 
        this.q[1,3] = "A"; this.q[1,4] = "Platypus";

        this.q[2,0] = "What are birds?"; 
        this.q[2,1] = "Animals that usually fly"; this.q[2,2] = "beefs"; 
        this.q[2,3] = "tires"; this.q[2,4] = "rockets";

        this.q[3,0] = "What is the Earth?"; 
        this.q[3,1] = "The Earth is our planet"; this.q[3,2] = "A cupcake"; 
        this.q[3,3] = "a sword"; this.q[3,4] = "just a myth";
        
    }
    }

    //Method
    //This method does not take arguments
    public void RandIt () 
    {
        int rand; 
        bool reTry = false;//Number already used, true=get another?
        //'this' keyword refers to paticular instance of the class
        //Set order of multiple choice questions to random
        for (i = 1; i < 5; i++)//Second number non-inclusive
        {   
            while(this.aOrder[i] == 0)//Keep looking for random numbers until value is set
            {
                Random randA = new Random();
                rand = randA.Next(1,5);//random 1 to 4
                //Go down and set all values in each array position
                for (j = 1; j < 5; j++)//Cycle second time to check arrays already set
                {  
                    if(this.aOrder[j] == rand)//Confirm value is not already used
                    {
                        reTry = true; //Value already taken break j loop
                    }
                }

                //Value was not used yet
                if(reTry == false)
                {
                    this.aOrder[i] = rand;
                    if(rand==1){this.correct=i;}//Store which answer the correct answer was moved to  
                } 
            }
        }
        Console.WriteLine("aOrder[1]: {0}\naOrder[2]: {0}\naOrder[3]: {0}\naOrder[4]: {0}\n",
        this.aOrder[1],this.aOrder[2],this.aOrder[3],this.aOrder[4]);
    }

    //Method signature: Access mod, return type, method name, parameters/arguments
    public string Print()
    {
        //return questions and multiple choices
        return $" {this.q[this.whatQ,0]}\n"+
        $"1.): {this.q[this.whatQ,this.aOrder[1]]}\n"+
        $"2.): {this.q[this.whatQ,this.aOrder[2]]}\n"+
        $"3.): {this.q[this.whatQ,this.aOrder[3]]}\n"+
        $"4.): {this.q[this.whatQ,this.aOrder[4]]}\n";
    }



}