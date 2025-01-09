class Fibo {
  public static ulong recursive(ulong num) {
    if (num < 2) {
      return num;
    }

    return recursive(num - 1) + recursive(num - 2);
  }  
}