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
    @State private var agree = false
    @State private var bill = 0
    var body: some View {
        VStack {
            Image(systemName: "exclamationmark.triangle.fill").font(.custom("Helvetica", size: 72)).foregroundColor(.yellow).padding()
            Text("본 후원 환불 및 구입목록 삭제는 애플 정책에 따라 개발자가 구입목록을 관리할 수 없습니다. 따라서 개발자가 아닌 애플에 문의하여 주십시오. ").multilineTextAlignment(.center).padding()
            List {
                Section(header: Text("후원할 품목 선택")) {
                    HStack {
                        Button(action: { self.schoolfood.toggle() }, label: {
                            HStack {
                                Rectangle()
                                .fill(!self.schoolfood ? Color.gray : Color.blue)
                                .frame(width: 20, height: 20, alignment: .center)
                                .cornerRadius(5)
                            }
                        }).disabled(self.agree)
                        Text("학식")
                        Spacer()
                        Text("₩4,000").foregroundColor(.gray)
                    }
                    HStack {
                        Button(action: { self.drink.toggle() }, label: {
                            HStack {
                                Rectangle()
                                .fill(!self.drink ? Color.gray : Color.blue)
                                .frame(width: 20, height: 20, alignment: .center)
                                .cornerRadius(5)
                            }
                        }).disabled(self.agree)
                        Text("코코아 / 탄산수")
                        Spacer()
                        Text("₩5,400").foregroundColor(.gray)
                    }
                    HStack {
                        Button(action: { self.hambuger.toggle() }, label: {
                            HStack {
                                Rectangle()
                                .fill(!self.hambuger ? Color.gray : Color.blue)
                                .frame(width: 20, height: 20, alignment: .center)
                                .cornerRadius(5)
                            }
                        }).disabled(self.agree)
                        Text("와퍼 세트")
                        Spacer()
                        Text("₩7,900").foregroundColor(.gray)
                    }
                }
                if self.drink || self.schoolfood || self.hambuger {
                    Section(footer: self.agree ? Text("후원할 품목을 변경하려면 다시 탭하십시오. ") : Text("후원하기 버튼을 표시하려면 합계 확인 후 탭하십시오. ")) {
                        HStack {
                            Button(action: { self.agree.toggle() }, label: {
                                HStack {
                                    Rectangle()
                                    .fill(!self.agree ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                                }
                            })
                            self.agree ? Text("결제될 금액") : Text("합계")
                            Spacer()
                            Text("₩\(Control(schoolfood: self.schoolfood, drink: self.drink, hambuger: self.hambuger, recept: self.bill))").foregroundColor(.gray)
                        }
                    }
                }
            }.listStyle(GroupedListStyle())
            VStack {
                if (self.drink || self.schoolfood || self.hambuger) && self.agree {
                    Button(action: {
                        // TODO: Sponsor Action
                    }, label: { Text("후원 하기").font(.title) }).padding()
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
