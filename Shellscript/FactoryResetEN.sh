#!/bin/bash

safeGuard=1         #   <-- Safe Trigger

if [ "$(id -u)" = "0" ]; then
    echo -e "\033[31mERR\033[m: This script does not allowed $USER"
    exit 1
fi
echo -e "Welcome to FactoryReset $USER! This prograss will resetting your home folder."
if [ ${safeGuard} -eq 0 ];then
    echo -e "Are you sure delete \033[0;1m$HOME\033[m files? This files will be deleted immediately. "
    echo -en "\033[33mCAUTION\033[m: You can not undo this operation. Do you want to continue? (y/N) > "
    read inputKey
    if [ "${inputKey}" = "Y" -o  "${inputKey}" = "y" ]; then
        cd ~
        rm -rf *
        rm -rf .*
        echo -e "\033[34mOK\033[m: Successfully deleted private files. check your \"$HOME\"."
        echo -e "Please reset $USER password like this: \033[0;1mp$USER!\033[m"
        passwd
        exit 0
    else
        echo -e "\033[31mERR\033[m: User abort FactoryReset progress. "
        exit 1
    fi
else
    echo -e "\033[31mERR\033[m: Please check this file which safeGuard value is false."
    exit 1
fi

