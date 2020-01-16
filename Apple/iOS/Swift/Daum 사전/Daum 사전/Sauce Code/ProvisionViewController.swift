//
//  ProvisionViewController.swift
//  Daum 사전
//
//  Created by HM on 2018. 4. 7..
//  Copyright © 2018년 HM. All rights reserved.
//

import UIKit
import WebKit

class ProvisionViewController: UIViewController, WKUIDelegate, WKNavigationDelegate, UIWebViewDelegate, UIScrollViewDelegate {
    @IBOutlet weak var webViewContainer: UIView!
    @IBOutlet weak var URLView: UIView!
    @IBOutlet weak var URLLabel: UILabel!
    
    var webView: WKWebView!
    var stoper = false
    var count = 0
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.loadWeb()
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
    
    func loadWeb() {
        let webConfiguration = WKWebViewConfiguration()
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.uiDelegate = self
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.autoresizingMask = [.flexibleWidth, .flexibleHeight]
        webView.navigationDelegate = self
        
        webViewContainer.addSubview(webView)
        
        let myUrl = URL(string: "http://policy.daum.net/docs/policy")
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
        if url == "http://policy.daum.net/docs/policy?type=mobile" {
            webView.goBack()
        } else if url.hasPrefix("http://policy.daum.net/docs/policy") {
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
    
    private func netErrFalse() {
        dismiss(animated: false, completion: nil)
    }
    
    private func reload() {
        if !stoper {
            self.loadWeb()
            count = count + 1
        }
        webView.reload()
        count = count + 1
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
        let myUrl = URL(string: "http://policy.daum.net/docs/policy")
        let myReq = URLRequest(url: myUrl!)
        webView.load(myReq)
    }
}
