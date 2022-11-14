using Somnia.Error;

namespace Somnia.Commands.Types;

public class Run : Command
{

    public Run()
    {
        Name = "run";
        Description = "Runs a command";
    }
    
    public override void Execute(string[] args)
    {

        if (args.Length == 0)
        {
            new CommandError().Throw("No path provided.");
            Environment.Exit(1);
        }
        
        Interpreter.Interpreter interpreter = new Interpreter.Interpreter(args[0]);
        interpreter.Run();
    }
}