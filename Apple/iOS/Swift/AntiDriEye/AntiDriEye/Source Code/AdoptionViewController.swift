//
//  AdoptionViewController.swift
//  AntiDriEye
//
//  Created by HM on 2018. 2. 15..
//  Copyright © 2018년 HM. All rights reserved.
//

import UIKit

class AdoptionViewController: UITableViewController {
    @IBOutlet weak var adOptionbool: UISwitch!
    @IBOutlet weak var resetAdoption: UIButton!
    @IBOutlet weak var removesAds: UISwitch!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    override func viewWillAppear(_ animated: Bool) {
        if !UserInfoDB.sharedInstance.bannerAds {
            removesAds.setOn(false, animated: false)
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    @IBAction func removeAd(_ sender: Any) {
        if UserInfoDB.sharedInstance.bannerAds {
            let alert = UIAlertController(title: "광고 프리 이용권 (30일)", message: "광고 프리 이용권을 US$1.09/월에 구독합니다.", preferredStyle: .alert)
            let cancelAction = UIAlertAction(title: "취소", style: .cancel, handler: {(action) in self.ReturnAds()})
            let okAction = UIAlertAction(title: "승인", style: .default, handler: {(action) in self.BuyremoveAds()})
            alert.addAction(cancelAction)
            alert.addAction(okAction)
            self.present(alert, animated: true, completion: nil)
        } else {
            let alert = UIAlertController(title: nil, message: "구독을 취소하려면 Apple지원에 문의하십시오.", preferredStyle: .alert)
            let okAction = UIAlertAction(title: "승인", style: .default, handler: {(action) in self.ReturnAds()})
            alert.addAction(okAction)
            self.present(alert, animated: true, completion: nil)
        }
    }
    
    func BuyremoveAds() {
        UserInfoDB.sharedInstance.bannerAds = false
    }
    
    func ReturnAds() {
        removesAds.setOn(true, animated: false)
        UserInfoDB.sharedInstance.bannerAds = true
    }
    
}
