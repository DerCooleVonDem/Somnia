using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class IfToken : Token
{
    public IfToken() : base("if") { }

    public override bool Run(string body, int line, string where)
    {
        bool? result = DataEvaluator.IfEvaluation(body, line, where);
        if(result == null)
        {
            return false;
        }

        if (!result.Value)
        {
            Interpreter.GetInstance().SkipToNextBreak();
        }
        
        return true;
    }
}