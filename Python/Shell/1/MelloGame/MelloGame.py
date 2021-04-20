#####################################
# 이 프로그램은 텍스트 게임입니다.
# Mello Game Delta           Offline
#####################################
import os
import os.path
import platform
import sys
import signal
import time
import random
import getpass
up = 1
z = 1
i = 1
breakpoint = 0
breakpointo = 0
reject = 0
start = 0
seto = -1
success = -1
loop = 0
money = 0
inmoney = 0
inventory = []
inputkey = [0]
paykey = [0]
secure = 0
result = 0
world = ['헤네시스', '커닝시티', '엘리니아', '시에라', '요세미티', '오르비스', '엘케피탄']
temp = 0
pharmacy = ['빨간 포션 - me : 10', '주황 포션 - me : 20', '하얀 포션 - me : 50', '파란 포션 - me : 30, 흰색 거담제- me : 5']
weapon = ['창 - me : 50', '방패 - me : 50', '아머', '활', '총', '칼']

# userinfo
ID = '1234567890'
PW = '485900'
LV = 1  # Max 200
SP = 15
fSP = 15
quest = []
EXP = 0
NM = 'NAME'
JB = '루미너스'
HP = 50
fHP = 50
MP = 50
fMP = 50
buHP = 15
uHP = 15  # user 가 몬스터에게 입히는 상대적 데미지
fuHP = 15  # == uHP

# enemy
eLV = 1
eHP = 1  # e는 몬스터의 정보
feHP = 1
eMP = 1  # m은 몬스터가 user를 때리는 상대적 데미지
feMP = 1
mHP = 0
poison = 0  # 독 함유량
eEXP = 0  # 경험치 증가


def profile():
    global HP
    global MP
    global SP
    global EXP
    global me
    print("ID : %s, 이름 : %s, 직업 : %s, LV : %s, me : %d" % (ID, NM, JB, LV, money))
    if HP > fHP:
        HP = fHP
    if HP < 0:
        HP = 0
    if EXP <= 0:
        EXP = 0
    if SP == 1 or SP <= 0:
        SP = 0
    print("스테미나 : %s / %s, HP : %s / %s, MP : %s / %s, EXP : %s" % (SP, fSP, HP, fHP, MP, fMP, EXP))
    if HP >= 11 and MP >= 11 and SP >= 11:
        print("=================================================")
    if HP <= 10 or MP <= 10 or SP <= 10:
        print("====================IMPORTANT====================")
        if HP <= 10 and HP >= 5:
            print("\tHP 가 부족합니다.\t\t\t%d" % (HP))
        if HP <= 4 and HP >= 1 and HP != 0:
            print("\tHP 가 위험수준에 도달하였습니다.\t%d" % (HP))
        if HP == 0:
            print("\tHP 가 없습니다.")
        if MP <= 10 and MP >= 5:
            print("\tMP 가 부족합니다.\t\t\t%d" % (MP))
        if MP <= 4 and MP >= 1 and MP != 0:
            print("\tMP 가 위험수준에 도달하였습니다.\t%d" % (MP))
        if MP == 0:
            print("\tMP 가 없습니다.")
        if SP <= 10 and SP >= 5:
            print("\t스테미나가 부족합니다.\t\t\t%d" % (SP))
        if SP <= 4 and SP >= 2 and SP != 1 and SP != 0:
            print("\t스테미나가 위험수준에 도달하였습니다.\t%d" % (SP))
        if SP == 1 and SP == 0:
            print("\t스테미나가 없습니다.")
        print("=================================================")
        time.sleep(2)
        if SP <= 9 and HP <= 0 and MP <= 9 and EXP <= 9 and me <= 9:
            print("GAME OVER!")
            time.sleep(2)
            sys.exit(0)


def levelup():
    global EXP
    global SP
    global HP
    global LV
    global MP
    global uHP
    global buHP
    global fSP
    global money
    global fMP
    global fHP
    if EXP >= 100:
        clearScreen()
        if EXP > 100:
            EXP = (EXP - 100)
        else:
            EXP = 0
        fSP = (fSP + 1)
        SP = fSP
        buHP = (buHP + 2)
        uHP = (uHP + 2)
        if LV == 200:
            pass
        else:
            LV = (LV + 1)
        fHP = (fHP + 2)
        HP = fHP
        fMP = (fMP + 2)
        MP = fMP
        money = (money + 10)
        print("LEVEL UP!")
        profile()
        time.sleep(10)


