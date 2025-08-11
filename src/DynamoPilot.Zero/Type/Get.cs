using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Type
{
    /// <summary>
    /// Ноды для выбора типов объектов в системе Pilot
    /// </summary>
    public static class Get
    {
        /// <summary>
        /// Получает список всех типов объектов
        /// </summary>
        /// <returns>Список всех доступных типов</returns>
        [IsDesignScriptCompatible]
        public static List<PType> AllTypes()
        {
            var repo = StaticMetadata.ObjectsRepository;

            return repo?.GetTypes()
                .ToList()
                   ?? new List<PType>();
        }

        /// <summary>
        /// Получает тип объекта по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор типа</param>
        /// <returns>Тип объекта или null, если не найден</returns>
        [IsDesignScriptCompatible]
        public static PType GetTypeById(int id)
            => StaticMetadata.ObjectsRepository?.GetType(id);

        /// <summary>
        /// Получает тип объекта по имени
        /// </summary>
        /// <param name="name">Имя типа</param>
        /// <returns>Тип объекта или null, если не найден</returns>
        [IsDesignScriptCompatible]
        public static PType GetTypeByName(string name)
            => StaticMetadata.ObjectsRepository?.GetType(name);
    }
}