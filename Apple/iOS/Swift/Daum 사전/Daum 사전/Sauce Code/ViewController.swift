//
//  ViewController.swift
//  Daum 사전
//
//  Created by HM on 2018. 1. 24..
//  Copyright © 2018년 HM. All rights reserved.
//  Copyright © 2018년 다음카카오. All rights reserved.
//

import UIKit
import WebKit

class ViewController: UIViewController, WKUIDelegate, WKNavigationDelegate, UIWebViewDelegate, UIScrollViewDelegate {
    
    @IBOutlet weak var webViewContainer: UIView!
    @IBOutlet weak var URLView: UIView!
    @IBOutlet weak var URLLabel: UILabel!
    
    var webView: WKWebView!
    var stoper = false
    var count = 0
    var refreshControl: UIRefreshControl!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.loadWeb()
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        webView.endEditing(true)
    }
    
    func webView(_ webView: WKWebView, didFailProvisionalNavigation navigation: WKNavigation!, withError error: Error) {
        var present = false
        if count > 60 {
            if !present {
                netErrTrue()
                present = true
            }
            self.reload()
        } else {
            count += 1
            self.reload()
        }
    }
    
    func webView(_ webView: WKWebView, didStartProvisionalNavigation navigation: WKNavigation!) {
        if UserDefaults.standard.bool(forKey: "view_web_url") {
            URLView.isHidden = false
        }
    }
    
    func webView(_ webView: WKWebView, didCommit navigation: WKNavigation!) {
        if !UserDB.sharedInstance.about {
            netErrFalse()
        }
        
        URLLabel.text = String(describing: webView.url!)
        
        UIApplication.shared.isNetworkActivityIndicatorVisible = true
        let url = String(describing: webView.url!)
        if url.hasPrefix("http://alldic.daum.net/") {
        } else if url.hasPrefix("https://logins.daum.net/") {
            imNew()
        } else if url.hasPrefix("https://m.daum.net/") {
            webView.goBack()
            UserDB.sharedInstance.about = true
            About()
        } else {
            webView.goBack()
        }
        stoper = true
    }
    
    private func openSettingView() {
        performSegue(withIdentifier: "SettingViewSegue", sender: nil)
    }
    
    private func About() {
        let alertController = UIAlertController(title: nil,message: "다음사전 설정에 진입하시겠습니까?", preferredStyle: UIAlertControllerStyle.alert)
        let okAction = UIAlertAction(title: "승인", style: UIAlertActionStyle.default, handler: {action in self.openSettingView()})
        let cancelAction = UIAlertAction(title: "취소", style: UIAlertActionStyle.cancel, handler: nil)
        alertController.addAction(okAction)
        alertController.addAction(cancelAction)
        self.present(alertController,animated: true,completion: nil)
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
    
    func loadWeb() {
        let webConfiguration = WKWebViewConfiguration()
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.uiDelegate = self
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.autoresizingMask = [.flexibleWidth, .flexibleHeight]
        webView.navigationDelegate = self
        
        webViewContainer.addSubview(webView)
        
        let myUrl = URL(string: "http://alldic.daum.net/")
        let myReq = URLRequest(url: myUrl!)
        
        webView.load(myReq)
        webView.allowsBackForwardNavigationGestures = true
        
        webView.scrollView.delegate = self
        
        refreshControl = UIRefreshControl()
        webView.scrollView.addSubview(refreshControl)
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
    
    func webView(_ webView: WKWebView, didFinish navigation: WKNavigation!) {
        UIApplication.shared.isNetworkActivityIndicatorVisible = false
        refreshControl.endRefreshing()
        count = 0
        if UserDefaults.standard.bool(forKey: "view_web_url") {
            URLView.isHidden = true
        }
    }
    
    private func reload() {
        if !stoper {
            self.loadWeb()
            count = count + 1
        }
        webView.reload()
        count = count + 1
    }
    
    func scrollViewWillEndDragging(_ scrollView: UIScrollView, withVelocity velocity: CGPoint, targetContentOffset: UnsafeMutablePointer<CGPoint>) {
        if scrollView.contentOffset.y < -145 {
            reload()
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
    private func netErrFalse() {
        dismiss(animated: false, completion: nil)
    }

    override func becomeFirstResponder() -> Bool {
        return true
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
        let myUrl = URL(string: "http://alldic.daum.net/")
        let myReq = URLRequest(url: myUrl!)
        webView.load(myReq)
    }
}
