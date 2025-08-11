using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для управления подписчиками объектов данных в системе Pilot
    /// </summary>
    public static class Subscriber
    {
        /// <summary>
        /// Добавляет подписчика к объекту по идентификатору
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="personId">Идентификатор пользователя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddSubscriber(
            Guid objectId,
            int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).AddSubscriber(personId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Добавляет подписчика к объекту
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="personId">Идентификатор пользователя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject AddSubscriberByObj(
            PDataObject obj,
            int personId)
        {
            return AddSubscriber(obj.Id, personId);
        }

        /// <summary>
        /// Удаляет подписчика объекта по идентификатору
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="personId">Идентификатор пользователя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject RemoveSubscriber(Guid objectId, int personId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).RemoveSubscriber(personId);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Удаляет подписчика объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="personId">Идентификатор пользователя</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject RemoveSubscriberByObj(PDataObject obj, int personId)
        {
            return RemoveSubscriber(obj.Id, personId);
        }
    }
}
