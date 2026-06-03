using Ascon.Pilot.SDK;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Data.Attributes
{
    /// <summary>
    /// Единая точка применения набора атрибутов к <see cref="PObjectBuilder"/>.
    /// <para>
    /// Если для атрибута известно его определение в <see cref="IType"/>, значение приводится
    /// строго к объявленному <see cref="AttributeType"/> (точное приведение, без угадывания).
    /// Если определение не найдено — используется приведение по форме значения.
    /// </para>
    /// </summary>
    public static class AttributeApplier
    {
        public static void Apply(PObjectBuilder builder, IType type, IEnumerable<KeyValuePair<string, object>> attributes)
        {
            if (builder == null || attributes == null) return;

            var defs = BuildTypeMap(type);

            foreach (var kvp in attributes)
            {
                var name = kvp.Key;
                var value = kvp.Value;
                if (string.IsNullOrEmpty(name) || value == null)
                    continue;

                if (defs != null && defs.TryGetValue(name, out var attrType))
                    ApplyTyped(builder, name, attrType, value);
                else
                    ApplyByShape(builder, name, value);
            }
        }

        private static Dictionary<string, AttributeType> BuildTypeMap(IType type)
        {
            if (type?.Attributes == null) return null;
            var map = new Dictionary<string, AttributeType>(StringComparer.Ordinal);
            foreach (var a in type.Attributes)
                if (a != null && !string.IsNullOrEmpty(a.Name))
                    map[a.Name] = a.Type;
            return map;
        }

        /// <summary>Приведение по объявленному типу атрибута.</summary>
        private static void ApplyTyped(PObjectBuilder builder, string name, AttributeType attrType, object value)
        {
            switch (attrType)
            {
                case AttributeType.Integer:
                    if (AttributeValueConverter.TryToLong(value, out var l)) builder.SetAttribute(name, l);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.Double:
                    if (AttributeValueConverter.TryToDouble(value, out var d)) builder.SetAttribute(name, d);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.Decimal:
                    if (AttributeValueConverter.TryToDecimal(value, out var m)) builder.SetAttribute(name, m);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.DateTime:
                    if (AttributeValueConverter.TryToDateTime(value, out var dt)) builder.SetAttribute(name, dt);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.String:
                case AttributeType.Numerator:
                    builder.SetAttribute(name, AttributeValueConverter.ToStr(value));
                    break;

                case AttributeType.Boolean:
                    if (AttributeValueConverter.TryToBool(value, out var b)) builder.SetAttributeAsObject(name, b);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.UserState:
                    if (AttributeValueConverter.TryToGuid(value, out var g)) builder.SetAttribute(name, g);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.OrgUnit:
                    if (AttributeValueConverter.IsArrayLike(value))
                        builder.SetAttribute(name, AttributeValueConverter.ToIntArray(value));
                    else if (AttributeValueConverter.TryToInt(value, out var oi))
                        builder.SetAttribute(name, oi);
                    else ApplyByShape(builder, name, value);
                    break;

                case AttributeType.Array:
                    ApplyArray(builder, name, value);
                    break;

                // ElementBook / ByteArray / Inherited и прочие — без надёжного отображения:
                // отдаём как объект, пусть SDK решает.
                default:
                    ApplyByShape(builder, name, value);
                    break;
            }
        }

        /// <summary>Приведение по фактической форме значения (когда тип атрибута неизвестен).</summary>
        private static void ApplyByShape(PObjectBuilder builder, string name, object value)
        {
            switch (value)
            {
                case string s: builder.SetAttribute(name, s); break;
                case bool b: builder.SetAttributeAsObject(name, b); break;
                case long l: builder.SetAttribute(name, l); break;
                case int i: builder.SetAttribute(name, (long)i); break;
                case double d: builder.SetAttribute(name, d); break;
                case float f: builder.SetAttribute(name, (double)f); break;
                case decimal m: builder.SetAttribute(name, m); break;
                case DateTime dt: builder.SetAttribute(name, dt); break;
                case Guid g: builder.SetAttribute(name, g); break;
                case int[] ia: builder.SetAttribute(name, ia); break;
                case string[] sa: builder.SetAttribute(name, sa); break;
                default:
                    if (AttributeValueConverter.IsArrayLike(value))
                        ApplyArray(builder, name, value);
                    else
                        builder.SetAttributeAsObject(name, value);
                    break;
            }
        }

        /// <summary>Массив: числовой → <c>int[]</c>, иначе → <c>string[]</c>.</summary>
        private static void ApplyArray(PObjectBuilder builder, string name, object value)
        {
            if (AttributeValueConverter.AllItemsIntLike(value))
                builder.SetAttribute(name, AttributeValueConverter.ToIntArray(value));
            else
                builder.SetAttribute(name, AttributeValueConverter.ToStringArray(value));
        }
    }
}
