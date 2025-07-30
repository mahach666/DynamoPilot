using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public static class TypeNodes
{
    // IType
    [IsDesignScriptCompatible]
    public static List<PilotType> AllTypes()
    {
        var repo = StaticMetadata.ObjectsRepository;

        return repo?.GetTypes()
            .ToList()
               ?? new List<PilotType>();
    }

    [IsDesignScriptCompatible]     
    public static PilotType GetTypeById(int id)
        => StaticMetadata.ObjectsRepository?.GetType(id);

    [IsDesignScriptCompatible]
    public static PilotType GetTypeByName(string name)
        => StaticMetadata.ObjectsRepository?.GetType(name);


    // Other
    //public static IDictionary<string, object> GetProperties(PilotType t)
    //{
    //    var result = new Dictionary<string, object>();
    //    if (t == null) return result;

    //    var type = t.GetType();

    //    foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
    //    {
    //        if (prop.GetIndexParameters().Length == 0)
    //        {
    //            if(prop.Name.Contains("Unwrap")) continue; 
    //            result[prop.Name] = prop.GetValue(t) ?? "null";
    //        }
    //    }

    //    foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
    //    {
    //        if (field.Name.Contains("Unwrap")) continue;
    //        result[field.Name] = field.GetValue(t) ?? "null";
    //    }

    //    return result;
    //}
}

