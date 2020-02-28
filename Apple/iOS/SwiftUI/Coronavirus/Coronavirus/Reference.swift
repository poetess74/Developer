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
            Section(header: Text("참고 자료")) {
                NavigationLink(destination: DetailView(discipline: "Q&A")) {
                    Text("코로나19 Q&A")
                }
                NavigationLink(destination: DetailView(discipline: "팩트 체크")) {
                    Text("코로나 팩트 체크")
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
