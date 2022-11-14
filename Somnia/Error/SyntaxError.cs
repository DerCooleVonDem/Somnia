namespace Somnia.Error;

public class SyntaxError
{
    public void Throw(string message, int line, string where)
    {
        Console.WriteLine("\u001b[31m" + "Syntax Error: " + message + " at line " + (line + 1) + " in " + where);
    }
}