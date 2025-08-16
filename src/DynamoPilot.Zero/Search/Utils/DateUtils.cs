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

        /// <summary>
        /// Добавляет дни к дате
        /// </summary>
        /// <param name="date">Исходная дата</param>
        /// <param name="days">Количество дней</param>
        /// <returns>Новая дата</returns>
        [IsDesignScriptCompatible]
        public static DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }

        /// <summary>
        /// Вычитает дни из даты
        /// </summary>
        /// <param name="date">Исходная дата</param>
        /// <param name="days">Количество дней</param>
        /// <returns>Новая дата</returns>
        [IsDesignScriptCompatible]
        public static DateTime SubtractDays(DateTime date, int days)
        {
            return date.AddDays(-days);
        }

        /// <summary>
        /// Добавляет месяцы к дате
        /// </summary>
        /// <param name="date">Исходная дата</param>
        /// <param name="months">Количество месяцев</param>
        /// <returns>Новая дата</returns>
        [IsDesignScriptCompatible]
        public static DateTime AddMonths(DateTime date, int months)
        {
            return date.AddMonths(months);
        }

        /// <summary>
        /// Добавляет годы к дате
        /// </summary>
        /// <param name="date">Исходная дата</param>
        /// <param name="years">Количество лет</param>
        /// <returns>Новая дата</returns>
        [IsDesignScriptCompatible]
        public static DateTime AddYears(DateTime date, int years)
        {
            return date.AddYears(years);
        }

        /// <summary>
        /// Возвращает начало месяца для указанной даты
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Первый день месяца</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetStartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// Возвращает конец месяца для указанной даты
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Последний день месяца</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetEndOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        /// <summary>
        /// Возвращает начало года
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Первый день года</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetStartOfYear(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }

        /// <summary>
        /// Возвращает конец года
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Последний день года</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetEndOfYear(DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
    }
} 