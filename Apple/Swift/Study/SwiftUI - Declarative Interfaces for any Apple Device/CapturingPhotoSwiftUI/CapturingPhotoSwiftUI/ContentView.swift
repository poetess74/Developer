//
//  ContentView.swift
//  CapturingPhotoSwiftUI
//
//  Created by HM on 1/19/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var showImagePicker: Bool = false
    @State private var image: Image? = nil
    var body: some View {
        VStack {
            image?.resizable().scaledToFit()
            Button("Open Camera") {
                self.showImagePicker = true
            }.padding().background(Color.green)
             .foregroundColor(.white).cornerRadius(10)
        }.sheet(isPresented: self.$showImagePicker) {
            PhotoCaptureView(showImagePicker: self.$showImagePicker, image: self.$image)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
