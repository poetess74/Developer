//
//  ReportViewController.swift
//  Daum 사전
//
//  Created by HM on 2018. 3. 19..
//  Copyright © 2018년 HM. All rights reserved.
//  Copyright © 2018년 다음카카오. All rights reserved.
//

import UIKit
import WebKit

class ReportViewController: UIViewController, WKUIDelegate, WKNavigationDelegate, UIWebViewDelegate, UIScrollViewDelegate {
    @IBOutlet weak var webViewContainer: UIView!
    @IBOutlet weak var URLView: UIView!
    @IBOutlet weak var URLLabel: UILabel!
    
    var webView: WKWebView!
    var stoper = false
    var count = 0
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.loadWeb()
        let alertController = UIAlertController(title: nil,message: "로그인을 하시면 'My'메뉴에서 질문과 답변 내용을 확인하실 수 있습니다. 로그인 하시겠습니까?", preferredStyle: UIAlertControllerStyle.alert)
        let okAction = UIAlertAction(title: "승인", style: UIAlertActionStyle.default, handler: {action in self.login()})
        let disAction = UIAlertAction(title: "취소", style: UIAlertActionStyle.cancel, handler: nil)
        alertController.addAction(okAction)
        alertController.addAction(disAction)
        self.present(alertController,animated: true,completion: nil)
    }
    
    override func viewWillAppear(_ animated: Bool) {
        webView.frame = webViewContainer.bounds
        URLView.layer.cornerRadius = 10
        URLView.layer.borderWidth = 1.0
        URLView.layer.borderColor = UIColor.black.cgColor
        URLView.layer.shadowColor = UIColor.black.cgColor
        URLView.layer.shadowOffset = CGSize(width: 3, height: 3)
        URLView.layer.shadowOpacity = 0.7
        URLView.layer.shadowRadius = 4.0
    }
    
    private func login() {
        let myUrl = URL(string: "https://logins.daum.net/accounts/loginform.do?daumauth=1&url=http%3A%2F%2Fcs.daum.net%2Fm%2Fask")
        let myReq = URLRequest(url: myUrl!)
        webView.load(myReq)
    }
    
    func loadWeb() {
        let webConfiguration = WKWebViewConfiguration()
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.uiDelegate = self
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.autoresizingMask = [.flexibleWidth, .flexibleHeight]
        webView.navigationDelegate = self
        
        webViewContainer.addSubview(webView)
        
        let myUrl = URL(string: "https://cs.daum.net/m/")
        let myReq = URLRequest(url: myUrl!)
        
        webView.load(myReq)
        webView.allowsBackForwardNavigationGestures = true
        
        webView.scrollView.delegate = self
    }
    
    func webView(_ webView: WKWebView, didStartProvisionalNavigation navigation: WKNavigation!) {
        if UserDefaults.standard.bool(forKey: "view_web_url") {
            URLView.isHidden = false
        }
    }
    
    func webView(_ webView: WKWebView, didCommit navigation: WKNavigation!) {
        if !UserDB.sharedInstance.about {
            netErrFalse()
            UserDB.sharedInstance.about = true
        }
        
        URLLabel.text = String(describing: webView.url!)
        
        UIApplication.shared.isNetworkActivityIndicatorVisible = true
        let url = String(describing: webView.url!)
        if url.hasPrefix("https://cs.daum.net/m/") {
        } else if url.hasPrefix("https://logins.daum.net/") {
            imNew()
        } else {
            webView.goBack()
        }
        stoper = true
    }
    
    func webView(_ webView: WKWebView, didFinish navigation: WKNavigation!) {
        UIApplication.shared.isNetworkActivityIndicatorVisible = false
        count = 0
        if UserDefaults.standard.bool(forKey: "view_web_url") {
            URLView.isHidden = true
        }
    }
    
    func webView(_ webView: WKWebView, didFailProvisionalNavigation navigation: WKNavigation!, withError error: Error) {
        var present = false
        if count > 60 {
            if !present {
                netErrTrue()
                present = true
                UserDB.sharedInstance.about = false
            }
            self.reload()
        } else {
            count += 1
            self.reload()
        }
    }
    
    private func netErrTrue() {
        let alert = UIAlertController(title: nil, message: "인터넷 연결 확인", preferredStyle: .alert)
        let loadingIndicator = UIActivityIndicatorView(frame: CGRect(x: 10, y: 5, width: 50, height: 50))
        loadingIndicator.hidesWhenStopped = true
        loadingIndicator.activityIndicatorViewStyle = UIActivityIndicatorViewStyle.gray
        loadingIndicator.startAnimating();
        alert.view.addSubview(loadingIndicator)
        present(alert, animated: true, completion: nil)
    }
    
    private func reload() {
        if !stoper {
            self.loadWeb()
            count = count + 1
        }
        webView.reload()
        count = count + 1
    }
    
    private func netErrFalse() {
        dismiss(animated: false, completion: nil)
    }
    
    private func imNew() {
        let alertController = UIAlertController(title: nil,message: "\"아이디/비밀번호 찾기\" 또는 \"회원가입\"은 Daum 홈페이지에서 진행하여 주시기 바랍니다.", preferredStyle: UIAlertControllerStyle.alert)
        let okAction = UIAlertAction(title: "승인", style: UIAlertActionStyle.cancel, handler: {action in self.kakaoLogin()})
        alertController.addAction(okAction)
        self.present(alertController,animated: true,completion: nil)
    }
    
    private func kakaoLogin() {
        let alertController = UIAlertController(title: nil,message: "\"카카오간편로그인\"기능은 준비중이므로 상단의 계정 로그인을 이용하여 주십시오.", preferredStyle: UIAlertControllerStyle.alert)
        let okAction = UIAlertAction(title: "승인", style: UIAlertActionStyle.cancel, handler: nil)
        alertController.addAction(okAction)
        self.present(alertController,animated: true,completion: nil)
    }
    
    override var keyCommands: [UIKeyCommand]? {
        return [
            UIKeyCommand(input: "r", modifierFlags: .command, action: #selector(refreshByCmdR), discoverabilityTitle: "새로 고침"),
            UIKeyCommand(input: ".", modifierFlags: .command, action: #selector(stopByCmdpoint), discoverabilityTitle: "로드 중단"),
            UIKeyCommand(input: "h", modifierFlags: [.shift, .command], action: #selector(goHome), discoverabilityTitle: "홈으로"),
            UIKeyCommand(input: UIKeyInputLeftArrow, modifierFlags: .command, action: #selector(moveBackCmd), discoverabilityTitle: "뒤로 이동"),
            UIKeyCommand(input: UIKeyInputRightArrow, modifierFlags: .command, action: #selector(moveForwardCmd), discoverabilityTitle: "앞으로 이동")
        ]
    }
    
    @objc func refreshByCmdR(sender: UIKeyCommand) {
        reload()
    }
    @objc func stopByCmdpoint(sender: UIKeyCommand) {
        webView.stopLoading()
    }
    @objc func moveBackCmd(sender: UIKeyCommand) {
        webView.goBack()
    }
    @objc func moveForwardCmd(sender: UIKeyCommand) {
        webView.goForward()
    }
    @objc func goHome(sender: UIKeyCommand) {
        let myUrl = URL(string: "https://cs.daum.net/m/")
        let myReq = URLRequest(url: myUrl!)
        webView.load(myReq)
    }
}
