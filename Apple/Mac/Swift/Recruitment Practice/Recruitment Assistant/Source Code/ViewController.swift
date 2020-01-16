//
//  ViewController.swift
//  Recruitment Assistant
//
//  Created by HM on 1/25/19.
//  Copyright © 2019 HM. All rights reserved.
//

import Cocoa

class ViewController: NSViewController {
    @IBOutlet weak var userName: NSTextField!
    @IBOutlet weak var userID: NSTextField!
    @IBOutlet weak var userPIN: NSSecureTextField!
    @IBOutlet weak var userLogin: NSButton!
    @IBOutlet weak var userLanguage: NSPopUpButton!
    @IBOutlet weak var loginStatus: NSTextField!
    @IBOutlet weak var userHelper: NSTextField!
    @IBOutlet weak var userAnswer: NSScrollView!
    @IBOutlet weak var comAnswer: NSTextField!
    @IBOutlet weak var AnswerContainer: NSSplitView!
    
    
    @IBOutlet weak var timerMin: NSTextField!
    @IBOutlet weak var testMessage: NSTextField!
    @IBOutlet weak var sourceDone: NSButton!
    
    private var login = false
    private var editpossble = false
    
    private let originsec = 600
    private var sec = 600
    private var timer = Timer()
    private var isTimer = false
    
    private let Clangtest = ["두개의 문자열을 입력받아 첫 번째 문자열의 앞부분 두자를 두 번째 문자열의 앞부분에 복사하고 다시 뒷부분에 이어 붙여서 저장한 후 두 번째 문자열을 출력하는 프로그램을 작성하시오.\n입력: ABCDE QWERTY | 출력: ABERTYAB", "자연수 N을 입력받아 N이 홀수인 경우에는 1부터 N까지의 홀수를, 짝수인 경우에는 2부터 N까지의 짝수를 모두 출력하는 프로그램을 재귀함수로 작성하시오.\n입력: 15 | 출력: 1 3 5 7 9 11 13 15", "5개짜리 정수형 배열을 선언하고 포인터 변수에 저장한 후 포인터 변수를 이용하여 입력을 받은 후 홀수번째 입력값을 출하는 프로그램을 작성하시오.\n입력: 1 15 23 9 12 | 출력: 1 23 12", "두개의 정수를 입력받아 작은 수부터 큰 수까지 3의 배수이거나 5의 배수인 수들의 합과 평균을 출력하는 프로그램을 작성하시오. (평균은 반올림하여 소수 첫째 자리까지 출력한다.)\n입력: 10 15 | 출력: 합계 : 37\\n평균 : 12.3", "구조체를 사용하여 \"이름\",\"학교명\",\"학년\"을 입력받아 출하는 프로그램을 작성하시오.\n입력: 홍길동 예제초등학교 1 | 출력: 예제초등학교 1학년에 재학중인 홍길동입니다."]
    private let Jlangtest = ["5개의 수를 입력받아 큰 순서대로 나열하는 프로그램을 작성하시오. \n입력: 수1 = 10\\n 수2 = 20\\n 수3 = 10\\n 수4 = 50\\n 수5 = 70\\n | 출력: 100 > 70 > 50 > 20 > 10", "안드로이드앱의 Button을 생성하고 버튼의 텍스트는 'Hello World'로 정의하시오. ", "연도를 입력받아 윤년인지 아닌지를 구별하는 프로그램을 작성하시오. \n입력: 2000 | 출력: 2000년은 윤년입니다. ", "사람의 정보를 입력받고 변경하고 보여주는 'PersonInfo'클래스를 작성하시오. (사람의 정보는 이름, 주민번호, 전화번호, 주소, 직업을 입력받는 것으로 한다. )", "자바 입 • 출력을 이용하여 로컬 영역의 게시판을 만들어 보시오. (기본 기능에는 '리스트 목록 보기', '글쓰기', '글읽기', '글수정', '글삭제' 등이 있다. )"]
    private let Slangtest = ["리스트를 선언하고 안에 '101, 2, 509, 301, 21'숫자를 담는 코드를 작성하시오. ", "리스트를 선언하고 리스트의 각 숫자들을 비교해서 최댓값을 출력하는 코드를 작성하시오. \n출력: 최댓값은 7입니다. ", "변수를 선언하고 현재 시간을 출력하는 프로그램을 작성하시오. ", "특정 상황 (예 0으로 나누기 등)에 대비한 예외처리를 담당하는 코드를 작성하시오. ", "아이폰앱의 UIButton을 활성화하는 Outlet과 Action을 생성하고 버튼의 텍스트는 'Hello World'로 정의하시오. "]
    private let Plangtest = ["숫자 한 개를 입력받은 후 짝수인지 홀수인지 판별한 후 그 숫자의 배수를 출력하시오. (단 프로그램은 is_integer() 메소드를 이용하여 입력값이 소수점 이하일 경우 에러 메시지를 출력하도록 하십시오. )", "섭씨와 화씨 또는 킬로미터와 마일 상호 변환기 프로그램을 작성하시오. (단 C = (F - 32) X (5 / 9), km = mi * 1.6)", "이차 방정식의 근을 구하는 프로그램을 작성하시오. ", "두 분수 간 기초 수학 연산을 실행할 수 있는 계산기를 작성하시오. (단 사용자는 두 분수와 실행하고자 하는 값을 선택해야 한다)", "특정 상황 (예 0으로 나누기 등)에 대비한 예외처리를 담당하는 코드를 작성하시오. "]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

