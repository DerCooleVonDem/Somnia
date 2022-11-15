namespace Somnia.Error;

public class CommandError : Error{
    
    public override void Throw(string message)
    {
        Console.WriteLine(RED + "Command Error: " + message);
    }
}