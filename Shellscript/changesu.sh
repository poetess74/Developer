#!/bin/bash

if [ "$1" == "brew" ]; then
    su bard -c "brew $@"
elif [ "$1" == "mysql.server" ]; then
    su bard -c "mysql.server $2"
elif [ "$1" == "brewall" ]; then
    su bard -c "/Users/bard/Library/Scripts/brewall.sh"
elif [ "$1" == "rtlogin" ]; then
    su bard -c "/Users/bard/Library/Scripts/rtlogin.sh $2"
fi
