Random rd = new Random();
int randomNum = rd.Next(0,100);
int input = 101;
int counter = 1;
int diff;
Console.WriteLine("Guess a number between 0 - 100");
while(input != randomNum ) 
{
    input = Convert.ToInt32(Console.ReadLine());
    diff = Math.Abs(input - randomNum);
    if (input < randomNum)
    {
        switch (diff)
        {
        case < 5:       
            Console.WriteLine("You're hot, almost there buddy!");
            Console.WriteLine("Try going up a little"); 
            break;                    
        case < 25:        
            Console.WriteLine("You're warm, not that far off keep trying");
            Console.WriteLine("Go up a bit");           
            break;
        case < 50:
            Console.WriteLine("Not even close...");
            Console.WriteLine("Yikes! Go up a lot!");     
            break;
        default: 
            Console.WriteLine("Give up, you're not even trying");
            break;
        }      
    }
    if (input > randomNum)
    {
        switch (diff)
        {     
        case < 5:      
            Console.WriteLine("You're hot, almost there buddy!");
            Console.WriteLine("Try going down a little");                      
            break;
        case < 25:        
            Console.WriteLine("You're warm, try it again");
            Console.WriteLine("Go down a bit");        
            break;
        case  < 50:
            Console.WriteLine("Not even close...");
            Console.WriteLine("Yikes! Go down a lot!");    
            break;
        default: 
            Console.WriteLine("Come on thats nowhere near right!");
            break;
        }          
    }
    counter +=1;
}
Console.WriteLine("You guessed it! it only took you " + counter + " tries");

