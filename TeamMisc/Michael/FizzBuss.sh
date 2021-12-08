#!/usr/bin/bash
#fizzbuzz is a simple problem where we loop through and display numbers given user
#input
#However, if the number is divisible by 3, we print "fizz" instead
# If the number is divisible by 5, we print "Buzz"
# If the number is both divisible by 3 and 5, we pront "FizzBuzz"







echo "Enter a positive integer"
read number

#checking input to make sure it's greater than zero
#will continue to run until the input is greater than zero.

while [ $number -le 0 ]
do
    echo "the number should be greater then 0"
    echo "Enter a positive integer"
    read number
done
echo "you entered $number"

#create a counter variable which will start at 1 and then continue incrementing by 1

#counter=1

#while [ $counter -le $number ]
#do
    #Check if the number is not divisible by 3
   # if [ $((counter % 3)) -ne 0 ]
   # then
   #     if [ $((counter % 5)) -eq 0 ]
   #     then
   #         echo "Buzz"
   #     else
   #     echo $counter
   #     fi
    # if number is divisible by 5
    
    #else
    #    echo "Fizz"
   # fi 

   # if [ $(($counter % 3)) -eq 0 && $(($counter % 5)) -eq 0 ]

   if [$((counter % 15)) -eq 0]
    then
        echo "FizzBuzz"
    elif [ $((counter % 3)) -eq 0 ]
    then
        echo "Fizz"
    elif [ $((counter % 5)) -eq 0 ]
    then
        echo "Buzz"

    else
    #First, we're printing counter variable
    echo $counter
    fi

    # and then. we are incrementing the variable by 1
    counter=$(($counter+1))
done 

