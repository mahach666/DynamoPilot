using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Reflection;

namespace Utils
{
    public static class Reflection
    {
        [IsDesignScriptCompatible]
        public static IDictionary<string, object> GetProperties(PType t)
        {
            var result = new Dictionary<string, object>();
            if (t == null) return result;

            var type = t.GetType();

            foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.GetIndexParameters().Length == 0)
                {
                    result[prop.Name] = prop.GetValue(t) ?? "null";
                }
            }

            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                result[field.Name] = field.GetValue(t) ?? "null";
            }

            return result;
        }
    }
}
