//
//  Info.swift
//  대기오염정보
//
//  Created by Hyeongmin Kim on 2017. 7. 16..
//  Copyright © 2017년 HM. All rights reserved.
//

import Foundation

class Info {
    var status: Int = 0
    var dataTime: Date = Date()
    var dataTimeStr: String = ""
    
    var station: String = ""
    
    var pm10Value: Int32 = 0
    var pm25Value: Int32 = 0
    var coValue: String = ""
    var khaiValue: Int32 = 0
    var no2Value: String = ""
    var o3Value: String = ""
    var so2Value: String = ""
}
