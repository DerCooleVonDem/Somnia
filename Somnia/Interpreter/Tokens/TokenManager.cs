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
        AddToken(new IfNotToken());
        AddToken(new VarToken());
        AddToken(new InputToken());
    }
    
    public void AddToken(Token token)
    {
        Tokens.Add(token);
    }
    
    public void RemoveToken(Token token)
    {
        Tokens.Remove(token);
    }

    public bool RunToken(string body, int line, string where)
    {
        List<Token> foundMatches = new List<Token>();
        body = body.Trim();
        foreach (Token token in Tokens)
        {
            if (body.StartsWith(token.ID))
            {
                foundMatches.Add(token);
            }
        }
        
        if(foundMatches.Count >= 1)
        {
            foundMatches.Sort((x, y) => x.ID.Length.CompareTo(y.ID.Length));
            foundMatches.Reverse();
            body = body.Replace(foundMatches[0].ID, "");
            body = body.Trim();
            return foundMatches[0].Run(body, line, where);
        }
        
        if (string.IsNullOrWhiteSpace(body))
        {
            return true;
        }
        
        new SyntaxError().Throw("Unknown token", line, where);
        return false;
    }

}