//
//  SettingViewController.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 17..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class SettingViewController : NSViewController {
//공통
    @IBOutlet weak var basisSegmented: NSSegmentedControl!
//무료
    var limit = false
    var limperfomance = false
    
    @IBOutlet weak var morethanTextfield: NSTextField!
    @IBOutlet weak var alettimesPopup: NSPopUpButton!
    
    @IBOutlet weak var appautoupdatePopup: NSPopUpButton!
    @IBOutlet weak var limCheckBox: NSButton!
    @IBOutlet weak var priorDonate: NSButton!
    @IBOutlet weak var limLabel: NSTextField!
//프리미엄
    var activeLocation = false
    var search = false
    
    @IBOutlet weak var cleanButton: NSButton!
    @IBOutlet weak var autoclenCheckBox: NSButton!
    @IBOutlet weak var cleanratioPopup: NSPopUpButton!
    @IBOutlet weak var devmodeCheckBox: NSButton!
    @IBOutlet weak var backgroundCheckBox: NSButton!
    @IBOutlet weak var searchCheckBox: NSButton!
    @IBOutlet weak var adappearCheckBox: NSButton!
    @IBOutlet weak var CLBoolCheckBox: NSButton!
    @IBOutlet weak var lifeLabel: NSTextField!
    @IBOutlet weak var souceLabel: NSTextField!
    @IBOutlet weak var searchedCheckBox: NSButton!
    @IBOutlet weak var searchedPopup: NSPopUpButton!
    @IBOutlet weak var rmdockCheckBox: NSButton!
    @IBOutlet weak var mininfo: NSTextField!
    @IBOutlet weak var rmsearchnowBtn: NSButton!
//기능 선언 끝
//공통 작업흐름 시작
//공통 작업흐름 끝
//기본 작업흐름 시작
    @IBAction func alettimesPopup(_ sender: NSPopUpButton) {
        self.morethanTextfield.isHidden = (sender.selectedItem!.tag == 0)
    }
    @IBAction func Donate(_ sender: Any) {
        let storyboard = NSStoryboard(name: NSStoryboard.Name(rawValue: "Main"), bundle: nil)
        let contractUpgradeWindowController = storyboard.instantiateController(withIdentifier: NSStoryboard.SceneIdentifier(rawValue: "contractUpgrade")) as! NSViewController
        
        self.presentViewControllerAsModalWindow(contractUpgradeWindowController)
    }
    @IBAction func limBool(_ sender: NSButton) {
        self.limit = (sender.state.rawValue == 1)
        self.limLabel.isHidden = (sender.state.rawValue == 0)
        self.autoclenCheckBox.isEnabled = (sender.state.rawValue == 0)
        self.cleanratioPopup.isHidden = (sender.state.rawValue == 0)
        self.backgroundCheckBox.isEnabled = (sender.state.rawValue == 0)
        limperfomance = true
        if limperfomance {
            self.rmdockCheckBox.isHidden = true
            self.mininfo.isHidden = false
            self.searchedPopup.isEnabled = false
            
        }
        limCheckBox.state.rawValue == 1 ? (autoclenCheckBox.state = NSControl.StateValue(rawValue: 1)) : (autoclenCheckBox.state = NSControl.StateValue(rawValue: 0))
        limCheckBox.state.rawValue == 1 ? (backgroundCheckBox.state = NSControl.StateValue(rawValue: 0)) : (backgroundCheckBox.state = NSControl.StateValue(rawValue: 0))
        limCheckBox.state.rawValue == 1 ? (rmdockCheckBox.state = NSControl.StateValue(rawValue: 0)) : (rmdockCheckBox.state = NSControl.StateValue(rawValue: 0))
    }
//기본 작업흐름 끝
//프리미엄 작업흐름 시작
    @IBAction func AcleancacheCheckBox(_ sender: NSButton) {
        self.cleanratioPopup.isHidden = (sender.state.rawValue == 0)
    }
    @IBAction func devactiveCheckBox(_ sender: NSButton) {
        UserDefaults.standard.set(sender.state.rawValue == 1, forKey: "dev_mode")
    }
    @IBAction func searchboolCheckbox(_ sender: NSButton) {
        self.searchedPopup.isEnabled = false
        self.CLBoolCheckBox.isHidden = (sender.state.rawValue == 0)
        self.souceLabel.isHidden = (sender.state.rawValue == 0)
        souceLabel.textColor = NSColor.darkGray
        self.lifeLabel.isHidden = (sender.state.rawValue == 1)
        self.searchedCheckBox.isHidden = (sender.state.rawValue == 0)
        self.searchedPopup.isHidden = (sender.state.rawValue == 0)
        self.rmsearchnowBtn.isHidden = (sender.state.rawValue == 0)
        searchCheckBox.state.rawValue == 0 ? (CLBoolCheckBox.state = NSControl.StateValue(rawValue: 0)) : (searchedCheckBox.state = NSControl.StateValue(rawValue: 0))
        if searchedCheckBox.state.rawValue == 0 {
            self.souceLabel.stringValue = "기본 표시 : 검색"
            activeLocation = false
        } else {
            self.souceLabel.stringValue = "기본 표시 : 위치"
            activeLocation = true
        }
    }
   
    @IBAction func CLlocationBool(_ sender: NSButton) {
        if activeLocation == true {
            self.souceLabel.stringValue = "기본 표시 : 검색"
            activeLocation = false
        } else {
            self.souceLabel.stringValue = "기본 표시 : 위치"
            activeLocation = true
        }
    }
    @IBAction func rmSearchBool(_ sender: NSButton) {
        self.search = (sender.state.rawValue == 1)
        self.searchedPopup.isEnabled = (sender.state.rawValue == 1)
    }
    @IBAction func rmclearcache(_ sender: Any) {
    }
    @IBAction func RmSearchBtn(_ sender: Any) {
    }
   
    @IBAction func backBool(_ sender: NSButton) {
        self.rmdockCheckBox.isHidden = (sender.state.rawValue == 0)
        self.mininfo.isHidden = (sender.state.rawValue == 1)
        backgroundCheckBox.state.rawValue == 0 ? (rmdockCheckBox.state = NSControl.StateValue(rawValue: 0)) : (rmdockCheckBox.state = NSControl.StateValue(rawValue: 0))
    }
//프리미엄 작업흐름 끝
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if UserDefaults.standard.bool(forKey: "dev_mode") {
            devmodeCheckBox.state = UserDefaults.standard.bool(forKey: "dev_mode") ? NSControl.StateValue.on : NSControl.StateValue.off
        }
        // Do any additional setup after loading the view.
    }
    
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }
}
