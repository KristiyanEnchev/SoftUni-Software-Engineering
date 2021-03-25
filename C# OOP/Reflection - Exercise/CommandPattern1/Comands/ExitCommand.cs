using CommandPattern.Core.Contracts;
using CommandPattern.Comands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Comands
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
