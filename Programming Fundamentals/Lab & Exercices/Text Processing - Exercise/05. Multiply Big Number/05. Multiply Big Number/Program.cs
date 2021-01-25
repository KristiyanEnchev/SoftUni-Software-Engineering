using System;
using System.Linq;
using System.Text;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine().TrimStart('0');
            int multiplyer = int.Parse(Console.ReadLine());
            int temp = 0;
            var sb = new StringBuilder();

            if (multiplyer == 0 || num == "")
            {
                Console.WriteLine(0);
                return;
            }

            foreach (var charr in num.Reverse())
            {
                int digit = int.Parse(charr.ToString());
                int result = digit * multiplyer + temp;

                int rest = result % 10;
                temp = result / 10;

                sb.Insert(0, rest);
            }

            if (temp > 0)
            {
                sb.Insert(0, temp);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
