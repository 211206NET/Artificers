#!/usr/bin/bash

 randomNum=$(($RANDOM % 101)) 
 lastguess=0

 echo $randomNum

 # force corrent number > 0
 while [ $randomNum -le 0 ]
 do
    randomNum=$((RANDOM % 101)) #0 to 100
 done

 echo "Guess the number from 1 to 100"

 read guess

 echo "you guessed $guess"

  # gets the difference between the guess and the random generated number
 difference=$(($guess - $randomNum))

 echo "the difference between the guess and the random number is $difference"

 #checks if the difference is negative
  if [ $difference -le 0 ]

  then
    # If the result is negative turn it positive
     difference=$((difference*-1))
     echo "the difference was negative it is now $difference"
 fi

  echo $difference

 while [ $guess -ne $randomNum ] 
 do 

     if [ $guess -lt $randomNum ]
     then 
         echo " you are under the random number"
     elif [ $guess -gt $randomNum ]
     then
         echo " you are over the random number "
     fi

      # echo "Guess again"

      # lastguess=$guess
      echo "this is last guess value $lastguess and guess $guess"
      if [ $lastguess = 0 ]
      then 
      echo "this was a great first attempt."
      elif [ $lastguess -le $guess ]
      then 
         echo "echo you are getting colder"
        else
        echo "echo you are getting warmer"
        fi

       
      lastguess=$guess
      counter=$((counter+=1))
      echo "guess again"
      read guess
      
  done
  echo "good guess! it only took you $counter tries"





  

    