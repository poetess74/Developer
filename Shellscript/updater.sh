#!/bin/bash

if [ "$1" == "brew" ]; then
    ~/Documents/Release/brewall/brewall.sh
else
    cd ~/Documents/Release/brewall
    git pull origin master
    cd - > /dev/null
fi

cd ~/Documents/Dev
git pull origin master
cd - > /dev/null

cd ~/Documents/Release/Recruitment-Assistant
git pull origin master
cd - > /dev/null

softwareupdate -l

