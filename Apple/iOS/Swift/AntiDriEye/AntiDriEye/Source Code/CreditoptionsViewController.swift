//
//  creditOptionsViewController.swift
//  AntiDriEye
//
//  Created by HM on 2018. 2. 14..
//  Copyright © 2018년 HM. All rights reserved.
//

import UIKit

class CreditoptionsViewController: UITableViewController {
    @IBOutlet weak var currentCredit: UILabel!
    @IBOutlet weak var Buycredit: UIButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if UserInfoDB.sharedInstance.credit > 0 {
            currentCredit.text = String(UserInfoDB.sharedInstance.credit) + "개"
        } else {
            currentCredit.text = "없음"
        }
    }
    @IBAction func buyCredit(_ sender: Any) {
        let alert = UIAlertController(title: nil, message: "기능 준비 중에 있습니다.", preferredStyle: .alert)
        let okAction = UIAlertAction(title: "승인", style: .default, handler: nil)
        alert.addAction(okAction)
        self.present(alert, animated: true, completion: nil)
    }
}
