using Somnia.Error;
using Somnia.Interpreter.Tokens.Default;

namespace Somnia.Interpreter.Tokens;

public class TokenManager
{
    
    public List<Token> Tokens = new List<Token>();

    public TokenManager()
    {
        AddToken(new PrintToken());
        AddToken(new GotoToken());
        AddToken(new ExitToken());
        AddToken(new RunToken());
        AddToken(new IfToken());
    }
    
    public void AddToken(Token token)
    {
        Tokens.Add(token);
    }
    
    public void RemoveToken(Token token)
    {
        Tokens.Remove(token);
    }

    public bool RunToken(string id, string body, int line, string where)
    {
        foreach (Token token in Tokens)
        {
            if (token.ID == id)
            {
                return token.Run(body, line, where);
            }
        }
        new SyntaxError().Throw("Unknown token", line, where);
        return false;
    }

}