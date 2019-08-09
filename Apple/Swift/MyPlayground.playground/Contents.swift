import Cocoa
import Foundation

let dateStr = "2017-07-16 22:00"

let dateFormatter = DateFormatter()

dateFormatter.dateFormat = "yyyy-MM-dd HH:mm"
dateFormatter.locale = Locale.init(identifier: "ko_KR")

var date = dateFormatter.date(from: dateStr)