def store():
    clearScreen()
    global HP
    global MP
    global money
    global SP
    global EXP
    global fuHP
    global eMP
    global uHP
    print("구입하실 목록을 선택하여 주십시오.")
    print("약품 (1), 무기구 (2) me구입 (3) | 가진 돈 : %dme" % (money))
    inputkey = input("\n#] ")
    if '1' == inputkey:
        profile()
        print(pharmacy)
        print("구입하실 목록을 숫자로 선택하여 주십시오\n(시작번호 : 왼쪽부터 1 / 5). 이는 즉시 적용됩니다.")
        inputkey = input("\n#] ")
        if '1' == inputkey:
            print("빨간 포션을 선택하셨습니다.")
            if money >= 10:
                print("HP가 100 회복 됩니다.")
                HP = HP + 100
                money = (money - 10)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("me가 부족합니다.")
                time.sleep(2)
        if '2' == inputkey:
            print("주황 포션을 선택하셨습니다")
            if money >= 20:
                print("HP가 1,000회복 됩니다.")
                HP = HP + 1000
                money = (money - 20)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("me가 부족합니다.")
                time.sleep(2)
        if '3' == inputkey:
            print("하얀 포션을 선택하셨습니다")
            if money >= 50:
                print("HP가 10,000 회복 됩니다.")
                HP = HP + 10000
                money = (money - 50)
                if HP >= fHP:
                    HP = fHP
                time.sleep(2)
            else:
                print("me가 부족합니다.")
                time.sleep(2)
        if '4' == inputkey:
            print("파란 포션을 선택하셨습니다")
            if money >= 30:
                print("MP가 50 회복 됩니다.")
                MP = MP + 50
                money = (money - 30)
                if MP >= fMP:
                    HP = fMP
                time.sleep(2)
            else:
                print("me가 부족합니다.")
                time.sleep(2)
        if '5' == inputkey:
            print("흰색 거담제를 선택하셨습니다.")
            if money >= 5:
                print("스테미나가 100회복됩니다.")
                SP = SP + 100
                money = (money - 5)
                if SP >= fSP:
                    SP = fSP
                time.sleep(2)
            else:
                print("me가 부족합니다.")
                time.sleep(2)
        else:
            print("잘못 입력하셨습니다.\n다시 입력하여 주십시오.")
            time.sleep(5)
            pass
    if '2' == inputkey:
        skill()
        print(weapon)
        print("구입하실 목록을 숫자로 선택하여 주십시오\n(시작번호 : 왼쪽부터 1 / 8). 이는 인벤토리에 저장됩니다.")
        inputkey = input("\n#] ")
        if '1' == inputkey:
            print("창을 선택하셨습니다.")
            if money >= 50:
                inventory.append('창')
                uHP = (uHP + 10)
                fuHP = uHP
                money = (money - 50)
                time.sleep(2)
            else:
                print("me가 부족합니다")
                time.sleep(2)
        if '2' == inputkey:
            print("방패를 선택하셨습니다.")
            if money >= 50:
                inventory.append('방패')
                eMP = (eMP - 10)
                money = (money - 50)
                time.sleep(2)
            else:
                print("me가 부족합니다")
                time.sleep(2)
        else:
            print("재고가 없습니다.")
            time.sleep(2)
    if '3' == inputkey:
        clearScreen()
        print("충전하실 돈을 선택하십시오.")
        print("능력치는 결제수단으로 사용됩니다.")
        print("""
                1 : 10 me       2 : 50  me
                3 : 100 me      4 : 500 me
                5 : 1,000 me    6 : 5,000 me
                """)
        inputkey = input("\n#] ")
        print("결제 수단을 선택하십시오.")
        print("""
                1 : HP          2: MP
                3 : 스테미나    4: EXP
              """)
        paykey = input("\n#] ")
        if inputkey == '1':
            print("충전금액 : 10me")
            print("충전을 시작합니다.")
            if paykey == '1':
                if HP >= 10:
                    HP = (HP - 10)
                    money = (money + 10)
                    print("HP가 10 감소되었습니다")
                else:
                    print("지불 가능한 HP가 없습니다")
                time.sleep(2)
            if paykey == '2':
                if MP >= 10:
                    MP = (MP - 10)
                    money = (money + 10)
                    print("MP가 10 감소되었습니다.")
                else:
                    print("지불 가능한 MP가 없습니다")
                time.sleep(2)
            if paykey == '3':
                if SP >= 10:
                    SP = (SP - 10)
                    money = (money + 10)
                    print("스테미나가 10 감소되었습니다.")
                else:
                    print("지불가능한 스테미나가 없습니다")
                time.sleep(2)
            if paykey == '4':
                if EXP >= 10:
                    EXP = (EXP - 10)
                    money = (money + 10)
                    print("EXP가 10 감소되었습니다.")
                else:
                    print("지불 가능한 EXP가 없습니다")
                time.sleep(2)
        if inputkey == '2':
            print("충전금액 : 50 me")
            print("충전을 시작합니다.")
            if paykey == '1':
                if HP >= 50:
                    HP = (HP - 50)
                    money = (money + 50)
                    print("HP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 HP가 없습니다.")
                time.sleep(2)
            if paykey == '2':
                if MP >= 50:
                    MP = (MP - 50)
                    money = (money + 50)
                    print("MP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 MP가 없습니다.")
                time.sleep(2)
            if paykey == '3':
                if SP >= 50:
                    SP = (SP - 50)
                    money = (money + 50)
                    print("스테미나가 50 감소되었습니다.")
                else:
                    print("지불가능한 스테미나가 없습니다.")
                time.sleep(2)
            if paykey == '4':
                if EXP >= 50:
                    EXP = (EXP - 50)
                    money = (money + 50)
                    print("EXP가 50 감소되었습니다.")
                else:
                    print("지불 가능한 EXP가 없습니다.")
                time.sleep(2)
            if inputkey == '3':
                print("준비중입니다.")
            if inputkey == '4':
                print("준비중입니다.")
            if inputkey == '5':
                print("준비중입니다.")
            if inputkey == '6':
                print("준비중입니다.")


