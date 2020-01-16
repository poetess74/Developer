//
//  CLLocationApiManager.swift
//  대기오염정보
//
//  Created by HM on 2017. 11. 18..
//  Copyright © 2017년 HM. All rights reserved.
//

import Cocoa
import CoreLocation

class CLLocationApiManager: NSObject, CLLocationManagerDelegate {
    static let shared = CLLocationApiManager()
    
    var locationManager: CLLocationManager = CLLocationManager()
    
    static var latitude: Double = 0
    static var longLatitude: Double = 0
    static var CLLocation: String = ""
    
    static let serviceUrl = "http://maps.googleapis.com/maps/api/geocode/json?latlng="
    
    static var updating = false

    func getCLLocation() {
        CLLocationApiManager.updating = true
        locationManager.desiredAccuracy = kCLLocationAccuracyBest
        locationManager.delegate = self
        locationManager.startUpdatingLocation()
    }
    
    func locationManager(_ manager: CLLocationManager,
                         didUpdateLocations locations: [CLLocation])
    {
        CLLocationApiManager.updating = false

        let loc: CLLocation = locations[locations.count - 1]
        
        print("latitude: \(loc.coordinate.latitude)")
        print("longitude: \(loc.coordinate.longitude)")
        print("altitude: \(loc.altitude)")
        print("horizontal accuracy: \(loc.horizontalAccuracy)")
        print("vertical accuracy: \(loc.verticalAccuracy)")
    }
    
    func locationManager(_ manager: CLLocationManager,
                         didFailWithError error: Error)
    {
        CLLocationApiManager.updating = false
    }
 
    func getAddress() -> Void {
        let config = URLSessionConfiguration.default
        let session = URLSession(configuration: config)
        
        let urlStr = "\(CLLocationApiManager.serviceUrl)\(CLLocationApiManager.latitude),\(CLLocationApiManager.longLatitude)&language=ko"
        
        let url = URL(string: urlStr)
        
        let task = session.dataTask(with: url!, completionHandler:
        {
            (data, response, error) in
            if let httpResponse = response as? HTTPURLResponse {
                if (httpResponse.statusCode == 200) {
                    do {
                        if let json = try JSONSerialization.jsonObject(with: data!, options: .allowFragments) as? [String: Any]
                        {
                            if let result = json["results"] as? [[String : Any]] {
                                for (index, element) in result.enumerated() {
                                    if index != 0 {
                                        continue
                                    }
                                    
                                    if let address = element["address_components"] as? [[String : Any]] {
                                        let item = address[2]
                                        CLLocationApiManager.CLLocation = item["long_name"] as! String
                                        CLLocationApiManager.updating = false;
                                    }
                                }
                            }
                        }
                    } catch {
                        CLLocationApiManager.updating = false;
                        DispatchQueue.main.async {
                            func dialogOKCancel(question: String, text: String) -> Bool {
                                let alert = NSAlert()
                                alert.messageText = question
                                alert.informativeText = text
                                alert.alertStyle = .critical
                                alert.addButton(withTitle: "승인")
                                return alert.runModal() == .alertFirstButtonReturn
                            }
                        }
                        
                    }
                } else {
                    CLLocationApiManager.updating = false;
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
