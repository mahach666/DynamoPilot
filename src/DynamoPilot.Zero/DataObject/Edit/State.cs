using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для изменения состояния объектов данных в системе Pilot
    /// </summary>
    public static class State
    {
        /// <summary>
        /// Изменяет состояние объекта данных
        /// </summary>
        /// <param name="object">Объект данных</param>
        /// <param name="state">Новое состояние объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject ChangeState(PDataObject @object, ObjectState state)
        {
            StaticMetadata.ObjectModifier.ChangeState((IDataObject)@object.Unwrap(), state);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Select.GetByGuid(@object.Id);
        }

        /// <summary>
        /// Блокирует объект данных по идентификатору
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <returns>Заблокированный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject Lock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Lock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Блокирует объект данных
        /// </summary>
        /// <param name="obj">Объект данных для блокировки</param>
        /// <returns>Заблокированный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject LockByObj(PDataObject obj)
        {
            return Lock(obj.Id);
        }

        /// <summary>
        /// Делает объект публичным (открывает доступ)
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject MakePublic(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakePublic();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Делает объект публичным (открывает доступ)
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject MakePublicByObj(PDataObject obj)
        {
            return MakePublic(obj.Id);
        }

        /// <summary>
        /// Делает объект секретным (ограничивает доступ)
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject MakeSecret(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).MakeSecret();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Делает объект секретным (ограничивает доступ)
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject MakeSecretByObj(PDataObject obj)
        {
            return MakeSecret(obj.Id);
        }

        /// <summary>
        /// Устанавливает флаг удаления объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="isDeleted">Флаг удаления</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIsDeleted(Guid objectId,
            bool isDeleted)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsDeleted(isDeleted);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает флаг удаления объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="isDeleted">Флаг удаления</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIsDeletedByObj(PDataObject obj, bool isDeleted)
        {
            return SetIsDeleted(obj.Id, isDeleted);
        }

        /// <summary>
        /// Устанавливает флаг нахождения объекта в корзине
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="isInRecycleBin">Флаг нахождения в корзине</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIsInRecycleBin(Guid objectId,
            bool isInRecycleBin)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetIsInRecycleBin(isInRecycleBin);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает флаг нахождения объекта в корзине
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="isInRecycleBin">Флаг нахождения в корзине</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIsInRecycleBinByObj(PDataObject obj, bool isInRecycleBin)
        {
            return SetIsInRecycleBin(obj.Id, isInRecycleBin);
        }

        /// <summary>
        /// Разблокирует объект данных по идентификатору
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <returns>Разблокированный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject Unlock(Guid objectId)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).Unlock();

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Select.GetByGuid(objectId);
        }

        /// <summary>
        /// Разблокирует объект данных
        /// </summary>
        /// <param name="obj">Объект данных для разблокировки</param>
        /// <returns>Разблокированный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject UnlockByObj(PDataObject obj)
        {
            return Unlock(obj.Id);
        }
    }
}
