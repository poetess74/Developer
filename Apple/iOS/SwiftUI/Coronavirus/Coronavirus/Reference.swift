//
//  Reference.swift
//  Coronavirus
//
//  Created by HM on 2020/02/25.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Reference: View {
    var body: some View {
        List {
            Section(header: Text("출처")) {
                NavigationLink(destination: DetailView(discipline: "보건복지부")) {
                    Text("보건복지부")
                }
                NavigationLink(destination: DetailView(discipline: "질병관리본부")) {
                    Text("질병관리본부")
                }
                NavigationLink(destination: DetailView(discipline: "COVID-19")) {
                    Text("COVID-19")
                }
            }
            Section(header: Text("참고 자료"), footer: Text("위 링크는 모두 트위터로 연결됩니다. ")) {
                NavigationLink(destination: DetailView(discipline: "청와대 트위터")) {
                    Text("청와대")
                }
                NavigationLink(destination: DetailView(discipline: "정부 트위터")) {
                    Text("정부")
                }
                NavigationLink(destination: DetailView(discipline: "보건복지부 트위터")) {
                    Text("보건복지부")
                }
                NavigationLink(destination: DetailView(discipline: "질병관리본부 트위터")) {
                    Text("질병관리본부")
                }
                NavigationLink(destination: DetailView(discipline: "WHO 트위터")) {
                    Text("WHO (영문)")
                }
            }
        }.listStyle(GroupedListStyle())
    .navigationBarTitle("출처 및 참고자료")
    }
}

struct Reference_Previews: PreviewProvider {
    static var previews: some View {
        Reference()
    }
}
