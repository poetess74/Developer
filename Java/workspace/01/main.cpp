#include <iostream>
#include <fstream>

using namespace std;

int main() {
	int max = INT_MIN;
	int min = INT_MAX;
	int count, value;

	ifstream fin("input.txt");
	ofstream fout("output.txt");

	fin >> count;
	while (count > 0) {
		fin >> value;

		if (max < value) {
			max = value;
		}

		if (value < min){
			min = value;
		}
		count--;
	}
	fout << max - min << endl;


	fin.close();
	fout.close();

	return 0;

}
