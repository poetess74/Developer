#-*- coding: utf-8 -*-
import os
import os.path
import platform
import sys
import signal
import time
import getpass
import pickle

class const:
    INFO_STAR = '*' * 20
    INFO_HASH = '#' * 20
    INFO_DASH = '=' * 20
    FRONT_TAB = ' ' * 40
    MAX_RETRY = 3
    INITIAL_PASSWORD = '0000'
    BACKUP_PASSWORD = '@sweethome'
    MAX_PASS = 5
    SAVE_FILE_NAME = '.SecureNote.txt'

class tcor:
    HEADER = '\033[95m'
    BLUE = '\033[94m'
    GREEN = '\033[92m'
    WARNING = '\033[93m'
    FAIL = '\033[91m'
    ENDC = '\033[0m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'

_retry = const.MAX_RETRY
_tri_pass = const.MAX_PASS

_memoApp = {
        'password' : const.INITIAL_PASSWORD,
        'memos'    : []
    }

def load():
    global _memoApp

    if os.path.isfile(const.SAVE_FILE_NAME):
        f = open(const.SAVE_FILE_NAME, 'rb')
        _memoApp = pickle.load(f)
        f.close()

def save():
    global _memoApp

    f = open(const.SAVE_FILE_NAME, 'wb')
    pickle.dump(_memoApp, f)
    f.close()

def clearScreen():
    if platform.system() == 'Windows':
        os.system('cls')
    else:
        os.system('clear')

    print(const.INFO_STAR, ' SecureNote v0.1.0 ', const.INFO_STAR)
    print()

def colorPrint(str, tcorType):
    print('%s%s%s' % (tcorType, str, tcor.ENDC))

def signalHandler(signal, frame):
    colorPrint('\n^C 키를 입력하여 프로그램을 종료합니다.', tcor.BLUE)
    sys.exit(0)

def login():
    global _memoApp
    global _retry
    global _tri_pass

    while True:
        if getpass.getpass('로그인 패스워드: ') == _memoApp['password']:
            _tri_pass = const.MAX_PASS
            _retry = const.MAX_RETRY
            break

        print(const.INFO_HASH, '[로그인 실패]', const.INFO_HASH)
        print('실패사유: 잘못된 로그인 패스워드')
        if _retry > 0:
            print('다시 입력하여 주시기 바랍니다.')
            print('남은 시간 :', _tri_pass, ', 남은횟수: ', _retry)
            _retry -= 1
            time.sleep(_tri_pass)
            _tri_pass += 5
        else:
            print(const.FRONT_TAB, '남은횟수: 없음')
            resetPassword()

def resetPassword():
    global _memoApp
    global _retry
    global _memoApp

    retry = const.MAX_RETRY

    print('패스워드를 리셋해야만 합니다.\n백업 패스워드를 입력해주십시오.')
    print('프로그램을 종료하시려면 ^C 키를 누르시기 바랍니다.')

    if len(_memoApp['memos']) > 0:
        colorPrint('단, 프로그램을 종료하면 모든 메모는 영원히 삭제됩니다.', tcor.UNDERLINE)
    
    while True:
        if getpass.getpass('백업 패스워드: ') == const.BACKUP_PASSWORD:
            break

        colorPrint('백업 패스워드가 다릅니다.', tcor.FAIL)
        if retry > 0:
            print(const.FRONT_TAB, '남은횟수: ', retry)
            retry -= 1
        else:
            colorPrint('최대 시도회수를 초과하였습니다. 프로그램을 종료합니다.', tcor.GREEN)
            sys.exit(0)

    _retry = const.MAX_RETRY
    _memoApp['password'] = const.INITIAL_PASSWORD

    save()

    print('패스워드가 초기값으로 리셋되었습니다.\n\n')
    ClearScreen()
    
def changePassword(skipOldPasswordCheck):
    global _memoApp

    clearScreen()
    print(const.INFO_DASH, '패스워드 변경', const.INFO_DASH)

    if not skipOldPasswordCheck:
        oldpassword = getpass.getpass('기존 패스워드 입력: ')

        if oldpassword != _memoApp['password']:
            colorPrint('기존 패스워드가 일치하지 않습니다.', tcor.FAIL)
            time.sleep(1)
            return False

    retry = const.MAX_RETRY

    while True:
        newpassword = getpass.getpass('새로운 패스워드 입력 (4문자 이상): ')
        if len(newpassword) >= 4:
            break

        print('패스워드가 너무 짧습니다. 다시 입력해 주십시오.')
        retry -= 1
        if retry == 0:
            return False
        
    retry = const.MAX_RETRY

    while True:
        newpassword2 = getpass.getpass('새로운 패스워드 재입력: ')
        if newpassword == newpassword2:
            break

        print('재입력한 패스워드가 일치하지 않습니다.')
        retry -= 1

        if retry == 0:
            colorPrint('재입력한  패스워드가 일치하지 않습니다.\n패스워드 변경을 취소합니다.', tcor.FAIL)
            time.sleep(1)
            return False

    _memoApp['password'] = newpassword

    save()

    if not skipOldPasswordCheck:
        colorPrint('\n패스워드가 변경되었습니다. 새로 로그인 해주시기 바랍니다.', tcor.FAIL)
        time.sleep(1)

    return True

