using CommandPattern.Core.Contracts;
using CommandPattern.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory comandFactory;

        public CommandInterpreter() 
        {
            this.comandFactory = new CommandFactory();
        }

        public string Read(string args)
        {
            string[] parts = args.Split();
            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();

            ICommand comand = this.comandFactory.CreateCommand(commandType);

            return comand.Execute(commandArgs);
        }

    }
}
