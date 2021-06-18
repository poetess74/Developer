//selection short
#include <fstream>
#include <vector>
#include <iostream>
#include <algorithm>

using namespace std;

int main() {
	vector<int> data;
	int count;
	int value;

//	ifstream fin("input.txt");
//
//	fin >> count;
//
//	for (int i = 0; i < count; i++) {
//		fin >> value;
//		data.push_back(value);
//	}
//
//	fin.close();

	count = 10;

	for (int i = 0; i < count; i++) {
		value = rand() % 10000;
		data.push_back(value);
	}

	clock_t t = clock();

//	for (int i = 0; i < count - 1; i++) {
//		for (int j = i + 1; j < count; j++) {
//			if (data[i] < data[j]) {
//				swap(data[i], data[j]);
//			}
//		}
//	}

	sort(data.begin(), data.end());

	printf("\nTime taken: %.4fs\n", (float)(clock() - t) / CLOCKS_PER_SEC);

	ofstream fout("output.txt");

	for (int i = 0; i < count; i++) {
		fout << data[i] << endl;
	}

	fout.close();

	return 0;
}
