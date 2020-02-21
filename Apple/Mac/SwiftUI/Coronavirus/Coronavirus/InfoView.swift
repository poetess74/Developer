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
            VStack {
                Text("개발자: Hyeongmin Kim").padding()
                Text("코로나 19 의심 판별 기준\n\"코로나 유행지역 방문 또는 확진자의 동선 겹침\"\n이 선택되어야 함").multilineTextAlignment(.center)
                Text("본 자가진단앱은 코로나 19에 감염되었는지 간단히 체크하는 용도이며 과신할 경우 문제의 소지가 있습니다. ").multilineTextAlignment(.center).padding()
                Text("상담할 때 증상을 사실대로 의료진에게 얘기하셔야 하며 의료진의 격리 및 치료 요구의 불응은 자신과 가족 더 나아가 사회에 큰 해가 될 수 있음을 숙지하십시오.\n코로나 19 검진으로 인해 병원을 방문할 시 \"선별 진료소\"로 자차를 이용하여 방문하시길 부탁드립니다. ").multilineTextAlignment(.center).foregroundColor(.red).padding()
                Text("동선 또는 선별진료소 찾기")
                HStack {
                    Image(systemName: "location")
                    Text("(주변) 탭에서")
                }
                HStack {
                    Image(systemName: "location.north.line")
                    Text("(발생현황 및 이동경로) 나")
                }
                HStack {
                    Image(systemName: "staroflife")
                    Text("(선별 진료소 찾기) 를 탭하여")
                }
                Text("동선과 주변의 선별진료소를 확인하십시오. ")
            }
                .navigationBarTitle("이 앱의 정보", displayMode: .inline)
        }
    }
}

struct InfoView_Previews: PreviewProvider {
    static var previews: some View {
        InfoView()
    }
}
