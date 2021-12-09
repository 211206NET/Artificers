#!/usr/bin/bash

#-le lesser or equal
#-lt less than
#-ne not equal
#-gt greator than
#-ge greator or equal

randomNum=$(($RANDOM % 101)) #0 to 100
diff=1 #difference between guess and random
lastDiff=0 #Previous guess user made to compare if they got closer or not
count=1

#force correct number > 0
while [ $randomNum -le 0 ] # if 0 or lower
do
    randomNum=$(($RANDOM % 101)) #0 to 100
done

echo "Number to guess $randomNum"

while [ $diff -ne 0 ]
do
    echo "Guess a number from 1 to 100"
    read guess

    diff=$(($guess - $randomNum))
    echo $diff

    #return difference between values MATH.ABS
    if [ $diff -le 0 ]
    then
        diff=$((diff*-1))
        echo "got this far"
    fi

    if [ $guess = $randomNum ] #$diff =  0
    then
        echo "That is correct!"
    else
        if [ $lastDiff -ne 0 ]
        then 
            if [ $lastDiff -lt $diff ]
            then
                echo "Incorrect, you tried $count times, you are getting colder do you want to try agian? 'y' or 'n'"
            else
                echo "Incorrect, you tried $count times, but you are getting warmer do you want to try agian? 'y' or 'n'"
            fi
        else 
            echo "Incorrect, do you want to try agian? 'y' or 'n'"
        fi
        
        lastDiff=$diff
        count=$((count+1))
        read choose
        if [ $choose = 'n' ]
        then
            break
        else
            echo "Keep going!"
        fi
    fi
done