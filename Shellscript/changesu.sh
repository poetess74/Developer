#!/bin/bash

if [ "$1" == "brew" ]; then
    su bard -c "brew $@"
elif [ "$1" == "brewall" ]; then
    su bard -c "/Users/bard/Library/Scripts/brewall/brewall.sh; cd /Users/bard/Library/Scripts/brewall; git pull origin master; cd - > /dev/null"
elif [ "$1" == "rtlogin" ]; then
    su bard -c "/Users/bard/Library/Scripts/rtlogin.sh $2"
fi