def signalHandler(signal, frame):
    print("\n@] ", end="", flush=True)
    time.sleep(0.05)
    print("^C | CTRL - C")
    print("키보드 입력")
    time.sleep(0.5)
    sys.exit(0)


def Help():
    print("""
            도움말
        HP 가 \'0\'이 되면 결투장은 종료됩니다.
        주요 단축기는 다음과 같습니다.
            i = 인벤토리    o = 설정            a = 공격        d = 스킬 3
            s = 능력치      h = 도움말          q = 퀘스트      g = 스킬 4
            e = 전투도구    z = 아이템 줍기     b = 스킬 1      h = 스킬 5
            w = 지도        x = 대화            c = 스킬 2      p = 프로필
            f = 결투장     < 중요! 스킬 단축기는 최대 5개까지 등록 가능>
            """)


def setting():
    print("하실 작업을 선택하십시오")
    print("""
            1 : 계정 설정
            2 : 게임 설정
            3 : 네트워크 설정 (비활성)
            4 : 초기화
            5 : 프로그램 정보
            6 : 릴리즈 노트 <!>
            """)
    seto = input("\n#] ")
    if '1' == seto:
        pass
    if '2' == seto:
        pass
    if '3' == seto:
        print("서버에 연결할 수 없습니다.")
        print("만약 이 프로그램을 인터넷에서 다운받았을 경우 불법복제품일 수 있습니다.")
        time.sleep(5)
    if '4' == seto:
        print("모든 게임 정보가 삭제되며 프로그램이 종료됩니다.")
        time.sleep(2)
        sys.exit(0)
    if '5' == seto:
        clearScreen()
        print("MelloGame Program 0.1.0Delta")
        print("베타버전이며 사전등록된 개발자만 사용가능합니다.")
        print("다음 소스코드로 판올림 하였으며 업데이트가 없습니다.")
        time.sleep(2)

    if '6' == seto:
        clearScreen()
        print("릴리즈 노트 | 새로운 프로그램이 출시되었습니다.")
        print("새로운 프로그램은 다음을 지원합니다.")
        print("""
            √ 더욱 향상된 보안 기능 : 계정 판별 방식이 완전히 바뀌었습니다.
            √ 안전한 캐릭터 : 몹의 HP가 음수로 되어도 계속 공격하는 문제를 뿌리 뽑                               았습니다.
            √ 더욱 적어진 용량 : 소스코드를 처음부터 다시 작성하여 용량 절약에 도움                                 이 됩니다. 또한 더욱 반응속도가 빠릅니다.
            √ 더욱 예뻐진 UI : \'=\'을 더욱 많이 사용하여 UI를 더욱 예쁘게 처리하였                              습니다.
            \t\t그외에도 더 많은 기능을 찾아보세요
            """)
        time.sleep(15)
        print("지금 업그레이드 하시겠습니까?")
        print("업그레이드 \'1\' 아니요 \'2\'")
        seto = input("\n#] ")
        if seto == '1':
            print("설치파일을 다운받는 중에 문제가 생겼습니다.")
            print("개발자 홈페이지에서 직접 다운로드 해주십시오.")
            time.sleep(2)
        if seto == '2':
            print("업그레이드를 취소하였습니다.")
            time.sleep(1)
        else:
            print("잘못 입력하셨습니다.")


