//
//  OrderListViewModel.swift
//  HotCoffeeApp
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI
import CoreData
import Combine

class OrderListViewModel: ObservableObject {
    @Published
    var orders = [OrderViewModel]()
    init() {
        fetchAllOrders()
    }
    func deleteOrder(_ orderVM: OrderViewModel) {
        CoreDataManager.shared.deleteOrder(name: orderVM.name)
        fetchAllOrders()
    }
    func fetchAllOrders() {
        self.orders = CoreDataManager.shared.getAllOrders().map(OrderViewModel.init)
        NSLog("\(self.orders)")
    }
}

class OrderViewModel {
    var name = ""
    var type = ""
    init(order: Order) {
        self.name = order.name!
        self.type = order.type!
    }
}
