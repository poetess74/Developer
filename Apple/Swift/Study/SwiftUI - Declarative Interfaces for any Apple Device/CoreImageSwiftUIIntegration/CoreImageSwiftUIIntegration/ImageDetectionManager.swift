//
//  ImageDetectionManager.swift
//  CoreImageSwiftUIIntegration
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import CoreML
import UIKit

class ImageDetectionManager {
    let model = Resnet50()
    func detect(_ img: UIImage) -> String? {
        guard let pixelBuffer = img.toCVPixelBuffer(),
            let prediction = try? model.prediction(image: pixelBuffer) else {
                return nil
        }
        return prediction.classLabel
    }
}
