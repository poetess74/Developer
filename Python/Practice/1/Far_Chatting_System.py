import os
import os.path
import platform
import sys
import signal
import time
import getpass
import pickle
import random
loop = 0
loop1 = 0
temp = 0
inputkey = [0]
Chatkey = [0]


def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def clearCmd():
    if platform.system() == 'Windows':
        print('cls',end="", flush=True);
    else:
        print('clear or ⌘k', end="", flush=True);

def signalHandler(signal, frame):
    print("\n@] ", end="", flush=True)
    time.sleep(0.05)
    print("^C")
    print("Keyboard Interrupt")
    time.sleep(0.5)
    sys.exit(0)

clearScreen()
print ("Waiting for signal...")
print ("[", end="", flush=True);
temp = 0
while loop == 0:
    signal.signal(signal.SIGINT, signalHandler)
    print ("#", end="", flush=True);
    time.sleep(0.2)
    temp +=1
    if temp == 50:
        break
print("]")
print("Determination of the Signal...")
loop = 1
temp = 0
print ("[", end="", flush=True);
while loop == 1:
    signal.signal(signal.SIGINT, signalHandler)
    print("#",end="", flush=True);
    time.sleep(0.05)
    temp += 1
    if temp == 50:
        print("]")
        break
print("Complete signal discrimination.")
time.sleep(1.5)
clearScreen()
print("""
        Far Chatting System 2.7.11 (default, Dec 5 2015, 14:44:53)
        [GCC 4.2.1 Compatible Apple LLVM 7.0.0 (clang-700.1.76)] on darwin
        \"Help\"for more information, \"Chat\"for Chatting The other People. 
        Clean the screen command is \"
        """, end="", flush=True)
clearCmd()
print("")
while True:
    signal.signal(signal.SIGINT, signalHandler)
    inputkey = input("\n#] ")
    result = inputkey.lower()
    if "help" == inputkey:
        clearScreen()
        print("""
                \t\t\tCOMMAND
                Help\t:\tHelp This Program
                Chat\t:\tChatting The other People

                \tChat Command
               \'/\'All Command has Start /Key
                """)
        print("\t", end="", flush=True);
        clearCmd()
        print("\t:\tClear The Screen")
    elif "clear" == result or "cls" == result:
        clearScreen()
    elif "chat" == result:
        clearScreen()
        print ("Chat Mode")
        while True:
            signal.signal(signal.SIGINT, signalHandler)
            loop1 = 0
            Chatkey = input("\n$] ")
            temp = 0
            result = Chatkey.lower()
            if "" == Chatkey:
                loop1 = 1
            a = Chatkey.find('/')
            if a == 0:
                result = Chatkey.lower()
                loop1 = 1
                loop2 = 0
                if "/Sys_Starts" == Chatkey:
                    print("System : Not associated with the contact")
                    loop2 = 1
                if "/Sys_Ping" == Chatkey:
                    print("Ping : invalid timeout")
                    loop2 = 1
                if "/" == Chatkey:
                    print("/Sys_Starts\t/Sys_Ping\t/exit\t")
                    print("/", end="", flush=True);
                    clearCmd()
                    loop2 = 1
                if "/clear" == result or "/cls" == result:
                    clearScreen()
                    loop2 = 1
                if "/help" == result:
                    print("""
                        If you Can't Recive Message You Must To This -
                        /Sys_Starts
                        Or You Test Your Network Speed - 
                        /Sys_Ping
                        """)
                    print("\t\t", end="", flush=True);
                    print("/exit\t:\tEnd Chat Mode")
                    loop2 = 1
                if "/exit" == result:
                    print("End Chat Mode")
                    clearScreen()
                    break
                else:
                    if loop2 == 0:
                        print("COMMAND NOT FOUND : ", Chatkey)
            if loop1 != 1:
                print("Sending...")
                print("[", end="", flush=True);
                while loop1 == 0:
                    signal.signal(signal.SIGINT, signalHandler)
                    print("#", end="", flush=True);
                    time.sleep(0.05)
                    temp += 1
                    if temp == 50:
                        print("]")
                        print("invalid timeout")
                        break
    elif "" == result:
        pass
    elif "exit" == result:
        clearScreen()
        sys.exit(0)
           
    else:
        print("COMMAND NOT FOUND : ", inputkey)
