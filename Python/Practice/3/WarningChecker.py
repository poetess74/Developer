#############################
# WarningChecker.py
# by Hyeongmin Kim
# Green Gecko Games
# 모듈 시작
#############################
import os
import sys
import platform
import time
import timeit
import signal
import getpass
from datetime import datetime

now = datetime.now()
##############################
# 모듈 끝 설정 시작
##############################
AUTO_RELUNCH = True
DEBUG_ENABLE = False
##############################
# 설정 끝 전역 변수 시작
##############################
userInput = ''
userInputNum = 0
userSex = ''
userName = ""
result = ""
userAge = 0
userScore = 0
userSSN = ''
CNT_YEAR = int(now.year)
urgencyBool = False
abortSignal = 0
###############################
# 전역 변수 끝 class 시작
###############################
class const:
    errorMSG = "테스트 참여 조건에 만족하지 않습니다. "
    untrustedAnswer = "신뢰성이 없는 답변"
    privacyMSG = "사용자의 개인정보보호를 위해 검사가 종료되면 자동으로 버퍼를 비우는 작업을 수행합니다. \n검사 결과 및 응답은 어디에도 전송하거나 저장하지 않으므로 안심하세요. \n단 운영을 위해 RAM에 저장하는 것은 제외하며 검사가 완료될 시 응답 데이터는 삭제됩니다. "
###############################
# class 끝 함수 시작
###############################
def clearScreen():
    try:
        if DEBUG_ENABLE == False:
            if platform.system() == 'Windows':
                os.system('cls')
            else:
                os.system('clear')
        else:
            print("clearScreen() raised")
    except EOFError:
        exceptctrlD()

def signalHandler(signal, frame):
    global abortSignal
    abortSignal += 1
    if DEBUG_ENABLE:
        print("\nsignalHandler(signal: %s, frame: %s) raised" % (signal, frame))
    else:
        print(" 키를 눌렀습니다.")
        print("한번 더 ^C 키를 누르시면 즉시 종료됩니다. ")
    if abortSignal < 2:
        autoClearScreen()
    else:
        clearScreen()
    sys.exit(0)

def exceptctrlD():
    try:
        global urgencyBool
        if DEBUG_ENABLE:
            print("^D")
            print("exceptctrlD() raised")
        else:
            print("^D 키를 눌렀습니다.")
            print("테스트를 재시작 합니다. ")
        unexpetectExit(urgencyBool)
    except EOFError:
        exceptctrlD()
        
def autoClearScreen():
    try:
        if DEBUG_ENABLE == False:
            print("\n개인정보보호법에 의거하여 다음 시간 후 버퍼 청소 예정...")
            for temp in range(0, 4):
                print(" %d .." % (3 - temp), end="", flush=True)
                time.sleep(1)
            print(" TIME_OUT")
        else:
            print("autoClearScreen() raised")
        clearScreen()
    except EOFError:
        exceptctrlD()


def unexpetectExit(status):
    try:
        global urgencyBool
        urgencyBool = False
        if DEBUG_ENABLE:
            print("unexpetectExit() raised")
        global result
        global userSex
        global userAge
        global userScore
        global AUTO_RELUNCH

        if status:
            clearScreen()
        else:
            autoClearScreen()

        if AUTO_RELUNCH == False:
            sys.exit(-1)
        else:
            result = ""
            userSex = ''
            userAge = 0
            userScore = 0

            startMessage()
    except EOFError:
        exceptctrlD()


def scoreResult():
    try:
        global urgencyBool
        if DEBUG_ENABLE:
            print("scoreResult() raised")
        global userScore
        global userName
        global result
        if userScore < 0:
            result = "현자"
        elif userScore < 20:
            result = "안전"
        elif userScore < 40:
            result = "보통"
        elif userScore < 60:
            result = "높음"
        elif userScore < 80:
            result = "위험"
        else:
            result = "심각"
        if userName == 'p':
            print("\n검사가 완료되었습니다. 당신의 음란 마귀 수준은 '%s' 입니다. " % (result))
        else:
            print("\n검사가 완료되었습니다. %s님의 음란 마귀 수준은 '%s' 입니다. " % (userName, result))

        if (DEBUG_ENABLE):
            print("DEBUG userScore : %d" % userScore)

        unexpetectExit(urgencyBool)
    except EOFError:
        exceptctrlD()

