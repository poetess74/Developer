//
//  HelpViewController.swift
//  대기오염정보
//
//  Created by Hyeongmin Kim on 2017. 7. 18..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class HelpViewController : NSViewController {
    override func viewDidAppear() {
        if let window = view.window {
            window.standardWindowButton(NSWindow.ButtonType.zoomButton)?.isEnabled = false
            window.styleMask.remove(.resizable)
        }
    }
}
