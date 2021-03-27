#!/bin/bash
cntBranch=$(git branch | sed '/* /!d'| sed 's/* //g')

if [ "$1" == "brew" ]; then
    ~/Documents/Release/brewall/brewall.sh
    cd ~/Documents/Release/aptall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $cntBranch
        cd - > /dev/null
    fi
elif [ "$1" == "apt" ]; then
    ~/Documents/Release/aptall/aptall.sh
    cd ~/Documents/Release/brewall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $cntBranch
        cd - > /dev/null
    fi
else
    cd ~/Documents/Release/brewall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $cntBranch
        cd - > /dev/null
    fi
    cd ~/Documents/Release/aptall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $cntBranch
        cd - > /dev/null
    fi
fi

cd ~/Documents/Dev 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $cntBranch
    cd - > /dev/null
fi

cd ~/Documents/Release/Recruitment-Assistant 2> /dev/null
if [ $? == 0 ]; then
    git pull --rebase --stat origin $cntBranch
    cd - > /dev/null
fi

