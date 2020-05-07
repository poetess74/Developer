#!/bin/bash

if [ "$1" == "brew" ]; then
    su bard -c "brew $@"
elif [ "$1" == "brewall" ]; then
    su bard -c "/Users/bard/Library/Scripts/brewall.sh; echo -n \"Installed brewall script version: \"; /Users/bard/Library/Scripts/brewall.sh version"
elif [ "$1" == "rtlogin" ]; then
    su bard -c "/Users/bard/Library/Scripts/rtlogin.sh $2"
fi
