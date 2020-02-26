#!/bin/bash

inited=true
debugPath=~/Library/Logs/Homebrew
update=false
upgrade=false
cleanup=false
doctor=false

function printInit() {
    echo '#################### INSTALL GUIDE ###################'
    echo 'TODO: INSERT this command to your $SHELL_CONFIG_FILE (except "#!>", "<!#"). '
    echo 'NOTE: This command tested on zsh.'
    echo ''
    echo '#!> echo 'alias brewall="$CUSTOMPATH/brewall.sh;softwareupdate -l;echo \"\a\""' >> $SHELL_CONFIG_FILE && source $SHELL_CONFIG_FILE; chmod 550 $CUSTOMPATH/brewall.sh; touch ~/Library/Application\ Support/com.greengecko.brewall.initializationed <!#'
    echo ''
    echo 'ex) echo 'alias brewall="~/.etc/brewall.sh;upgrade_oh_my_zsh;softwareupdate -l;echo \"\a\""' >> ~/.zshrc && source ~/.zshrc; chmod 550 ~/.etc/brewall.sh; touch ~/Library/Application\ Support/com.greengecko.brewall.initializationed'
    echo ''
    echo 'WARN: Do not modify ">>" to ">". You will lost your $SHELL_CONFIG_FILE forever.'
    echo '      Do not grant write permission all user account. (except path change) '
    echo '          And you should grant your user account permission read and execute. (Recommend grant mode: 550, 500)'
    echo ''
    echo 'INFO: This command will set alias "brewall" in your shell config.'
    echo '      When "brewall" command entered run this script, upgrade oh_my_zsh, check macos update. '
    echo '      And this script will update brew and save logs to ~/Library/Logs/Homebrew.'
    echo '######################################################'
}

ls ~/Library/Application\ Support 2>/dev/null | grep com.greengecko.brewall.initializationed > /dev/null 2>&1
if [ "$?" != "0" ]; then
    inited=false
    echo " WARN: Please add \"init\" option to run faster this script."
    echo "USAGE: ./brewall.sh init"
    echo " INFO: This option will print install guide."
fi

if [ "$1" == "init" ]; then
    if [ "$inited" == "false" ]; then
        printInit
    else
        echo "You are already configured this script."
    fi
    exit 0
fi

echo -e "\033[32mInitiated time: $(date)\033[m"

while true; do
    ping -c 1 -W 1 -q "www.google.com" &> /dev/null
    if [ "$?" != "0" ]; then
        echo -e "\033[31mCheck your internet connection.\033[m"
        sleep 1
    else
        break
    fi
done

brew update 2> $debugPath/brew_update_debug.log
if [ "$?" != "0" ]; then
    update=true
else
    rm $debugPath/brew_update_debug.log
fi
brew upgrade 2> $debugPath/brew_upgrade_debug.log
if [ "$?" != "0" ]; then
    upgrade=true
else
    rm $debugPath/brew_upgrade_debug.log
fi
brew cleanup 2> $debugPath/brew_cleanup_debug.log
if [ "$?" != "0" ]; then
    cleanup=true
else
    rm $debugPath/brew_cleanup_debug.log
fi
brew doctor 2> $debugPath/brew_doctor_debug.log
if [ "$?" != "0" ]; then
    doctor=true
else
    rm $debugPath/brew_doctor_debug.log
fi
if [ "$update" = true -o "$upgrade" = true -o "$cleanup" = true -o "$doctor" = true ]; then
    logFiles=$(ls $debugPath |grep brew_ |grep -c debug.log)
    if [ $logFiles == 1 ]; then
        echo -e "\033[31mbrewall has failed and/or occurred warning.\033[m\nbrewall log file located \033[0;1m$debugPath\033[m"
        echo "----- brew log list -----"
    else
        echo -e "\033[31mbrewall has failed and/or occurred warning.\033[m\nbrewall log files located \033[0;1m$debugPath\033[m"
        echo "----- brew logs list -----"
    fi
    ls $debugPath |grep brew_ |grep debug.log
    if [ $logFiles == 1 ]; then
        echo "-------------------------"
    else
        echo "--------------------------"
    fi
    exit 1
else
    echo -e "\033[34mbrewall has successful."
    exit 0
fi
