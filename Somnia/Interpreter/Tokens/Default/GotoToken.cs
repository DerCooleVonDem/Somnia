using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class GotoToken : Token
{
    public GotoToken() : base("goto") { }

    public override bool Run(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) != INT && DataUtil.IdentifyDataType(body) != VARIABLE)
        {
            new SyntaxError().Throw("Invalid data type for goto statement - Expected int, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
            return false;
        }

        int toLine = -1;
        
        if (DataUtil.IdentifyDataType(body) == INT)
        {
            toLine = int.Parse(body);
        }
        else if (DataUtil.IdentifyDataType(body) == VARIABLE)
        {
            string? unparsed = DataUtil.FromVariable(body);
            if (unparsed == null)
            {
                new SyntaxError().Throw("Invalid data type for goto statement - Expected int, got empty " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
                return false;
            }
            
            toLine = DataUtil.ToInt(unparsed);
        }

        Interpreter.GetInstance().GotoLine(toLine - 1);
        return true;
    }
}