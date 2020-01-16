//
//  RootSetViewController.swift
//  Daum 사전
//
//  Created by HM on 2018. 3. 19..
//  Copyright © 2018년 HM. All rights reserved.
//  Copyright © 2018년 다음카카오. All rights reserved.
//

import UIKit

var copyright = true

class RootSetViewController: UIViewController {
    @IBOutlet weak var copyrightLabel: UIButton!
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    @IBAction func dissmiss(_ sender: Any) {
        self.dismiss(animated: true, completion: nil)
    }
    
    override func viewWillDisappear(_ animated: Bool) {
        UserDB.sharedInstance.about = false
    }
    
    @IBAction func copyrightAct(_ sender: Any) {
        if copyright {
            copyrightLabel.setTitle("Copyright ⓒKakao Corp. All rights reserved.", for: .normal)
            copyright = false
        } else {
            copyrightLabel.setTitle("제공된 콘텐츠의 저작권 및 법적 책임은 자료 제공사 또는 글쓴이에 있으며 Kakao의 입장과 다를 수 있습니다.", for: .normal)
            copyright = true
        }
    }
    @IBAction func Easteregg(_ sender: Any) {
        let array = ["오늘 하루도 열심히", "보람찬 하루를 보내자", "오늘 하루도 수고했어", "좋은 결과가 있을거야", "내일로 미루지 말자", "자책하지 말자"]
        let randomIndex = Int(arc4random_uniform(UInt32(array.count)))

        copyrightLabel.setTitle(array[randomIndex], for: .normal)
    }
    
}
