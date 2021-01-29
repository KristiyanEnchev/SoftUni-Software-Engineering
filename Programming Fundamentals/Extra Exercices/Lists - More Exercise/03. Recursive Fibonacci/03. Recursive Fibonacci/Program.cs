using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        int[] arr = new int[input + 2];
        arr[0] = 1;
        arr[1] = 1;

        for (int i = 0; i < arr.Length - 2; i++)
        {
            int num = arr[i] + arr[i + 1];
            arr[i + 2] = num;
        }

        Console.WriteLine(arr[input - 1]);
    }
}