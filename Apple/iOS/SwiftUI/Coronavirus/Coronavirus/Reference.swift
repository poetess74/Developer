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
            Section(header: Text("출처"), footer: Text("이 앱에 포함된 콘텐츠는 보건복지부의 지침을 참조하여 제작되었습니다. 하지만 앱을 제작하는 도중 오류가 있을 수 있으므로 주의하여 주십시오. ")) {
                NavigationLink(destination: DetailView(discipline: "보건복지부")) {
                    Text("보건복지부")
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
                    Text("WHO")
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
