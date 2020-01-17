//
//  FlagDetailView.swift
//  FlagsOfTheWorld
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct FlagDetailView: View {
    @Binding var country: String
    @Binding var showModal: Bool
    var flag: String = ""
    var body: some View {
        VStack {
            Text(self.flag)
                .font(.custom("Arial", size: 200))
            TextField("Enter country name", text: $country)
                .padding()
                .fixedSize()
            Button("Submit") {
                self.showModal.toggle()
            }
        }
    }
}

struct FlagDetailView_Previews: PreviewProvider {
    static var previews: some View {
        FlagDetailView(country: .constant("USA"), showModal: .constant(false))
    }
}
