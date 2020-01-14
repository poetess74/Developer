#!/bin/bash
banUser=""
checkKill="N"
currenttty=$(tty)
currentps=~/Library/Logs/forcedisconnectssh.log


while true; do
    w
    ps -ef | grep zsh | awk '{print $2, $5, $6, $7, $8}'
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
    elif [ "$checkKill" == "n" -o "$checkKill" == "N" ]; then
        echo "Aborting."
    elif [ x$checkKill == x ]; then
        echo "Aborting."
    else
        echo "Aborting."
        break
    fi
done

exit 0
