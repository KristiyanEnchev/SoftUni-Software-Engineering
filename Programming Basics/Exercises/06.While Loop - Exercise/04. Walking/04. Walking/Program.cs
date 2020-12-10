using System;
class Program
{
    static void Main(string[] args)
    {
        int goal = 10000;
        int stepCount = 0;
        string comand = Console.ReadLine();
        while (comand != "Going home")
        {
            int steps = int.Parse(comand);
            stepCount += steps;
            if (stepCount >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepCount - 10000} steps over the goal!");
                break;
            }
            comand = Console.ReadLine();
        }
        if (comand == "Going home")
        {
            int stepsToHome = int.Parse(Console.ReadLine());
            stepCount += stepsToHome;
            if (stepCount >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepCount - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(stepCount - 10000)} more steps to reach goal.");
            }
        }
    }
}