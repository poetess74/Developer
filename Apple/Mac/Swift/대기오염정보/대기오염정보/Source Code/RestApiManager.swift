//
//  RestApiManager.swift
//  대기오염정보
//
//  Created by HM on 2017. 6. 17..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa

class RestApiManager: NSObject {
    static let shared = RestApiManager()
    
    static var updating = false
    
    static let baseUrl = "http://openapi.airkorea.or.kr/openapi/services/rest/ArpltnInforInqireSvc/"
    static let serviceKey = "MKtP5htGVVobTzK8PmnO%2BHYCTeRwkTc0lho44z6xAF4QOoC4HTTZdGc5uXSGISXQ3fnaPAK%2Br7NbY410MB%2Bhrw%3D%3D"
    
    func getMsrstnAcctoRltmMesureDnsty(stationName: String,
                                          dataTerm: String,
                                            pageNo: Int,
                                         numOfRows: Int,
                                           handler: @escaping (Info) -> Void) -> Void {
        RestApiManager.updating = true
        
        let config = URLSessionConfiguration.default
        let session = URLSession(configuration: config)
        
        let paramStationName = stationName.addingPercentEncoding(withAllowedCharacters: CharacterSet.urlQueryAllowed)!
        let paramDataTerm = dataTerm.addingPercentEncoding(withAllowedCharacters: CharacterSet.urlQueryAllowed)!
        
        let urlStr = "\(RestApiManager.baseUrl)getMsrstnAcctoRltmMesureDnsty?stationName=\(paramStationName)&dataTerm=\(paramDataTerm)&pageNo=\(pageNo)&numOfRows=\(numOfRows)&ServiceKey=\(RestApiManager.serviceKey)&_returnType=json"
        
        let url = URL(string: urlStr)
        
        let task = session.dataTask(with: url!, completionHandler:
        {
            (data, response, error) in
                if let httpResponse = response as? HTTPURLResponse {
                   if (httpResponse.statusCode == 200) {
                        do {
                            if let json = try JSONSerialization.jsonObject(with: data!, options: .allowFragments) as? [String: Any]
                            {
                                let info = Info()
                                
                                if let list = json["list"] as? [[String: Any]] {
                                    let firstItem = list[0]
                                    let pm10Value = (firstItem["pm10Value"] as! NSString).intValue
                                    let pm25Value = (firstItem["pm25Value"] as! NSString).intValue
                                    let coValue = firstItem["coValue"] as! String
                                    let khaiValue = (firstItem["khaiValue"] as! NSString).intValue
                                    let no2Value = firstItem["no2Value"] as! String
                                    let so2Value = firstItem["so2Value"] as! String
                                    let o3Value = firstItem["o3Value"] as! String
                                    
                                    let dataTimeStr = firstItem["dataTime"] as! String
                                    let dateFormatter = DateFormatter()
                                    
                                    dateFormatter.dateFormat = "yyyy-MM-dd HH:mm"
                                    dateFormatter.locale = Locale.init(identifier: "ko_KR")
                                    
                                    let dataTime = dateFormatter.date(from: dataTimeStr)!
                                    
                                    info.status = 1
                                    info.dataTime = dataTime
                                    info.dataTimeStr = dataTimeStr
                                    info.pm10Value = pm10Value
                                    info.pm25Value = pm25Value
                                    info.coValue = coValue
                                    info.khaiValue = khaiValue
                                    info.no2Value = no2Value
                                    info.o3Value = o3Value
                                    info.so2Value = so2Value
                                    
                                    RestApiManager.updating = false

                                }

                                if let svcVo = json["ArpltnInforInqireSvcVo"] as? [String: Any] {
                                    let station = svcVo["stationName"] as! String
                                    info.station = station
                                }
                                
                                handler(info)
                            }
                        } catch {
                            RestApiManager.updating = false
                            DispatchQueue.main.async {
                                func dialogOKCancel(question: String, text: String) -> Bool {
                                    let alert = NSAlert()
                                    alert.messageText = question
                                    alert.informativeText = text
                                    alert.alertStyle = .critical
                                    alert.addButton(withTitle: "승인")
                                    return alert.runModal() == .alertFirstButtonReturn
                                }
                                
                                _ = dialogOKCancel(question: "파싱중 예기치 않은 오류가 발생 하였습니다.", text: "다시 시도하시거나 시스템 재시동 또는, 설정>지금 캐시 비우기를 시도하여 주시기 바랍니다.")
                            }
                            
                        }
                    } else {
                    RestApiManager.updating = false
                        DispatchQueue.main.async {
                            func dialogOKCancel(question: String, text: String) -> Bool {
                                let alert = NSAlert()
                                alert.messageText = question
                                alert.informativeText = text
                                alert.alertStyle = .critical
                                alert.addButton(withTitle: "승인")
                                return alert.runModal() == .alertFirstButtonReturn
                            }
                            
                            _ = dialogOKCancel(question: "\(HTTPURLResponse.localizedString(forStatusCode: httpResponse.statusCode))", text: "잠시후 다시 시도하여 주시기 바랍니다.")
                        }
                    }
                }
        })
        task.resume()
    }
}
