using System;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstTupleData = Console.ReadLine().Split(" ");
            string fullName = $"{firstTupleData[0]} {firstTupleData[1]}";

            MyTuple<string, string> tuple = new MyTuple<string, string>(fullName, firstTupleData[2]);

            string[] secondTupleData = Console.ReadLine().Split(" ");

            MyTuple<string, int> secondTuple = new MyTuple<string, int>(secondTupleData[0], int.Parse(secondTupleData[1]));

            string[] thirdTupleData = Console.ReadLine().Split(" ");

            MyTuple<int, double> thirdTuple = new MyTuple<int, double>(int.Parse(thirdTupleData[0]), double.Parse(thirdTupleData[1]));

            Console.WriteLine(tuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
