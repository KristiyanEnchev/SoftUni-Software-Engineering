using CommandPattern.Core.Contracts;
using CommandPattern.Comands;

namespace CommandPattern.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
