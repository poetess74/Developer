//
//  DishCell.swift
//  Xcode-Previews
//
//  Created by HM on 1/14/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation
import SwiftUI

struct DishCell: View {
    let dish: Dish
    var body: some View {
        HStack {
            Image(dish.imageURL)
                .resizable()
                .frame(width: 100, height: 100)
                .clipShape(Circle())
            VStack(alignment: .leading) {
                Text(dish.name)
                Text("$\(dish.price)")
                    .foregroundColor(.green)
            }
        }.padding(5)
    }
}

struct DishCell_Previews: PreviewProvider {
    static var previews: some View {
        Group {
/*
 *           DishCell().colorScheme(.dark)
 *           DishCell().previewDevice("iPhone 8")
 *           DishCell().previewLayout(.sizeThatFits)
 *               .environment(\.sizeCategory, .extraSmall)
 *           DishCell().previewLayout(.sizeThatFits)
 *               .environment(\.sizeCategory, .extraExtraLarge)
 */
            DishCell(dish: Dish.all()[0]).previewLayout(.sizeThatFits)
                .environment(\.sizeCategory, .extraExtraExtraLarge)
        }
    }
}
