using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int nan = 0;
        while (true)
        {
            int num = int.Parse(Console.ReadLine());
            nan += num;
            if (nan < n)
            {
                continue;
            }
            else
            {
                Console.WriteLine(nan);
            }
            break;
        }
    }
}
