using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        var random = new Random();
        int[] arr = new int[1000000];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(0, 1000000);
        }

        var stopwatch = Stopwatch.StartNew();
        Quicksort(arr, 0, arr.Length - 1);
        stopwatch.Stop();

        Console.WriteLine($"C#: {stopwatch.Elapsed.TotalSeconds} seconds");
    }

    static void Quicksort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            Quicksort(arr, low, pi - 1);
            Quicksort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(ref arr[i], ref arr[j]);
            }
        }
        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
