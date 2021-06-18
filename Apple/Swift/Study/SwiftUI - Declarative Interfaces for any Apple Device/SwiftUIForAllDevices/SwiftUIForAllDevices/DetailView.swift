//
//  DetailView.swift
//  SwiftUIForAllDevices
//
//  Created by HM on 2020/02/03.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct DetailView: View {
    let animal: Animal
    var body: some View {
        VStack {
            Text(animal.image)
                .font(.custom("Arial", size: 100))
            Text(animal.name)
            Text(animal.description)
        }
    }
}

struct DetailView_Previews: PreviewProvider {
    static var previews: some View {
        DetailView(animal: Animal(name: "Cat", description: "This is a cat", image: "🐈"))
    }
}
