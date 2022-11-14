using Somnia.Error;
using Somnia.Interpreter.Data;

namespace Somnia.Interpreter.Tokens.Default;

public class PrintToken : Token
{
    public PrintToken() : base("print") { }

    public override bool Run(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) == DataTypes.STRING)
        {
            Console.WriteLine(DataUtil.ToString(body));
            return true;
        }
        
        new SyntaxError().Throw("Invalid data type for print statement - Expected string, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
        return false;
    }
}