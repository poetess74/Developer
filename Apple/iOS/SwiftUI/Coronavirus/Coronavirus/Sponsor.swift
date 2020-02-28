//
//  Sponsor.swift
//  Coronavirus
//
//  Created by HM on 2020/02/28.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct Sponsor: View {
    @State private var drink = false
    @State private var schoolfood = false
    @State private var hambuger = false
    @State private var bill = 0
    var body: some View {
        VStack {
            Image(systemName: "exclamationmark.triangle.fill").font(.custom("Helvetica", size: 72)).foregroundColor(.yellow).padding()
            Text("본 후원 환불은 애플 정책에 따라 개발자가 구입목록을 관리할 수 없습니다. 따라서 개발자가 아닌 애플에 문의하여 주십시오. ").multilineTextAlignment(.center).padding()
            Divider()
            Text("후원할 품목 선택").font(.title)
            List {
                Button(action: {
                    self.schoolfood.toggle()
                }, label: {
                    HStack {
                        Rectangle()
                        .fill(!self.schoolfood ? Color.gray : Color.blue)
                        .frame(width: 20, height: 20, alignment: .center)
                        .cornerRadius(5)
                        Text("학식")
                        Spacer()
                        Text("₩4,000").foregroundColor(.gray)
                    }
                })
                Button(action: {
                    self.drink.toggle()
                }, label: {
                    HStack {
                        Rectangle()
                        .fill(!self.drink ? Color.gray : Color.blue)
                        .frame(width: 20, height: 20, alignment: .center)
                        .cornerRadius(5)
                        Text("코코아 / 탄산수")
                        Spacer()
                        Text("₩5,400").foregroundColor(.gray)
                    }
                })
                Button(action: {
                    self.hambuger.toggle()
                }, label: {
                    HStack {
                        Rectangle()
                        .fill(!self.hambuger ? Color.gray : Color.blue)
                        .frame(width: 20, height: 20, alignment: .center)
                        .cornerRadius(5)
                        Text("와퍼 세트")
                        Spacer()
                        Text("₩7,900").foregroundColor(.gray)
                    }
                })
                if self.drink || self.schoolfood || self.hambuger {
                    HStack {
                        Text("합계")
                        Spacer()
                        Text("₩\(Control(schoolfood: self.schoolfood, drink: self.drink, hambuger: self.hambuger, recept: self.bill))").foregroundColor(.gray)
                    }
                }
            }.listStyle(GroupedListStyle())
            HStack {
                if self.drink || self.schoolfood || self.hambuger {
                    Button(action: {
                        self.drink = false
                        self.schoolfood = false
                        self.hambuger = false
                        self.bill = 0
                    }, label: { Text("초기화").font(.title).foregroundColor(.red) }).padding()
                    Button(action: {}, label: { Text("후원하기").font(.title) }).padding()
                } else {
                    Text("먼저 후원하실 품목을 선택하여 주십시오. ").padding()
                }
            }
            
            .navigationBarTitle("후원하기")
        }
    }
}

private func Control(schoolfood: Bool, drink: Bool, hambuger: Bool, recept: Int) -> Int {
    var bill = recept
    if schoolfood {
        bill += 4000
    }
    if drink {
        bill += 5400
    }
    if hambuger {
        bill += 7900
    }
    return bill
}

struct Sponsor_Previews: PreviewProvider {
    static var previews: some View {
        Sponsor()
    }
}
