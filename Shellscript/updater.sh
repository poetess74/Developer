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
    noSuchSparkle="\033[33mWRN\033[m: Sparkle framework not found in"
    if [ -d /Applications ]; then
        echo "--- /Applications ---"
        find /Applications -name Sparkle.framework -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
        if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
            echo -e "$noSuchSparkle \033[0;4m/Applications\033[m"
        else
            grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
            while read line; do
                appVersion=$(mdls -raw -name kMDItemVersion $line)
                echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
            done < ~/Library/Logs/find1.log

            nl ~/Library/Logs/find2.log

            rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
        fi
    fi
    if [ -d /Volumes/External\ HD/Applications ]; then
        echo -e "\n--- /Volumes/External HD/Applications ---"
        find /Volumes/External\ HD/Applications -name Sparkle.framework  -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
        if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
            echo -e "$noSuchSparkle \033[0;4m/Volumes/External HD/Applications\033[m"
        else
            grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
            while read line; do
                appVersion=$(mdls -raw -name kMDItemVersion $line)
                echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
            done < ~/Library/Logs/find1.log

            nl ~/Library/Logs/find2.log

            rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
        fi
    fi
    if [ -d $HOME/Applications ]; then
        echo -e "\n--- $HOME/Applications ---"
        find ~/Applications -name Sparkle.framework  -maxdepth 7 -mindepth 3 1> ~/Library/Logs/find.log 2> /dev/null
        if [ "$(cat ~/Library/Logs/find.log)" == "" ]; then
            echo -e "$noSuchSparkle \033[0;4m$HOME/Applications\033[m"
        else
            grep -ioE '.*\.app' ~/Library/Logs/find.log > ~/Library/Logs/find1.log 2>/dev/null
            while read line; do
                appVersion=$(mdls -raw -name kMDItemVersion $line)
                echo "$line ($appVersion)" >> ~/Library/Logs/find2.log
            done < ~/Library/Logs/find1.log

            nl ~/Library/Logs/find2.log

            rm ~/Library/Logs/find.log ~/Library/Logs/find1.log ~/Library/Logs/find2.log 2> /dev/null
        fi
    fi
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

