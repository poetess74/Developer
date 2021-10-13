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
    cd ~/Documents/Release/PracticeCalc 2> /dev/null
    if [ $? == 0 ]; then
        git pull --rebase --stat origin $(git branch | sed '/* /!d'| sed 's/* //g')
        cd - > /dev/null
    fi
}

function sparkleUpdate() {
    echo -e "\n\033[0;1mCheck for updates manually for the apps below that use the Sparkle framework.\033[m"
    echo "--- /Applications ---"
    find /Applications -name Sparkle.framework 2> /dev/null | awk -F'/' '{print $3}' | awk -F'.' '{print $1}'
    echo -e "\n--- $HOME/Applications ---"
    find ~/Applications -name Sparkle.framework 2> /dev/null | awk -F'/' '{print $5}' | awk -F'.' '{print $1}'
}

if [ "$SKIP_PACKAGE_UPDATER" == "true" ]; then
    gitUpdate
    sparkleUpdate
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
    sparkleUpdate
elif [ "$(uname -s)" == "Linux" ]; then
    if [ -x ~/Documents/Release/aptall/aptall.sh ]; then
        ~/Documents/Release/aptall/aptall.sh $@
        exitCode=$?
    else
        gitUpdate
    fi
    sparkleUpdate
else
    gitUpdate
    sparkleUpdate
fi

echo -e '\a'
exit $exitCode

