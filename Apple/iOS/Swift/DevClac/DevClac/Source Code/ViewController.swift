//
//  ViewController.swift
//  DevClac
//
//  Created by HM on 4/2/19.
//  Copyright © 2019 HM. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    @IBOutlet weak var inputVal: UITextField!
    @IBOutlet weak var UvalSwitch: UISwitch!
    @IBOutlet weak var inputType: UITextField!
    @IBOutlet weak var resultType: UITextField!
    @IBOutlet weak var resultSubmit: UIButton!
    @IBOutlet weak var resultVal: UILabel!
    @IBOutlet weak var resultCopy: UIButton!
    
    private var getType = 0
    private var returnType = 0
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?){
        self.view.endEditing(true)
    }
    
    @IBAction func submitAction(_ sender: UITextField) {
        resultSubmit.isEnabled = true
    }
    
    @IBAction func Submit(_ sender: UIButton) {
        resultVal.text = "NaN"
//        resultVal.text = String(Int(inputVal.text!)!, radix: returnType)
        resultVal.isHidden = false
        resultCopy.isHidden = false
    }
    @IBAction func Copy(_ sender: UIButton) {
        UIPasteboard.general.string = resultVal.text
    }
    
}

