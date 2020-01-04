//
//  HikeDetail.swift
//  Hiking
//
//  Created by HM on 1/4/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct HikeDetail: View {
    let hike: Hike
    var body: some View {
        VStack {
            Image(hike.imageURL)
                .resizable()
                .aspectRatio(contentMode: .fit)
            Text(hike.name)
            Text(String(format: "%.2f", hike.miles))
        }
    }
}

struct HikeDetail_Previews: PreviewProvider {
    static var previews: some View {
        HikeDetail(hike: Hike(name: "Angels Landing", imageURL: "tam", miles: 10.0))
    }
}
