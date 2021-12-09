#!usr/bin/bash

#randomNum is between 1-100
randomNum=$(($RANDOM % 100))

echo $randomNum

echo "Guess a number"
read number
counter=1

while [ $number -ne $randomNum ]
do    
    if [ $number -lt $randomNum ]
    then 
        x=$((randomNum - $number))
        echo "Too Low. Off by $x"

    elif [ $number -gt $randomNum ]
    then

         y=$((number - $randomNum))
        echo "Too High. Off by $y"
    fi
    echo "Guess again"
    counter=$((counter+=1))
    read number
done
echo "Correct! It took you $counter guesses"

