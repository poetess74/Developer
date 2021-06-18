//
//  SettingViewController.swift
//  Daum 사전
//
//  Created by HM on 2018. 3. 18..
//  Copyright © 2018년 HM. All rights reserved.
//  Copyright © 2018년 다음카카오. All rights reserved.
//

import UIKit

class SettingViewController: UITableViewController {
    //앱 실행시 초기 화면 시작
    //앱 실행시 초기 화면 끝 || 웹 사이트 데이터 시작
    @IBOutlet weak var cleanWebdata: UIButton!
    //웹 사이트 데이터 끝 || 기타 시작
    @IBOutlet weak var NewsSW: UISwitch!
    @IBOutlet weak var ENCameraNEWLabel: UILabel!
    @IBOutlet weak var ENCameraGET: UIButton!
    @IBOutlet weak var LoadViewURL: UISwitch!
    
    //기타 끝
    
    override func viewDidLoad() {
        super.viewDidLoad()
        if UserDefaults.standard.bool(forKey: "new_news_alert") {
            NewsSW.isOn = true
        }
        if UserDefaults.standard.bool(forKey: "view_web_url") {
            LoadViewURL.isOn = true
        }
    }
    
    @IBAction func webDataClean(_ sender: Any) {
        let alertController = UIAlertController(title: "웹 사이트 데이터 제거",message: "이 동작은 모든 웹 사이트 데이터가 지워지며 실행취소할 수 없습니다.", preferredStyle: UIAlertControllerStyle.alert)
        let informantAction = UIAlertAction(title: "지우기", style: UIAlertActionStyle.destructive, handler: {action in self.cleaning()})
        let cancelAction = UIAlertAction(title: "취소", style: UIAlertActionStyle.cancel, handler: nil)
        alertController.addAction(informantAction)
        alertController.addAction(cancelAction)
        self.present(alertController,animated: true,completion: nil)
    }
    
    private func cleaning() {
        let alertController = UIAlertController(title: nil,message: "변경 사항을 적용하기 위하여 앱을 종료합니다.", preferredStyle: UIAlertControllerStyle.alert)
        let okAction = UIAlertAction(title: "승인", style: UIAlertActionStyle.cancel, handler: {action in exit(2)})
        alertController.addAction(okAction)
        self.present(alertController,animated: true,completion: nil)
    }
    @IBAction func ShowURL(_ sender: UISwitch) {
        UserDefaults.standard.set(sender.isOn, forKey: "view_web_url")
    }
}
