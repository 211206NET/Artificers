#!usr/bin/bash
echo "Enter a positive integer"
read number

while [ $number -le 0 ]
do
    echo "The number should be greater than 0"
    echo "Enter a positive integer"
    read number
done

echo "You entered $number"


counter=1

while [ $counter -le $number ]
do
    if [ $(($counter % 3)) -ne 0 ]
    then 
        if [ $((counter % 5)) -eq 0]
        then
            echo "Buzz"
    else
        echo $counter

    fi
else
    echo "Fizz"
fi 
    counter=$((counter+=1))
done