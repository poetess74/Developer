//
//  ContentView.swift
//  Xcode-Previews
//
//  Created by HM on 1/14/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    let dishes = Dish.all()
    var body: some View {
        List {
            ForEach(dishes, id: \.self) { dish in
                DishCell(dish: dish)
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
