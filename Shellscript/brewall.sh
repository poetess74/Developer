#!/bin/bash

inited=true
debugPath=~/Library/Logs/Homebrew
update=false
upgrade=false
cleanup=false
doctor=false
version=1.0.5

function printInit() {
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo '#################### 설치 가이드 ###################'
        echo '해야할 것: 아래 명령어를 당신의 $SHELL_CONFIG_FILE 에 삽입하여 주십시오 ("#!>", "<!#" 제외). '
        echo '메모: 이 명령어는 zsh에서 테스트 되었습니다. '
        echo ''
        echo '#!> echo 'alias brewall="$CUSTOMPATH/brewall.sh;softwareupdate -l;echo \"\a\""' >> $SHELL_CONFIG_FILE && source $SHELL_CONFIG_FILE; chmod 550 $CUSTOMPATH/brewall.sh; touch ~/Library/Application\ Support/com.greengecko.brewall.initializationed <!#'
        echo ''
        echo 'ex) echo 'alias brewall="~/.etc/brewall.sh;upgrade_oh_my_zsh;softwareupdate -l;echo \"\a\""' >> ~/.zshrc && source ~/.zshrc; chmod 550 ~/.etc/brewall.sh; touch ~/Library/Application\ Support/com.greengecko.brewall.initializationed'
        echo ''
        echo '경고: ">>" 에서 ">"로 수정하지 마십시오. 당신은 $SHELL_CONFIG_FILE의 내용을 영원히 잃게 됩니다. '
        echo '      모든 사용자에게 쓰기 권한을 부여하지 마십시오.  (경로 변경 제외) '
        echo '          그리고 당신의 사용자계정에는 읽기와 실행권한을 부여해야 합니다.  (추천 권한 모드: 550 또는 500)'
        echo ''
        echo '정보: 이 명령어는 당신의 $SHELL_CONFIG_FILE 에"brewall" 별칭을 설정합니다. '
        echo '      이 "brewall" 별칭 설정이 완료되면 upgrade_oh_my_zsh 및 시스템 업데이트도 확인할 수 있습니다. '
        echo '      그리고 이 스크립트는 Homebrew를 업데이트하며 로그를 ~/Library/Logs/Homebrew 에 저장할겁니다.'
        echo '######################################################'
    else
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
        echo '          And you should grant your user account permission read and execute. (Recommend grant mode: 550 or 500)'
        echo ''
        echo 'INFO: This command will set alias "brewall" in your $SHELL_CONFIG_FILE'
        echo '      When "brewall" command entered run this script, upgrade oh_my_zsh, check macos update. '
        echo '      And this script will update brew and save logs to ~/Library/Logs/Homebrew.'
        echo '######################################################'
    fi
}

ls ~/Library/Application\ Support 2>/dev/null | grep com.greengecko.brewall.initializationed > /dev/null 2>&1
if [ "$?" != "0" ]; then
    inited=false
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "  경고: \"init\"을 추가하여 이 스크립트를 더 빠르게 실행해 보십시오. "
        echo "사용법: ./brewall.sh init"
        echo "  정보: 이 옵션은 설치 가이드를 프린트할 것입니다. "
    else
        echo " WARN: Please add \"init\" option to run faster this script."
        echo "USAGE: ./brewall.sh init"
        echo " INFO: This option will print install guide."
    fi
fi

if [ "$1" == "init" ]; then
    if [ "$inited" == "false" ]; then
        printInit
    else
        if [ $LANG == "ko_KR.UTF-8" ]; then
            echo "이미 스크립트가 설정되어 있습니다. "
        else
            echo "You are already configured this script."
        fi
    fi
    exit 0
elif [ "$1" == "version" ]; then
    echo $version
    exit 0
fi

ls $debugPath |grep brewall_initiated 
if [ $? == 0 ]; then
    cat $debugPath/brewall_initiated.log
fi
if [ $LANG == "ko_KR.UTF-8" ]; then
    echo -n "[33m이전 시간: $(date)[0m " > $debugPath/brewall_initiated.log
    echo -e "\033[32m시작 시간: $(date)\033[m"
else
    echo -n "[33m Previous time: $(date)[0m " > $debugPath/brewall_initiated.log
    echo -e "\033[32mInitiated time: $(date)\033[m"
fi

while true; do
    ping -c 1 -W 1 -q "www.google.com" &> /dev/null
    if [ "$?" != "0" ]; then
        if [ $LANG == "ko_KR.UTF-8" ]; then
            echo -e "\033[31m인터넷 연결 확인\033[m"
        else
            echo -e "\033[31mCheck your internet connection.\033[m"
        fi
        sleep 1
    else
        break
    fi
done

brew update 2> $debugPath/brew_update_debug.log
if [ "$?" != "0" ]; then
    update=true
    cat $debugPath/brew_update_debug.log
