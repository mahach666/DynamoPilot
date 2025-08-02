using Dynamo.Graph.Nodes;
using System;

namespace Search.Utils
{
    public static class DateUtils
    {
        [IsDesignScriptCompatible]
        public static DateTime GetToday()
        {
            return DateTime.Today;
        }

        [IsDesignScriptCompatible]
        public static DateTime GetNow()
        {
            return DateTime.Now;
        }

        [IsDesignScriptCompatible]
        public static DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }

        [IsDesignScriptCompatible]
        public static DateTime SubtractDays(DateTime date, int days)
        {
            return date.AddDays(-days);
        }

        [IsDesignScriptCompatible]
        public static DateTime AddMonths(DateTime date, int months)
        {
            return date.AddMonths(months);
        }

        [IsDesignScriptCompatible]
        public static DateTime AddYears(DateTime date, int years)
        {
            return date.AddYears(years);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetEndOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        [IsDesignScriptCompatible]
        public static DateTime GetStartOfYear(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        [IsDesignScriptCompatible]
        public static DateTime GetEndOfYear(DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
    }
} 