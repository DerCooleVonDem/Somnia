namespace Somnia.Interpreter.Tokens;

public abstract class Token
{

    public string ID;
    
    public Token(string id)
    {
        ID = id;
    }
    
    public abstract bool Run(string body, int line, string where);
}