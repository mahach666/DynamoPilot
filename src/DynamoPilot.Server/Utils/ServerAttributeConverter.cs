using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ascon.Pilot.DataClasses;

namespace DynamoPilot.Server.Utils
{
    /// <summary>
    /// Надёжное приведение значений из Dynamo к <see cref="DValue"/> для серверного API.
    /// <para>
    /// Учитывает форматы маршалинга Dynamo (целые → <see cref="long"/>, вещественные → <see cref="double"/>,
    /// списки → <c>object[]</c>, отсутствие <see cref="Guid"/> — приходит строкой) и, при наличии
    /// определения атрибута (<see cref="MAttrType"/>), приводит значение строго к нужному типу.
    /// </para>
    /// </summary>
    public static class ServerAttributeConverter
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        /// <summary>
        /// Заполняет словарь DValue из набора атрибутов с учётом определений типа (если они известны).
        /// </summary>
        /// <param name="target">Целевой словарь атрибутов объекта</param>
        /// <param name="attributes">Входные атрибуты (имя → значение из Dynamo)</param>
        /// <param name="attrTypes">Карта «имя атрибута → тип» из метаданных (может быть null)</param>
        public static void Apply(
            IDictionary<string, DValue> target,
            IDictionary<string, object> attributes,
            IDictionary<string, MAttrType> attrTypes)
        {
            if (target == null || attributes == null) return;

            foreach (var kvp in attributes)
            {
                var name = kvp.Key;
                var value = kvp.Value;
                if (string.IsNullOrWhiteSpace(name) || value == null)
                    continue;

                MAttrType? type = null;
                if (attrTypes != null && attrTypes.TryGetValue(name, out var t))
                    type = t;

                target[name] = ToDValue(value, type);
            }
        }

        public static DValue ToDValue(object value, MAttrType? type)
        {
            if (value == null) return new DValue();

            if (type.HasValue)
            {
                switch (type.Value)
                {
                    case MAttrType.Integer:
                        if (TryToLong(value, out var l)) return new DValue { IntValue = l };
                        break;
                    case MAttrType.Double:
                        if (TryToDouble(value, out var d)) return new DValue { DoubleValue = d };
                        break;
                    case MAttrType.Decimal:
                        if (TryToDecimal(value, out var m)) return new DValue { DecimalValue = m };
                        break;
                    case MAttrType.DateTime:
                        if (TryToDateTime(value, out var dt)) return new DValue { DateValue = dt };
                        break;
                    case MAttrType.String:
                    case MAttrType.Numerator:
                        return new DValue { StrValue = ToStr(value) };
                    case MAttrType.UserState:
                        if (TryToGuid(value, out var g)) return new DValue { GuidValue = g };
                        break;
                    case MAttrType.OrgUnit:
                        if (IsArrayLike(value)) return new DValue { ArrayIntValue = ToIntArray(value) };
                        if (TryToLong(value, out var ol)) return new DValue { IntValue = ol };
                        break;
                    case MAttrType.Array:
                        return ArrayToDValue(value);
                    // Boolean / ByteArray / ElementBook / Inherited — приведение по форме значения.
                }
            }

            return ByShape(value);
        }

        private static DValue ByShape(object value)
        {
            switch (value)
            {
                case string s: return new DValue { StrValue = s };
                case long l: return new DValue { IntValue = l };
                case int i: return new DValue { IntValue = i };
                case double d: return new DValue { DoubleValue = d };
                case float f: return new DValue { DoubleValue = f };
                case decimal m: return new DValue { DecimalValue = m };
                case DateTime dt: return new DValue { DateValue = dt };
                case Guid g: return new DValue { GuidValue = g };
                case int[] ia: return new DValue { ArrayIntValue = ia };
                case string[] sa: return new DValue { ArrayValue = sa };
                default:
                    if (IsArrayLike(value)) return ArrayToDValue(value);
                    return new DValue { StrValue = ToStr(value) };
            }
        }

