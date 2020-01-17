//
//  CoreDataManager.swift
//  HotCoffeeApp
//
//  Created by HM on 1/17/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import CoreData

class CoreDataManager {
    static let shared = CoreDataManager(moc: NSManagedObjectContext.current)
    var moc: NSManagedObjectContext
    
    private init(moc: NSManagedObjectContext) {
        self.moc = moc
    }
    func getAllOrders() -> [Order] {
        var orders = [Order]()
        let orderRequest: NSFetchRequest<Order> = Order.fetchRequest()
        do {
            orders = try self.moc.fetch(orderRequest)
        } catch let error as NSError {
            NSLog("\(error)")
        }
        return orders
    }
    func saveOrder(name: String, type: String) {
        let order = Order(context: self.moc)
        order.name = name
        order.type = type
        do {
            try self.moc.save()
        } catch let error as NSError {
            NSLog("\(error)")
        }
    }
}
