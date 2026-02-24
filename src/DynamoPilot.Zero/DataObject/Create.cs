using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataObject
{
    /// <summary>
    /// Ноды для создания объектов данных в системе Pilot
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Создает новый объект данных с указанным родительским объектом и типом
        /// </summary>
        /// <param name="parent">Родительский объект данных</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentObjAndType(PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанным идентификатором, родительским объектом и типом
        /// </summary>
        /// <param name="id">Уникальный идентификатор создаваемого объекта</param>
        /// <param name="parent">Родительский объект данных</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentObjAndType(Guid id, PDataObject parent, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(id, (IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанным идентификатором родителя и типом
        /// </summary>
        /// <param name="parentId">Идентификатор родительского объекта</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentIdAndType(Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.Create(parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает новый объект данных с указанными идентификаторами объекта, родителя и типом
        /// </summary>
        /// <param name="id">Уникальный идентификатор создаваемого объекта</param>
        /// <param name="parentId">Идентификатор родительского объекта</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <returns>Созданный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByIdAndParentIdAndType(Guid id, Guid parentId, PType type)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект и сразу заполняет атрибуты (словарь ключ-значение).
        /// </summary>
        /// <param name="parent">Родительский объект</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithAttributes(PDataObject parent, PType type, Dictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект и сразу заполняет атрибуты (словарь ключ-значение).
        /// </summary>
        /// <param name="parentId">Родительский объект</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentIdWithAttributes(Guid parentId, PType type, Dictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create(parentId, (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект и сразу заполняет атрибуты (словарь ключ-значение).
        /// </summary>
        /// <param name="parentId">Родительский объект</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByStrParentIdWithAttributes(string parentId, PType type, Dictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create(new Guid(parentId), (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект с заданным Guid и заполняет атрибуты.
        /// </summary>
        /// <param name="id">Идентификатор создаваемого объекта</param>
        /// <param name="parentId">Идентификатор родителя</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithIdAndAttributes(Guid id, Guid parentId, PType type, IDictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        /// <summary>
        /// Создает объект с заданным строковым Id и заполняет атрибуты.
        /// </summary>
        /// <param name="id">Идентификатор создаваемого объекта (строка)</param>
        /// <param name="parentId">Идентификатор родителя (строка)</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Словарь атрибутов (имя -> значение)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithStrIdAndAttributes(string id, string parentId, PType type, Dictionary<string, object> attributes)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(new Guid(id), new Guid(parentId), (IType)type.Unwrap());
            ApplyAttributes(builder, attributes);
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }

        private static void ApplyAttributes(PObjectBuilder builder, IDictionary<string, object> attributes)
        {
            if (builder == null || attributes == null)
                return;

            foreach (var kvp in attributes)
            {
                if (kvp.Value == null)
                    continue;

                switch (kvp.Value)
                {
                    case string value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case int value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case double value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case DateTime value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case decimal value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case long value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case Guid value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case int[] value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case List<int> listInt:
                        builder.SetAttribute(kvp.Key, listInt.ToArray());
                        break;
                    case string[] value:
                        builder.SetAttribute(kvp.Key, value);
                        break;
                    case List<string> listString:
                        builder.SetAttribute(kvp.Key, listString.ToArray());
                        break;
                    case System.Collections.IEnumerable enumerable:
                        // Обработка других коллекций - конвертируем в массивы если возможно
                        if (enumerable is IEnumerable<int> intEnum)
                        {
                            builder.SetAttribute(kvp.Key, intEnum.ToArray());
                            break;
                        }
                        if (enumerable is IEnumerable<long> longEnum)
                        {
                            // Конвертируем long[] в int[] поскольку long[] не поддерживается
                            builder.SetAttribute(kvp.Key, longEnum.Select(l => (int)l).ToArray());
                            break;
                        }
                        if (enumerable is IEnumerable<string> stringEnum)
                        {
                            builder.SetAttribute(kvp.Key, stringEnum.ToArray());
                            break;
                        }
                        if (enumerable is System.Collections.ArrayList arrayList)
                        {
                            // Обработка ArrayList - конвертируем в массив соответствующего типа
                            if (arrayList.Count > 0)
                            {
                                var firstElement = arrayList[0];
                                if (firstElement is int)
                                {
                                    builder.SetAttribute(kvp.Key, arrayList.Cast<int>().ToArray());
                                    break;
                                }
                                else if (firstElement is long)
                                {
                                    // Конвертируем long[] в int[] поскольку long[] не поддерживается
                                    builder.SetAttribute(kvp.Key, arrayList.Cast<long>().Select(l => (int)l).ToArray());
                                    break;
                                }
                                else if (firstElement is string)
                                {
                                    builder.SetAttribute(kvp.Key, arrayList.Cast<string>().ToArray());
                                    break;
                                }
                            }
                        }
                        // Для остальных коллекций используем SetAttributeAsObject
                        builder.SetAttributeAsObject(kvp.Key, kvp.Value);
                        break;
                    default:
                        builder.SetAttributeAsObject(kvp.Key, kvp.Value);
                        break;
                }
            }
        }
    }
}
