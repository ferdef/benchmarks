fn fibo(num: Int) -> Int:
  if (num < 2):
    return num

  return fibo(num-1) + fibo(num-2)

def main():
  var num = 50
  var result = fibo(num)
  print("Fibo of " + str(num) + " is " + str(result))