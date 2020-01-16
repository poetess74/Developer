//
//  blinkEyeoptionViewController.swift
//  AntiDriEye
//
//  Created by HM on 2018. 2. 14..
//  Copyright © 2018년 HM. All rights reserved.
//

import UIKit

class BlinkeyeOptionViewController: UITableViewController {
    @IBOutlet weak var blinkEyeBool: UISwitch!
    @IBOutlet weak var blinkEyeInterval: UILabel!
    @IBOutlet weak var testAlert: UIButton!
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    override func viewWillAppear(_ animated: Bool) {
        if !UserInfoDB.sharedInstance.blinkalert {
            blinkEyeBool.setOn(false, animated: false)
        }
        var min: UInt = 0
        if UserInfoDB.sharedInstance.blinkeyeTime >= 60 {
            min = UserInfoDB.sharedInstance.blinkeyeTime / 60
            let string = String(min)
            blinkEyeInterval.text = string + "분"
        } else {
            min = UserInfoDB.sharedInstance.blinkeyeTime
            let string = String(min)
            blinkEyeInterval.text = string + "초"
        }
    }
    
    @IBAction func Alertsend(_ sender: Any) {
        let alert = UIAlertController(title: "눈을 깜빡일 시간입니다 (테스트)", message: "눈의 건조함을 피하기 위해서 잠깐동안 눈을 감고 계세요.", preferredStyle: .alert)
        let okAction = UIAlertAction(title: "승인", style: .default, handler: nil)
        alert.addAction(okAction)
        self.present(alert, animated: true, completion: nil)
    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    @IBAction func boolChange(_ sender: Any) {
        UserInfoDB.sharedInstance.blinkalert = blinkEyeBool.isOn
    }
}
