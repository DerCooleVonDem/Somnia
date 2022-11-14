using Somnia.Error;
using static Somnia.Interpreter.Data.DataTypes;

namespace Somnia.Interpreter.Data;

public class DataEvaluator
{

    public static bool? IfEvaluation(string body, int line, string where)
    {
        if (DataUtil.IdentifyDataType(body) == BOOL)
        {
            return DataUtil.ToBool(body);
        }
        
        //split at the == operator
        string[] split = body.Split("==");
        
        //compare the two sides
        int dataTypeLeft = DataUtil.IdentifyDataType(split[0]);
        int dataTypeRight = DataUtil.IdentifyDataType(split[1]);
        
        //if not the same type, return false
        if (dataTypeLeft != dataTypeRight)
        {
            new SyntaxError().Throw("Cannot compare different data types (" + DataUtil.DataTypeToString(dataTypeLeft) + "==" +
                                    DataUtil.DataTypeToString(dataTypeRight) + ")", line, where);
            return null;
        }
        
        //if the same type, compare the two sides
        switch (dataTypeLeft)
        {
            case BOOL:
                return DataUtil.ToBool(split[0]) == DataUtil.ToBool(split[1]);
            case INT:
                return DataUtil.ToInt(split[0]) == DataUtil.ToInt(split[1]);
            case STRING:
                return DataUtil.ToString(split[0]).Equals(DataUtil.ToString(split[1]));
            default:
                new SyntaxError().Throw("Cannot compare different data types (" + DataUtil.DataTypeToString(dataTypeLeft) + "==" +
                                        DataUtil.DataTypeToString(dataTypeRight) + ")", line, where);
                return null;
        }
    }
    
}