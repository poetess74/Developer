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
            if discipline == "기준 및 경고" {
                ScrollView {
                    HStack {
                        Image(systemName: "magnifyingglass")
                        Text("(검사) 에서").fixedSize()
                    }
                    HStack {
                        Rectangle()
                            .fill(Color.gray)
                            .frame(width: 20, height: 20, alignment: .center)
                            .cornerRadius(5)
                        Text("코로나 유행지역 방문 또는 확진자와 동선 겹침").font(.caption)
                        Image(systemName: "arrow.left")
                        Text("(X)")
                    }
                    HStack {
                        Rectangle()
                            .fill(Color.blue)
                            .frame(width: 20, height: 20, alignment: .center)
                            .cornerRadius(5)
                        Text("코로나 유행지역 방문 또는 확진자와 동선 겹침").font(.caption)
                        Image(systemName: "arrow.left")
                        Text("(O)")
                    }
                    HStack {
                        Text("위 항목 선택 후 다른 사항 선택 후 아래")
                        Image(systemName: "checkmark")
                        Text("탭")
                    }
                    Divider()
                    Text("본 자가진단앱은 코로나19에 감염되었는지 간단히 체크하는 용도이며 의료진의 처방보다 과신할 경우 문제의 소지가 있습니다.").multilineTextAlignment(.center).padding().foregroundColor(.red).fixedSize(horizontal: false, vertical: true)
                    Text("상담할 때 증상을 사실대로 의료진에게 얘기하셔야 하며 의료진의 격리 및 치료 요구의 불응은 자신과 가족 더 나아가 사회에 큰 해가 될 수 있음을 숙지하십시오.\n코로나19 검진으로 인해 병원을 방문할 시 \"선별 진료소\"로 자차를 이용하여 방문하시길 부탁드립니다.").multilineTextAlignment(.center).padding().foregroundColor(.red).fixedSize(horizontal: false, vertical: true)
                    Text("이 앱의 일부 기능은 인터넷 연결이 필요하며 셀룰러 데이터로 연결시 가입하신 요금제에 따라 금액이 부과될 수 있습니다. 자세한 사항은 가입하신 요금제 정책을 참조하십시오. ").multilineTextAlignment(.center).padding().fixedSize(horizontal: false, vertical: true)
                    Text("1339[연중무휴]는 무료로 통화할 수 있습니다. 다만 셀룰러 회사 또는 요금제의 정책에 따라 통화 금액이 부과될 수 있습니다. 자세한 사항은 가입하신 셀룰러 회사 또는 요금제 정책을 참조하십시오. ").multilineTextAlignment(.center).padding().fixedSize(horizontal: false, vertical: true)
                }
            } else if discipline == "Q&A" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://ncov.mohw.go.kr/faqBoardList.do?brdId=3&brdGubun=34&dataGubun=&ncvContSeq=&contSeq=&board_id=")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://ncov.mohw.go.kr/faqBoardList.do?brdId=3&brdGubun=34&dataGubun=&ncvContSeq=&contSeq=&board_id=")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
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
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "COVID-19" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://ncov.mohw.go.kr")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://ncov.mohw.go.kr")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "질병관리본부" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://www.cdc.go.kr/index.es?sid=a2")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://www.cdc.go.kr/index.es?sid=a2")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "보건복지부" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "http://www.mohw.go.kr/react/index.jsp")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "http://www.mohw.go.kr/react/index.jsp")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "보건복지부 트위터" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "https://twitter.com/mohwpr")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "https://twitter.com/mohwpr")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "질병관리본부 트위터" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "https://twitter.com/KoreaCDC")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "https://twitter.com/KoreaCDC")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
                    }
                }
            } else if discipline == "WHO 트위터" {
                if SafariLoad() {
                    WebView(request: URLRequest(url: URL(string: "https://twitter.com/WHO?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor")!))
                } else {
                    VStack {
                        Text("WebKit을 로드할 수 없습니다. ").padding()
                        Button(action: {
                            UIApplication.shared.open(URL(string: "https://twitter.com/WHO?ref_src=twsrc%5Egoogle%7Ctwcamp%5Eserp%7Ctwgr%5Eauthor")!)
                        }) { Text("링크 열기")}
                        Text("위 버튼은 외부 앱으로 연결되며\n이 오류는 주로 iOS 버전이 최신이 아닐 때 발생합니다. ").font(.caption).multilineTextAlignment(.center).padding()
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
        let view = WKWebView(frame: .zero)
        view.configuration.preferences.javaScriptEnabled = true
        view.load(request)
        return view
    }
    func updateUIView(_ uiView: WKWebView, context: UIViewRepresentableContext<WebView>) { }
}

struct DetailView_Previews: PreviewProvider {
    static var previews: some View {
        DetailView(discipline: "")
    }
}
