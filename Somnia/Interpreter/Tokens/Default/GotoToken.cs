using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class GotoToken : Token
{
    public GotoToken() : base("goto") { }

    public override bool Run(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) == INT)
        {
            Interpreter.GetInstance().GotoLine(DataUtil.ToInt(body));
            return true;
        }
        
        new SyntaxError().Throw("Invalid data type for goto statement - Expected int, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
        return false;
    }
}