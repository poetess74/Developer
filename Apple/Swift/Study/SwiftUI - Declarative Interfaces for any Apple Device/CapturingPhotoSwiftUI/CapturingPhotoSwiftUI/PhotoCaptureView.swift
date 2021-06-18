//
//  PhotoCaptureView.swift
//  CapturingPhotoSwiftUI
//
//  Created by HM on 1/19/20.
//  Copyright © 2020 HM. All rights reserved.
//

import SwiftUI

struct PhotoCaptureView: View {
    @Binding var showImagePicker: Bool
    @Binding var image: Image?
    var body: some View {
        ImagePicker(isShown: $showImagePicker, image: $image)
    }
}

struct PhotoCaptureView_Previews: PreviewProvider {
    static var previews: some View {
        PhotoCaptureView(showImagePicker: .constant(false), image: .constant(Image("")))
    }
}
