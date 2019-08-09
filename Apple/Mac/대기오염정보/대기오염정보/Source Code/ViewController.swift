//
//  ViewController.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 16..
//  Copyright © 2017년 HM. All rights reserved.

import Cocoa
import WebKit

//TODO; : GPS 해결; 검색 안정화; 예보 파싱;

class ViewController: NSViewController, NSTouchBarDelegate {
    static var updating = false
    var search = ""
//글로벌
    @IBOutlet weak var updatetime: NSTextField!
    @IBOutlet weak var basisPoint: NSTextField!
    @IBOutlet weak var btnUpdate: NSButton!
    @IBOutlet weak var lastver: NSTextField!
    @IBOutlet weak var oldver: NSTextField!
    @IBOutlet weak var neterr: NSTextField!
    @IBOutlet weak var updatePrograss: NSProgressIndicator!
    @IBOutlet weak var window: NSTabView!
    @IBOutlet weak var CL: NSButton!
    //NSTouchBar
    @IBOutlet weak var TBupdateTime: NSTextField!
    @IBOutlet weak var netState: NSTextField!
    @IBOutlet weak var TBupdate: NSButton!
    //요약
    @IBOutlet weak var LSearch: NSSearchField!
    @IBOutlet weak var CLocation: NSTextField!
    @IBOutlet weak var fineDust: NSTextField!
    @IBOutlet weak var microDust: NSTextField!
    @IBOutlet weak var calAll: NSTextField!
    @IBOutlet weak var Contents: NSTextField!
    //CAI
    @IBOutlet weak var cal_CLocation: NSTextField!
    @IBOutlet weak var cal_Current: NSTextField!
    @IBOutlet weak var cal_Status: NSTextField!
//PM10
    @IBOutlet weak var pm10_CLocation: NSTextField!
    @IBOutlet weak var pm10_Current: NSTextField!
    @IBOutlet weak var pm10_Status: NSTextField!
    @IBOutlet weak var pm10_Rules: NSTextField!
//PM2.5
    @IBOutlet weak var pm2_CLocation: NSTextField!
    @IBOutlet weak var pm2_Current: NSTextField!
    @IBOutlet weak var pm2_Status: NSTextField!
    @IBOutlet weak var pm2_Rules: NSTextField!
//기타
    @IBOutlet weak var etc_CLocation: NSTextField!
    @IBOutlet weak var etc_o3: NSTextField!
    @IBOutlet weak var etc_so2: NSTextField!
    @IBOutlet weak var etc_co: NSTextField!
    @IBOutlet weak var etc_no2: NSTextField!
//대기 오염 예보
    @IBOutlet weak var foreCast: NSTextField!
//기능 설정 끝
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }

    override func viewDidDisappear() {
        NSApplication.shared.terminate(self)
    }
    
    @IBAction func SearchLocate(_ sender: Any) {
        if LSearch.stringValue != "" {
            search = LSearch.stringValue
        }
    }
    @IBAction func SearchCL(_ sender: Any) {
        self.foreCast.stringValue = "업데이트 중..."
        self.updatetime.stringValue = "갱신 중..."
        self.TBupdateTime.stringValue = "업데이트 중"
        self.netState.textColor = NSColor.white
        self.netState.stringValue = "갱신 중..."
        self.lastver.isHidden = true
        self.neterr.isHidden = true
        self.updatePrograss.isHidden = false
        updatePrograss.startAnimation(self)
        self.basisPoint.isHidden = true
        CL.image = NSImage(named: NSImage.Name(rawValue: "CLing.png"))
        CLLocationApiManager.shared.getCLLocation()
//        while CLLocationApiManager.updating {}
        RestApiManager.shared.getMsrstnAcctoRltmMesureDnsty(
            stationName: CLLocationApiManager.CLLocation,
            dataTerm: "daily",
            pageNo: 1,
            numOfRows: 1,
            handler: handleUpdate)
//        while RestApiManager.updating {}
//        while ViewController.updating {}
        updatePrograss.stopAnimation(self)
        self.updatePrograss.isHidden = true
        self.basisPoint.isHidden = false
        CL.image = NSImage(named: NSImage.Name(rawValue: "CL.png"))
    }
    @IBAction func onUpdatePress(_ sender: Any) {
        self.foreCast.stringValue = "업데이트 중..."
        self.updatetime.stringValue = "갱신 중..."
        self.TBupdateTime.stringValue = "업데이트 중"
        self.netState.textColor = NSColor.white
        self.netState.stringValue = "갱신 중..."
        self.updatePrograss.isHidden = false
        updatePrograss.startAnimation(self)
        self.window.isHidden = true
        self.lastver.isHidden = true
        self.neterr.isHidden = true
        self.basisPoint.isHidden = true
        CL.image = NSImage(named: NSImage.Name(rawValue: "CL.png"))
        self.btnUpdate.isEnabled = false
        self.TBupdate.isEnabled = false
        self.CL.isEnabled = false
        if search != ""{
            RestApiManager.shared.getMsrstnAcctoRltmMesureDnsty(
                    stationName: self.search,
                    dataTerm: "daily",
                    pageNo: 1,
                    numOfRows: 1,
                    handler: handleUpdate)
            self.basisPoint.isHidden = false
        } else {
            self.basisPoint.isHidden = true
            self.updatetime.stringValue = "데이터 없음"
            self.TBupdateTime.stringValue = "데이터 없음"
            
            func dialogOKCancel(question: String, text: String) -> Bool {
                let alert = NSAlert()
                alert.messageText = question
                alert.informativeText = text
                alert.alertStyle = .critical
                alert.addButton(withTitle: "승인")
                return alert.runModal() == .alertFirstButtonReturn
            }
            
            _ = dialogOKCancel(question: "현재 검색 기능을 사용중이지만 검색창이 비어 있습니다. 검색하려는 장소를 검색창에 작성후 다시 시도하세요.", text: "위치 기능을 사용하시려면 환경설정에서 위치기능을 활성화 하세요.")
            
            self.neterr.isHidden = false
            self.netState.textColor = NSColor.red
            self.netState.stringValue = "확인 오류"
        }
        
        self.LSearch.stringValue = ""
        while RestApiManager.updating {}
        while ViewController.updating {}
        self.window.isHidden = false
        updatePrograss.stopAnimation(self)
        self.updatePrograss.isHidden = true
        self.btnUpdate.isEnabled = true
        self.TBupdate.isEnabled = true
        self.CL.isEnabled = true
        
    }
    
    func handleUpdate(info: Info) -> Void {
        ViewController.updating = true
        pm10_Current.stringValue = String(info.pm10Value)
        pm2_Current.stringValue = String(info.pm25Value)
        fineDust.stringValue = String(info.pm10Value)
        microDust.stringValue = String(info.pm25Value)
        calAll.stringValue = String(info.khaiValue)

        CLocation.stringValue = String(info.station)
        cal_CLocation.stringValue = String(info.station)
        pm10_CLocation.stringValue = String(info.station)
        pm2_CLocation.stringValue = String(info.station)
        etc_CLocation.stringValue = String(info.station)
        
        updatetime.stringValue = info.dataTimeStr
        etc_co.stringValue = String(info.coValue)
        cal_Current.stringValue = String(info.khaiValue)
        etc_no2.stringValue = String(info.no2Value)
        etc_o3.stringValue = String(info.o3Value)
        etc_so2.stringValue = String(info.so2Value)
        
        let labels = [
            "공기 상태 최고! 건강하세요!",
            "신선한 공기 많이 마시세요~",
            "쾌적한 날이에요~",
            "그냥 무난한 날이에요~",
            "공기가 탁하네요 조심하세요~",
            "탁한 공기, 마스크 챙기세요~",
            "위험합니다! 외출을 삼가세요!",
            "절대 나가지 마세요!!!" ]
        let colors = [ NSColor.blue, NSColor.cyan, NSColor.green, NSColor.yellow, NSColor.orange, NSColor.magenta, NSColor.red, NSColor.black ]
        
        var status: String
        var color: NSColor
        var pm10step = 0
        var pm25step = 0
        
        if info.pm10Value < 16 {
            pm10step = 0
            status = "최고"
            color = NSColor.blue
        } else if info.pm10Value < 31 {
            pm10step = 1
            status = "좋음"
            color = NSColor.cyan
        } else if info.pm10Value < 41 {
            pm10step = 2
            status = "양호"
            color = NSColor.green
        } else if info.pm10Value < 51 {
            pm10step = 3
            status = "보통"
            color = NSColor.yellow
        } else if info.pm10Value < 76 {
            pm10step = 4
            status = "나쁨"
            color = NSColor.orange
        } else if info.pm10Value < 101 {
            pm10step = 5
            status = "상당히 나쁨"
            color = NSColor.magenta
        } else if info.pm10Value < 151 {
            pm10step = 6
            status = "매우 나쁨"
            color = NSColor.red
        } else {
            pm10step = 7
            status = "최악"
            color = NSColor.black
        }
        
        pm10_Status.stringValue = status
        pm10_Status.textColor = color
        fineDust.stringValue = status
        fineDust.textColor = color
        
        if info.pm25Value < 9 {
            pm25step = 0
            status = "최고"
            color = NSColor.blue
        } else if info.pm25Value < 16 {
            pm25step = 1
            status = "좋음"
            color = NSColor.cyan
        } else if info.pm25Value < 21 {
            pm25step = 2
            status = "양호"
            color = NSColor.green
        } else if info.pm25Value < 26 {
            pm25step = 3
            status = "보통"
            color = NSColor.yellow
        } else if info.pm25Value < 38 {
            pm25step = 4
            status = "나쁨"
            color = NSColor.orange
        } else if info.pm25Value < 51 {
            pm25step = 5
            status = "상당히 나쁨"
            color = NSColor.magenta
        } else if info.pm25Value < 76 {
            pm25step = 6
            status = "매우 나쁨"
            color = NSColor.red
        } else {
            pm25step = 7
            status = "최악"
            color = NSColor.black
        }
        
        microDust.stringValue = status
        microDust.textColor = color
        pm2_Status.stringValue = status
        pm2_Status.textColor = color
        
        let step = (pm10step > pm25step) ? pm10step : pm25step
        Contents.stringValue = labels[step]
        Contents.textColor = colors[step]
        
        if Float(info.coValue)! < 1.001 {
            color = NSColor.blue
        } else if Float(info.coValue)! < 2.001 {
            color = NSColor.cyan
        } else if Float(info.coValue)! < 5.501 {
            color = NSColor.green
        } else if Float(info.coValue)! < 9.001 {
            color = NSColor.yellow
        } else if Float(info.coValue)! < 12.001 {
            color = NSColor.orange
        } else if Float(info.coValue)! < 15.001 {
            color = NSColor.magenta
        } else if Float(info.coValue)! < 32.001 {
            color = NSColor.red
        } else {
            color = NSColor.black
        }
        etc_co.textColor = color
        
        if Float(info.o3Value)! < 0.021 {
            color = NSColor.blue
        } else if Float(info.o3Value)! < 0.031 {
            color = NSColor.cyan
        } else if Float(info.o3Value)! < 0.061 {
            color = NSColor.green
        } else if Float(info.o3Value)! < 0.091 {
            color = NSColor.yellow
        } else if Float(info.o3Value)! < 0.121 {
            color = NSColor.orange
        } else if Float(info.o3Value)! < 0.151 {
            color = NSColor.magenta
        } else if Float(info.o3Value)! < 0.381 {
            color = NSColor.red
        } else {
            color = NSColor.black
        }
        etc_o3.textColor = color
        
        if Float(info.no2Value)! < 0.021 {
            color = NSColor.blue
        } else if Float(info.no2Value)! < 0.031 {
            color = NSColor.cyan
        } else if Float(info.no2Value)! < 0.051 {
            color = NSColor.green
        } else if Float(info.no2Value)! < 0.061 {
            color = NSColor.yellow
        } else if Float(info.no2Value)! < 0.131 {
            color = NSColor.orange
        } else if Float(info.no2Value)! < 0.201 {
            color = NSColor.magenta
        } else if Float(info.no2Value)! < 1.101 {
            color = NSColor.red
        } else {
            color = NSColor.black
        }
        etc_no2.textColor = color
        
        if Float(info.so2Value)! < 0.011 {
            color = NSColor.blue
        } else if Float(info.so2Value)! < 0.021 {
            color = NSColor.cyan
        } else if Float(info.so2Value)! < 0.041 {
            color = NSColor.green
        } else if Float(info.so2Value)! < 0.051 {
            color = NSColor.yellow
        } else if Float(info.so2Value)! < 0.101 {
            color = NSColor.orange
        } else if Float(info.so2Value)! < 0.151 {
            color = NSColor.magenta
        } else if Float(info.so2Value)! < 0.601 {
            color = NSColor.red
        } else {
            color = NSColor.black
        }
        etc_so2.textColor = color
        
        if info.khaiValue < 51 {
            status = "좋음"
            color = NSColor.blue
        } else if info.khaiValue < 101 {
            status = "보통"
            color = NSColor.green
        } else if info.khaiValue < 251 {
            status = "나쁨"
            color = NSColor.orange
        } else {
            status = "매우 나쁨"
            color = NSColor.red
        }
        
        
        calAll.stringValue = status
        calAll.textColor = color
        cal_Status.stringValue = status
        cal_Status.textColor = color
        
        if info.status == 1 {
            self.lastver.isHidden = false
            self.neterr.isHidden = true
            self.netState.textColor = NSColor.blue
            self.netState.stringValue = "최신 버전"
            info.status = 0
        } else {
            self.lastver.isHidden = true
            self.neterr.isHidden = false
            self.netState.textColor = NSColor.red
            self.netState.stringValue = "확인 오류"
        }
        updatePrograss.stopAnimation(self)
        self.updatePrograss.isHidden = true
        ViewController.updating = false
    }
}

