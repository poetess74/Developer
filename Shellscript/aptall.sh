#!/bin/bash

aptLog=~/.local/logs

update=false
upgrade=false
cleanup=false

echo -e "\033[32mInitiated time: $(date)\033[m"

sudo echo "null" &> /dev/null

sudo apt update 2> $aptLog/apt_update.log
if [ "$?" != "0" ]; then
    update=true
else
    rm -f $aptLog/apt_update.log
fi
sudo apt upgrade 2> $aptLog/apt_upgrade.log
if [ "$?" != "0" ]; then
    upgrade=true
else
    rm -f $aptLog/apt_upgrade.log
fi
sudo apt autoremove 2> $aptLog/apt_autoremove.log
if [ "$?" != "0" ]; then
    cleanup=true
else
    rm -f $aptLog/apt_autoremove.log
fi

if [ "$update" = true -o "$upgrade" = true -o "$cleanup" = true ]; then
    echo -e "\033[31maptall has failed.\033[m"
    echo "--------- ERR LIST --------"
    if [ "$update" = true ]; then
        echo "apt_update.log"
    fi
    if [ "$upgrade" = true ]; then
        echo "apt_upgrade.log"
    fi
    if [ "$cleanup" = true ]; then
        echo "apt_autoremove.log"
    fi
    echo "---------------------------"
else
    echo -e "\033[34maptall has successful. \033[m"
fi
