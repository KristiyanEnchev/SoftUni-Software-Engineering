using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var sizeGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var valueOfIntellegence = int.Parse(Console.ReadLine());

            var bulletStack = new Stack<int>(bullets); 
            var locksQueue = new Queue<int>(locks); 
            var usedBullets = 0; 
            var barrelCount = 0; 

            while (bulletStack.Any() && locksQueue.Any())
            {

                if (bulletStack.Peek() <= locksQueue.Peek()) 
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue(); 
                    bulletStack.Pop(); 
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletStack.Pop();

                }

                barrelCount++;

                if (barrelCount == sizeGunBarrel && bulletStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }

                usedBullets++;
            }

            if (bulletStack.Count >= 0 && locksQueue.Count == 0)
            {
                var earn = valueOfIntellegence - (usedBullets * bulletPrice);
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earn}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}