//
//  AnimalService.swift
//  SwiftUIForAllDevices
//
//  Created by HM on 2020/02/03.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class AnimalService {
    static func getAll() -> [Animal] {
        return [
            Animal(name: "Tiger", description: "This is tiger", image: "🐅"),
            Animal(name: "Rat", description: "This is rat", image: "🐀"),
            Animal(name: "Giraffe", description: "This is giraffe", image: "🦒"),
            Animal(name: "Cat", description: "This is cat", image: "🐈")
        ]
    }
}
