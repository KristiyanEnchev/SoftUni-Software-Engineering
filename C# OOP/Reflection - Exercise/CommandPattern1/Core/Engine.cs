using CommandPattern.Core.Contracts;
using CommandPattern.Comands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpretator;

        public Engine(ICommandInterpreter commandInterpretator)
        {
            this.commandInterpretator = commandInterpretator;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                string result = this.commandInterpretator.Read(line);

                if (result == null)
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
