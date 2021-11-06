#!/bin/bash

cd ~

if [ "$1" == "mysql.server" ]; then
    which mysql > /dev/null
    if [ $? == 0 ]; then
        echo "Enter password for bard. "
        su bard -c "mysql.server $2"
    else
        echo "mysql not found"
    fi
    result=$?
elif [ "$1" == "brewall" ]; then
    echo "Enter password for bard. "
    su bard -c "~/Library/Scripts/brewall/brewall.sh $2 $3; echo ''"
    if [ $? == 0 ]; then
        ln -sF $(find /usr/local/Cellar/macvim/ -name "MacVim.app") ~/Applications/  
        if [ $# == 1 ]; then
            echo -e "\nEnter password for poetess. "
            su poetess -c "source ~/.zshrc && youtube-dl -U && omz update"
        fi
        result=$?
    else
        result=$?
    fi
elif [ "$1" == "rtlogin" ]; then
    echo "Enter password for bard. "
    su bard -c "~/Library/Scripts/rtlogin.sh $2"
    result=$?
fi

cd - > /dev/null

exit $result
