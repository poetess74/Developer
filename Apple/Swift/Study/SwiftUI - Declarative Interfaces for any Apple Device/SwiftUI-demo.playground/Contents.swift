import UIKit
import PlaygroundSupport
import SwiftUI

struct ContentView: View {
    var body: some View {
        Text("Hello World")
            .font(.title)
            .foregroundColor(.green)
    }
}

let contentView = ContentView()

PlaygroundPage.current.liveView = UIHostingController(rootView: contentView)
