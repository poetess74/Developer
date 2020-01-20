//
//  SettingsViewModel.swift
//  SwiftIntSwiftUI
//
//  Created by HM on 1/20/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class SettingsViewModel: ObservableObject {
    @Published var isOn: Bool = UserDefaults.standard.bool(forKey: "isOn") {
        didSet {
            UserDefaults.standard.set(self.isOn, forKey: "isOn")
        }
    }
}
