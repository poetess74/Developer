//
//  ImageDownloader.swift
//  DownloadImageSwiftUI
//
//  Created by HM on 1/21/20.
//  Copyright © 2020 HM. All rights reserved.
//

import Foundation

class ImageDownlader: ObservableObject {
    @Published var downloadedData: Data? = nil
    func downloadImage(url: String) {
        guard let imageURL = URL(string: url) else {
            fatalError("Invalid Url")
        }
        DispatchQueue.global().async {
            let data = try? Data(contentsOf: imageURL)
            DispatchQueue.main.async {
                self.downloadedData = data
            }
        }
    }
}
