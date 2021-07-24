#!/bin/bash

cd ~
echo "Enter password for bard. "

if [ "$1" == "mysql.server" ]; then
    su bard -c "mysql.server $2"
    result=$?
elif [ "$1" == "brewall" ]; then
    su bard -c "~/Library/Scripts/brewall/brewall.sh;"
    ln -sF $(find /usr/local/Cellar/macvim/ -name "MacVim.app") ~/Applications/  
    result=$?

    echo "Enter password for poetess. "
    su poetess -c "source ~/.zshrc && omz update"
    result=$?
elif [ "$1" == "rtlogin" ]; then
    su bard -c "~/Library/Scripts/rtlogin.sh $2"
    result=$?
fi

cd - > /dev/null

exit $result
