namespace StoreQA;

public class StoredQA {

    //Empty Constructor
    public StoredQA() {}

    //this is called automatic property
    public int qOrder { get; set; } //What order this question will appear on the test
    public int whatQ { get; set; } //What question this is
    public bool used { get; set; }//This question was answered already
    string[,] q = new string[31,5];//2D array with 30 questions and 4 answers each    
    public int correct; //Which answer is the correct one
    int[] aOrder = new int[5];//Stores order of questions
    bool canSet = true;
    public bool error { get; set; }//If true, this question was answered wrong
    int i;
    int j;
    int k; //Help set string arrays
    public void InitIt () {
    //Default aOrder to 0
    if(this.canSet == true)
    {
        for (i = 1; i < 5; i++)
        { this.aOrder[i]=0;}
        this.canSet = false;

        //Storage of all questions and answers:
        k=1;
        this.q[k,0] = "In Git Bash, what do you type to return to the home directory?"; 
        this.q[k,1] = "cd ~"; this.q[k,2] = "git ~"; 
        this.q[k,3] = "git -a"; this.q[k,4] = "cd /";
        k=2;
        this.q[k,0] = "In Git Bash, what do you type to return to root directory?"; 
        this.q[k,1] = "cd /"; this.q[k,2] = "git cd ~"; 
        this.q[k,3] = "cd root"; this.q[k,4] = "git cd / ";
        k=3;
        this.q[k,0] = "In Git Bash, what do you type to go to parent directory?"; 
        this.q[k,1] = "cd .."; this.q[k,2] = "cd ."; 
        this.q[k,3] = "git up"; this.q[k,4] = "cd up";
        k=4;
        this.q[k,0] = "In Git Bash, what do you type add current files to the index before commit?"; 
        this.q[k,1] = "git add ."; this.q[k,2] = "add ."; 
        this.q[k,3] = "git add .."; this.q[k,4] = "git commit -m \"message\"";
        k=5;
        this.q[k,0] = "In Git Bash, what represents the current directory?"; 
        this.q[k,1] = " . "; this.q[k,2] = " .. "; 
        this.q[k,3] = "/"; this.q[k,4] = ".this";
        k=6;
        this.q[k,0] = "In Git Bash, what do you type to record your changes to a repository?"; 
        this.q[k,1] = "git commit -m \"message\""; this.q[k,2] = "git add ."; 
        this.q[k,3] = "git push"; this.q[k,4] = "git pull";
        k=7;
        this.q[k,0] = "In Git Bash, what do you type to update remote repositories?"; 
        this.q[k,1] = "git push"; this.q[k,2] = "git add ."; 
        this.q[k,3] = "git commit -m \"message\""; this.q[k,4] = "git pull";
        k=8;
        this.q[k,0] = "In Git Bash, what do you type to update your local repository with remote files?"; 
        this.q[k,1] = "git pull"; this.q[k,2] = "git add ."; 
        this.q[k,3] = "git commit -m \"message\""; this.q[k,4] = "git push";
        k=9;
        this.q[k,0] = "What order makes the most sense? (comma represents pushing enter)"; 
        this.q[k,1] = "git checkout main , git pull , git add . , git commit -m \"message\" , git push"; 
        this.q[k,2] = "git pull , git add . , git checkout main , git commit -m \"message\" , git push"; 
        this.q[k,3] = "git add . , git checkout main , git commit -m \"message\" , git push ,  git pull";  
        this.q[k,4] = "git pull , git add . , git commit -m \"message\" , git push, git checkout main"; 
        k=10;
        this.q[k,0] = "In Git Bash, how do you switch branches?"; 
        this.q[k,1] = "git checkout branchName"; this.q[k,2] = "git add branchName"; 
        this.q[k,3] = "cd BranchName"; this.q[k,4] = "touch branchName";
        k=11;
        this.q[k,0] = "If you delete files in your local repo, what will happen after you git push to main?"; 
        this.q[k,1] = "Those files will be deleted on the remote repo too."; 
        this.q[k,2] = "The files will be automatically backed up on the cloud and will be added back to main."; 
        this.q[k,3] = "Those files will still be on the remote repo, but just won't be added again."; 
        this.q[k,4] = "You won't be able to push the commit.";
        k=12;
        this.q[k,0] = "In Git Bash, how do you remove a file?"; 
        this.q[k,1] = "rm fileName"; this.q[k,2] = "rm -m ."; 
        this.q[k,3] = "-rm fileName"; this.q[k,4] = "rm -r fileName";
        k=13;
        this.q[k,0] = "In Git Bash, how do you remove a folder?"; 
        this.q[k,1] = "rm -r folderName"; this.q[k,2] = "git rm -m ."; 
        this.q[k,3] = "-rm folderName"; this.q[k,4] = "rm folderName";
        k=14;
        this.q[k,0] = "In Git Bash, how do you view the files in the current directory?"; 
        this.q[k,1] = "ls"; this.q[k,2] = "p ."; 
        this.q[k,3] = "git ls"; this.q[k,4] = "mkdir";
        k=15;
        this.q[k,0] = "In Git Bash, how do you make a new folder?"; 
        this.q[k,1] = "mkdir folderName"; this.q[k,2] = "mkDir FolderName = new mkDir"; 
        this.q[k,3] = "git mkdir folderName"; this.q[k,4] = "touch FolderName";
        k=16;
        this.q[k,0] = "In Git Bash, how do you make a new file?"; 
        this.q[k,1] = "touch fileName"; this.q[k,2] = "mkDir fileName -a"; 
        this.q[k,3] = "mkdir fileName"; this.q[k,4] = "nano fileName";
        k=17;
        this.q[k,0] = "In Git Bash, how do you show the contents of a text file for example?"; 
        this.q[k,1] = "cat fileName"; this.q[k,2] = "mkDir fileName cat"; 
        this.q[k,3] = "ls"; this.q[k,4] = "rm fileName";
        k=18;
        this.q[k,0] = "In Git Bash, how do you show the contents of a folder including hidden?"; 
        this.q[k,1] = "ls -a"; this.q[k,2] = "ls all"; 
        this.q[k,3] = "ls .gitignore"; this.q[k,4] = "root_system(show hidden=true)";
        k=19;
        this.q[k,0] = "In Git Bash, how do you show the help information about git?"; 
        this.q[k,1] = "git help"; this.q[k,2] = "show help"; 
        this.q[k,3] = "help"; this.q[k,4] = "console(show help=true)";
        k=20;
        this.q[k,0] = "In Git Bash, how do you show the help information about ls specifically?"; 
        this.q[k,1] = "ls --help"; this.q[k,2] = "git help"; 
        this.q[k,3] = "cd ls help"; this.q[k,4] = "ls .help";
        k=21;
        this.q[k,0] = "In Git Bash, how do you show a read out of a commit (current working tree status?)"; 
        this.q[k,1] = "git log"; this.q[k,2] = "git commit -m \"message\""; 
        this.q[k,3] = "commit log"; this.q[k,4] = "ls log";
        k=22;
        this.q[k,0] = "In Git Bash, how do you open a file in Visual Studio Code?"; 
        this.q[k,1] = "code FileName"; this.q[k,2] = "touch fileName"; 
        this.q[k,3] = "vs code fileName"; this.q[k,4] = "cat fileName";
        k=23;
        this.q[k,0] = "In Git Bash, how do you delete an entire branch?"; 
        this.q[k,1] = "git branch -d branchName"; this.q[k,2] = "rm branch branchName"; 
        this.q[k,3] = "branch -d branchName"; this.q[k,4] = "rm -r branchName";
        k=24;
        this.q[k,0] = "In Git Bash, how do you make a new branch?"; 
        this.q[k,1] = "git branch branchName"; this.q[k,2] = "add branch branchName"; 
        this.q[k,3] = "branch branchName"; this.q[k,4] = "git add branchName";
        k=25;
        this.q[k,0] = "In Git Bash, how do you show a list of all remote repos?"; 
        this.q[k,1] = "git remote -v"; this.q[k,2] = "git remote -m"; 
        this.q[k,3] = "remote -v"; this.q[k,4] = "git remote -m main";
        k=26;
        this.q[k,0] = "In Git Bash, how do you add a new local repo from a remote repo?"; 
        this.q[k,1] = "git clone  <url to repo>"; 
        this.q[k,2] = "git remote origin add <host-or-remote url>"; 
        this.q[k,3] = "git remote origin <host-or-remote url>"; 
        this.q[k,4] = "remote add new origin <host-or-remote url>";
        k=27;
        this.q[k,0] = "In Git Bash, how do you remove a connection to a remote repo?"; 
        this.q[k,1] = "git remote rm nameOfRepo"; this.q[k,2] = "git remote -rm nameOfRepo"; 
        this.q[k,3] = "remote rm nameOfRepo"; this.q[k,4] = "remote rm -r nameOfRepo";
        k=28;
        this.q[k,0] = "In Git Bash, how do you list all branches currently present in the repo?"; 
        this.q[k,1] = "git branch"; this.q[k,2] = "git ls branch"; 
        this.q[k,3] = "branch"; this.q[k,4] = "ls branch";
        k=29;
        this.q[k,0] = "In Git Bash, how can you tell what branch you are currently in?"; 
        this.q[k,1] = "The blue branch name to the right in parenthesis"; 
        this.q[k,2] = "git ls branch"; 
        this.q[k,3] = "by sending a git push through"; 
        this.q[k,4] = "ls branch";
        k=30;
        this.q[k,0] = "In Git Bash, how do you connect the local repository to a remote server?"; 
        this.q[k,1] = "git remote add origin <host-or-remote url>"; 
        this.q[k,2] = "git remote origin add <host-or-remote url>"; 
        this.q[k,3] = "git remote origin <host-or-remote url>"; 
        this.q[k,4] = "remote add new origin <host-or-remote url>";
        
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
                reTry = false;
                //Console.WriteLine("Maybe after a while?"+i);
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
        //Console.WriteLine("aOrder[1]: {0}\naOrder[2]: {1}\naOrder[3]: {2}\naOrder[4]: {3}",
        //this.aOrder[1],this.aOrder[2],this.aOrder[3],this.aOrder[4]);
   
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