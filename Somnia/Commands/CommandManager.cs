using Somnia.Commands.Types;
using Somnia.Error;

namespace Somnia.Commands;

public class CommandManager
{
 
    public List<Command> Commands = new List<Command>();

    public CommandManager()
    {
        AddCommand(new HelloWorldCommand());
        AddCommand(new Run());
    }
    
    public void AddCommand(Command command)
    {
        Commands.Add(command);
    }
    
    public void RemoveCommand(Command command)
    {
        Commands.Remove(command);
    }
    
    public void Execute(string command, string[] args)
    {
        bool found = false;

        if (!command.StartsWith("--"))
        {
            new CommandError().Throw("No valid command syntax provided.");
            Environment.Exit(1);
        }

        string replace = command.Replace("--", "");


        foreach (Command c in Commands)
        {
            if (c.Name == replace)
            {
                found = true;
                c.Execute(args);
            }
        }

        if (!found)
        {
            new CommandError().Throw("No valid commant found. Please check your spelling. \nType --help for a list of commands.");
            Environment.Exit(1);
        }
    }
}