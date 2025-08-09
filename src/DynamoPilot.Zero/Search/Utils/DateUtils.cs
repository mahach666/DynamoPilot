using Dynamo.Graph.Nodes;
using System;

namespace Search.Utils
{
    /// <summary>
    /// Ноды для работы с датами в поисковых запросах
    /// </summary>
    public static class DateUtils
    {
        /// <summary>
        /// Получает сегодняшнюю дату
        /// </summary>
        /// <returns>Сегодняшняя дата</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetToday()
        {
            return DateTime.Today;
        }

        /// <summary>
        /// Получает текущие дату и время
        /// </summary>
        /// <returns>Текущие дата и время</returns>
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