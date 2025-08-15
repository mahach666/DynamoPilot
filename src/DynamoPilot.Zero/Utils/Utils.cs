using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Reflection;

namespace Utils
{
    /// <summary>
    /// Утилиты для работы с рефлексией и помощники для Dynamo
    /// </summary>
    public static class Reflection
    {
        /// <summary>
        /// Получает все публичные свойства и поля объекта типа с помощью рефлексии
        /// </summary>
        /// <param name="t">Тип объекта для анализа</param>
        /// <returns>Словарь свойств и их значений</returns>
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
