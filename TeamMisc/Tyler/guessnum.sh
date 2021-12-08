#!/usr/bin/bash

randomNum=$(($RANDOM % 101))  
diff=1
lastdiff=0          
guess=0                
guesses=0              
number=$(($$ % $randomNum))       

while [ $guess -ne $number ] 
do
    echo "Guess a number: " ; 
    read guess

    if [ "$guess" -lt $number ] ; then
        lastdiff=$(($number - $guess))
        echo "Higher! You're off by $lastdiff"

    elif [ "$guess" -gt $number ] ; then
        diff=$(($guess - $number))
        echo "Lower! You're off by $diff"

    fi
    guesses=$(($guesses + 1))
done

echo "Correct!! You guessed #$number in $guesses tries."
exit