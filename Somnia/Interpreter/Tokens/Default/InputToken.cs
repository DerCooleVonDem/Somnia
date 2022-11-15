using Somnia.Error;
using Somnia.Interpreter.Data;
using Somnia.Interpreter.Variable;

namespace Somnia.Interpreter.Tokens.Default;

public class InputToken : Token
{
    public InputToken() : base("input") { }

    public override bool Run(string body, int line, string where)
    {
        string[] parts = body.Split("->");
        
        if(parts.Length != 2)
        {
            new SyntaxError().Throw("Invalid input declaration", line, where);
            return false;
        }

        string name = parts[0].Trim();
        string value = parts[1].Trim();

        //Get the input out of the console
        Console.Write(DataUtil.ToString(value) + " ");
        string? input = Console.ReadLine();
        if(input == null)
        {
            new SyntaxError().Throw("Invalid input - Input can not be null", line, where);
            return false;
        }

        VariablePool.GetInstance().AddVariable(name, "\"" + input + "\"");
        return true;
    }
}