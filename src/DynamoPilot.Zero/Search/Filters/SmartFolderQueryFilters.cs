using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace Search.Filters
{
    /// <summary>
    /// Ноды для фильтрации в умных папках
    /// </summary>
    public static class SmartFolderQueryFilters
    {
        /// <summary>
        /// Фильтрует по автору
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="authorId">Идентификатор автора</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithAuthor(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            int authorId)
        {
            smartFolderQueryBuilder.WithAuthor(authorId);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует по множеству авторов
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="authorIds">Список идентификаторов авторов</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithAuthors(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            IEnumerable<int> authorIds)
        {
            smartFolderQueryBuilder.WithAuthors(authorIds);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Ограничивает период создания
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="fromUtc">Дата начала (UTC)</param>
        /// <param name="toUtc">Дата окончания (UTC)</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedInRange(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            DateTime fromUtc,
            DateTime toUtc)
        {
            smartFolderQueryBuilder.WithCreatedInRange(fromUtc, toUtc);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные за последний месяц
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastMonth(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastMonth();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные за последнюю неделю
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastWeek(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastWeek();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные за последний год
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedLastYear(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedLastYear();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные в текущем месяце
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedThisMonth(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisMonth();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные на текущей неделе
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedThisWeek(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisWeek();
            return smartFolderQueryBuilder;
        }

        [IsDesignScriptCompatible]

        /// <summary>
        /// Фильтрует документы, созданные в текущем году
        /// </summary>
        public static PSmartFolderQueryBuilder WithCreatedThisYear(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedThisYear();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные сегодня
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedToday(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedToday();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует документы, созданные вчера
        /// </summary>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithCreatedYesterday(PSmartFolderQueryBuilder smartFolderQueryBuilder)
        {
            smartFolderQueryBuilder.WithCreatedYesterday();
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Добавляет ключевое слово для поиска
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="keyword">Ключевое слово</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithKeyword(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            string keyword)
        {
            smartFolderQueryBuilder.WithKeyword(keyword);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Добавляет ключевое слово в кавычках (точное соответствие)
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="keyword">Ключевое слово</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithQuotedKeyword(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            string keyword)
        {
            smartFolderQueryBuilder.WithQuotedKeyword(keyword);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Устанавливает режим поиска
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="searchMode">Режим поиска</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithSearchMode(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            SearchMode searchMode)
        {
            smartFolderQueryBuilder.WithSearchMode(searchMode);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует по состоянию объектов
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="state">Состояние</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithState(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            ObjectState state)
        {
            smartFolderQueryBuilder.WithState(state);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует по типу объекта
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="typeId">Идентификатор типа</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithType(PSmartFolderQueryBuilder smartFolderQueryBuilder, int typeId)
        {
            smartFolderQueryBuilder.WithType(typeId);
            return smartFolderQueryBuilder;
        }

        /// <summary>
        /// Фильтрует по нескольким типам объектов
        /// </summary>
        /// <param name="smartFolderQueryBuilder">Построитель умной папки</param>
        /// <param name="typeIds">Список идентификаторов типов</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder WithTypes(PSmartFolderQueryBuilder smartFolderQueryBuilder,
            IEnumerable<int> typeIds)
        {
            smartFolderQueryBuilder.WithTypes(typeIds);
            return smartFolderQueryBuilder;
        }
    }
}