def startMessage():
    try:
        if DEBUG_ENABLE:
            print("==================== RESTART ====================")
            print("startMessage() raised")
        clearScreen()
        print("음란 마귀 테스트", end="", flush=True)
        if AUTO_RELUNCH and DEBUG_ENABLE:
            print("  [자동 실행] [디버그]")
        elif AUTO_RELUNCH:
            print("  [자동 실행]")
        elif DEBUG_ENABLE:
            print("  [디버그]")
        else:
            print("")
        print("음란 마귀 테스트에 오신것을 환영합니다. \n먼저 참여조건에 만족하는지 확인하는 절차를 거치겠습니다. ")
        print("참여 조건은 테스트가 완료된 후 공개되며 테스트를 다시 시작하려면 ^D 키를 누르십시오. ")
        if DEBUG_ENABLE == False:
            print("\n개인정보 처리방침을 보려면 문항의 질문에 'priv'라 입력하십시오. ")
        userCheck()
    except EOFError:
        exceptctrlD()

def testSuccessful():
    try:
        if DEBUG_ENABLE:
            print("testSuccessful() raised")
        print("음란 마귀 테스트에 적합하신 것으로 보입니다. 그럼 테스트를 시작하겠습니다. ")
        print("\n\n\t\t\t\t\t* 테스트 조건 *")
        print("키스를 해보았고, 남자는 나이가 19세에서 45세, 여자는 19세에서 50세일 경우 테스트가 통과됩니다. ")
        testStart()
    except EOFError:
        exceptctrlD()

