using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DynamoPilot.Data.Attributes
{
    /// <summary>
    /// Надёжное приведение значений, пришедших из Dynamo, к типам, которые понимает Pilot SDK.
    /// <para>
    /// Особенности маршалинга Dynamo, которые здесь учитываются:
    /// все целые приходят как <see cref="long"/>, все вещественные — как <see cref="double"/>,
    /// списки — как <c>object[]</c> с боксированными элементами, а <see cref="Guid"/> у Dynamo
    /// нет вовсе — он приходит строкой. Стандартный <c>switch</c> по рантайм-типу из-за этого
    /// промахивается, поэтому здесь приведение делается явно и терпимо к формату входа.
    /// </para>
    /// </summary>
    public static class AttributeValueConverter
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        public static bool TryToLong(object value, out long result)
        {
            result = 0;
            switch (value)
            {
                case null: return false;
                case long l: result = l; return true;
                case int i: result = i; return true;
                case short s: result = s; return true;
                case byte b: result = b; return true;
                case bool bo: result = bo ? 1 : 0; return true;
                case double d: result = (long)Math.Round(d); return true;
                case float f: result = (long)Math.Round(f); return true;
                case decimal m: result = (long)Math.Round(m); return true;
                case string str:
                    return long.TryParse(str, NumberStyles.Any, Inv, out result)
                        || (double.TryParse(str, NumberStyles.Any, Inv, out var dd) && SetRounded(dd, out result));
                default:
                    try { result = Convert.ToInt64(value, Inv); return true; }
                    catch { return false; }
            }
        }

        private static bool SetRounded(double d, out long result)
        {
            result = (long)Math.Round(d);
            return true;
        }

        public static bool TryToInt(object value, out int result)
        {
            result = 0;
            if (!TryToLong(value, out var l)) return false;
            if (l < int.MinValue || l > int.MaxValue) return false;
            result = (int)l;
            return true;
        }

        public static bool TryToDouble(object value, out double result)
        {
            result = 0;
            switch (value)
            {
                case null: return false;
                case double d: result = d; return true;
                case float f: result = f; return true;
                case long l: result = l; return true;
                case int i: result = i; return true;
                case decimal m: result = (double)m; return true;
                case bool bo: result = bo ? 1 : 0; return true;
                case string str: return double.TryParse(str, NumberStyles.Any, Inv, out result);
                default:
                    try { result = Convert.ToDouble(value, Inv); return true; }
                    catch { return false; }
            }
        }

        public static bool TryToDecimal(object value, out decimal result)
        {
            result = 0m;
            switch (value)
            {
                case null: return false;
                case decimal m: result = m; return true;
                case double d: result = (decimal)d; return true;
                case float f: result = (decimal)f; return true;
                case long l: result = l; return true;
                case int i: result = i; return true;
                case string str: return decimal.TryParse(str, NumberStyles.Any, Inv, out result);
                default:
                    try { result = Convert.ToDecimal(value, Inv); return true; }
                    catch { return false; }
            }
        }

        public static bool TryToDateTime(object value, out DateTime result)
        {
            result = default;
            switch (value)
            {
                case null: return false;
                case DateTime dt: result = dt; return true;
                case string str:
                    return DateTime.TryParse(str, Inv, DateTimeStyles.None, out result)
                        || DateTime.TryParse(str, CultureInfo.CurrentCulture, DateTimeStyles.None, out result);
                default:
                    try { result = Convert.ToDateTime(value, Inv); return true; }
                    catch { return false; }
            }
        }

        public static bool TryToGuid(object value, out Guid result)
        {
            result = Guid.Empty;
            switch (value)
            {
                case null: return false;
                case Guid g: result = g; return true;
                case string str: return Guid.TryParse(str, out result);
                default: return false;
            }
        }

        public static bool TryToBool(object value, out bool result)
        {
            result = false;
            switch (value)
            {
                case null: return false;
                case bool b: result = b; return true;
                case long l: result = l != 0; return true;
                case int i: result = i != 0; return true;
                case double d: result = Math.Abs(d) > double.Epsilon; return true;
                case string str:
                    if (bool.TryParse(str, out result)) return true;
                    if (long.TryParse(str, NumberStyles.Any, Inv, out var n)) { result = n != 0; return true; }
                    return false;
                default: return false;
            }
        }

        /// <summary>Является ли значение коллекцией (но не строкой).</summary>
        public static bool IsArrayLike(object value)
            => value is IEnumerable && value is not string;

        private static IEnumerable<object> AsItems(object value)
        {
            if (value is IEnumerable e && value is not string)
                foreach (var item in e) yield return item;
        }

        public static int[] ToIntArray(object value)
        {
            if (value is int[] direct) return direct;
            var list = new List<int>();
            foreach (var item in AsItems(value))
                if (TryToInt(item, out var i)) list.Add(i);
            return list.ToArray();
        }

        public static string[] ToStringArray(object value)
        {
            if (value is string[] direct) return direct;
            return AsItems(value).Select(ToStr).ToArray();
        }

        /// <summary>
        /// Все ли элементы коллекции приводятся к целому — признак того, что массив числовой
        /// и его стоит хранить как <c>int[]</c>, а не как <c>string[]</c>.
        /// </summary>
        public static bool AllItemsIntLike(object value)
        {
            var any = false;
            foreach (var item in AsItems(value))
            {
                any = true;
                if (!TryToInt(item, out _)) return false;
            }
            return any;
        }

        public static string ToStr(object value)
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
