namespace Somnia.Interpreter.Data;

public class DataUtil
{

    public static int IdentifyDataType(string data)
    {
        //check if the data is surrounded by quotes
        if (data.StartsWith("\"") && data.EndsWith("\"") || data.StartsWith("'") && data.EndsWith("'"))
        {
            return DataTypes.STRING;
        }

        return DataTypes.INVALID;
    }
    
    public static string ToPrintable(string data)
    {
        if (data.StartsWith("\"") && data.EndsWith("\"") || data.StartsWith("'") && data.EndsWith("'"))
        {
            return data.Substring(1, data.Length - 2);
        }

        return data;
    }
    
    public static string DataTypeToString(int dataType)
    {
        switch (dataType)
        {
            case DataTypes.STRING:
                return "string";
            case DataTypes.INVALID:
                return "invalid";
            default:
                return "unknown";
        }
    }
}