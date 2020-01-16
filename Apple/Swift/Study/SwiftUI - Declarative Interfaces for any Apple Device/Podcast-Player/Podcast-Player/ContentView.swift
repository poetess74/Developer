//
//  ContentView.swift
//  Podcast-Player
//
//  Created by HM on 1/9/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct ContentView: View {
    let episode = Episode(name: "Macbreak Weekly", track: "WWDC 2019")
    @State private var isPlaying = false
    var body: some View {
        VStack {
            Text(self.episode.name)
                .font(.title)
                .foregroundColor(self.isPlaying ? .green : .black)
            Text(self.episode.track)
                .foregroundColor(.secondary)
            PlayButton(isPlaying: $isPlaying)
        }
    }
}

struct PlayButton: View {
    @Binding var isPlaying: Bool
    var body: some View {
        Button(action: {
            self.isPlaying.toggle()
        }) {
            if (!self.isPlaying) {
                Text("Play")
            } else {
                Text("Stop")
            }
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
