#!/usr/bin/bash
randomNum=$(($RANDOM % 100))
echo $randomNum

echo "Guess a number"
read number
counter=1

while [ $number -ne $randomNum ]
do    
    if [ $number -lt $randomNum ]
    then 
        echo " Under guess again"
    elif [ $number -gt $randomNum ]
    then
        echo " Over guess again"
    fi
    echo "Guess again"
    counter=$((counter+=1))
    read number
done
echo "Good guess it only took you $counter tries"