def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')


def fighting():
    global i
    global HP
    global SP
    global EXP
    global money
    global reject
    global temp
    while i == 1:
        print("당신은 이 몬스터와 결투하게 됩니다.")
        print("LV : %d, HP : %d, MP : %d" % (eLV, feHP, feMP))
        print("데미지 : %d" % mHP)  # 디버그
        eHP = feHP
        eMP = feMP
        Fight()
        inputkey = input("\n#] ")
        result = inputkey.lower()
        if "e" == inputkey:
            print("정말로 기권하시겠습니까?")
            print("기권하실 경우 스테미나가 추가로 2개 감소합니다.")
            print("기권하실려면 \'1\'키, 계속하시려면 \'2\'키를 누르십시오.")
            inputkey = input("\n#] ")
            if "1" == inputkey:
                if SP >= 4:
                    print("기권 요청을 완료하였습니다.")
                    SP = (SP - 4)
                    reject = 1
                    time.sleep(2)
                    i = 0
                else:
                    print("기권을 완료할 수 없습니다.")
                    time.sleep(2)
                    clearScreen()
                    continue
            if "2" == inputkey:
                clearScreen()
                clearScreen()
                continue
        if "a" == result:
            clearScreen()
            temp = 1
            while eHP > 0 or HP > 0:
                time.sleep(0.5)
                print("진행상황 | %d회 진행중..." % temp)
                if eMP > feMP:
                    eMP = feMP
                if HP <= 0:
                    pass
                else:
                    eHP = (eHP - uHP)
                if eHP >= 1:
                    print("몬스터 HP : %d / %d, 몬스터 MP : %d / %d" % (eHP, feHP, eMP, feMP))
                else:
                    print("몬스터 HP : 0 / %d, 몬스터 MP : 0 / %d" % (feHP, feMP))
                if eHP <= 0:
                    pass
                else:
                    HP = (HP - mHP)
                if HP >= 1:
                    print("캐릭터 HP : %d / %d, 캐릭터 MP : %d / %d" % (HP, fHP, MP, fMP))
                    temp = (temp + 1)
                else:
                    HP = 0
                    print("캐릭터 HP : 0 / %d, 캐릭터 MP : 0 / %d" % (fHP, fMP))
                if HP <= 0 or eHP <= 0:
                    if HP <= 0:
                        print("\t캐릭터가 죽었습니다.")
                        i = 0
                        if SP <= 2:
                            print("스테미나가 부족합니다.")
                            profile()
                            time.sleep()
                            break
                        else:
                            SP = SP - 2
                        if EXP <= 0:
                            EXP = 0
                        else:
                            EXP = EXP - round(eEXP / 2)
                        time.sleep(0.2)
                        print("\t\t결투가 종료되었습니다.")
                        time.sleep(10)
                        clearScreen()
                        profile()
                        time.sleep(10)
                        break
                    else:
                        if eHP <= 0:
                            print("\t몬스터가 죽었습니다.")
                            time.sleep(0.2)
                            print("\t\t결투가 종료되었습니다.")
                            time.sleep(10)
                            clearScreen()
                            i = 0
                        if SP >= 2:
                            EXP = EXP + eEXP
                            SP = SP - 2
                            money = (money + inmoney)
                            if EXP >= 100:
                                levelup()
                            else:
                                profile()
                                time.sleep(10)
                            break
                        else:
                            print("스테미나가 부족합니다.")
                            time.sleep(10)
                            levelup()
                            clearScreen()
                            if EXP != 0:
                                profile()
                            time.sleep(10)
                            break
                        continue


def Fight():
    print("하실 작업을 선택하십시오")
    print("""
            a : 공격    b, c, d, g, h : 스킬    q : 퀘스트  e : 전투 도구
            i : 인벤토리    e : 기권    s = 능력치  o : 설정    p : 프로필
            """)


