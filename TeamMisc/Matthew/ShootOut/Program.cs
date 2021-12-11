//SHOOT OUT!
Console.WriteLine("Bad guy: There ain't enough room in this town for both of us!");

//Win
int win = 0; //2 = lose, 1 = win
bool turn = false; //true = player turn, false = bad guy turn

//Player stats
int hP = 100;
int bullets = 30;
int loaded = 6;
int shells = 4;
int shotLoad = 1;
int heal = 0;
int reload = 0;
int revDmg = 0; //Revolver Damage
int shotDmg = 0; //Shotgun Damage
string choose = "";
bool choseRight = false; //Player has chosen a real answer
int bandages = 3;

//Bad guy stats
int eHP = 100;
int eBullets = 30;
int eLoaded = 6;
int eShells = 4;
int eShotLoad = 1;
int eHeal = 0;
int eReload = 0;
int eRevDmg = 0; //Enemy Revolver Damage
int eShotDmg = 0; //Enemy Shotgun Damage
int eGun = 0; //For AI to choose weapon
int eBandages = 3;

//Array for actions $"You picked {toDoList[selection].Print()}"
string[] yourActions = new string[] { $"heal your self for ", $"bullets into your revolver: ", 
"load a shell into your shotgun", "rack your shotgun", "fire your revolver", "fire your shotgun", "give up" };
//Array for bad guy actions
string[] badActions = new string[] { $"heals himself for ", $"bullets into his revolver: ", 
"loads a shell into his shotgun", "racks his shotgun", "fires his revolver", "fires his shotgun", "gives up" };
//Array for results
string[] results = new string[] { $"You are hurt for ", $"You are blasted for ", 
$"He is hurt for ", $"He is blasted for ", $"Health left: ", $"His health left: ", 
$"Bullets left: ", $"Shells left: ", "you won", "you lost", "it's a draw, you both done killed each other I reckon"};

