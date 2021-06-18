//
//  SettingViewController.swift
//  AntiDriEye
//
//  Created by HM on 2017. 12. 19..
//  Copyright © 2017년 HM. All rights reserved.
//

import UIKit

class SettingViewController: UITableViewController {
    @IBOutlet weak var startPage: UILabel!
    @IBOutlet weak var usetime: UILabel!
    @IBOutlet weak var resttime: UILabel!
    @IBOutlet weak var blinkeye: UILabel!
    @IBOutlet weak var forceBreak: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        var min: UInt = 0
        var hr: UInt = 0
//        startPage.text = UserInfoDB.sharedInstance.startpage
        
        if UserInfoDB.sharedInstance.nomalTime >= 60 {
            min = UserInfoDB.sharedInstance.nomalTime / 60
            usetime.text = String(min) + "분"
        } else {
            hr = UserInfoDB.sharedInstance.nomalTime / 3600
            min = UserInfoDB.sharedInstance.nomalTime % 3600 / 60
            usetime.text = String(hr) + "시간 " + String(min) + "분"
        }
        
        min = UserInfoDB.sharedInstance.cooldownTime / 60
        resttime.text = String(min) + "분"
        
        
        if UserInfoDB.sharedInstance.blinkalert {
            blinkeye.text = "켬"
        } else {
            blinkeye.text = "끔"
        }
        if UserInfoDB.sharedInstance.forceBreak {
            forceBreak.text = "켬"
        } else {
            forceBreak.text = "끔"
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
}
