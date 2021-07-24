#!/bin/bash

cd ~
echo "Enter password for bard. "

if [ "$1" == "mysql.server" ]; then
    su bard -c "mysql.server $2"
    result=$?
elif [ "$1" == "brewall" ]; then
    su bard -c "~/Library/Scripts/brewall/brewall.sh $2 $3;"
    ln -sF $(find /usr/local/Cellar/macvim/ -name "MacVim.app") ~/Applications/  
    result=$?

    if [ $# == 1 ]; then
        echo -e "\nEnter password for poetess. "
        su poetess -c "source ~/.zshrc && youtube-dl -U && omz update"
        result=$?
    fi

elif [ "$1" == "rtlogin" ]; then
    su bard -c "~/Library/Scripts/rtlogin.sh $2"
    result=$?
fi

cd - > /dev/null

exit $result
