//
//  ViewController.swift
//  AntiDriEye
//
//  Created by HM on 2017. 12. 19..
//  Copyright © 2017년 HM. All rights reserved.
//

import UIKit
import WebKit

class ViewController: UIViewController, WKUIDelegate, WKNavigationDelegate, UITextFieldDelegate {
    @IBOutlet weak var searchBar: UITextField!
    @IBOutlet weak var Progress: UIProgressView!
    @IBOutlet weak var webViewContainer: UIView!
    @IBOutlet weak var reLoad: UIBarButtonItem!
    @IBOutlet weak var back: UIBarButtonItem!
    @IBOutlet weak var forward: UIBarButtonItem!
    @IBOutlet weak var share: UIBarButtonItem!
    @IBOutlet weak var coolDowntimer: UIProgressView!
    @IBOutlet weak var option: UIBarButtonItem!
    
    var webView: WKWebView!
    var count: UInt8 = 1
    var stoper = false
    
    var secure = true
    var secureIndex = ""
    
    var pause = false
    
    var timer = Timer()
    var blink = Timer()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        self.searchBar.delegate = self
        self.view.endEditing(true)
        loadWeb()
        Timer.scheduledTimer(timeInterval: 1, target: self, selector: #selector(coolTimer), userInfo: nil, repeats: true)
        self.blinkBool()
    }
    
