//
//  InfoView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct InfoView: View {
    @State private var swapDevtoVer = false
    @Environment(\.colorScheme) var colorSchme: ColorScheme
    var body: some View {
        NavigationView {
            List {
                Section {
                    Button(action: {
                        self.swapDevtoVer.toggle()
                    }) {
                        HStack {
                            if !swapDevtoVer {
                                colorSchme == .light ? Text("개발자").foregroundColor(.black) : Text("개발자").foregroundColor(.white)
                                Spacer()
                                Text("Hyeongmin Kim").foregroundColor(.gray)
                            } else {
                                colorSchme == .light ? Text("버전").foregroundColor(.black) : Text("버전").foregroundColor(.white)
                                Spacer()
                                Text("\(Bundle.main.object(forInfoDictionaryKey: "CFBundleShortVersionString") as? String ?? "사용할 수 없음")").foregroundColor(.gray)
                            }
                        }
                    }
                    NavigationLink(destination: Sponsor()) {
                        Text("후원하러 가기")
                    }
                    NavigationLink(destination: Reference()) {
                        Text("출처 및 참고자료")
                    }
                }
                Section {
                    NavigationLink(destination: DetailView(discipline: "기준 및 경고")) {
                        Text("판별 기준 및 주의사항")
                    }
                    NavigationLink(destination: SearchHelp()) {
                        Text("주변 찾기 사용법")
                    }
                }
            }.listStyle(GroupedListStyle())
                .navigationBarTitle("이 앱의 정보", displayMode: .inline)
        }
    }
}

struct InfoView_Previews: PreviewProvider {
    static var previews: some View {
        InfoView()
    }
}
