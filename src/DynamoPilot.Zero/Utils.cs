using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Reflection;

public static class Utils
    {
    public static IDictionary<string, object> GetProperties(PilotType t)
    {
        var result = new Dictionary<string, object>();
        if (t == null) return result;

        var type = t.GetType();

        foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (prop.GetIndexParameters().Length == 0)
            {
                if (prop.Name.Contains("Unwrap")) continue;
                result[prop.Name] = prop.GetValue(t) ?? "null";
            }
        }

        foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
        {
            if (field.Name.Contains("Unwrap")) continue;
            result[field.Name] = field.GetValue(t) ?? "null";
        }

        return result;
    }
}

