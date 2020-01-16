//
//  SecondViewController.swift
//  Game Memo
//
//  Created by HM on 2017. 11. 9..
//  Copyright © 2017년 HM. All rights reserved.
//

import UIKit

class SecondViewController: UIViewController,
                            UITextViewDelegate {
//오브젝트 선언 시작
    @IBOutlet weak var memoEdittitle: UITextField!
    @IBOutlet weak var memoEdittime: UILabel!
    @IBOutlet weak var memoEditsubtitle: UITextField!
    @IBOutlet weak var memoEditsaveBtn: UIBarButtonItem!
    @IBOutlet weak var memocancelBtn: UIBarButtonItem!
    @IBOutlet weak var memosaveLoad: UIActivityIndicatorView!
    
    // 게임성 시작
    @IBOutlet weak var fiveMinfunnyControl: UISegmentedControl!
    @IBOutlet weak var retryControl: UISegmentedControl!
    @IBOutlet weak var firsttimeControl: UISegmentedControl!
    // 게임성 끝 / 기획 및 시장성 시작
    @IBOutlet weak var trendControl: UISegmentedControl!
    @IBOutlet weak var companyimageControl: UISegmentedControl!
    @IBOutlet weak var systemControl: UISegmentedControl!
    // 기획 및 시장성 끝 / 그래픽 및 사운드 시작
    @IBOutlet weak var playerdesignControl: UISegmentedControl!
    @IBOutlet weak var UIdesignControl: UISegmentedControl!
    @IBOutlet weak var BGMControl: UISegmentedControl!
    // 그래픽 및 사운드 끝 / 세부사항 시작
    @IBOutlet weak var textView: UITextView!
    @IBOutlet weak var tappingLabel: UILabel!
    // 세부사항 끝
// 오브젝트 선언 끝
    @IBAction func memoEditcancel(_ sender: AnyObject) {
        let alertController = UIAlertController(
            title: "메모편집을 정말로 취소하시겠습니까?", message: "저장되지 않은 변경사항은 모두 손실됩니다.", preferredStyle: .alert)
        let defaultAction = UIAlertAction(
            title: "승인", style: .default, handler: nil)
        //you can add custom actions as well
        alertController.addAction(defaultAction)
        
        present(alertController, animated: true, completion: nil)
    }
    
    var timer = Timer()
    
    func startTimer() {
        timer = Timer.scheduledTimer(
            timeInterval: 1,
            target: self,
            selector: #selector(updateTimer),
            userInfo: nil,
            repeats: true)
    }
    
    func stopTimer() {
        timer.invalidate()
    }
    
    @objc func updateTimer() {
        let dateFormatter = DateFormatter()
        dateFormatter.dateFormat = "MM월 dd일 HH:mm"
        memoEdittime.text = dateFormatter.string(from: Date())
    }
    
    override func viewDidLoad(){
        super.viewDidLoad()
        textView.delegate = self
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(animated)
        updateTimer()
        startTimer()
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        textView.endEditing(true)
        memoEdittitle.endEditing(true)
        memoEditsubtitle.endEditing(true)
    }

    override func didReceiveMemoryWarning() {
        let dialog = UIAlertController(title: "메모리 부족", message: "", preferredStyle: .alert)
        
        let action = UIAlertAction(title: "승인", style: UIAlertActionStyle.default)
        dialog.addAction(action)
        
        self.present(dialog, animated: true, completion: nil)
        super.didReceiveMemoryWarning()
    }
    
    func moveTextView(_ textView: UITextView, moveDistance: Int, up: Bool) {
        let moveDuration = 0.35
        let movement: CGFloat = CGFloat(up ? -moveDistance : moveDistance)
        
        UIView.beginAnimations("animateTextView", context: nil)
        UIView.setAnimationBeginsFromCurrentState(true)
        UIView.setAnimationDuration(moveDuration)
        view.frame = view.frame.offsetBy(dx: 0, dy: movement)
        UIView.commitAnimations()
    }
    
    func textViewDidBeginEditing(_ textView: UITextView) {
        tappingLabel.isHidden = true
        moveTextView(textView, moveDistance: 170, up: true)
    }
    
    func textViewDidEndEditing(_ textView: UITextView) {
        moveTextView(textView, moveDistance: 170, up: false)
        if textView.text.count == 0 {
            tappingLabel.isHidden = false
        }
    }
}

