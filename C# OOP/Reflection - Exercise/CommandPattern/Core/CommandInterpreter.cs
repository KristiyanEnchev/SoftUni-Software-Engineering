using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs[0].ToLower();
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            var allTypes = assembly.GetTypes();

            Type commandType = allTypes
                .FirstOrDefault(x => x.Name.ToLower().StartsWith(commandName));

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}