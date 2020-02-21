//
//  AroundView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct AroundView: View {
    var body: some View {
        NavigationView {
            VStack {
                HStack {
                    VStack {
                        Button(action: {
                            let url = URL(string: "http://ncov.mohw.go.kr/bdBoardList.do?brdId=1&brdGubun=11&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
                            UIApplication.shared.open(url!)
                        }) { Image(systemName: "location.north.line") }.padding(40).font(.largeTitle)
                        Text("발생현황 및 이동경로").font(.caption)
                    }
                    VStack {
                        Button(action: {
                            let url = URL(string: "http://www.mohw.go.kr/react/popup_200128.html")
                            UIApplication.shared.open(url!)
                        }) { Image(systemName: "staroflife") }.padding(40).font(.largeTitle)
                        Text("선별 진료소 찾기").font(.caption)
                    }
                }
                Text("위 버튼은 Safari 브라우저로 리다이렉트 됩니다. ").padding()
            }
            .navigationBarTitle("코로나 19 현황 및 진료소 찾기", displayMode: .inline)
        }
    }
}

struct AroundView_Previews: PreviewProvider {
    static var previews: some View {
        AroundView()
    }
}
