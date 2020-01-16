//
//  forceBreakViewController.swift
//  AntiDriEye
//
//  Created by HM on 2018. 2. 14..
//  Copyright © 2018년 HM. All rights reserved.
//

import UIKit

class ForcebreakViewController: UITableViewController {
    @IBOutlet weak var forceBreakbool: UISwitch!
    @IBOutlet weak var currentCredit: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        if UserInfoDB.sharedInstance.forceBreak {
            forceBreakbool.setOn(true, animated: false)
        }
        if UserInfoDB.sharedInstance.credit > 0 {
            currentCredit.text = String(UserInfoDB.sharedInstance.credit) + "개"
        } else {
            currentCredit.text = "없음"
        }
    }
    
    @IBAction func forceBreak(_ sender: Any) {
        UserInfoDB.sharedInstance.forceBreak = forceBreakbool.isOn
    }
}
