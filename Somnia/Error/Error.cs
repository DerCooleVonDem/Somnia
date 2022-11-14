namespace Somnia.Error;

public abstract class Error
{

    protected const string RED = "\u001b[31m";
    
    public abstract void Throw(string message);
}