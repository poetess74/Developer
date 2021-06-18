# -*- coding: <UTF-8> -*-

import os
import os.path
import sys
import signal
import time
import random
import platform

######################################################
#Value Start
######################################################
classStudent = 0
picker = 0
picker1 = 0
result = []
inputnum = 0

######################################################
#Souce Code Start
######################################################
def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

def signalHandler(signal, frame):
    print(" 키보드 입력")
    time.sleep(0.5)
    sys.exit(0)

######################################################
try:
    signal.signal(signal.SIGINT, signalHandler)
    clearScreen()
    print("초기화 중...", end="", flush=True)
    time.sleep(5)
    print(" - 완료")
    time.sleep(1)
    clearScreen()
    while True:
        result = []
        picker = 0
        if classStudent <= 1:
            print("전체 학생 수 입력", end="", flush=True)
            classStudent = int(input(" : "))
        print("선출할 학생 수 입력", end="", flush=True)
        picker = int(input(" : "))
        if classStudent <= 1:
            print("오류 : 전체 학생수가 1 보다 작거나 같습니다.")
            time.sleep(5)
            clearScreen()
            continue
        if picker <= 0:
            print("오류 : 선출할 학생수가 0 보다 작거나 같습니다.")
            print("전체 학생수(%d) 를 변경하시려면 \'1\'을 입력하시거나," % (classStudent))
            print("계속 진행하시려면 엔터를 누르십시오.")
            inputkey = input("#]")
            if inputkey == '1':
                clearScreen()
                classStudent = 0
                continue
            else:
                clearScreen()
                continue
            clearScreen()
            continue
        if classStudent <= picker:
            print("오류 : 학생수(%d) 가 선출수(%d) 보다 작거나 같습니다." % (classStudent, picker))
            print("전체 학생수를 변경하시려면 \'1\'을 입력하시거나,")
            print("계속 진행하시려면 엔터를 누르십시오.")
            inputkey = input("#]")
            if inputkey == '1':
                clearScreen()
                classStudent = 0
                continue
            else:
                clearScreen()
                continue
            clearScreen()
            continue
        picker1 = picker
        while picker1 <= picker and picker1 != 0:
            result.append(random.randrange(1, classStudent + 1))
            result = list(set(result))
            picker1 = picker - len(result)
            result.sort()
        clearScreen()
        time.sleep(0.2)
        print("%d명 선출이 완료되었습니다." % (picker))
        print("선출 번호 : ", end="", flush=True)
        print(result)
        time.sleep(1)
        print("계속하시려면 엔터를 누르십시오")
        inputkey = input("")
        if inputkey == "":
            clearScreen()
            continue
 
except EOFError:
    print("^D 키보드 입력")
    time.sleep(0.5)
    sys.exit(0)

except ValueError:
    print("숫자만 입력 가능합니다.")
    classStudent = 0
    picker = 0
    time.sleep(0.5)
    pass
