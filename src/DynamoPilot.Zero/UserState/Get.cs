using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserState
{
    public static class Get
    {
        /// <summary>
        /// Получает список всех состояний
        /// </summary>
        /// <returns>Коллекция состояний пользователей</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PUserState> GetAll()
        {
            return StaticMetadata.ObjectsRepository.GetUserStates();
        }
        /// <summary>
        /// Получает состояние по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор состояния пользователя</param>
        /// <returns>Состояние пользователя</returns>
        [IsDesignScriptCompatible]
        public static PUserState GetById(Guid id)
        {
            return StaticMetadata.ObjectsRepository.GetUserStates().FirstOrDefault(us => us.Id == id);
        }
    }
}
