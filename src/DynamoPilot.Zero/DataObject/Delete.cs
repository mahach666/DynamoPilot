using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject
{
    /// <summary>
    /// Ноды для удаления объектов данных в системе Pilot
    /// </summary>
    public static class Delete
    {
        /// <summary>
        /// Удаляет объект данных (перемещает в корзину)
        /// </summary>
        /// <param name="object">Объект данных для удаления</param>
        /// <returns>True, если удаление прошло успешно; иначе false</returns>
        public static bool DeleteByObj(PDataObject @object)
        {
            return DeleteById(@object.Id);
        }

        /// <summary>
        /// Удаляет объект данных по идентификатору (перемещает в корзину)
        /// </summary>
        /// <param name="objectId">Идентификатор объекта для удаления</param>
        /// <returns>True, если удаление прошло успешно; иначе false</returns>
        public static bool DeleteById(Guid objectId)
        {
            try
            {
                StaticMetadata.ObjectModifier.DeleteById(objectId);
                StaticMetadata.ObjectModifier.Apply();
                StaticMetadata.ObjectModifier.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Удаляет объект данных навсегда (безвозвратно)
        /// </summary>
        /// <param name="objectId">Идентификатор объекта для безвозвратного удаления</param>
        /// <returns>True, если удаление прошло успешно; иначе false</returns>
        public static bool DeletePermanently(Guid objectId)
        {
            try
            {
                StaticMetadata.ObjectModifier.DeletePermanently(objectId);
                StaticMetadata.ObjectModifier.Apply();
                StaticMetadata.ObjectModifier.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
