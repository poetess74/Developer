//
//  ContentView.swift
//  CoreImageSwiftUIIntegration
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    let images = ["cat1", "dog", "tree", "mountains"]
    @State private var selectedImage = ""
    var body: some View {
        NavigationView {
            VStack {
                ScrollView([.horizontal]) {
                    HStack {
                        ForEach(self.images, id: \.self) { name in
                            Image(name)
                                .resizable()
                                .frame(width: 300, height: 300)
                                .padding()
                                .onTapGesture {
                                    self.selectedImage = name
                            }.border(Color.black, width: self.selectedImage == name ? 10 : 0)
                        }
                    }
                }
                Button("Detect") {
                    
                }.padding().background(Color.orange)
                 .foregroundColor(.white).cornerRadius(10)
                Text("Prediction will be displayed here...")
            }.navigationBarTitle("Core ML")
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
