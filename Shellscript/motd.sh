#!/bin/bash
loginFile=~/Library/Temp/login.txt
w | grep $USER > $loginFile

result=$(cat $loginFile)
sed "s/$USER    / /g" <<< "$result" > $loginFile

mesg n > /dev/null
uptime
cat $loginFile
echo ""
