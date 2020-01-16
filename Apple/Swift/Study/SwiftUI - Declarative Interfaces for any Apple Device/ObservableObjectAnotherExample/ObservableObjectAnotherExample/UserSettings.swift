//
//  UserSettings.swift
//  ObservableObjectAnotherExample
//
//  Created by HM on 1/9/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI
import Combine

class UserSettings: ObservableObject {
    @Published var score: Int = 0
}
