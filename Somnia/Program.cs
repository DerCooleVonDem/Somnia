using Somnia.Commands;
using Somnia.Error;

namespace Somnia;

class Program
{

    public static CommandManager CommandManager;
    
    static void Main(string[] args)
    {
        CommandManager = new CommandManager();

        if (args.Length == 0)
        {
            new CommandError().Throw("No arguments were provided.");
            Environment.Exit(1);
        }

        string command = args[0];
        string[] arguments = args.Skip(1).ToArray();
        CommandManager.Execute(command, arguments);
    }
}