def printHelp():
    clearScreen()
    print(const.INFO_DASH, 'HELP', const.INFO_DASH)
    print("메모장 : 이프로그램의 주요기능으로서,\n강력한 보안 기능을 가지고 있어서 안심하고 사용할수 있습니다.")
    print("패스워드 : 패스워드는 메모를 보호하기 위한 수단입니다.")
    print("\t패스워드는 4문자 이상 입력해야 합니다.")
    print("백업 패스워드 : 백업 패스워드는 패스워드 분실시 \n되돌릴 수 있는 유일한 수단입니다.")
    input('\n메뉴로 돌아가려면 엔터를 입력하십시오.')

def aboutProgram():
    clearScreen()
    print(const.INFO_DASH, 'INFO', const.INFO_DASH)
    print('이 프로그램은 라이트 사용자를 위한 비밀메모장입니다.')
    colorPrint('만든이 : 絹田明日賀 ', tcor.GREEN)
    input('\n메뉴로 돌아가려면 엔터를 입력하십시오.')
              
def printBackupPassword():
    clearScreen()
    print(const.INFO_DASH, '백업 패스워드 확인', const.INFO_DASH)
    print('백업 패스워드: [%s]' % (const.BACKUP_PASSWORD))
    input('\n메뉴로 돌아가려면 엔터를 입력하십시오.')

def newMemo():
    global _memoApp

    clearScreen()
    print(const.INFO_DASH, '새로운 메모작성', const.INFO_DASH)

    memo = input('메모 내용입력: ')

    _memoApp['memos'].append(memo)
    save()

def _printMemos():
    print(const.INFO_DASH, '메모목록', const.INFO_DASH)
    if len(_memoApp['memos']) > 0:
        no = 1
        for memo in _memoApp['memos']:
            print('%d - %s' % (no, memo))
        no += 1
    else:
        print('저장된 메모가 없습니다.')

def printMemos():
    clearScreen()
    _printMemos()

    input('\n메뉴로 돌아가려면 엔터를 입력하십시오.')

def editMemo():
    global _memoApp

    while True:
        clearScreen()
        _printMemos()

        print()

        try:
            menu = input('편집할 메모 번호(메뉴로 돌아가려면 엔터): ')

            if menu == '':
                save()
                return

            no = int(menu) - 1
            if no >= 0 or no < len(_memoApp['memos']):
                newMemo = input('메모 내용입력: ')
                _memoApp['memos'][no] = newMemo
            else:
                colorPrint('\n메모 번호가 잘못되었습니다.', tcor.FAIL)
                time.sleep(1)
        except:
            colorPrint('\n메모 번호는 숫자로 입력해 주시기 바랍니다.', tcor.FAIL)
            time.sleep(1)

def deleteMemo():
    global _memoApp

    while True:
        clearScreen()
        _printMemos()

        print()

        try:
            menu = input('삭제할 메모 번호(메뉴로 돌아가려면 엔터): ')

            if menu == '':
                save()
                return

            no = int(menu) - 1
            if no >= 0 or no < len(_memoApp['memos']):
                del _memoApp['memos'][no]
                colorPrint('\n메모가 삭제되었습니다.', tcor.WARNING)
                time.sleep(1)
            else:
                colorPrint('\n메모 번호가 잘못되었습니다.', tcor.FAIL)
                time.sleep(1)
        except:
            colorPrint('\n메모 번호는 숫자로 입력해 주시기 바랍니다.', tcor.FAIL)
            time.sleep(1)

def memoMenu():
    while True:
        clearScreen()
        print('''
========= MEMO =========

1) 메모 편집
2) 메모 새로 만들기
3) 메모 삭제 하기
4) 메모 훑어 보기
5) 상위 메뉴
    ''') 
        
        select = input('메뉴선택: ')

        if select == '1':
            editMemo()
        elif select == '2':
            newMemo()
        elif select == '3':
            deleteMemo()
        elif select == '4':
            printMemos()
        elif select == '5':
            return
        else:
            print('\n잘못된 메뉴번호 입니다. 다시 입력해 주십시오.\n')
            time.sleep(1)

def mainMenu():
    clearScreen()
    print('''
========= MENU =========

1) 패스워드 변경
2) 도움말
3) 이 프로그램에 관하여
4) 메모장
5) 프로그램 종료
6) 백업 패스워드 확인
7) 로그아웃
    ''') 
    
    select = input('메뉴선택: ')

    if select == '1':
        if changePassword(False):
            clearScreen()
            return False
    elif select == '2':
        printHelp()
    elif select == '3':
        aboutProgram()
    elif select == '4':
        memoMenu()
    elif select == '5':
        sys.exit(0)
    elif select == '6':
        printBackupPassword()
    elif select == '7':
        clearScreen()
        return False
    else:
        print('\n잘못된 메뉴번호 입니다. 다시 입력해 주십시오.\n')
        time.sleep(1)
    return True

signal.signal(signal.SIGINT, signalHandler)

clearScreen()
load()

if _memoApp['password'] == const.INITIAL_PASSWORD:
    print('초기 패스워드는 "0000"입니다.')

while True:
    login()
    print('\n성공적으로 로그인되었습니다.\n환영합니다.\n')
    if _memoApp['password'] == const.INITIAL_PASSWORD:
        print('최초 로그인시 반드시 패스워드를 변경해야 합니다.')
        print('패스워드 변경화면으로 이동합니다.')
        time.sleep(2)
        if not changePassword(True):
            colorPrint('\n보안상 문제로 패스워드를 변경하지 않으면 사용할 수 없습니다.', tcor.FAIL)
            colorPrint('프로그램을 종료합니다.', tcor.FAIL)
            time.sleep(1)
            sys.exit(-1)

    time.sleep(1)
    while mainMenu():
        pass

