# ~/.zlogout: executed by zsh(1) when login shell exits.

# when leaving the console clear the screen to increase privacy

chmod 700 ~/Temp

cntdate=$(date "+%Y-%m-%d %H:%M:%S")

echo " [36;1m$cntdate [1;31m Session terminated. "

if [ "$SHLVL" = 1 ]; then
    [ -x /usr/bin/clear_console ] && /usr/bin/clear_console -q
fi
