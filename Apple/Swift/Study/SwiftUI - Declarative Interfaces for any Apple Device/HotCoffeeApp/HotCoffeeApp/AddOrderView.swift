//
//  AddOrderView.swift
//  HotCoffeeApp
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct AddOrderView: View {
    @State var addOrderVM = AddOrderViewModel()
    @Binding var isPresented: Bool
    var body: some View {
        NavigationView {
            Group {
                VStack {
                    TextField("Enter name", text: self.$addOrderVM.name)
                    Picker(selection: self.$addOrderVM.type, label: Text("")) {
                        Text("Cappuccino").tag("cap")
                        Text("Regular").tag("reg")
                        Text("Expresso").tag("ex")
                    }.pickerStyle(SegmentedPickerStyle())
                    Button("Place Order") {
                        self.addOrderVM.saveOrder()
//                        self.isPresented = false
                    }.padding(8).cornerRadius(10)
                     .foregroundColor(.white).background(Color.green)
                }
            }.padding().navigationBarTitle("Add Order")
        }
    }
}

struct AddOrderView_Previews: PreviewProvider {
    static var previews: some View {
        AddOrderView(isPresented: .constant(false))
    }
}
