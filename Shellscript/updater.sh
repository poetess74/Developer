#!/bin/bash

~/.shellscript/brewall.sh

cd ~/Documents/Dev
git pull origin master
cd - > /dev/null

cd ~/Documents/Release/Recruitment-Assistant
git pull origin master
cd - > /dev/null

cd ~/Documents/Release/brewall
git pull origin master
cd - > /dev/null

softwareupdate -l

