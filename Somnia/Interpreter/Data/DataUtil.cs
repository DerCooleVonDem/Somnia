using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Data;

public class DataUtil
{

    public static int IdentifyDataType(string data)
    {
        //check if the data is surrounded by quotes
        if (data.StartsWith("\"") && data.EndsWith("\"") || data.StartsWith("'") && data.EndsWith("'"))
        {
            return STRING;
        }
        
        //check if the data is a int
        if (int.TryParse(data, out int result))
        {
            return INT;
        }
        
        //check if the data is a bool
        if (bool.TryParse(data, out bool result2))
        {
            return BOOL;
        }

        return INVALID;
    }
    
    public static string ToString(string data)
    {
        if(IdentifyDataType(data) != STRING) return "";
        
        if (data.StartsWith("\"") && data.EndsWith("\"") || data.StartsWith("'") && data.EndsWith("'"))
        {
            return data.Substring(1, data.Length - 2);
        }

        return data;
    }
    
    public static int ToInt(string data)
    {
        if(IdentifyDataType(data) != INT) return 0;
        
        if (int.TryParse(data, out int result))
        {
            return result;
        }

        return 0;
    }
    
    public static bool ToBool(string data)
    {
        if(IdentifyDataType(data) != BOOL) return false;
        
        if (bool.TryParse(data, out bool result))
        {
            return result;
        }

        return false;
    }
    
    public static string DataTypeToString(int dataType)
    {
        switch (dataType)
        {
            case STRING:
                return "string";
            case INT:
                return "int";
            case BOOL:
                return "bool";
            case INVALID:
                return "invalid";
            default:
                return "unknown";
        }
    }
    
    public static string FromRelativePath(string originPath, string path)
    {
        if (path.StartsWith("./"))
        {
            path = path.Substring(2);
            
            //remove the file from the origin path
            originPath = originPath.Substring(0, originPath.LastIndexOf("/"));
            
            //add the relative path to the origin path
            return originPath + "/" + path;
        }

        return path;
    }
}