        private static DValue ArrayToDValue(object value)
            => AllItemsIntLike(value)
                ? new DValue { ArrayIntValue = ToIntArray(value) }
                : new DValue { ArrayValue = ToStringArray(value) };

        // --- конвертеры значений (терпимы к форматам Dynamo) ------------------

        private static bool TryToLong(object value, out long result)
        {
            result = 0;
            switch (value)
            {
                case long l: result = l; return true;
                case int i: result = i; return true;
                case double d: result = (long)Math.Round(d); return true;
                case decimal m: result = (long)Math.Round(m); return true;
                case bool b: result = b ? 1 : 0; return true;
                case string s when long.TryParse(s, NumberStyles.Any, Inv, out var r): result = r; return true;
                case string s when double.TryParse(s, NumberStyles.Any, Inv, out var rd): result = (long)Math.Round(rd); return true;
                default: return false;
            }
        }

        private static bool TryToInt(object value, out int result)
        {
            result = 0;
            if (!TryToLong(value, out var l) || l < int.MinValue || l > int.MaxValue) return false;
            result = (int)l;
            return true;
        }

        private static bool TryToDouble(object value, out double result)
        {
            result = 0;
            switch (value)
            {
                case double d: result = d; return true;
                case float f: result = f; return true;
                case long l: result = l; return true;
                case int i: result = i; return true;
                case decimal m: result = (double)m; return true;
                case string s when double.TryParse(s, NumberStyles.Any, Inv, out var r): result = r; return true;
                default: return false;
            }
        }

        private static bool TryToDecimal(object value, out decimal result)
        {
            result = 0m;
            switch (value)
            {
                case decimal m: result = m; return true;
                case double d: result = (decimal)d; return true;
                case float f: result = (decimal)f; return true;
                case long l: result = l; return true;
                case int i: result = i; return true;
                case string s when decimal.TryParse(s, NumberStyles.Any, Inv, out var r): result = r; return true;
                default: return false;
            }
        }

        private static bool TryToDateTime(object value, out DateTime result)
        {
            result = default;
            switch (value)
            {
                case DateTime dt: result = dt; return true;
                case string s when DateTime.TryParse(s, Inv, DateTimeStyles.None, out var r): result = r; return true;
                case string s when DateTime.TryParse(s, CultureInfo.CurrentCulture, DateTimeStyles.None, out var r2): result = r2; return true;
                default: return false;
            }
        }

        private static bool TryToGuid(object value, out Guid result)
        {
            result = Guid.Empty;
            switch (value)
            {
                case Guid g: result = g; return true;
                case string s when Guid.TryParse(s, out var r): result = r; return true;
                default: return false;
            }
        }

        private static bool IsArrayLike(object value) => value is IEnumerable && !(value is string);

        private static IEnumerable<object> AsItems(object value)
        {
            if (value is IEnumerable e && !(value is string))
                foreach (var item in e) yield return item;
        }

        private static int[] ToIntArray(object value)
        {
            if (value is int[] direct) return direct;
            var list = new List<int>();
            foreach (var item in AsItems(value))
                if (TryToInt(item, out var i)) list.Add(i);
            return list.ToArray();
        }

        private static string[] ToStringArray(object value)
        {
            if (value is string[] direct) return direct;
            return AsItems(value).Select(ToStr).ToArray();
        }

        private static bool AllItemsIntLike(object value)
        {
            var any = false;
            foreach (var item in AsItems(value))
            {
                any = true;
                if (!TryToInt(item, out _)) return false;
            }
            return any;
        }

        private static string ToStr(object value)
        {
            switch (value)
            {
                case null: return null;
                case string s: return s;
                case double d: return d.ToString(Inv);
                case float f: return f.ToString(Inv);
                case decimal m: return m.ToString(Inv);
                case DateTime dt: return dt.ToString("o", Inv);
                case bool b: return b ? "true" : "false";
                default: return Convert.ToString(value, Inv);
            }
        }
    }
}
