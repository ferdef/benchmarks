use std::time::Instant;

fn fibonacci(n: u64) -> u64 {
    if n < 2 {
        n
    } else {
        fibonacci(n - 1) + fibonacci(n - 2)
    }
}

fn main() {
    let n = 50;
    let start = Instant::now();
    let result = fibonacci(n);
    let duration = start.elapsed();

    println!("Fibo of {} is: {}. {:?} elapsed", n, result, duration);
}
