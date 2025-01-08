package main

import (
    "fmt"
    "math/rand"
    "time"
)

func quicksort(arr []int) []int {
    if len(arr) < 2 {
        return arr
    }

    left, right := 0, len(arr)-1

    pivotIndex := rand.Int() % len(arr)

    arr[pivotIndex], arr[right] = arr[right], arr[pivotIndex]

    for i, _ := range arr {
        if arr[i] < arr[right] {
            arr[i], arr[left] = arr[left], arr[i]
            left++
        }
    }

    arr[left], arr[right] = arr[right], arr[left]

    quicksort(arr[:left])
    quicksort(arr[left+1:])

    return arr
}

func main() {
    rand.Seed(time.Now().UnixNano())
    arr := make([]int, 1000000)
    for i := range arr {
        arr[i] = rand.Intn(1000000)
    }

    start := time.Now()
    quicksort(arr)
    duration := time.Since(start)

    fmt.Printf("Go: %v seconds\n", duration.Seconds())
}
