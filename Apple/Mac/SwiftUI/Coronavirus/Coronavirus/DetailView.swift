//
//  DetailView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/22.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct DetailView: View {
    let discipline: String
    var body: some View {
        VStack {
            if discipline == "판별 기준" {
                Text("코로나 19 의심 판별 기준\n\n\"코로나 유행지역 방문 또는 확진자의 동선 겹침\"\n이 선택되어야 함").multilineTextAlignment(.center).padding()
            } else if discipline == "주의 사항" {
                Text("본 자가진단앱은 코로나 19에 감염되었는지 간단히 체크하는 용도이며 의료진의 처방보다 과신할 경우 문제의 소지가 있습니다.").multilineTextAlignment(.center).padding().foregroundColor(.red)
                Text("상담할 때 증상을 사실대로 의료진에게 얘기하셔야 하며 의료진의 격리 및 치료 요구의 불응은 자신과 가족 더 나아가 사회에 큰 해가 될 수 있음을 숙지하십시오.").multilineTextAlignment(.center).padding().foregroundColor(.red)
                Text("코로나 19 검진으로 인해 병원을 방문할 시 \"선별 진료소\"로 자차를 이용하여 방문하시길 부탁드립니다.").multilineTextAlignment(.center).padding().foregroundColor(.red)
            }
        }
        .navigationBarTitle(Text("\(discipline)"), displayMode: .inline)
    }
}

struct DetailView_Previews: PreviewProvider {
    static var previews: some View {
        DetailView(discipline: "")
    }
}
