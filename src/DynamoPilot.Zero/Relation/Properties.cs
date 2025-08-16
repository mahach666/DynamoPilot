using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Relation
{
    /// <summary>
    /// Ноды для получения свойств связей между объектами
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Возвращает идентификатор связи
        /// </summary>
        /// <param name="pRelation">Связь</param>
        /// <returns>Идентификатор связи</returns>
        [IsDesignScriptCompatible]
        public static Guid GetId(PRelation pRelation) => pRelation.Id;

        /// <summary>
        /// Возвращает идентификатор целевого объекта связи
        /// </summary>
        /// <param name="pRelation">Связь</param>
        /// <returns>Идентификатор целевого объекта</returns>
        [IsDesignScriptCompatible]
        public static Guid GetTargetId(PRelation pRelation) => pRelation.TargetId;

        /// <summary>
        /// Возвращает тип связи
        /// </summary>
        /// <param name="pRelation">Связь</param>
        /// <returns>Тип связи</returns>
        [IsDesignScriptCompatible]
        public static ObjectRelationType GetType(PRelation pRelation) => pRelation.Type;

        /// <summary>
        /// Возвращает имя связи
        /// </summary>
        /// <param name="pRelation">Связь</param>
        /// <returns>Имя связи</returns>
        [IsDesignScriptCompatible]
        public static string GetName(PRelation pRelation) => pRelation.Name;

        /// <summary>
        /// Возвращает дату создания версии, к которой относится связь
        /// </summary>
        /// <param name="pRelation">Связь</param>
        /// <returns>Дата/время версии (UTC)</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetVersionId(PRelation pRelation) => pRelation.VersionId;
    }
}
