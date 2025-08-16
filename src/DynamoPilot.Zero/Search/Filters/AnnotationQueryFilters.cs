using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;

namespace Search.Filters
{
    /// <summary>
    /// Ноды для фильтрации аннотаций в построителях запросов
    /// </summary>
    public static class AnnotationQueryFilters
    {
        /// <summary>
        /// Ограничивает поиск аннотаций текущей версией
        /// </summary>
        /// <param name="pAnnotationQueryBuilder">Построитель запросов аннотаций</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithCurrentVersion(PAnnotationQueryBuilder pAnnotationQueryBuilder)
        {
            pAnnotationQueryBuilder.WithCurrentVersion();
            return pAnnotationQueryBuilder;
        }

        /// <summary>
        /// Добавляет ключевое слово для поиска аннотаций
        /// </summary>
        /// <param name="pAnnotationQueryBuilder">Построитель запросов аннотаций</param>
        /// <param name="keyword">Ключевое слово</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithKeyword(PAnnotationQueryBuilder pAnnotationQueryBuilder , string keyword)
        {
            pAnnotationQueryBuilder.WithKeyword(keyword);
            return pAnnotationQueryBuilder;
        }

        /// <summary>
        /// Добавляет ключевое слово в кавычках (точное соответствие)
        /// </summary>
        /// <param name="pAnnotationQueryBuilder">Построитель запросов аннотаций</param>
        /// <param name="keyword">Ключевое слово</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithQuotedKeyword(PAnnotationQueryBuilder pAnnotationQueryBuilder,string keyword)
        {
            pAnnotationQueryBuilder.WithQuotedKeyword(keyword);
            return pAnnotationQueryBuilder;
        }

        /// <summary>
        /// Фильтрует аннотации по типу
        /// </summary>
        /// <param name="pAnnotationQueryBuilder">Построитель запросов аннотаций</param>
        /// <param name="typeId">Идентификатор типа аннотаций</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithType(PAnnotationQueryBuilder pAnnotationQueryBuilder,int typeId)
        {
            pAnnotationQueryBuilder.WithType(typeId);
            return pAnnotationQueryBuilder;
        }

        /// <summary>
        /// Фильтрует аннотации по нескольким типам
        /// </summary>
        /// <param name="pAnnotationQueryBuilder">Построитель запросов аннотаций</param>
        /// <param name="typeIds">Коллекция идентификаторов типов</param>
        /// <returns>Обновленный построитель</returns>
        [IsDesignScriptCompatible]
        public static PAnnotationQueryBuilder WithTypes(PAnnotationQueryBuilder pAnnotationQueryBuilder, IEnumerable<int> typeIds)
        {
            pAnnotationQueryBuilder.WithTypes(typeIds);
            return pAnnotationQueryBuilder;
        }
    }
}
