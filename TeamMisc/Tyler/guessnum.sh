#!/usr/bin/bash

randomNum=$(($RANDOM % 101))  
diff=1
lastdiff=0          
guess=0                
guesses=0                   

echo "A random number between 0 and 100 was selected."

while [ $guess -ne $randomNum ] 
do
    echo "Guess the number: " ; 
    read guess

    if [ "$guess" -lt $randomNum ] ; 
        then
            lastdiff=$(($randomNum - $guess))
            echo "Higher! You're off by $lastdiff"

    elif [ "$guess" -gt $randomNum ] ; 
        then
            diff=$(($guess - $randomNum))
            echo "Lower! You're off by $diff"

    fi
    guesses=$(($guesses + 1))
done

echo "Correct!! You guessed #$randomNum. It took you $guesses tries."
exit
