using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Haker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
