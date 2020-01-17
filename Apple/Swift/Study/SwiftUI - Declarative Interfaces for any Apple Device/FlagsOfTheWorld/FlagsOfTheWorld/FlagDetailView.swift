//
//  FlagDetailView.swift
//  FlagsOfTheWorld
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct FlagDetailView: View {
    @Binding var flagVM: FlagViewModel
    var body: some View {
        VStack {
            Text(self.flagVM.flag)
                .font(.custom("Arial", size: 200))
            TextField("Enter country name", text: self.$flagVM.country)
                .padding()
                .fixedSize()
            Button("Submit") {
                self.flagVM.showModal.toggle()
            }
        }
    }
}

struct FlagDetailView_Previews: PreviewProvider {
    static var previews: some View {
        FlagDetailView(flagVM: .constant(FlagViewModel()))
    }
}
