//
//  ContentView.swift
//  SearchingSwiftUI
//
//  Created by HM on 1/20/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    @State private var searchTerm: String = ""
    let names = ["Azam", "Jake", "Alex", "Mary", "Jack", "Jerry"]
    var body: some View {
        List {
            SearchBar(text: $searchTerm)
            ForEach(self.names.filter { self.searchTerm.isEmpty ? true : $0.localizedCaseInsensitiveContains(self.searchTerm) }, id: \.self) { name in
                Text(name)
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
