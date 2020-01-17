//
//  ImageDetectionViewModel.swift
//  CoreImageSwiftUIIntegration
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI
import Combine

class ImageDetectionViewModel: ObservableObject {
    var name: String = ""
    var manager: ImageDetectionManager
    @Published var predictionLabel: String = ""
    
    init(manager: ImageDetectionManager) {
        self.manager = manager
    }
    func detect(_ name: String) {
        
    }
}
