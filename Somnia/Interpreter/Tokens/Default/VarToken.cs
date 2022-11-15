using Somnia.Error;
using Somnia.Interpreter.Data;
using Somnia.Interpreter.Variable;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class VarToken : Token
{
    public VarToken() : base("var") { }

    public override bool Run(string body, int line, string where)
    {
        string[] parts = body.Split('=');
        
        if(parts.Length != 2)
        {
            new SyntaxError().Throw("Invalid variable declaration", line, where);
            return false;
        }

        string name = parts[0].Trim();
        string value = parts[1].Trim();

        VariablePool.GetInstance().AddVariable(name, value);
        return true;
    }
}