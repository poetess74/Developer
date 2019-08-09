//
//  CheckReportViewController.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 19..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class CheckReportViewController : NSViewController {
    @IBOutlet weak var agreeCheckBox: NSButton!
    @IBOutlet weak var agreeCheckLable: NSTextField!
    
    @IBAction func agreeCheckBox(_ sender: Any) {
        self.agreeCheckBox.isHidden = true
        self.agreeCheckLable.isHidden = false
    }
    
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }
    //Do any additional Setup..
    
}
