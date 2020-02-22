//
//  SearchHelp.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct SearchHelp: View {
    private let discipline = "주변 찾기"
    var body: some View {
        VStack {
            HStack {
                Image(systemName: "location")
                Text("(주변) 탭에서")
            }
            HStack {
                Image(systemName: "location.north.line")
                Text("(발생현황 및 이동경로) 나")
            }
            HStack {
                Image(systemName: "staroflife")
                Text("(선별 진료소 찾기) 를 탭하여")
            }
            Text("동선과 주변의 선별진료소를 확인하십시오. ")
            HStack {
                Image(systemName: "tray.full")
                Text("(보도자료) 를 탭하면")
            }
            Text("발표된 보도자료를 확인할 수 있습니다. ")
        }
        .navigationBarTitle(Text("\(discipline)"), displayMode: .inline)
    }
}

struct SearchHelp_Previews: PreviewProvider {
    static var previews: some View {
        SearchHelp()
    }
}
