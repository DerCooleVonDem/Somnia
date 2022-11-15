using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class PrintToken : Token
{
    public PrintToken() : base("print") { }

    public override bool Run(string body, int line, string where)
    {
        int type = DataUtil.IdentifyDataType(body);
        if (type != STRING && type != VARIABLE)
        {
            new SyntaxError().Throw("Invalid data type for print statement - Expected string, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
            return false;
        }
        
        if (type == VARIABLE)
        {
            string? unparsed = DataUtil.FromVariable(body);
            if (unparsed == null)
            {
                new SyntaxError().Throw("Invalid data type for print statement - Expected string, got empty " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
                return false;
            }

            if (DataUtil.IdentifyDataType(unparsed) != STRING)
            {
                new SyntaxError().Throw("Invalid data type for print statement - Expected string, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(unparsed)), line, where);
                return false;   
            }
            
            Console.WriteLine(DataUtil.ToString(unparsed));
            return true;
        }
        
        Console.WriteLine(DataUtil.ToString(body));
        return true;
    }
}