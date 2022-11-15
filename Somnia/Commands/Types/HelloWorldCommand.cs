using System.Transactions;

namespace Somnia.Commands.Types;

public class HelloWorldCommand : Command
{

    public HelloWorldCommand()
    {
        Name = "hw";
        Description = "Hello World";
    }
    
    public override void Execute(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("Args: " + string.Join(", ", args));
    }
}