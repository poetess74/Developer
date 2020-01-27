//
//  StoreDrive.swift
//  Alert
//
//  Created by HM on 2020/01/27.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI
import Combine

class StoreDrive: ObservableObject {
    @Published var bgColor: Color = .white
    @Published var altStatus: Int = 0
}
