//
//  AroundView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI
import SafariServices

struct AroundView: View {
    @State private var showSafari = false
    @State private var url: URL?
    var body: some View {
        NavigationView {
            VStack {
                HStack {
                    VStack {
                        Button(action: {
                            self.showSafari = true
                            self.url = URLStore(control: 0)
                        }) { Image(systemName: "location.north.line") }.padding(40).font(.largeTitle).sheet(isPresented: $showSafari) {
                            SafariView(url: self.url!)
                        }
                        Text("발생동향 및 이동경로").font(.caption)
                    }
                    VStack {
                        Button(action: {
                            self.showSafari = true
                            self.url = URLStore(control: 1)
                        }) { Image(systemName: "staroflife") }.padding(40).font(.largeTitle).sheet(isPresented: $showSafari) {
                            SafariView(url: self.url!)
                        }
                        Text("선별 진료소 찾기").font(.caption)
                    }
                }
                VStack {
                    Button(action: {
                        self.showSafari = true
                        self.url = URLStore(control: 2)
                    }) { Image(systemName: "tray.full") }.padding(40).font(.largeTitle).sheet(isPresented: $showSafari) {
                        SafariView(url: self.url!)
                    }
                    Text("보도자료").font(.caption)
                }
            }
            .navigationBarTitle("코로나19 현황 및 진료소 찾기", displayMode: .inline)
        }
    }
}

struct SafariView: UIViewControllerRepresentable {
    let url: URL
    func makeUIViewController(context: UIViewControllerRepresentableContext<SafariView>) -> SFSafariViewController {
        return SFSafariViewController(url: url)
    }
    func updateUIViewController(_ uiViewController: SafariView.UIViewControllerType, context: UIViewControllerRepresentableContext<SafariView>) { }
}

private func URLStore(control: Int) -> URL? {
    switch control {
    case 0:
        return URL(string: "http://ncov.mohw.go.kr/bdBoardList.do?brdId=1&brdGubun=11&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
    case 1:
        return URL(string: "http://www.mohw.go.kr/react/popup_200128.html")
    case 2:
        return URL(string: "http://ncov.mohw.go.kr/tcmBoardList.do?brdId=&brdGubun=&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
    default:
        return nil
    }
}

struct AroundView_Previews: PreviewProvider {
    static var previews: some View {
        AroundView()
    }
}
