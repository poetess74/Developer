#!/bin/bash

cd ~
echo "Enter password for bard. "

if [ "$1" == "brewall" ]; then
    su bard -c "/Users/bard/Library/Scripts/brewall.sh"
    result=$?
elif [ "$1" == "rtlogin" ]; then
    su bard -c "/Users/bard/Library/Scripts/rtlogin.sh $2"
    result=$?
else
    su bard -c "$@"
    result=$?
fi

cd - > /dev/null

exit $result
