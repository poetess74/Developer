//
//  ContentView.swift
//  Coronavirus
//
//  Created by HM on 2020/02/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var fever = false
    @State private var contact = false
    @State private var cough = false
    @State private var sputum = false
    @State private var lethargy = false
    @State private var throat = false
    @State private var dyspnea = false
    @State private var isAlert = false
    @State private var done = false
    @State private var title = ""
    @State private var message = ""
    private let callURL: NSURL = URL(string: "TEL://1339")! as NSURL
    var body: some View {
        NavigationView {
            VStack {
                List {
                    if ((self.fever || self.cough) || (self.sputum || self.lethargy) || (self.throat || self.dyspnea)) && self.done && self.contact {
                        ZStack {
                            Rectangle()
                                .fill(Color.red)
                                .frame(width: 350, height: 60, alignment: .center)
                                .cornerRadius(5)
                            VStack {
                                Text("코로나 19 감염의심 증상이 확인되었습니다. ").bold().foregroundColor(.white)
                                HStack {
                                    Button(action: {
                                        UIApplication.shared.open(self.callURL as URL, options: [:], completionHandler: nil)
                                    }, label: { Text("1339").bold() })
                                    Text("에 연락 후 상담사 지시에 따르기").bold().foregroundColor(.white)
                                }
                            }
                        }
                    } else if ((self.fever || self.cough) || (self.sputum || self.lethargy) || (self.throat || self.dyspnea)) && self.done && !self.contact {
                        ZStack {
                            Rectangle()
                                .fill(Color.green)
                                .frame(width: 350, height: 60, alignment: .center)
                                .cornerRadius(5)
                            VStack {
                                Text("코로나 19 감염은 아닌것 같지만 진단을 받으려면").bold().foregroundColor(.white)
                                HStack {
                                    Button(action: {
                                        UIApplication.shared.open(self.callURL as URL, options: [:], completionHandler: nil)
                                    }, label: { Text("1339").bold() })
                                    Text("에 연락 후 상담사 지시에 따르기").bold().foregroundColor(.white)
                                }
                            }
                        }
                    } else if !((self.fever || self.cough) || (self.sputum || self.lethargy) || (self.throat || self.dyspnea)) && self.done && !self.contact {
                        ZStack {
                            Rectangle()
                                .fill(Color.blue)
                                .frame(width: 350, height: 60, alignment: .center)
                                .cornerRadius(5)
                            Text("코로나 19에 감염되지 않았음").bold().foregroundColor(.white)
                        }
                    } else if !((self.fever || self.cough) || (self.sputum || self.lethargy) || (self.throat || self.dyspnea)) && self.done && self.contact {
                        ZStack {
                            Rectangle()
                                .fill(Color.orange)
                                .frame(width: 350, height: 60, alignment: .center)
                                .cornerRadius(5)
                            Text("코로나 19가 현재 잠복기인 것 같습니다. ").bold().foregroundColor(.white)
                        }
                    }
                    if !self.done || self.contact {
                        HStack {
                            Button(action: {
                                self.contact.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.contact ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("코로나 유행지역 방문 또는 확진자와 동선 겹침").font(.caption)
                        }.padding()
                    }
                    if !self.done || self.fever {
                        HStack {
                            Button(action: {
                                self.fever.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.fever ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("37.5°C 이상 발열")
                        }.padding()
                    }
                    if !self.done || self.cough {
                        HStack {
                            Button(action: {
                                self.cough.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.cough ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("기침")
                        }.padding()
                    }
                    if !self.done || self.sputum {
                        HStack {
                            Button(action: {
                                self.sputum.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.sputum ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("가래")
                        }.padding()
                    }
                    if !self.done || self.lethargy {
                        HStack {
                            Button(action: {
                                self.lethargy.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.lethargy ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("무기력")
                        }.padding()
                    }
                    if !self.done || self.throat {
                        HStack {
                            Button(action: {
                                self.throat.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.throat ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("인후통")
                        }.padding()
                    }
                    if !self.done || self.dyspnea {
                        HStack {
                            Button(action: {
                                self.dyspnea.toggle()
                            }) {
                                Rectangle()
                                    .fill(!self.dyspnea ? Color.gray : Color.blue)
                                    .frame(width: 20, height: 20, alignment: .center)
                                    .cornerRadius(5)
                            }.disabled(self.done)
                            Text("호흡곤란")
                        }.padding()
                    }
                }.listStyle(GroupedListStyle())
                if self.done && self.contact {
                    Text("상담할 때 증상을 사실대로 의료진에게 얘기하셔야 하며 의료진의 격리 및 치료 요구의 불응은 자신과 가족 더 나아가 사회에 큰 해가 될 수 있음을 숙지하십시오.\n코로나 19 검진으로 인해 병원을 방문할 시 \"선별 진료소\"로 자차를 이용하여 방문하시길 부탁드립니다. ").multilineTextAlignment(.center).foregroundColor(.red).padding()
                } else {
                    Text("본 자가진단앱은 코로나 19에 감염되었는지 간단히 체크하는 용도이며 과신할 경우 문제의 소지가 있습니다.  ").multilineTextAlignment(.center).padding()
                }
                if !self.done {
                    Button(action: {
                        if (self.fever || self.cough) || (self.sputum || self.lethargy) || (self.throat || self.dyspnea) {
                            self.title = "코로나 19 의심 증상이 확인되었습니다. "
                            self.message = "1339에 연락 후 가까운 선별 진료소에 방문하셔서 진단을 받아보시길 권장드립니다. "
                        } else if self.contact {
                            self.title = "코로나 19 잠복기인 것 같습니다. "
                            self.message = "마스크, 손씻기 등 위생관리를 철저히 하여 추가 피해를 방지하여 주시기 바랍니다. "
                        } else {
                            self.title = "코로나 19에 감염되지 않았습니다. "
                            self.message = "마스크, 손씻기 등 위생관리를 철저히 하시길 바랍니다. "
                        }
                        self.isAlert = true
                        self.done = true
                    }) { Image(systemName: "checkmark") }.padding().font(.largeTitle)
                } else {
                    Button(action: {
                        self.fever = false
                        self.contact = false
                        self.cough = false
                        self.sputum = false
                        self.lethargy = false
                        self.throat = false
                        self.dyspnea = false
                        self.done = false
                    }) { Image(systemName: "arrow.clockwise").foregroundColor(.red)}.font(.largeTitle).alert(isPresented: $isAlert) {
                        Alert(title: Text(self.title), message: Text(self.message), dismissButton: .default(Text("승인")))
                    }.padding()
                }
                
                HStack {
                    Button(action: {
                        let url = URL(string: "http://ncov.mohw.go.kr/bdBoardList.do?brdId=1&brdGubun=11&dataGubun=&ncvContSeq=&contSeq=&board_id=&gubun=")
                        UIApplication.shared.open(url!)
                    }) { Image(systemName: "location.north.line") }.padding(40).font(.largeTitle)
                    Button(action: {
                        let url = URL(string: "http://www.mohw.go.kr/react/popup_200128.html")
                        UIApplication.shared.open(url!)
                    }) { Image(systemName: "staroflife") }.padding(40).font(.largeTitle)
                }
            }
            .navigationBarTitle("코로나 19 자가진단", displayMode: .inline)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
