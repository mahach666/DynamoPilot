using Ascon.Pilot.SDK;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.App.Utils;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace DataObject
{
    /// <summary>
    /// Ноды для выбора и поиска объектов данных в системе Pilot
    /// </summary>
    public static class Select
    {
        /// <summary>
        /// Получает объект данных по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор объекта</param>
        /// <returns>Объект данных или null, если не найден</returns>
        [IsDesignScriptCompatible]
        public static PDataObject GetByGuid(Guid id)
        {
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            var preRes = loader.LoadObjects(new[] { id }, default).FirstOrDefault();
            if (preRes == null) return null;

            return new PDataObject(preRes);
        }

        /// <summary>
        /// Получает объект данных по строковому представлению идентификатора
        /// </summary>
        /// <param name="id">Строковое представление идентификатора</param>
        /// <returns>Объект данных или null, если не найден</returns>
        [IsDesignScriptCompatible]
        public static PDataObject GetByStrGuid(string id)
        {
            return GetByGuid(new Guid(id));
        }

        /// <summary>
        /// Загружает список объектов по списку строковых GUID
        /// </summary>
        /// <param name="ids">Список строковых GUID</param>
        /// <returns>Список объектов данных</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static List<PDataObject> GetByStrGuids(IList<string> ids)
        {
            if (ids == null || ids.Count == 0)
                return new List<PDataObject>();

            var validIds = new List<Guid>();
            foreach (var s in ids)
            {
                if (Guid.TryParse(s, out var g))
                    validIds.Add(g);
            }

            if (validIds.Count == 0)
                return new List<PDataObject>();

            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());
            return loader.LoadObjects(validIds, default)
                .Select(o => new PDataObject(o))
                .ToList();
        }

        /// <summary>
        /// Загружает список объектов по списку строковых GUID и возвращает массив
        /// </summary>
        /// <param name="ids">Список строковых GUID</param>
        /// <returns>Массив объектов данных</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static PDataObject[] GetByStrGuidsArray(IList<string> ids)
        {
            if (ids == null || ids.Count == 0)
                return Array.Empty<PDataObject>();

            var validIds = new List<Guid>();
            foreach (var s in ids)
            {
                if (Guid.TryParse(s, out var g))
                    validIds.Add(g);
            }

            if (validIds.Count == 0)
                return Array.Empty<PDataObject>();

            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());
            return loader.LoadObjects(validIds, default)
                .Select(o => new PDataObject(o))
                .ToArray();
        }

        /// <summary>
        /// Получает родительский объект по идентификатору типа
        /// </summary>
        /// <param name="pDataObject">Объект данных для поиска родителя</param>
        /// <param name="id">Идентификатор типа родительского объекта</param>
        /// <returns>Родительский объект указанного типа или null</returns>
        [IsDesignScriptCompatible]
        public static PDataObject GetParentByTypeId(PDataObject pDataObject, int id)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Id == id && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .FirstOrDefault();
        }

        /// <summary>
        /// Получает родительский объект по имени типа
        /// </summary>
        /// <param name="pDataObject">Объект данных для поиска родителя</param>
        /// <param name="name">Имя типа родительского объекта</param>
        /// <returns>Родительский объект указанного типа или null</returns>
        [IsDesignScriptCompatible]
        public static PDataObject GetParentByTypeName(PDataObject pDataObject, string name)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Name == name && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .FirstOrDefault();
        }

        /// <summary>
        /// Получает список родительских объектов по идентификатору типа
        /// </summary>
        /// <param name="pDataObject">Объект данных для поиска родителей</param>
        /// <param name="id">Идентификатор типа родительских объектов</param>
        /// <returns>Список родительских объектов указанного типа</returns>
        [IsDesignScriptCompatible]
        public static List<PDataObject> GetParentListByTypeId(PDataObject pDataObject, int id)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Id == id && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .ToList();
        }

        /// <summary>
        /// Получает список родительских объектов по имени типа
        /// </summary>
        /// <param name="pDataObject">Объект данных для поиска родителей</param>
        /// <param name="name">Имя типа родительских объектов</param>
        /// <returns>Список родительских объектов указанного типа</returns>
        [IsDesignScriptCompatible]
        public static List<PDataObject> GetParentListByTypeName(PDataObject pDataObject, string name)
        {
            var context = pDataObject.Context();
            var loader = new SynkObjectLoader((IObjectsRepository)StaticMetadata.ObjectsRepository.Unwrap());

            return loader.LoadObjects(context, default)
                .Where(o => o.Type.Name == name && o.Id != pDataObject.Id)
                .Select(o => new PDataObject(o))
                .ToList();
        }
    }
}