#!/bin/bash

~/Documents/Release/brewall/brewall.sh

cd ~/Documents/Dev
git pull origin master
cd - > /dev/null

cd ~/Documents/Release/Recruitment-Assistant
git pull origin master
cd - > /dev/null

softwareupdate -l