def userCheck():
    try:
        global urgencyBool
        global userScore
        global userName
        global userAge
        global userSex
        if DEBUG_ENABLE:
            print("userCheck() raised")
        while True:
            userInput = input("\n참여자의 성함을 입력하세요 (익명 : p) : ")
            if userInput == '':
                continue
            elif userInput.lower() == 'priv':
                print(const.privacyMSG)
                continue
            elif userInput.lower() == 'p':
                print("익명으로 테스트를 진행합니다. ")
                userName = userInput
                break
            else:
                userName = userInput
                break

        print("\n타인의 주민번호를 무단으로 사용할 경우 처벌 받을 수 있습니다. ")
        print("개인정보보호를 위해 결과 및 응답은 어디에도 전송 및 저장하지 않으므로 안심하세요. ")
        print("\n참여자 신원확인 방식을 선택하세요")
        print("""
    1. 주민등록번호
    2. 사회보장번호
    3. 사회보험번호
    4. 개인인증번호
    5. 개인식별번호
                """)
        while True:
            try:
                userInputNum = int(input("신원확인 방식 선택 : "))
                if userInputNum > 0 and userInputNum < 6:
                    if userInputNum != 1:
                        print("다른 기능은 준비중입니다. ") #TODO
                        continue
                    else:
                        break
                else:
                    raise ValueError
            except ValueError:
                print("잘못 입력하셨습니다. ")
                continue

        if userInputNum == 1:
            while True:
                if userInputNum != 1:
                    break
                while True:
                    userInput = getpass.getpass("\n참여자의 주민번호를 입력하세요 ('-' 제외) : ")
                    if userInput.lower() == 'priv':
                        print(const.privacyMSG)
                        continue
                    if userInput == '':
                        continue
                    if userInput.lower() == 'p':
                        print("신원확인은 필수이며 익명으로 진행할 수 없습니다. ")
                        continue
                    try:
                        temp = int(userInput)
                    except ValueError:
                        print("잘못 입력하셨습니다. ")
                        continue
                    if len(userInput) != 13:
                        print("잘못 입력하셨습니다. ")
                        continue
                    userSSN = userInput
                    break
                result = 0
                for i in range(0, 12):
                    try:
                        if i < 8:
                            result += (i + 2) * int(userSSN[i])
                        else:
                            result += (i - 10 + 4) * int(userSSN[i])
                    except ValueError:
                        print("주민번호 유효성 검사중 내부 오류 발생")
                        urgencyBool = True
                        unexpetectExit(urgencyBool)
                        break
                result = (11 - (result % 11)) % 10
                result = str(result)
                if result != userSSN[12]:
                    print("잘못 입력하셨습니다. ")
                    continue
                else:
                    break

            temp = str(CNT_YEAR)
            convertedYear = int(temp[1:4])
            convertedSSN = int(userSSN[0:2])
            if convertedSSN > convertedYear:
                userAge= abs(CNT_YEAR - (1900 + convertedSSN))
            else:
                userAge= abs(convertedYear + convertedSSN)

            if userSSN[6] == '1' or userSSN[6] == '3' or userSSN[6] == '5' or userSSN[6] == '7' or userSSN[6] == '9':
                print("성별은 '남', 나이는 '%d'으로 설정되었습니다. " % userAge)
                userSex = 'm'
            else:
                print("성별은 '여', 나이는 '%d'으로 설정되었습니다. " % userAge)
                userSex = 'f'

        while True:
            userInput = input("\n키스를 해봤다 (y/n) : ")
            userInput = userInput.lower()
            if userInput == '':
                continue
            elif userInput == 'y':
                break
            elif userInput == 'n':
                if userName != 'p':
                    print("%s님은 " % userName, end="", flush=True)
                else:
                    print("당신은 ", end="", flush=True)
                print(const.errorMSG, end="", flush=True)
                print("이유 : 진정으로 사랑하는 사랑이 없는 것 같음")
                unexpetectExit(urgencyBool)
            elif userInput == 'priv':
                print(const.privacyMSG)
                continue
            else:
                print("잘못 입력하셨습니다. ")

        if userAge < 19:
            if userName != 'p':
                print("%s님은 " % userName, end="", flush=True)
            else:
                print("당신은 ", end="", flush=True)
            print(const.errorMSG, end="", flush=True)
            print("이유 : 연령 등급 19+ | 상습적인/과격한 성적인 내용 및 노출")
            unexpetectExit(urgencyBool)
        elif userAge > 45 and (userSex == 'm' or userSex == 'mtf'):
            if userName != 'p':
                print("%s님은 " % userName, end="", flush=True)
            else:
                print("당신은 ", end="", flush=True)
            print(const.errorMSG, end="", flush=True)
            print("이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
            unexpetectExit(urgencyBool)
        elif userAge > 50 and (userSex == 'f' or userSex == 'ftm'):
            if userName != 'p':
                print("%s님은 " % userName, end="", flush=True)
            else:
                print("당신은 ", end="", flush=True)
            print(const.errorMSG, end="", flush=True)
            print("이유 : 아직 성욕이 왕성하다면 건강하십니다. :)")
            unexpetectExit(urgencyBool)

        if userAge < 30 and (userSex == 'm' or userSex == 'mtf'):
            userScore += 10
        elif userAge > 40 and (userSex == 'f' or userSex == 'ftm'):
            userScore += 10

        testSuccessful()
    except EOFError:
        exceptctrlD()

def testStart():
    try:
        global userScore
        global userSex
        global userAge
        if DEBUG_ENABLE:
            print("testStart() raised")
        while True:
            userInput = input("\n섹스를 해봤다 (y/n) : ")
            userInput = userInput.lower()
            if userInput == '':
                continue
            elif userInput == 'priv':
                print(const.privacyMSG)
                continue
            elif userInput == 'y':
                if userSex == 'm' or userSex == 'f':
                    userScore += 5
                else:
                    userScore += 10
                break
            elif userInput == 'n':
                break
            else:
                print("잘못 입력하셨습니다. ")

        while True:
            userInput = input("\n성인물을 봤다 (y/n) : ")
            userInput = userInput.lower()
            if userInput == '':
                continue
            elif userInput == 'priv':
                print(const.privacyMSG)
                continue
            elif userInput == 'y':
                if userSex == 'f' or userSex == 'mtf':
                    userScore += 10
                else:
                    userScore += 5
                break
            elif userInput == 'n':
                while True:
                    start = timeit.default_timer()
                    untrusted = False
                    userInput = input("정말로 19금 콘텐츠를 한번도 안봤습니까? (y/n) : ")
                    userInput = userInput.lower()
                    if userInput == '':
                        continue
                    elif userInput == 'priv':
                        print(const.privacyMSG)
                        continue
                    elif userInput == 'y':
                        end = timeit.default_timer()
                        if (end - start) < 1:
                            untrusted = True
                            print(const.untrustedAnswer)
                        if (DEBUG_ENABLE):
                            print("DEBUG timer: %f" % (end - start))
                        if userSex == 'm' or userSex == 'ftm':
                            if untrusted == False:
                                userScore -= 10
                        else:
                            if untrusted == False:
                                userScore -= 5
                        break
                    elif userInput == 'n':
                        break
                    else:
                        print("잘못 입력하셨습니다. ")
                if userInput == 'y':
                    break
            else:
                print("잘못 입력하셨습니다. ")

        while True:
            userInput = input("\n자위중 기구 삽입을 해봤다 (y/n) : ")
            userInput = userInput.lower()
            if userInput == '':
                continue
            elif userInput == 'priv':
                print(const.privacyMSG)
                continue
            elif userInput == 'y':
                if userSex == 'f' or userSex == 'mtf':
                    userScore += 5
                elif userSex == 'm' or userSex == 'ftm':
                    userScore += 10
                break
            elif userInput == 'n':
                break
            else:
                print("잘못 입력하셨습니다. ")

        print("이제부터 성별에 따라 질문이 달라집니다. ")
        if userSex == 'm' or userSex == 'ftm':
            while True:
                userInput = input("\n한달 이상 사귄 여친이 있거나 있었다 (y/n) : ")
                userInput = userInput.lower()
                if userInput == '':
                    continue
                elif userInput == 'priv':
                    print(const.privacyMSG)
                    continue
                elif userInput == 'y':
                    userScore -= 10
                    break
                elif userInput == 'n':
                    userScore += 5
                    break
                else:
                    print("잘못 입력하셨습니다. ")
        elif userSex == 'f' or userSex == 'mtf':
            while True:
                userInput = input("\n한달 이상 사귄 남친이 있거나 있었다 (y/n) : ")
                userInput = userInput.lower()
                if userInput == '':
                    continue
                elif userInput == 'priv':
                    print(const.privacyMSG)
                    continue
                elif userInput == 'y':
                    userScore -= 5
                    break
                elif userInput == 'n':
                    userScore += 10
                    break
                else:
                    print("잘못 입력하셨습니다. ")

        if userSex == 'm' or userSex == 'ftm':
            while True:
                try:
                    userInputNum = int(input("\n하루 최대 자위 후 사정횟수 : "))
                    raise StopIteration
                except ValueError:
                    print("잘못 입력하셨습니다. ")
                except StopIteration:
                    break

            if userInputNum > 7:
                if userSex == 'm':
                    userScore += 10
                else:
                    userScore += 15
            elif userInputNum > 3 and userInputNum < 8:
                if userSex == 'm':
                    userScore += 5
                else:
                    userScore += 10
            elif userInputNum < 4 and userInputNum > 1:
                if userSex == 'ftm':
                    userInputNum += 5
        else:
            while True:
                userInput = input("\n자위를 해봤다. (y/n) : ")
                userInput = userInput.lower()
                if userInput == '':
                    continue
                elif userInput == 'priv':
                    print(const.privacyMSG)
                    continue
                elif userInput == 'y':
                    if userSex == 'f':
                        userScore += 5 
                    else:
                        userScore += 10
                    break
                elif userInput == 'n':
                    break
                else:
                    print("잘못 입력하셨습니다. ")


        scoreResult()
    except EOFError:
        exceptctrlD()

#################################################
# 함수 끝 코드 시작 
#################################################
try:
    signal.signal(signal.SIGINT, signalHandler)
    if DEBUG_ENABLE:
        print("DEBUG_ENABLE DETECTED")
    if DEBUG_ENABLE and AUTO_RELUNCH:
        print("ENABLED AUTO_RELUNCH")
    if DEBUG_ENABLE and AUTO_RELUNCH == False:
        print("DISABLED AUTO_RELUNCH")
    if DEBUG_ENABLE:
        print("PROGRAM START")
    startMessage()
except EOFError:
    exceptctrlD()
########################################
#  코드 종료
########################################
