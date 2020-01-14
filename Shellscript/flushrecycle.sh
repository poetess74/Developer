#!/bin/bash

echo "휴지통에 있는 항목들을 영구적으로 지우겠습니까?"
ls ~/.Trash
echo -n "이 동작은 실행 취소할 수 없습니다. (y/N) > "
read input
if [ "$input" == "y" -o "$input" == "Y" ]; then
    rm -rf ~/.Trash/*
    if [ "$?" != "0" ]; then
        sudo rm -rf ~/.Trash/*
        if [ "$?" != "0" ]; then
            exit 1
        else
            exit 0
        fi
    else
        exit 0
    fi
fi
exit 1
