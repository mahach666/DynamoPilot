using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;

namespace Search
{
    /// <summary>
    /// Ноды для создания построителей запросов для поиска в системе Pilot
    /// </summary>
    public static class SearchBuilder
    {
        /// <summary>
        /// Создает построитель запросов для поиска объектов
        /// </summary>
        /// <param name="updater">Параметр обновления</param>
        /// <returns>Построитель запросов для объектов</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateObjectQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetObjectQueryBuilder();
        }

        /// <summary>
        /// Создает пустой построитель запросов
        /// </summary>
        /// <param name="updater">Параметр обновления</param>
        /// <returns>Пустой построитель запросов</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateEmptyQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetEmptyQueryBuilder();
        }

        /// <summary>
        /// Создает построитель запросов для поиска задач
        /// </summary>
        /// <param name="updater">Параметр обновления</param>
        /// <returns>Построитель запросов для задач</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder CreateTaskQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetTaskQueryBuilder();
        }

        /// <summary>
        /// Создает построитель запросов для поиска аннотаций
        /// </summary>
        /// <param name="updater">Параметр обновления</param>
        /// <returns>Построитель запросов для аннотаций</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder CreateAnnotationQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetAnnotationQueryBuilder();
        }

        /// <summary>
        /// Создает построитель запросов для поиска в умных папках
        /// </summary>
        /// <param name="updater">Параметр обновления</param>
        /// <returns>Построитель запросов для умных папок</returns>
        [IsDesignScriptCompatible]
        public static PSmartFolderQueryBuilder CreateSmartFolderQueryBuilder(bool updater = false)
        {
            return StaticMetadata.SearchService.GetSmartFolderQueryBuilder();
        }

        //[IsDesignScriptCompatible]
        //public static PQueryBuilder CreateQueryBuilderFromTaskSearchExpression(bool updater = false)
        //{
        //    return StaticMetadata.SearchService.GetQueryBuilderFromTaskSearchExpression();
        //}

        /// <summary>
        /// Устанавливает максимальное количество результатов для построителя запросов
        /// </summary>
        /// <param name="builder">Построитель запросов</param>
        /// <param name="maxResults">Максимальное количество результатов</param>
        /// <returns>Обновленный построитель запросов</returns>
        [IsDesignScriptCompatible]
        public static PQueryBuilder SetMaxResults(PQueryBuilder builder, int maxResults)
        {
            builder.MaxResults(maxResults);
            return builder;
        }
    }
}