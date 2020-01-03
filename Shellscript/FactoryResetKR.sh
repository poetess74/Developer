#!/bin/bash

safeGuard=1         #   <-- Safe Trigger

if [ "$(id -u)" = "0" ]; then
    echo -e "\033[31m오류\033[m: 이 작업은 $USER에게는 금지되어 있습니다. "
    exit 1
fi
echo -e "$USER님 FactoryReset에 오신 것을 환영합니다! 이 작업은 당신의 홈 폴더를 초기화할 것입니다. "
if [ ${safeGuard} -eq 0 ];then
    echo -e "정말로 \033[0;1m$HOME\033[m 의 파일들을 삭제하겠습니까? 이 파일들은 즉시 삭제 됩니다. "
    echo -en "\033[33m주의\033[m: 이 작업은 취소할 수 없습니다. 계속하시겠습니까? (예/아니요) > "
    read inputKey
    if [ "${inputKey}" = "예" ]; then
        cd ~
        rm -rf *
        rm -rf .*
        echo -e "\033[34m성공\033[m: 성공적으로 홈 폴더 파일을 삭제했습니다. \"$HOME\" 폴더를 확인하여 주십시오."
        echo -e "$USER의 비밀번호를 다음과 같이 초기화해 주십시오 : \033[0;1mp$USER!\033[m"
        passwd
        exit 0
    else
        echo -e "\033[31m오류\033[m: 사용자가 FactoryReset 작업을 중단했습니다. "
        exit 1
    fi
else
    echo -e "\033[31m오류\033[m: 이 파일을 열어서 safeGuard 변수가 거짓인지 확인하여 주십시오. "
    exit 1
fi