    func blinkBool() {
        if (UserInfoDB.sharedInstance.blinkalert) {
            blink = Timer.scheduledTimer(timeInterval: TimeInterval(UserInfoDB.sharedInstance.blinkeyeTime), target: self, selector: #selector(blinkAlert), userInfo: nil, repeats: true)
        } else {
            blink.invalidate()
        }
    }
    
    private func loadWeb() {
        let webConfiguration = WKWebViewConfiguration()
        
        webView = WKWebView(frame: webViewContainer.frame, configuration: webConfiguration)
        webView.autoresizingMask = [.flexibleWidth, .flexibleHeight]
        //webView.uiDelegate = self
        webView.navigationDelegate = self
        
        webViewContainer.addSubview(webView)
        
        let myUrl = URL(string: UserInfoDB.sharedInstance.currentURL)
        let myReq = URLRequest(url: myUrl!)
        
        webView.load(myReq)
        
        webView.allowsBackForwardNavigationGestures = true
    }
    
    @objc private func blinkAlert() {
        let alert = UIAlertController(title: "눈을 깜빡일 시간입니다", message: "눈의 건조함을 피하기 위해서 잠깐동안 눈을 감고 계세요.", preferredStyle: .alert)
        let okAction = UIAlertAction(title: "승인", style: .default, handler: nil)
        alert.addAction(okAction)
        self.present(alert, animated: true, completion: nil)
    }
    
    override func viewWillAppear(_ animated: Bool) {
        webView.frame = webViewContainer.bounds
    }
    
    @IBAction func reLoad(_ sender: Any) {
        webView.reload()
    }
    
    @IBAction func backBtn(_ sender: Any) {
        webView.goBack()
    }
    
    @IBAction func forwardBtn(_ sender: Any) {
        webView.goForward()
    }
    @IBAction func option(_ sender: UIBarButtonItem) {
        pause = true
    }
    
    @IBAction func shareBtn(_ sender: Any) {
        shareIt()
    }
    
    func shareIt() {
        let textToShare = [ webView.url!.absoluteString ]
        let activityVC = UIActivityViewController(activityItems: textToShare, applicationActivities: nil)
        activityVC.excludedActivityTypes = [ UIActivityType.airDrop ]
        self.present(activityVC, animated: true, completion: nil)
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @objc func movePage() {
        if webView.canGoBack {
            back.isEnabled = true
        } else {
            back.isEnabled = false
        }
        if webView.canGoForward {
            forward.isEnabled = true
        } else {
            forward.isEnabled = false
        }
    }
    
    @objc func updateProgress() {
        coolDowntimer.progress = Float(UserInfoDB.sharedInstance.currentTime) / Float(UserInfoDB.sharedInstance.nomalTime)
        if (UserInfoDB.sharedInstance.currentTime > 0) {
            if !pause {
                UserInfoDB.sharedInstance.currentTime -= 1
            }
        } else {
            timer.invalidate()
            if !pause {
                let newView = self.storyboard!.instantiateViewController(withIdentifier: "RestViewController") as! RestViewController
                newView.modalPresentationStyle = UIModalPresentationStyle.overFullScreen
                self.present(newView, animated: true, completion: nil)
            }
        }
    }
    
    @objc func coolTimer() {
        if !UserInfoDB.sharedInstance.sleepBool {
            updateProgress()
        }
        
        switch coolDowntimer.progress {
            case 0.8...1 :
                coolDowntimer.tintColor = UIColor.blue
            case 0.6..<0.8 :
                coolDowntimer.tintColor = UIColor.cyan
            case 0.4..<0.6 :
                coolDowntimer.tintColor = UIColor.orange
            case 0.2..<0.4 :
                coolDowntimer.tintColor = UIColor.magenta
            case 0.000001..<0.2 :
                coolDowntimer.tintColor = UIColor.red
        default :
            UserInfoDB.sharedInstance.sleepBool = true
            UserInfoDB.sharedInstance.currentTime = UserInfoDB.sharedInstance.nomalTime
        }
    }
    
    func webView(_ webView: WKWebView, runJavaScriptAlertPanelWithMessage message: String, initiatedByFrame frame: WKFrameInfo, completionHandler: @escaping () -> Swift.Void){
        let alert = UIAlertController(title: nil, message: message, preferredStyle: .alert)
        let otherAction = UIAlertAction(title: "승인", style: .default, handler: {action in completionHandler()})
        alert.addAction(otherAction)
        
        self.present(alert, animated: true, completion: nil)
    }
    
    func webView(_ webView: WKWebView, runJavaScriptConfirmPanelWithMessage message: String, initiatedByFrame frame: WKFrameInfo, completionHandler: @escaping (Bool) -> Swift.Void){
        let alert = UIAlertController(title: nil, message: message, preferredStyle: .alert)
        let cancelAction = UIAlertAction(title: "취소", style: .cancel, handler: {(action) in completionHandler(false)})
        let okAction = UIAlertAction(title: "승인", style: .default, handler: {(action) in completionHandler(true)})
        alert.addAction(cancelAction)
        alert.addAction(okAction)
        self.present(alert, animated: true, completion: nil)
    }
    
    func webView(_ webView: WKWebView, didCommit navigation: WKNavigation!) {
        var url = ""
        UIApplication.shared.isNetworkActivityIndicatorVisible = true
        Progress.tintColor = UIColor.blue
        Progress.isHidden = false
        Progress.setProgress(1, animated: true)
        
        UserInfoDB.sharedInstance.currentURL = String(describing: webView.url!)
        url = String(UserInfoDB.sharedInstance.currentURL)
        
        if url.hasPrefix("https://") {
            searchBar.textColor = UIColor.blue
            secure = true
        } else {
            searchBar.textColor = UIColor.red
            if (secure || secureIndex != webView.url!.host!) {
                webView.stopLoading()
                UIApplication.shared.isNetworkActivityIndicatorVisible = false
                let alert = UIAlertController(title: "안전하지 않은 연결", message: "공격자가 \'\(String(describing: webView.url!.host!))\'에서 사용자의 정보를 도용하려고 시도할 수 있습니다.\n웹 페이지를 계속 탐색하시겠습니까?", preferredStyle: .alert)
                let cancelAction = UIAlertAction(title: "취소", style: .cancel, handler: {action in webView.goBack();self.secure = true})
                let okAction = UIAlertAction(title: "승인", style: .destructive, handler: {action in self.notSecureReload()})
                alert.addAction(cancelAction)
                alert.addAction(okAction)
                self.present(alert, animated: true, completion: nil)
            }
        }
        searchBar.text = String(describing: webView.url!.host!)
    }
    
    func notSecureReload() {
        secure = false
        webView.reload()
        UIApplication.shared.isNetworkActivityIndicatorVisible = true
        secureIndex = webView.url!.host!
    }
    
    func webView(_ webView: WKWebView, didFinish navigation: WKNavigation!){
        Progress.setProgress(0, animated: true)
        Progress.isHidden = true
        UIApplication.shared.isNetworkActivityIndicatorVisible = false
        movePage()

        stoper = true
        count = 1
    }
    @IBAction func searching(_ sender: Any) {
        searchUrl()
    }
    @IBAction func editStart(_ sender: Any) {
        searchBar.textColor = UIColor.black
        searchBar.text = String(describing: webView.url!)
    }
    
    func searchUrl() {
        if searchBar.text != "" {
            if (searchBar.text?.hasPrefix("http"))! {
                UserInfoDB.sharedInstance.currentURL = searchBar.text!
                let myUrl = URL(string: UserInfoDB.sharedInstance.currentURL)
                let myReq = URLRequest(url: myUrl!)
                webView.load(myReq)
            } else if (searchBar.text?.contains("."))! {
                let text = String(describing: searchBar.text!)
                let append = "https://" + text
                UserInfoDB.sharedInstance.currentURL = append
                let myUrl = URL(string: UserInfoDB.sharedInstance.currentURL)
                
                if myUrl != nil {
                    let myReq = URLRequest(url: myUrl!)
                    webView.load(myReq)
                } else {
                    let text = String(describing: searchBar.text!)
                    let append = "https://www.google.co.kr/search?q=" + text.addingPercentEncoding(withAllowedCharacters: .urlQueryAllowed)!
                    UserInfoDB.sharedInstance.currentURL = append
                    let myUrl = URL(string: UserInfoDB.sharedInstance.currentURL)
                    let myReq = URLRequest(url: myUrl!)
                    webView.load(myReq)
                }
            } else {
                let text = String(describing: searchBar.text!)
                let append = "https://www.google.co.kr/search?q=" + text.addingPercentEncoding(withAllowedCharacters: .urlQueryAllowed)!
                UserInfoDB.sharedInstance.currentURL = append
                let myUrl = URL(string: UserInfoDB.sharedInstance.currentURL)
                let myReq = URLRequest(url: myUrl!)
                webView.load(myReq)
                
            }
        } else {
            searchBar.text = String(webView.url!.host!)
        }
    }
    
    func webView(_ webView: WKWebView, didFailProvisionalNavigation navigation: WKNavigation!, withError error: Error) {
        Progress.tintColor = UIColor.red
        Progress.setProgress(1, animated: true)
        Progress.isHidden = false
        var string = ""
        if webView.url != nil {
            string = "장치가 인터넷에 연결되어 있지 않거나, 서버가 응답하지 않기 때문에 요청한 페이지를 열 수 없습니다."
        } else {
            string = "장치가 인터넷에 연결되어 있지 않기 때문에 요청한 페이지를 열 수 없습니다."
        }
        let alert = UIAlertController(title: "인터넷 연결 오류", message: string, preferredStyle: UIAlertControllerStyle.alert)
        if count >= 3 && webView.url != nil {
            alert.addAction(UIAlertAction(title: "승인", style: UIAlertActionStyle.cancel, handler: {action in self.count = 1}))
        }
        if 5 >= count || webView.url == nil {
            alert.addAction(UIAlertAction(title: "새로 고침", style: UIAlertActionStyle.default, handler: {action in self.reload()}))
        }
        self.present(alert, animated: true, completion: nil)
    }
    
    private func reload() {
        if !stoper {
            self.loadWeb()
            count = count + 1
        }
        webView.reload()
        count = count + 1
    }
    
    func textFieldShouldReturn(_ textField: UITextField) -> Bool {
        textField.resignFirstResponder()
        return true;
    }
}