def skill():
    clearScreen()
    print("능력치 | LV : %d" % LV)
    print("HP : %d / %d, MP : %d / %d, 스테미나 : %d / %d" % (HP, fHP, MP, fMP, SP, fSP))
    print("데미지 : %d / %d | AVG : %d, EXP : %d / 100.0" % (uHP, fuHP, buHP, EXP))
    time.sleep(5)


def progressbar():
    print("[", end="", flush=True)
    while loop == 0:
        global temp
        signal.signal(signal.SIGINT, signalHandler)
        print("#", end="", flush=True)
        time.sleep(0.05)
        temp += 1
        if temp == 50:
            break
    print("]")
    time.sleep(0.5)


def verCheck():
    global up
    global breakpoint
    global breakpointo
    if up != 1:
        clearScreen()
    if up == 1:
        print("새로운 버전이 있습니다. 업그레이드를 해주시기 바랍니다.")
        breakpoint = (breakpoint + 1)
        breakpointo = (10 - breakpoint)
        if breakpointo > 0:
            print("프로그램 종료까지 %d회 남음." % (breakpointo))
        else:
            print("지금 프로그램이 종료되려고 합니다.")
        time.sleep(5)
        clearScreen()
        if breakpoint == 10:
            print("보안문제로 프로그램을 종료합니다.")
            print("다시 실행하여 게임을 계속하거나 업그레이드를 하십시오.")
            time.sleep(5)
            clearScreen()
            sys.exit(-1)


