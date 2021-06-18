#!/bin/bash

banUser=""
checkKill="N"

w
echo ""
ps -ef |grep bash
echo ""
echo "Which do you want kill session PID?"
echo -n "> "
read banUser
if [ x$banUser == x ]; then
    echo "Aborting."
    exit 1
fi
echo -n "Are you sure kill session? PID: $banUser (y/N) : "
read checkKill
if [ "$checkKill" == "y" -o "$checkKill" == "Y" ]; then
    kill -9 $banUser
    if [ "$?" == "0" ]; then
        echo "Successfully killed $banUser"
        exit 0
    else
        echo "Failed kill $banUser"
        exit 1
    fi
else
    echo "Aborting."
    exit 1
fi
