import os
import sys
import platform
import getpass
import time
import random
import math
import signal

userInput = ''
userInputNum = 0
userSex = ''
userAge = 0

class const:
    errorMSG = "테스트 참여 조건에 만족하지 않습니다. "

def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

print("음란 마귀 테스트")
print("음란 마귀 테스트에 오신것을 환영합니다. \n먼저 참여조건에 만족하는지 확인하는 절차를 거치겠습니다. ")
while True:
    userInput = input("\n키스를 해봤다 (y/n) : ")
    if userInput == 'y':
        break
    elif userInput == 'n':
        print(const.errorMSG, "이유 : 진정으로 사랑하는 사랑이 없는것 같음")
        sys.exit(-1)
    else:
        print("잘못 입력하셨습니다. ")

userInputNum = int(input("\n참여자의 만 나이 : "))
if userInputNum < 19:
    print(const.errorMSG, "이유 : 청소년 이용불가 콘텐츠임")
    sys.exit(-1)
elif userInputNum > 40:
    print(const.errorMSG, "이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
userAge = userInputNum

while True:
    userInput = input("\n참여자의 성별 (m/f) : ")
    if userInput == 'm':
        userSex = 'm'
        break
    elif userInput == 'f':
        userSex = 'f'
        break
    else:
        print("잘못 입력하셨습니다. ")
