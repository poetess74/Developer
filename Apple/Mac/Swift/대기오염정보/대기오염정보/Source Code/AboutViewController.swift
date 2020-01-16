//
//  AboutViewController.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 17..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class AboutViewController : NSViewController {
    @IBOutlet weak var devName: NSTextField!
    @IBOutlet weak var version: NSTextField!
    @IBOutlet weak var copyright: NSTextField!
    @IBOutlet weak var userprofile1: NSTextField!//홈
    @IBOutlet weak var userprofile2: NSTextField!//엄
    @IBOutlet weak var devURLbtn: NSButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()
                
        if let version = Bundle.main.infoDictionary?["CFBundleShortVersionString"] as? String {
            self.version.stringValue = version
        }
        if let copyright = Bundle.main.infoDictionary?["CFCopyright"] as? String {
            self.copyright.stringValue = copyright
        }
        devName.stringValue = "Hyeongmin Kim" //KR
//      devName.stringValue = "Peter Cameron" //EN

    }
    
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }

    
    @IBAction func devURLbtnAC(_ sender: Any) {
        NSWorkspace.shared.open(URL(string: "http://greengeckogames.com")!)
    }
    
}
