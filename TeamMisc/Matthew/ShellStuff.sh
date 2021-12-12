#!/usr/bin/bash

#-le lesser or equal
#-lt less than
#-ne not equal
#-gt greator than
#-ge greator or equal
# echo "abcdefg" | cut -c1-3 #returns abc
# echo "abcdefg" | cut -c2-4 #returns bcd
# echo "abcdefg" | cut -c5-5 #returns e
str=abchellodef
echo $str
echo $str | cut -c4-8 #echo the change but not actually make the change
str=$(echo $str | cut -c4-8 | tr "[:lower:]" "[:upper:]") #actually make changes
echo $str

str2=wanttobebig #easy way to modify string
str2=${str2^^}
echo $str2

echo "You have version $BASH_VERSION."
if ((BASH_VERSINFO[0] < 4)); then
    printf '%s\n' "Error: This requires Bash v4.0 or higher. You have version $BASH_VERSION." 1>&2
    exit 2
fi

myFunction(){
    echo "My Function ran ${1^}"
}

str3="thisIsMyString"
myFunction $str3