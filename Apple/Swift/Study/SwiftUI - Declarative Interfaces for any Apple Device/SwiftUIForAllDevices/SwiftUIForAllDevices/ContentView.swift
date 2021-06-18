//
//  ContentView.swift
//  SwiftUIForAllDevices
//
//  Created by HM on 2020/01/27.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    private var animals = AnimalService.getAll()
    var body: some View {
        NavigationView {
            List(self.animals, id:\.name) { animal in
                NavigationLink(destination: DetailView(animal: animal)) {
                    HStack {
                        Text(animal.image)
                            .font(.custom("Arial", size: 100))
                        Text(animal.name)
                            .font(.title)
                    }
                }
            }
            .navigationBarTitle("Animals")
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
