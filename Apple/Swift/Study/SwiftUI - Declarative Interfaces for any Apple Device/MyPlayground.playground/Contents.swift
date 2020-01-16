import UIKit

let numbers = [2, 3, 4, 5, 6, 7, 8, 10, 12]

extension Array {
    func chunked(into size: Int) -> [[Element]] {
        return stride(from: 0, through: count, by: size).map {
            Array(self[$0..<Swift.min($0 + size, count)])
        }
    }
}

print(numbers.chunked(into: 2))
