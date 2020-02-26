#!/bin/bash

decodeKey="U2FsdGVkX1/QcnEakCnE+eo5FIqAzO57YMpvvbUp14U="
decodePass="P@ssw0rd"
decodeResult=$(echo $decodeKey | openssl enc -aes-256-cbc -a -pass pass:$decodePass -d) 

motdPath=/etc/motd

remotelogin_on() {
    sudo systemsetup -setremotelogin on
    sudo systemsetup -getremotelogin
    sudo systemsetup -setsleep never
    ifconfig | egrep "(inet )"
}

remotelogin_off() {
    sudo systemsetup -f -setremotelogin off
    sudo systemsetup -getremotelogin
    sudo systemsetup -setsleep 10
}

remotelogin_status() {
    echo "$decodeResult" | sudo -S echo "null" &> /dev/null 
    sudo systemsetup -getremotelogin
    sudo systemsetup -getsleep
    ifconfig |egrep "(inet )"
    sudo -k
    ping -c 2 -W 1 -q "www.google.com" &> /dev/null
    if [ "$?" != "0" ]; then
        echo -e "Internet: Disconnected"
    else
        echo -e "Internet: Connected"
    fi
}

if [ "$1" == "off" ]; then
    remotelogin_off
elif [ "$1" == "on" ]; then
    remotelogin_on
elif [ "$1" == "status" ]; then
    remotelogin_status
elif [ "$1" == "help" ]; then
    echo "OVERVIEW: change remotelogin setting"
    echo -e "\033[0;1mREQUIRED\033[m: root or authorized user only run below function"
    echo "USAGE: rtlogin.sh [option]"
    echo "OPTIONS: "
    echo -e "    on: remotelogin enable\n   off: remotelogin disable"
    echo -e "status: remotelogin status\n  help: help this script"
else            # parameter error
    if [ x$1 == x ]; then
        echo "USAGE: rtlogin.sh [option]"
        echo "Please add help and will see help for this script."
    else
        echo -e "\033[31mERR\033[m: command not found: $1"
        echo "Please change $1 to help and will see help for this script."
    fi
    exit 1
fi
exit 0
