namespace StoreQA;

public class StoredQA {

    //Empty Constructor
    public StoredQA() {}

    //this is called automatic property
    public int qOrder { get; set; } //What order this question will appear on the test
    public int whatQ { get; set; } //What question this is
    public bool used { get; set; }//This question was answered already
    string[,] q = new string[61,5];//2D array with 30 questions and 4 answers each    
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
        this.q[k,2] = "git pull , git add . , git checkout main , git push , git commit -m \"message\""; 
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
        k=31;
        this.q[k,0] = "In Shell Script, what does an 'if statement' look like?"; 
        this.q[k,1] = "\nif [ $var1 -eq 10 ] \nthen\necho \"var1 equals: 10\"\nfi\n"; 
        this.q[k,2] = "\nif ( $var1 -eq 10 ) \n{\necho \"var1 equals: 10\"\n}\n"; 
        this.q[k,3] = "\nif [$var1 -eq 10] \nthen\nConsole.WriteLine( \"var1 equals: 10\");\nfi\n"; 
        this.q[k,4] = "\nif $(( $var1 -eq 10 )) \n{\necho \"var1 equals: 10\"\n}\n";
        k=32;
        this.q[k,0] = "In Shell Script, what is the syntax to change a negative value to a positive?"; 
        this.q[k,1] = "negIntVar=$((negIntVar*-1))"; 
        this.q[k,2] = "negIntVar*negIntVar*-1"; 
        this.q[k,3] = "negIntVar = negIntVar*-1"; 
        this.q[k,4] = "$negIntVar = $negIntVar*-1";
        k=33;
        this.q[k,0] = "In Shell Script, what is the syntax to display a message to the console?"; 
        this.q[k,1] = "echo \"This is a message\""; 
        this.q[k,2] = "Console.WriteLine(\"This is a message\");";
        this.q[k,3] = "$(\"This is a message\").String;"; 
        this.q[k,4] = "#This is a message";
        k=34;
        this.q[k,0] = "In Shell Script, what is the syntax to leave a comment in the code editor?"; 
        this.q[k,1] = "# This is a comment"; 
        this.q[k,2] = "Console.WriteLine(\"This is a comment\");";
        this.q[k,3] = "$(\"This is a comment\").String;"; 
        this.q[k,4] = "echo \"This is a comment\"";
        k=35;
        this.q[k,0] = "In Shell Script, what is the syntax to read the user input and store to a string?"; 
        this.q[k,1] = "read userInputVar"; 
        this.q[k,2] = "userInputVar = Console.ReadLine();";
        this.q[k,3] = "&userInputVar = readline"; 
        this.q[k,4] = "echo read userInputVar";
        k=36;
        this.q[k,0] = "In Shell Script, what is the syntax to check the value of a string in a condition?"; 
        this.q[k,1] = "if [ $stringVar = 'hello world' ] ..."; 
        this.q[k,2] = "if stringVar = \"hello world\" ...";
        this.q[k,3] = "if($stringVar == \"hello world\") ..."; 
        this.q[k,4] = "if read stringVar = '[hell world]' ...";
        k=37;
        this.q[k,0] = "In Shell Script, what is the syntax to store a random number 0 to 100?"; 
        this.q[k,1] = "randomNum=$(($RANDOM % 101)) "; 
        this.q[k,2] = "randomNum=$(($RANDOM % 100)) ";
        this.q[k,3] = "randomNum= new(($RANDOM % 100))"; 
        this.q[k,4] = "Random rand = new Random(); randomNum = rand.Next(0,101);";
        k=38;
        this.q[k,0] = "In Shell Script, what is the syntax to write a while loop?\n"; 
        this.q[k,1] = "while [ $intVar < 100 ]\ndo\necho \"intVar = $intVar\"\nintVar=$((intVar+1))\ndone\n"; 
        this.q[k,2] = "while [ intVar < 100 ]\n{\necho \"intVar = $intVar\"\nintVar=$((intVar+1))\n}\n";
        this.q[k,3] = "while ( &intVar < 100 )\n{\necho \"intVar = ${intVar}\"\nintVar= intVar+1\n}\n"; 
        this.q[k,4] = "while [intVar < 100]\ndo\necho \"intVar = $intVar\"\nintVar=$((intVar+1))\ndone\n";
        k=39;
        this.q[k,0] = "In Shell Script, what symbol means lesser or equal?"; 
        this.q[k,1] = "-le"; this.q[k,2] = "-lt"; this.q[k,3] = "-gt"; this.q[k,4] = "<=";
        k=40;
        this.q[k,0] = "In Shell Script, what symbol means less than?"; 
        this.q[k,1] = "-lt"; this.q[k,2] = "-le"; this.q[k,3] = "-gt"; this.q[k,4] = "<";
        k=41;
        this.q[k,0] = "In Shell Script, what symbol means not equal?"; 
        this.q[k,1] = "-ne"; this.q[k,2] = "-le"; this.q[k,3] = "-gt"; this.q[k,4] = "!=";
        k=42;
        this.q[k,0] = "In Shell Script, what symbol means greator than?"; 
        this.q[k,1] = "-gt"; this.q[k,2] = "+gt"; this.q[k,3] = "-ge"; this.q[k,4] = ">";
        k=43;
        this.q[k,0] = "In Shell Script, what symbol means greator or equal?"; 
        this.q[k,1] = "-ge"; this.q[k,2] = "+ge"; this.q[k,3] = "-le"; this.q[k,4] = ">=";
        k=44;
        this.q[k,0] = "In Shell Script, what is the correct syntax for setting a variable?"; 
        this.q[k,1] = "intVar=1"; this.q[k,2] = "intVar = 1;"; this.q[k,3] = "int intVar=1;"; this.q[k,4] = "intVar = 1";
        k=45;
        this.q[k,0] = "In Shell Script, what is the correct syntax when checking a variable?"; 
        this.q[k,1] = "if [ $intVar = 1 ] ..."; this.q[k,2] = "if[intVar==1] ..."; 
        this.q[k,3] = "if $intVar=1 ..."; this.q[k,4] = "if( intVar = 1 ) ...";
        k=46;
        this.q[k,0] = "In Shell Script, what is the correct syntax to break from a loop?"; 
        this.q[k,1] = "break"; this.q[k,2] = "break;"; this.q[k,3] = "end loop"; this.q[k,4] = "done";
        k=47;
        this.q[k,0] = "In Shell Script, how do you concat strings?"; 
        this.q[k,1] = "newString=\"$string1 $string2\""; this.q[k,2] = "newString = string1+string2"; 
        this.q[k,3] = "newString = concat(string1,string2);"; this.q[k,4] = "Shell scripting does not allow concating strings";
        k=48;
        this.q[k,0] = "In Shell Script, what do you type into your code to set debug mode?"; 
        this.q[k,1] = "set -x"; this.q[k,2] = "set debug = true"; 
        this.q[k,3] = "debug.set=true"; this.q[k,4] = "shell.debug$((mode.x)=-x) input";
        k=49;
        this.q[k,0] = "In Shell Script, what do you type into your code to treat unset variables as errors and exit?"; 
        this.q[k,1] = "set -u"; this.q[k,2] = "set uninit"; 
        this.q[k,3] = "debug.set=-u"; this.q[k,4] = "set $u";
        k=50;
        this.q[k,0] = "In Shell Script, how would you return what bash version the user has?"; 
        this.q[k,1] = "echo \"You have version $BASH_VERSION.\""; this.q[k,2] = "echo \"You have version BASH_VERSION.\""; 
        this.q[k,3] = "echo \"You have version $BASH.\""; this.q[k,4] = "echo \"You have version $BASH_VERSION(Show_Version).\"";
        k=51;
        this.q[k,0] = "In Shell Script, what do you type to cut the string \"hello\" from str = \"abchellodef\"?"; 
        this.q[k,1] = "str=$(echo $str | cut -c4-8)"; this.q[k,2] = "str=$(cut -c4-8)"; 
        this.q[k,3] = "str=$cut(echo $str | -c4-8)"; this.q[k,4] = "str=$string($str | -c4-8).cut";
        k=52;
        this.q[k,0] = "In Shell Script, what do you type to change the string 'str' to uppercase?"; 
        this.q[k,1] = "str=$(echo $str | tr \"[:lower:]\" \"[:upper:]\")"; 
        this.q[k,2] = "str toUpper;"; 
        this.q[k,3] = "str=$(echo $str | tr \"[echo :$str.lower:].case\" || \"[echo :$str.upper:].case\")"; 
        this.q[k,4] = "str=$string($str | -c4-8).cut to upper";
        k=53;
        this.q[k,0] = "In Visual Studio Code, what does it mean if the title at the top is red and crossed out?"; 
        this.q[k,1] = "The local file of the code being worked on has been deleted, probably by a git pull, or the file was moved."; 
        this.q[k,2] = "The code you are working on is broken and has been removed by the system for your convenience."; 
        this.q[k,3] = "You have auto save on."; 
        this.q[k,4] = "It doesn't mean anything important, it's just an aesthetic feature.";
        k=54;
        this.q[k,0] = "In Shell Script, what do you type to easily change the string 'str' to uppercase?"; 
        this.q[k,1] = "str=${str^^}"; 
        this.q[k,2] = "str toUpper;"; 
        this.q[k,3] = "str=$(echo $str | tr \"[echo :$str.lower:].case\" || \"[echo :$str.upper:].case\")"; 
        this.q[k,4] = "str=up^";
        k=55;
        this.q[k,0] = "In Shell Script, how do you change the first letter only in string 'str' to uppercase?"; 
        this.q[k,1] = "str=${str^}"; 
        this.q[k,2] = "str toUpperFirstOnly;"; 
        this.q[k,3] = ".net access-string-library [internal sub-database]: str=$(echo $str | tr \n\"[echo :$str.[1]lower:].case\" || \"[echo :$str.[1]upper:].case\")"; 
        this.q[k,4] = "str=up1^";
        k=56;
        this.q[k,0] = "In Shell Script, what is the syntax for a simple function?\n"; 
        this.q[k,1] = "myFunction() {\necho \"function stuff here\"\n}\n"; 
        this.q[k,2] = "myFunction() \nfunc\necho \"function stuff here\"\nendFunc\n"; 
        this.q[k,3] = "myFunction (\necho \"function stuff here\"\n)\n"; 
        this.q[k,4] = "$myFunction() {{\necho \"function stuff here\"\n}}\n";
        k=57;
        this.q[k,0] = "In Shell Script, what is the syntax to call a function?"; 
        this.q[k,1] = "myFunction $var"; 
        this.q[k,2] = "myFunction.var"; 
        this.q[k,3] = "myFunction(var)"; 
        this.q[k,4] = "myFunction() {$var}";
        k=58;
        this.q[k,0] = "What does CVCS mean?";
        this.q[k,1] = "Central Version Control System: maintains a single copy repository to record all changes"; 
        this.q[k,2] = "Current Variations Combination System: maintains a several copies of source code to record all changes"; 
        this.q[k,3] = "Cloud Version Codifying Syntax: Used to keep each contributer's code seperated from the rest."; 
        this.q[k,4] = "Consumer Value Convenience Store: A place to buy cookies, chips, makeup and medicine.";
        k=59;
        this.q[k,0] = "What does DVCS mean?"; 
        this.q[k,1] = "Distributed Version Control System : mirrors codebase on each user's computer"; 
        this.q[k,2] = "Distributed Variation Combined Signage : mirrors codebase on several websites"; 
        this.q[k,3] = "Dynamic Version Cloud Syntax: Used to keep each contributer's code seperated from the rest."; 
        this.q[k,4] = "Destination Variation Cloud System: allows users to work without the need for local files";
        k=60;
        this.q[k,0] = "What kind of VCS does GIT HUB use?"; 
        this.q[k,1] = "DVCS"; 
        this.q[k,2] = "CVCS"; 
        this.q[k,3] = "GITVCS"; 
        this.q[k,4] = "CLOUD.NET";
        
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