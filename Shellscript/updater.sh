#!/bin/bash

exitCode=0

function gitUpdate() {
    cd ~/Documents/Release/brewall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
    cd ~/Documents/Release/aptall 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
    cd ~/Documents/Dev 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
    cd ~/Documents/Release/Recruitment-Assistant 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
    cd ~/Documents/Release/Timer 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
}

if [ "$SKIP_PACKAGE_UPDATER" == "true" ]; then
    gitUpdate
    echo -e '\a'
    exit $exitCode
fi

if [ "$(uname -s)" == "Darwin" ]; then
    if [ -x ~/Documents/Release/brewall/brewall.sh ]; then
        ~/Documents/Release/brewall/brewall.sh $@
        exitCode=$?
    else
        gitUpdate
    fi
elif [ "$(uname -s)" == "Linux" ]; then
    if [ -x ~/Documents/Release/aptall/aptall.sh ]; then
        ~/Documents/Release/aptall/aptall.sh $@
        exitCode=$?
    else
        gitUpdate
    fi
else
    gitUpdate
fi

echo -e '\a'
exit $exitCode

