//
//  DetailView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/22.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI
import WebKit

struct DetailView: View {
    let discipline: String
    var body: some View {
        VStack {
            if discipline == "판별 기준" {
                VStack {
                    Image("ScreenShotScan").resizable().frame(width: 293, height: 222)
                    Text("")
                    HStack {
                        Rectangle()
                            .fill(Color.blue)
                            .frame(width: 20, height: 20, alignment: .center)
                            .cornerRadius(5)
                        Text("코로나 유행지역 방문 또는 확진자의 동선 겹침").font(.caption)
                    }.padding()
                    Text("위 사항이 선택되어야 함")
                }
            } else if discipline == "주의 사항" {
                Text("본 자가진단앱은 코로나 19에 감염되었는지 간단히 체크하는 용도이며 의료진의 처방보다 과신할 경우 문제의 소지가 있습니다.").multilineTextAlignment(.center).padding().foregroundColor(.red).fixedSize(horizontal: false, vertical: true)
                Text("상담할 때 증상을 사실대로 의료진에게 얘기하셔야 하며 의료진의 격리 및 치료 요구의 불응은 자신과 가족 더 나아가 사회에 큰 해가 될 수 있음을 숙지하십시오.").multilineTextAlignment(.center).padding().foregroundColor(.red).fixedSize(horizontal: false, vertical: true)
                Text("코로나 19 검진으로 인해 병원을 방문할 시 \"선별 진료소\"로 자차를 이용하여 방문하시길 부탁드립니다.").multilineTextAlignment(.center).padding().foregroundColor(.red).fixedSize(horizontal: false, vertical: true)
                Text("이 앱의 일부 기능은 인터넷 연결을 필요로 합니다. ").padding()
            } else if discipline == "Q&A" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://ncov.mohw.go.kr/faqBoardList.do?brdId=3&brdGubun=34&dataGubun=&ncvContSeq=&contSeq=&board_id=")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").multilineTextAlignment(.center).padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://ncov.mohw.go.kr/faqBoardList.do?brdId=3&brdGubun=34&dataGubun=&ncvContSeq=&contSeq=&board_id=")!)
                        }) { Text("Safari에서 링크 열기")}
                    }
                }
            } else if discipline == "팩트 체크" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://ncov.mohw.go.kr/factBoardList.do?brdId=3&brdGubun=33&dataGubun=&ncvContSeq=&contSeq=&board_id=")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://ncov.mohw.go.kr/factBoardList.do?brdId=3&brdGubun=33&dataGubun=&ncvContSeq=&contSeq=&board_id=")!)
                        }) { Text("Safari에서 링크 열기")}
                    }
                }
            } else if discipline == "출처 및 참고자료" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://ncov.mohw.go.kr/index_main.jsp")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://ncov.mohw.go.kr/index_main.jsp")!)
                        }) { Text("Safari에서 링크 열기")}
                    }
                }
            }
        }
        .navigationBarTitle(Text("\(discipline)"), displayMode: .inline)
    }
}

private func SafariLoad() -> Bool {
    if #available(iOS 13.4, *) {
        return true
    } else if #available(iOS 13.2, *) {
        return false
    } else {
        return true
    }
}

struct WebView: UIViewRepresentable {
    let request: URLRequest
    func makeUIView(context: UIViewRepresentableContext<WebView>) -> WebView.UIViewType {
        return WKWebView(frame: .zero)
    }
    func updateUIView(_ uiView: WKWebView, context: UIViewRepresentableContext<WebView>) {
        uiView.load(request)
    }
}

struct DetailView_Previews: PreviewProvider {
    static var previews: some View {
        DetailView(discipline: "")
    }
}
