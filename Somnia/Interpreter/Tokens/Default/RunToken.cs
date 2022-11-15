using Somnia.Error;
using Somnia.Interpreter.Data;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Tokens.Default;

public class RunToken : Token
{
    public RunToken() : base("run") { }

    public bool RunFile(string where, int line, string from)
    {
        string path = DataUtil.FromRelativePath(from, where);
        //if file not exists throw a syntax error
        if (!File.Exists(path))
        {
            new SyntaxError().Throw("Invalid file", line, from);
            return false;
        }

        Interpreter interpreter = new Interpreter(path);
        interpreter.Run();

        return true;
    }

    public override bool Run(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) == STRING)
        {
            return RunFile(DataUtil.ToString(body), line, where);
        }

        if (DataUtil.IdentifyDataType(body) == VARIABLE)
        {
            string? unparsed = DataUtil.FromVariable(body);
            if (unparsed == null)
            {
                new SyntaxError().Throw("Invalid variable", line, where);
            }

            if (DataUtil.IdentifyDataType(unparsed) != STRING)
            {
                new SyntaxError().Throw("Invalid data type for run statement - Expected string/path, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(unparsed)), line, where);
            }
            
            return RunFile(DataUtil.ToString(unparsed), line, where);
        }
        
        new SyntaxError().Throw("Invalid data type for run statement - Expected string/path, got " + DataUtil.DataTypeToString(DataUtil.IdentifyDataType(body)), line, where);
        return false;
    }
}