else
    logsize=$(ls -lh $debugPath/brew_update_debug.log | awk '{print $5}')
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "제거중: $HOME/Library/Logs/Homebrew/brew_update_debug.log... ($logsize)"
    else
        echo "Removing: $HOME/Library/Logs/Homebrew/brew_update_debug.log... ($logsize)"
    fi
    rm $debugPath/brew_update_debug.log
fi
brew upgrade 2> $debugPath/brew_upgrade_debug.log
if [ "$?" != "0" ]; then
    upgrade=true
    cat $debugPath/brew_upgrade_debug.log
else
    logsize=$(ls -lh $debugPath/brew_upgrade_debug.log | awk '{print $5}')
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "제거중: $HOME/Library/Logs/Homebrew/brew_upgrade_debug.log... ($logsize)"
    else
        echo "Removing: $HOME/Library/Logs/Homebrew/brew_upgrade_debug.log... ($logsize)"
    fi
    rm $debugPath/brew_upgrade_debug.log
fi
brew cleanup -s 2> $debugPath/brew_cleanup_debug.log
if [ "$?" != "0" ]; then
    cleanup=true
    cat $debugPath/brew_cleanup_debug.log
else
    logsize=$(ls -lh $debugPath/brew_cleanup_debug.log | awk '{print $5}')
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "제거중: $HOME/Library/Logs/Homebrew/brew_cleanup_debug.log... ($logsize)"
    else
        echo "Removing: $HOME/Library/Logs/Homebrew/brew_cleanup_debug.log... ($logsize)"
    fi
    rm $debugPath/brew_cleanup_debug.log
fi
brew doctor 2> $debugPath/brew_doctor_debug.log
if [ "$?" != "0" ]; then
    doctor=true
    cat $debugPath/brew_doctor_debug.log
else
    logsize=$(ls -lh $debugPath/brew_doctor_debug.log | awk '{print $5}')
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "제거중: $HOME/Library/Logs/Homebrew/brew_doctor_debug.log... ($logsize)"
    else
        echo "Removing: $HOME/Library/Logs/Homebrew/brew_doctor_debug.log... ($logsize)"
    fi
    rm $debugPath/brew_doctor_debug.log
fi
if [ "$update" = true -o "$upgrade" = true -o "$cleanup" = true -o "$doctor" = true ]; then
    logFiles=$(ls $debugPath |grep brew_ |grep -c debug.log)
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo -e "\033[31mbrewall이 실패했거나 경고가 발생하였습니다.\033[m\nbrewall 로그 파일이 \033[0;1m$debugPath\033[m 에 위치해 있습니다. "
        echo "----- brew 로그 목록 -----"
    else
        if [ $logFiles == 1 ]; then
            echo -e "\033[31mbrewall has failed and/or occurred warning.\033[m\nbrewall log file located \033[0;1m$debugPath\033[m"
            echo "----- brew log list -----"
        else
            echo -e "\033[31mbrewall has failed and/or occurred warning.\033[m\nbrewall log files located \033[0;1m$debugPath\033[m"
            echo "----- brew logs list -----"
        fi
    fi
    ls $debugPath |grep brew_ |grep debug.log
    if [ $logFiles == 1 ]; then
        echo "-------------------------"
    else
        echo "--------------------------"
    fi
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo "[31m[실패][0m " >> $debugPath/brewall_initiated.log
    else
        echo "[31m[FAILED][0m " >> $debugPath/brewall_initiated.log
    fi
    exit 1
else
    if [ $LANG == "ko_KR.UTF-8" ]; then
        echo -e "\033[34mbrewall 이 성공하였습니다.\033[m"
    else
        echo -e "\033[34mbrewall has successful.\033[m"
    fi
    ls /usr/local/Cellar/macvim/ > /dev/null 2>&1
    if [ "$?" == "0" ]; then
        macvimPath=$(find /usr/local/Cellar/macvim/ -name "MacVim.app")
        if [ "$macvimPath" != "" ]; then
            ln -sF $macvimPath ~/Applications/
            if [ $LANG == "ko_KR.UTF-8" ]; then
                echo "[34m[성공][0m " >> $debugPath/brewall_initiated.log
            else
                echo "[34m[SUCCEED][0m " >> $debugPath/brewall_initiated.log
            fi
            exit 0
        else
            if [ $LANG == "ko_KR.UTF-8" ]; then
                echo -e "\033[31mMacVim.app 바로가기를 생성하는데 실패하였습니다. \033[m"
                echo "[31m[실패][0m " >> $debugPath/brewall_initiated.log
            else
                echo -e "\033[31mFailure making MacVim.app alias.\033[m"
                echo "[31m[FAILED][0m " >> $debugPath/brewall_initiated.log
            fi
            exit 1
        fi
    else
        if [ $LANG == "ko_KR.UTF-8" ]; then
            echo "[34m[성공][0m " >> $debugPath/brewall_initiated.log
        else
            echo "[34m[SUCCEED][0m " >> $debugPath/brewall_initiated.log
        fi
        exit 0
    fi
fi
