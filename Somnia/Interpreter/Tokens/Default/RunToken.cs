using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class RunToken : Token
{
    public RunToken() : base("run") { }

    public override bool Run(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) == STRING)
        {
            string path = DataUtil.FromRelativePath(where, DataUtil.ToString(body));
            //if file not exists throw a syntax error
            if (!File.Exists(path))
            {
                new SyntaxError().Throw("Invalid file", line, where);
                return false;
            }

            Interpreter interpreter = new Interpreter(path);
            interpreter.Run();

            return true;
        }
        
        new SyntaxError().Throw("Invalid data type for run statement - Expected string/path, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
        return false;
    }
}