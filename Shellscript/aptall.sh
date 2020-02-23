#!/bin/bash

aptLog=~/.local/logs

update=false
upgrade=false
cleanup=false

function printInit() {
    echo '#################### INSTALL GUIDE ###################'
    echo 'TODO: INSERT this command to your $SHELL_CONFIG_FILE (except "#!>", "<!#"). '
    echo 'NOTE: This command tested on zsh.'
    echo ''
    echo '#!> echo 'alias aptall="$CUSTOMPATH/aptall.sh;echo \"\a\""' >> $SHELL_CONFIG_FILE && source $SHELL_CONFIG_FILE; chmod 550 $CUSTOMPATH/aptall.sh; touch ~/.config/greengecko-aptall.initializationed <!#'
    echo ''
    echo 'ex) echo 'alias aptall="~/.etc/aptall.sh;upgrade_oh_my_zsh;echo \"\a\""' >> ~/.zshrc && source ~/.zshrc; chmod 550 ~/.etc/aptall.sh; touch ~/.config/greengecko-aptall.initializationed'
    echo ''
    echo 'WARN: Do not modify ">>" to ">". You will lost your $SHELL_CONFIG_FILE forever.'
    echo '      Do not grant write permission all user account. (except path change) '
    echo '          And you should grant your user account permission read and execute. (Recommend grant mode: 550, 500)'
    echo ''
    echo 'INFO: This command will set alias "aptall" in your shell config.'
    echo '      When "aptall" command entered run this script, upgrade oh_my_zsh. '
    echo '      And this script will update brew and save logs to ~/.local/logs'
    echo '######################################################'
}

ls ~/.config 2>/dev/null | grep greengecko-aptall.initializationed > /dev/null 2>&1
if [ "$?" != "0" ]; then
    inited=false
    echo " WARN: Please add \"init\" option to run faster this script."
    echo "USAGE: ./aptall.sh init"
    echo " INFO: This option will print install guide."
fi

if [ "$1" == "init" ]; then
    if [ "$inited" == "false" ]; then
        printInit
    else
        echo "You are already configured this script."
    fi
fi

echo -e "\033[32mInitiated time: $(date)\033[m"

while true; do
    ping -c 1 -W 1 -q $pingloc &> /dev/null
    if [ "$?" != "0" ]; then
        echo -e "\033[31mCheck your internet connection.\033[m"
    else
        break
    fi
done

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
