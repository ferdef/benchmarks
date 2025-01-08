const { performance } = require('perf_hooks');

function quicksort(arr) {
    if (arr.length <= 1) {
        return arr;
    }
    let pivot = arr[Math.floor(arr.length / 2)];
    let left = arr.filter(x => x < pivot);
    let middle = arr.filter(x => x === pivot);
    let right = arr.filter(x => x > pivot);
    return quicksort(left).concat(middle, quicksort(right));
}

let arr = Array.from({ length: 1000000 }, () => Math.floor(Math.random() * 1000000));

const start = performance.now();
let sorted_arr = quicksort(arr);
const end = performance.now();

console.log(`Node.js: ${((end - start) / 1000).toFixed(2)} seconds`);
