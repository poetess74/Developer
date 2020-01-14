#!/bin/bash

if [ x"$1" == x ];then
    curl wttr.in?M
else
    curl wttr.in/$1?M
fi