    override var representedObject: Any? {
        didSet {
        // Update the view, if already loaded.
        }
    }

    @IBAction func Authentication(_ sender: NSButton) {
        if !(editpossble) {
            Login()
        } else {
            Logout()
        }
    }
    
    @IBAction func selectLanguage(_ sender: Any) {
        if (login) {
            let userSelect = userLanguage.selectedTag()
            let randomNum = Int(arc4random_uniform(5))
            switch userSelect {
            case 1:
                testMessage.stringValue = Clangtest[randomNum]
            case 2:
                testMessage.stringValue = Clangtest[randomNum]
            case 3:
                testMessage.stringValue = Clangtest[randomNum]
            case 4:
                testMessage.stringValue = Jlangtest[randomNum]
            case 5:
                testMessage.stringValue = Jlangtest[randomNum]
            case 6:
                testMessage.stringValue = Slangtest[randomNum]
            case 7:
                testMessage.stringValue = Plangtest[randomNum]
            default:
                debugPrint("selectLanguage에서 확인되지 않은 예외가 발생되었습니다. \n")
                exit(EXIT_FAILURE)
            }
            AnswerContainer.isHidden = false
            userHelper.isHidden = true
            userLanguage.isEnabled = false
            sourceDone.isEnabled = true
            userHelper.isHidden = true
            runTimer()
        }
    }
    
    @IBAction func Donetest(_ sender: Any) {
        let alert = NSAlert()
        alert.messageText = "수고하셨습니다. "
        alert.informativeText = "이제 답안지와 정답을 맞춰 보시기 바랍니다.\n※ 실제 시험장의 윈도우는 자동으로 닫힙니다. ※"
        alert.addButton(withTitle: "승인")
        alert.alertStyle = .informational
        alert.runModal()
        stopTimer()
    }
    
    
    private func Login() {
        if (userPIN.stringValue.isEmpty && userID.stringValue.isEmpty && userName.stringValue.isEmpty && userLanguage.selectItem(withTag: 0)) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "인적 사항을 기재하셔야 다음 단계로 넘어갈 수 있습니다. "
        } else if (userName.stringValue.isEmpty) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "이름을 기재하여 주십시오. "
        } else if (userID.stringValue.isEmpty) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "지원 코드를 기재하여 주십시오. "
        } else if (userPIN.stringValue.isEmpty) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "본인 확인용 PIN 4자리를 기재하여 주십시오. "
        } else if (userID.stringValue.count != 8) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "지원 코드를 정확히 기재하여 주십시오. "
            userID.stringValue = ""
        } else if (userPIN.stringValue.count != 4) {
            loginStatus.isHidden = false
            loginStatus.stringValue = "본인 확인용 PIN을 정확히 기재하여 주십시오. "
            userPIN.stringValue = ""
        } else {
            loginStatus.isHidden = true
            userID.isEnabled = false
            userName.isEnabled = false
            userLanguage.isEnabled = true
            userPIN.isEnabled = false
            editpossble = true
            login = true
            userLogin.title = "변 경"
            userHelper.stringValue = "테스트에 사용할 선호 언어를 선택하여 주십시오. "
        }
    }
    
    private func Logout() {
        userID.isEnabled = true
        userName.isEnabled = true
        userPIN.isEnabled = true
        timerMin.isHidden = true
        editpossble = false
        userLanguage.isEnabled = false
        userLanguage.selectItem(withTag: 0)
        login = false
        AnswerContainer.isHidden = true
        sourceDone.isEnabled = false
        //TODO: userAnswer.stringValue = ""
        comAnswer.stringValue = ""
        userLogin.title = "인 증"
        stopTimer()
        testMessage.stringValue = ""
        userName.stringValue = ""
        userID.stringValue = ""
        userPIN.stringValue = ""
        userHelper.isHidden = false
        userHelper.stringValue = "먼저 본인 인적사항을 입력하고 '인증'버튼을 눌러 인증하시기 바랍니다. "
    }
    
    private func runTimer() {
        timerMin.isHidden = false
        timer = Timer.scheduledTimer(timeInterval: 1, target: self, selector: (#selector(ViewController.updateTimer)), userInfo: nil, repeats: true)
        self.isTimer = true
    }
    
    @objc private func updateTimer() {
        if (sec > 0) {
            sec -= 1
        } else {
            loginStatus.isHidden = false
            stopTimer()
            loginStatus.stringValue = "제한 시간이 초과되었습니다. "
        }
        timerMin.stringValue = timeString(time: TimeInterval(sec))
    }
    
    private func timeString(time: TimeInterval) -> String {
        let min = Int(time) / 60 % 60
        let sec = Int(time) % 60
        return String(format: "%02i:%02i", min, sec)
    }
    
    private func stopTimer() {
        timer.invalidate()
        timerMin.isHidden = true
        sec = originsec
        self.isTimer = false
        timerMin.stringValue = "\(sec)"
    }
}

