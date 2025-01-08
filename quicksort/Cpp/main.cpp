#include <iostream>
#include <vector>
#include <algorithm>
#include <chrono>
#include <random>

void quicksort(std::vector<int>& arr, int low, int high) {
    if (low < high) {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++) {
            if (arr[j] <= pivot) {
                i++;
                std::swap(arr[i], arr[j]);
            }
        }
        std::swap(arr[i + 1], arr[high]);
        int pi = i + 1;

        quicksort(arr, low, pi - 1);
        quicksort(arr, pi + 1, high);
    }
}

int main() {
    std::vector<int> arr(1000000);
    std::generate(arr.begin(), arr.end(), []() { return rand() % 1000000; });

    auto start = std::chrono::high_resolution_clock::now();

    quicksort(arr, 0, arr.size() - 1);

    auto end = std::chrono::high_resolution_clock::now();
    std::chrono::duration<double> duration = end - start;
    std::cout << "C++: " << duration.count() << " seconds" << std::endl;

    return 0;
}
