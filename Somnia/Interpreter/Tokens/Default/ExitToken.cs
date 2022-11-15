using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class ExitToken : Token
{
    public ExitToken() : base("exit") { }

    public override bool Run(string body, int line, string where)
    {
        return false;
    }
}