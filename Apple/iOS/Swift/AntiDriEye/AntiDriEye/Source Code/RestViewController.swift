//
//  RestViewController.swift
//  AntiDriEye
//
//  Created by HM on 2017. 12. 19..
//  Copyright © 2017년 HM. All rights reserved.
//

import UIKit

class RestViewController: UIViewController {
    @IBOutlet weak var done: UIButton!
    @IBOutlet weak var credit: UIButton!
    @IBOutlet weak var remainTime: UILabel!
    @IBOutlet weak var restAlert: UILabel!
    @IBOutlet weak var info: UILabel!
    
    var timer = Timer()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        let min = UserInfoDB.sharedInstance.cooldownTime / 60
        let sec = UserInfoDB.sharedInstance.cooldownTime % 60
        remainTime.text = String(format: "%02d:%02d", min, sec)
        
        if !UserInfoDB.sharedInstance.forceBreak {
            done.isEnabled = true
        } else {
            credit.isHidden = false
            done.isHidden = true
        }
        Timer.scheduledTimer(timeInterval: 1, target: self, selector: #selector(callFunction), userInfo: nil, repeats: true)
    }
    
    @objc func callFunction() {
        let min = UserInfoDB.sharedInstance.cooldownCurrenttime / 60
        let sec = UserInfoDB.sharedInstance.cooldownCurrenttime % 60
        
        remainTime.text = String(format: "%02d:%02d", min, sec)
        
        if UserInfoDB.sharedInstance.cooldownCurrenttime > 0 {
            UserInfoDB.sharedInstance.cooldownCurrenttime -= 1
        } else {
            done.isEnabled = true
            credit.isHidden = true
            done.isHidden = false
            UserInfoDB.sharedInstance.sleepBool = false
            timer.invalidate()
            remainTime.isHidden = true
            restAlert.text = String("복귀할 시간입니다!")
            info.text = String("다시 작업에 복귀할 시간이 다가왔습니다.")
        }
    }
    
    func moveView() {
        let newView = self.storyboard!.instantiateViewController(withIdentifier: "ViewController") as! ViewController
        newView.modalPresentationStyle = UIModalPresentationStyle.overFullScreen
        self.present(newView, animated: true, completion: nil)
        exit(-1)
    }
    
    @IBAction func backWork(_ sender: Any) {
        self.moveView()
    }
    
    @IBAction func useCredit(_ sender: Any) {
        let alert = UIAlertController(title: "크래딧 사용", message: "크래딧을 사용하여 연결을 시도하시겠습니까?", preferredStyle: .alert)
        let useAction = UIAlertAction(title: "승인", style: .destructive, handler: {action in self.creditUse()})
        let otherAction = UIAlertAction(title: "취소", style: .cancel, handler: nil)
        alert.addAction(otherAction)
        alert.addAction(useAction)
        
        self.present(alert, animated: true, completion: nil)
        
        
    }
    
    func creditUse() {
        if UserInfoDB.sharedInstance.credit > 0 {
            UserInfoDB.sharedInstance.credit -= 1
            self.moveView()
        } else {
            let alert = UIAlertController(title: nil, message: "크래딧을 보유하고 있지 않아 강제 휴식을 건너뛸 수 없습니다.", preferredStyle: .alert)
            let otherAction = UIAlertAction(title: "승인", style: .default, handler: nil)
            alert.addAction(otherAction)
            self.present(alert, animated: true, completion: nil)
            credit.isHidden = true
            done.isHidden = false
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
}

