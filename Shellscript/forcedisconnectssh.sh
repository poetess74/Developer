#!/bin/bash
banUser=""
checkKill="N"
currenttty=$(tty)
currentps=~/Library/Logs/forcedisconnectssh.log


while true; do
    w
    echo ""
    who -uT
    echo -e "\n\033[33mNOTE\033[m: $currenttty is current session."
    echo "Which do you want kill session PID?"
    echo -n "> "
    read banUser
    if [ x$banUser == x ]; then
        echo "Aborting."
        break
    fi
    echo -n "Are you sure kill session? PID: $banUser (y/N) : "
    read checkKill
    if [ "$checkKill" == "y" -o "$checkKill" == "Y" ]; then
        kill -9 $banUser
        if [ $? != 0 ]; then
            sudo kill -9 $banUser
            if [ $? != 0 ]; then
                echo -e "\033[31mERR\033[m: Permission denied.\a"
                exit 1
            fi
        fi
    elif [ "$checkKill" == "n" -o "$checkKill" == "N" ]; then
        echo "Aborting."
        continue
    elif [ x$checkKill == x ]; then
        echo "Aborting."
        continue
    else
        echo "Aborting."
        continue
    fi
done
exit 0