//During Fight
while (win == 0)
{
    //Bad guy turn (Super advanced self aware skynet AI)
    while (turn == false)
    {
        //Decide if to heal
        if(eHP < 30 && eBandages > 0)
        {
            Random randEH = new Random();
            eHeal = randEH.Next(10,30); eBandages -= 1;
            eHP += eHeal; if(eHP > 100){eHP = 100;}
            Console.WriteLine($"The bad guy {badActions[0]} {eHeal}, his bandages ({eBandages})");
            turn = true; choseRight = false;
            break;
        }

        //Decide what weapon to use if not heal
        if((eLoaded > 0 && eShotLoad > 0) || (eBullets > 0 && eShells > 0))//Both guns have ammo
        {
            Random whtGun = new Random();
            eGun = whtGun.Next(1,3);
        }
        //Only revolver has ammo
        if((eBullets+eLoaded > 0) && (eShells+eShotLoad == 0))
        {
            eGun = 1;
        }
        //Only shotgun has ammo
        if((eBullets+eLoaded == 0) && (eShells+eShotLoad > 0))
        {
            eGun = 2;
        }
        //No ammo
        if((eBullets+eLoaded == 0) && (eShells+eShotLoad == 0))
        {
            Console.WriteLine($"The bad guy {badActions[6]}");
            win = 1;
            turn = true; choseRight = false;
            break;
        }

        //Shoot
        if(eGun == 1)
        {
            //Reload if can't shoot
            if(eLoaded == 0)
            {
                Random eRLR = new Random();
                eReload = eRLR.Next(1,4); if(eBullets == 1){eReload = 1;}//If only one bullet left
                eLoaded += eReload; eBullets -= eReload;
                if(eLoaded > 6){eBullets += eLoaded-6; eLoaded = 6;}//Fix overloading gun
                Console.WriteLine($"The bad guy puts {eReload} {badActions[1]}");
                turn = true; choseRight = false;
                break;
            }
            else
            {
                //Shoot!
                Console.WriteLine($"The bad guy {badActions[4]}");
                //Revolver damage
                Random eRD = new Random();
                eRevDmg = eRD.Next(1,20);
                eLoaded -= 1;
                hP -= eRevDmg;
                Console.WriteLine($"{results[0]} {eRevDmg}, {results[4]} {hP}");
                turn = true; choseRight = false;
                break;
            }

        }

        //Shoot Shotgun
        if(eGun == 2)
        {
            //Reload if can't shoot
            if(eShotLoad == 0)
            {
                eShotLoad = 1; eShells -= 1;
                Console.WriteLine($"The bad guy {badActions[2]} and {badActions[3]}");
                turn = true; choseRight = false;
                break;
            }
            else
            {
                //Shoot Shotgun!
                Console.WriteLine($"The bad guy {badActions[5]}");
                //Shot damage
                Random eSD = new Random();
                eShotDmg = eSD.Next(10,40);
                eShotLoad = 0;
                hP -= eShotDmg;
                Console.WriteLine($"{results[1]} {eShotDmg}, {results[4]} {hP}");
                turn = true; choseRight = false;
                break;
            }

        }

    }

    //Player turn
    while(turn == true)
    {
        
        while(choseRight == false)
        {
            Console.WriteLine($"The bad guy has {eHP} health, choose an action:\n1.) Shoot revolver, loaded({loaded})"+
            $"\n2.) Shoot Shotgun, loaded({shotLoad})\n3.) Reload revolver, loaded ({loaded}), extra bullets({bullets})"+
            $"\n4.) Reload Shotgun, loaded ({shotLoad}), extra shells({shells})\n5.) Heal, current health ({hP}), bandages: ({bandages})");

            choose = Console.ReadLine();
            choseRight = true;
            switch(choose)
            {
                case "1":
                    if(loaded > 0)
                    {
                        //Shoot revolver
                        Console.WriteLine($"You {yourActions[4]}");
                        //Revolver damage
                        Random rD = new Random();
                        revDmg = rD.Next(1,20);
                        eHP -= revDmg;
                        loaded -= 1;
                        Console.WriteLine($"{results[2]} {revDmg}, {results[5]} {eHP}");
                    }
                    else
                    {
                        choseRight = false;
                        Console.WriteLine("How ya gunna shoot without no bullets loaded?");
                    }    
                break;
                case "2":
                    if(shotLoad > 0)
                    {
                        //Shoot shotgun
                        Console.WriteLine($"You {yourActions[5]}");
                        //Revolver damage
                        Random rSD = new Random();
                        shotDmg = rSD.Next(10,40);
                        eHP -= shotDmg;
                        shotLoad -= 1;
                        Console.WriteLine($"{results[3]} {shotDmg}, {results[5]} {eHP}");
                    }
                    else
                    {
                        choseRight = false;
                        Console.WriteLine("Hold on partner, how ya plan on shootin that there shotgun"+
                        " without no shells in it?");
                    }  
                break;
                case "3":
                    //Reload revolver
                    if(loaded < 6){
                        Random rLR = new Random();
                        reload = rLR.Next(1,4); if(bullets == 1){reload = 1;}//If only one bullet left
                        loaded += reload; bullets -= reload;
                        if(loaded > 6){bullets += loaded-6; loaded = 6;}//Fix overloading gun
                        Console.WriteLine($"You put {reload} {yourActions[1]}");
                    }
                    else
                    {
                        choseRight = false;
                        Console.WriteLine("Your gun is already loaded you rascal!");
                    }
                break;
                case "4":
                    if(shotLoad == 0)
                    {    
                        //Reload shotgun
                        shotLoad = 1; shells -= 1;
                        Console.WriteLine($"You {yourActions[2]} and {yourActions[3]}");
                    }
                    else
                    {
                        choseRight = false;
                        Console.WriteLine("Your shotgun is already loaded you rascal!");
                    }
                break;
                case "5":
                    if(hP < 90){
                        if(bandages > 0)
                        {   
                            //Heal Self
                            Random randH = new Random();
                            heal = randH.Next(10,30); bandages -= 1;
                            hP += heal; if(hP > 100){hP = 100;}
                            Console.WriteLine($"You {yourActions[0]} {heal}");
                        }
                        else
                        {
                            choseRight = false;
                            Console.WriteLine("You ain't got no bandages left!");
                        }
                    }
                    else
                    {
                        choseRight = false;
                        Console.WriteLine("Don't be a baby!");
                    }
                break;
                default:
                    choseRight = false;
                    Console.WriteLine("Come on now cowboy, pick a real answer!");
                break;
            }
        }

        turn = false;
    }

    //No ammo
    if((bullets+loaded == 0) && (shells+shotLoad == 0))
    {
        Console.WriteLine($"You {yourActions[6]} as you have no ammo");
        if(eHP > 0){win = 2;}
    }

    //Check if anyone died
    if(hP < 1 && eHP > 0){win = 2;}
    if(eHP < 1 && hP > 0){win = 1;}
    if(eHP < 1 && hP < 1){win = 3;}//Draw
    
}

//Game Over
Console.WriteLine("Well... {0}",results[7+win]);
Console.ReadLine();
