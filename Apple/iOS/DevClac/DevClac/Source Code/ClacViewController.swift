//
//  ClacViewController.swift
//  DevClac
//
//  Created by HM on 4/2/19.
//  Copyright © 2019 HM. All rights reserved.
//

import UIKit

class ClacViewController: UIViewController {
    @IBOutlet weak var firstVal: UITextField!
    @IBOutlet weak var secondVal: UITextField!
    
    @IBOutlet weak var UvalSwitch: UISwitch!
    @IBOutlet weak var firstType: UITextField!
    @IBOutlet weak var secondType: UITextField!
    @IBOutlet weak var resultSubmit: UIButton!
    @IBOutlet weak var resultVal: UILabel!
    @IBOutlet weak var resultCopy: UIButton!
    
    private var editFirst = false
    private var editSecond = false
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?){
        self.view.endEditing(true)
    }
    @IBAction func submitFirst(_ sender: UITextField) {
        editFirst = true
        if editFirst && editSecond {
            resultSubmit.isEnabled = true
        }
    }
    @IBAction func submitSecond(_ sender: UITextField) {
        editSecond = true
        if editFirst && editSecond {
            resultSubmit.isEnabled = true
        }
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

