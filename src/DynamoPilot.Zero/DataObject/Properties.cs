using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataObject
{
    /// <summary>
    /// Ноды для получения свойств объектов данных в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает уникальный идентификатор объекта данных
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Уникальный идентификатор объекта</returns>
        [IsDesignScriptCompatible]
        public static Guid GetId(PDataObject dataObject)
        {
            return dataObject.Id;
        }

        /// <summary>
        /// Получает идентификатор родительского объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Идентификатор родительского объекта</returns>
        [IsDesignScriptCompatible]
        public static Guid GetParentId(PDataObject dataObject)
        {
            return dataObject.ParentId;
        }

        /// <summary>
        /// Получает дату создания объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Дата создания объекта</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetCreated(PDataObject dataObject)
        {
            return dataObject.Created;
        }

        /// <summary>
        /// Получает словарь атрибутов объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Словарь атрибутов объекта</returns>
        [IsDesignScriptCompatible]
        public static IDictionary<string, object> GetAttributes(PDataObject dataObject)
        {
            return dataObject.Attributes;
        }

        /// <summary>
        /// Получает отображаемое имя объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Отображаемое имя объекта</returns>
        [IsDesignScriptCompatible]
        public static string GetDisplayName(PDataObject dataObject)
        {
            return dataObject.DisplayName;
        }

        /// <summary>
        /// Получает тип объекта данных
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Тип объекта</returns>
        [IsDesignScriptCompatible]
        public static PType GetType(PDataObject dataObject)
        {
            return dataObject.Type;
        }

        /// <summary>
        /// Получает создателя объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Пользователь, создавший объект</returns>
        [IsDesignScriptCompatible]
        public static PPerson GetCreator(PDataObject dataObject)
        {
            return dataObject.Creator;
        }

        /// <summary>
        /// Получает список идентификаторов дочерних объектов
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция идентификаторов дочерних объектов</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<Guid> GetChildren(PDataObject dataObject)
        {
            return dataObject.Children;
        }

        /// <summary>
        /// Получает список связей объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция связей объекта</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PRelation> GetRelations(PDataObject dataObject)
        {
            return dataObject.Relations;
        }

        /// <summary>
        /// Получает список связанных исходных файлов
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция идентификаторов связанных файлов</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<Guid> GetRelatedSourceFiles(PDataObject dataObject)
        {
            return dataObject.RelatedSourceFiles;
        }

        /// <summary>
        /// Получает словарь типов дочерних объектов
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Словарь типов дочерних объектов</returns>
        [IsDesignScriptCompatible]
        public static IDictionary<Guid, int> GetTypesByChildren(PDataObject dataObject)
        {
            return dataObject.TypesByChildren;
        }

        /// <summary>
        /// Получает состояние объекта данных
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Состояние объекта</returns>
        [IsDesignScriptCompatible]
        public static DataState GetState(PDataObject dataObject)
        {
            return dataObject.State;
        }

        /// <summary>
        /// Получает информацию о состоянии объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Информация о состоянии объекта</returns>
        [IsDesignScriptCompatible]
        public static PStateInfo GetObjectStateInfo(PDataObject dataObject)
        {
            return dataObject.ObjectStateInfo;
        }

        /// <summary>
        /// Получает состояние синхронизации объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Состояние синхронизации</returns>
        [IsDesignScriptCompatible]
        public static SynchronizationState GetSynchronizationState(PDataObject dataObject)
        {
            return dataObject.SynchronizationState;
        }

        /// <summary>
        /// Получает список файлов объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция файлов объекта</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PFile> GetFiles(PDataObject dataObject)
        {
            return dataObject.Files;
        }

        /// <summary>
        /// Получает список записей доступа к объекту
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция записей доступа</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PAccessRecord> GetAccess2(PDataObject dataObject)
        {
            return dataObject.Access2;
        }

        /// <summary>
        /// Проверяет, является ли объект секретным
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>True, если объект секретный; иначе false</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsSecret(PDataObject dataObject)
        {
            return dataObject.IsSecret;
        }

        /// <summary>
        /// Получает актуальный снимок файлов объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Актуальный снимок файлов</returns>
        [IsDesignScriptCompatible]
        public static PFilesSnapshot GetActualFileSnapshot(PDataObject dataObject)
        {
            return dataObject.ActualFileSnapshot;
        }

        /// <summary>
        /// Получает список предыдущих снимков файлов объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция предыдущих снимков файлов</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PFilesSnapshot> GetPreviousFileSnapshots(PDataObject dataObject)
        {
            return dataObject.PreviousFileSnapshots;
        }

        /// <summary>
        /// Получает список подписчиков объекта
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция идентификаторов подписчиков</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetSubscribers(PDataObject dataObject)
        {
            return dataObject.Subscribers;
        }

        /// <summary>
        /// Получает контекст объекта (цепочку родительских объектов)
        /// </summary>
        /// <param name="dataObject">Объект данных</param>
        /// <returns>Коллекция идентификаторов контекста</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<Guid> GetContext(PDataObject dataObject)
        {
            return dataObject.Context();
        }
    }
}

