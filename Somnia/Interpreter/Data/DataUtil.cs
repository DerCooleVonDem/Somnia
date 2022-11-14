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
        
        //check if the data is a int
        if (int.TryParse(data, out int result))
        {
            return DataTypes.INT;
        }

        return DataTypes.INVALID;
    }
    
    public static string ToPrintable(string data)
    {
        if(IdentifyDataType(data) != DataTypes.STRING) return "";
        
        if (data.StartsWith("\"") && data.EndsWith("\"") || data.StartsWith("'") && data.EndsWith("'"))
        {
            return data.Substring(1, data.Length - 2);
        }

        return data;
    }
    
    public static int ToInt(string data)
    {
        if(IdentifyDataType(data) != DataTypes.INT) return 0;
        
        if (int.TryParse(data, out int result))
        {
            return result;
        }

        return 0;
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