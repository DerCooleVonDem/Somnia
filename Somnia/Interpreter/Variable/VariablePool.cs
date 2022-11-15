using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Variable;

public class VariablePool
{
    
    public static VariablePool Instance { get; private set; }
    
    public VariablePool()
    {
        Instance = this;
    }
    
    public static VariablePool GetInstance()
    {
        return Instance;
    }
    
    public Dictionary<string, string> Variables { get; set; } = new Dictionary<string, string>();
    
    public void AddVariable(string name, string value)
    {
        Variables.Add(name, value);
    }

    public void RemoveVariable(string name)
    {
        Variables.Remove(name);
    }
    
    public string? GetVariable(string name)
    {
        return Variables.TryGetValue(name, out var value) ? value : null;
    }
}