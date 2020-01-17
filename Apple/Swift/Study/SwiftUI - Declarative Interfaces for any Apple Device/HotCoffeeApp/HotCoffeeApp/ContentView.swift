//
//  ContentView.swift
//  HotCoffeeApp
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @ObservedObject var orderListVM: OrderListViewModel
    init() {
        self.orderListVM = OrderListViewModel()
    }
    var body: some View {
        NavigationView {
            List {
                ForEach(self.orderListVM.orders, id: \.name) { order in
                    HStack {
                        Image(order.type)
                            .resizable()
                            .frame(width: 100, height: 100)
                            .cornerRadius(10)
                        Text(order.name)
                            .font(.largeTitle)
                            .padding([.leading], 10)
                    }
                }
            }.navigationBarTitle("Orders")
             .navigationBarItems(trailing: Button("Add New Order") {
                    
             })
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
