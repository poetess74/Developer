//
//  AroundView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct AroundView: View {
    @State private var locationIsAlert = false
    @State private var scanIsAlert = false
    @State private var newsIsAlert = false
    private let title = "위 버튼은 Safari 브라우저로 리다이렉트 됩니다. "
    var body: some View {
        NavigationView {
            VStack {
                HStack {
                    VStack {
                        Button(action: {
                            self.locationIsAlert = true
                        }) { Image(systemName: "location.north.line") }.padding(40).font(.largeTitle).alert(isPresented: $locationIsAlert) {
                            AlertRun(control: 0)
                        }
                        Text("발생동향 및 이동경로").font(.caption)
                    }
                    VStack {
                        Button(action: {
                            self.scanIsAlert = true
                        }) { Image(systemName: "staroflife") }.padding(40).font(.largeTitle).alert(isPresented: $scanIsAlert) {
                            AlertRun(control: 1)
                        }
                        Text("선별 진료소 찾기").font(.caption)
                    }
                }
                VStack {
                    Button(action: {
                        self.newsIsAlert = true
                    }) { Image(systemName: "tray.full") }.padding(40).font(.largeTitle).alert(isPresented: $newsIsAlert) {
                        AlertRun(control: 2)
                    }
                    Text("보도자료").font(.caption)
                }
                Text("위 버튼은 Safari 브라우저로 리다이렉트 됩니다. ").padding()
            }
            .navigationBarTitle("코로나 19 현황 및 진료소 찾기", displayMode: .inline)
        }
    }
}

private func AlertRun(control: Int) -> Alert {
    var url = URL(string: "")
    switch control {
    case 0:
        url = URL(string: "http://ncov.mohw.go.kr/bdBoardList.do?brdId=1&brdGubun=11&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
    case 1:
        url = URL(string: "http://www.mohw.go.kr/react/popup_200128.html")
    case 2:
        url = URL(string: "http://ncov.mohw.go.kr/tcmBoardList.do?brdId=&brdGubun=&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
    default:
        NSLog("NullReferenceException: Object reference not set to an instance of an object")
        exit(EXIT_FAILURE)
    }
    return Alert(title: Text("코로나 자가진단에서 떠나시겠습니까?"), message: Text("이 버튼은 코로나 자가진단이 아닌 다른 앱에서 열 것입니다. 정말로 열겠습니까?"), primaryButton: .default(Text("열기")) {
        UIApplication.shared.open(url!)
    }, secondaryButton: .cancel())
}

struct AroundView_Previews: PreviewProvider {
    static var previews: some View {
        AroundView()
    }
}
