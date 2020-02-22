//
//  InfoView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/21.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct InfoView: View {
    var body: some View {
        NavigationView {
            List {
                Section {
                    HStack {
                        Text("개발자")
                        Spacer()
                        Text("Hyeongmin Kim").foregroundColor(.gray)
                    }
                }
                Section {
                    NavigationLink(destination: DetailView(discipline: "판별 기준")) {
                        Text("코로나 19 의심 판별 기준")
                    }
                    NavigationLink(destination: DetailView(discipline: "주의 사항")) {
                        Text("이 앱을 사용시 주의사항")
                    }
                }
                Section {
                    NavigationLink(destination: SearchHelp()) {
                        Text("동선 또는 선별진료소 찾는 방법")
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