clearScreen()
signal.signal(signal.SIGINT, signalHandler)
print("WELCOME TO TEXT GAME!")
print("게임을 로드할때 까지 잠시만 기다려 주시기 바랍니다.")
progressbar()
while z == 1:
    verCheck()
    if start == 0:
        clearScreen()
        print("WELCOME TO TEXT GAME!")
        print("업데이트 사용 가능")
        print("로드를 완료하였습니다. \n게임을 실행합니다.")
        print("도움말을 실행하려면 \'h\'키를 누르십시오")
        print("로그인 하시려면 \'1\'키를 누르십시오.")
    if success != 0:
        temp = 0
        inputkey = input("\n#] ")
        if "" == inputkey:
            temp = 1
            pass
        result = inputkey.lower()
        if "h" == result:
            clearScreen()
            Help()
            time.sleep(5)
            temp = 1
        if "1" == result:
            clearScreen()
            temp = 1
            print("로그인을 하시거나(1), 회원가입을 하십시오(2).")
            secure = input("\n#] ")
            if '2' == secure:
                clearScreen()
                temp = 1
                print("""
                                다음에 동의합니다.
                    √ 이용약관 동의                         (필수)
                    √ 개인정보 수집 및 이용에 대한 동의     (필수)
                """)
                print("이에 동의하시면 \'1\'키 동의하지 않으시면 \'0\'키를 눌러주시기 바랍니다.")
                inputkey = input("\n#] ")
                if '1' == inputkey:
                    pass
                if '0' == inputkey:
                    print("회원가입을 거부하였습니다.")
                    time.sleep(2)
                    sys.exit(0)
            if '1' == secure:
                while True:
                    clearScreen()
                    print("ID와 PW를 순서대로 입력하십시오.")
                    secure = input("\nID#] ")
                    if ID != secure:
                        print("다시 입력하여 주십시오.")
                        time.sleep(2)
                    if ID == secure:
                        secure = getpass.getpass('\nPW#] ')
                        if PW == secure:
                            success = 0
                            temp = 1
                            start = 1
                            break
                        else:
                            print("다시 입력하여 주십시오.")
                            print("문자가 보이지 않아도 입력은 되고 있습니다.")
                    time.sleep(2)
        else:
            if temp != 1:
                clearScreen()
                Help()
                print("명령어를 찾지 못했습니다.\n \'h\'와\'1\'중에 하나입니다.")
                print("다른 기능은 로그인 해야 사용 가능합니다. \n다시 입력하여 주십시오")
                time.sleep(5)
                continue
            if temp == 1:
                continue
    temp = 0
    if success == 0:
        clearScreen()
        print("새로운 버젼이 나왔습니다.")
        print("최신 버전으로 업그레이드 할 경우\n 더 많은 기능을 지원합니다.")
        print("환영합니다\'%s\'님" % (ID))
        print("하실 작업을 선택하십시오.")
        print("""
                    h : 도움말
                    q : 퀘스트
                    p : 프로필
                    f : 결투장
                    o : 설정 <!>
                    st : 상점
                """)
        inputkey = input("\n#] ")
        if "" == inputkey:
            temp = 1
            pass
        result = inputkey.lower()
        if "st" == result:
            store()
        if "h" == result:
            temp = 1
            clearScreen()
            Help()
            time.sleep(5)
        if "q" == result:
            temp = 1
            clearScreen()
            if quest == 0:
                print("퀘스트가 존재하지 않습니다.\n결투장에서 퀘스트를 수락할 수 있습니다.")
                time.sleep(3)
            else:
                print("퀘스트가 %s개 존재합니다.\n자세한 내용을 확인하시려면 \'1\'키를 누르십시오 (준비중)" % (quest))
                time.sleep(5)
        if "p" == result:
            temp = 1
            clearScreen()
            profile()
            time.sleep(10)
        if "o" == result:
            temp = 1
            clearScreen()
            setting()
            time.sleep(5)
            continue
        if "f" == result:
            temp = 1
            print("로드중입니다. 잠시만 기다리십시오.")
            progressbar()
            clearScreen()
            print("결투장에 오신것을 환영합니다.")
            profile()
            if HP <= 0:
                print("HP 없음")
            if SP <= 1:
                print("스테미나 없음")
            print("하실 작업을 선택하십시오.")
            print("""
                    f : 결투장       p : 프로필      h : 도움말
                    e : 전투도구    i : 인벤토리    s : 능력치
                    w : 지도        o : 설정        q : 퀘스트
                    """)
            inputkey = input("\n#] ")
            result = inputkey.lower()
            if "s" == result:
                skill()
            if "q" == result:
                clearScreen()
                print("%d개의 퀘스트가 있습니다." % (quest))
                time.sleep(2)
            if "o" == result:
                clearScreen()
                setting()
                time.sleep(5)
                continue
            if "b" == result:
                pass
            if "f" == result:
                if SP <= 1:
                    print("죄송합니다. 스테미나가 부족하여 결투장에 진입할 수 없습니다")
                    time.sleep(2)
                if HP <= 0:
                    print("죄송합니다. 당신의 캐릭터는 지금 부활이 필요하므로 결투장에 진입할 수 없습니다.")
                    time.sleep(2)
                else:
                    print("결투장에 오신것을 환영합니다.")
                    print("무작위로 대상을 선택하시겠습니까?")
                    print("예: \'1\' 아니요 \'2\'")
                    inputkey = input("\n#] ")
                    i = 1
                    if '1' == inputkey:
                        fuHP = uHP
                        if LV <= 10:
                            eLV = random.randrange(1, 16)
                            feHP = random.randrange(50, 80)
                            feMP = random.randrange(50, 80)
                            mHP = random.randrange(1, 21)
                            eEXP = random.randrange(1, 21)
                            inmoney = random.randrange(5, 20)
                            poison = random.randrange(0, 6)
                            if uHP >= poison:
                                uHP = (uHP - poison)
                            if HP >= poison:
                                HP = (HP - poison)
                            if MP >= poison:
                                MP = (MP - poison)
                            clearScreen()
                            fighting()
                        if LV > 10 and LV <= 20:
                            eLV = random.randorange(9, 25)
                            feHP = random.randorange(80, 120)
                            feMP = random.randorange(80, 120)
                            mHP = random.randorange(20, 50)
                            eEXP = random.randrange(20, 50)
                            inmoney = random.randrange(20, 40)
                            poison = random.randrange(5, 11)
                            if uHP >= poison:
                                uHP = (uHP - poison)
                            if HP >= poison:
                                HP = (HP - poison)
                            if MP >= poison:
                                MP = (MP - poison)
                            clearScreen()
                            fighting()
                        if LV > 20 and LV <= 30:
                            pass
                        if LV > 170 and LV <= 200:
                            eLV = random.randrange(165, 201)
                            eHP = random.randrange(800000, 1000000)
                            eMP = random.randrange(800000, 1000000)
                            mHP = random.randrange(800000, 1000000)
                            eEXP = random.randrange(1, 5)
                            inmoney = random.randrange(10000, 100000)
                            poison = random.randrange(999, 1001)
                            uHP = (uHP - poison)
                            HP = (HP - poison)
                            MP = (MP - poison)
                            clearScreen()
                            fighting()
                        uHP = fuHP
    else:
        if temp != 1:
            print("명령어를 찾지 못했습니다.")
            print("다시 입력하여 주십시오")
            time.sleep(2)
            continue
        if temp == 1:
            continue
