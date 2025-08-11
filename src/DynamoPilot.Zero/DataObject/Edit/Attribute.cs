using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;

namespace DataObject.Edit
{
    /// <summary>
    /// Ноды для работы с атрибутами объектов данных в системе Pilot
    /// </summary>
    public static class Attribute
    {
        /// <summary>
        /// Удаляет атрибут объекта по идентификатору
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="name">Имя атрибута</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject RemoveAttribute(Guid objectId, string name)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).RemoveAttribute(name);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Удаляет атрибут объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="name">Имя атрибута</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject RemoveAttributeByObj(PDataObject obj, string name)
        {
            return RemoveAttribute(obj.Id, name);
        }

        /// <summary>
        /// Устанавливает строковый атрибут объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Строковое значение</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetStringAttribute(Guid objectId,
           string name,
           string value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает строковый атрибут объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Строковое значение</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetStringAttributeByObj(
            PDataObject obj,
            string name,
            string value)
        {
            return SetStringAttribute(obj.Id, name, value);
        }

        /// <summary>
        /// Устанавливает целочисленный атрибут объекта
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Целочисленное значение</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIntAttribute(Guid objectId,
            string name,
            int value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает целочисленный атрибут объекта
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Целочисленное значение</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetIntAttributeByObj(
            PDataObject obj,
            string name,
            int value)
        {
            return SetIntAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDoubleAttribute(Guid objectId,
            string name,
            double value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDoubleAttributeByObj(
            PDataObject obj,
            string name,
            double value)
        {
            return SetDoubleAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDateTimeAttribute(Guid objectId,
            string name,
            DateTime value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDateTimeAttributeByObj(
            PDataObject obj,
            string name,
            DateTime value)
        {
            return SetDateTimeAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDecimalAttribute(Guid objectId,
            string name,
            decimal value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetDecimalAttributeByObj(
            PDataObject obj,
            string name,
            decimal value)
        {
            return SetDecimalAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetLongAttribute(Guid objectId,
            string name,
            long value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetLongAttributeByObj(
            PDataObject obj,
            string name,
            long value)
        {
            return SetLongAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetGuidAttribute(Guid objectId,
            string name,
            Guid value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetGuidAttributeByObj(
            PDataObject obj,
            string name,
            Guid value)
        {
            return SetGuidAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIntArrAttribute(Guid objectId,
            string name,
            int[] value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetIntArrAttributeByObj(
            PDataObject obj,
            string name,
            int[] value)
        {
            return SetIntArrAttribute(obj.Id, name, value);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetStringArrAttribute(Guid objectId,
            string name,
            string[] value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttribute(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        [IsDesignScriptCompatible]
        public static PDataObject SetStringArrAttributeByObj(
            PDataObject obj,
            string name,
            string[] value)
        {
            return SetStringArrAttribute(obj.Id, name, value);
        }

        /// <summary>
        /// Устанавливает атрибут как объект (универсальный метод)
        /// </summary>
        /// <param name="objectId">Идентификатор объекта</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Значение атрибута</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetAttributeAsObject(Guid objectId,
            string name,
            object value)
        {
            StaticMetadata.ObjectModifier.EditById(objectId).SetAttributeAsObject(name, value);

            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();

            return Get.GetByGuid(objectId);
        }

        /// <summary>
        /// Устанавливает атрибут как объект (универсальный метод)
        /// </summary>
        /// <param name="obj">Объект данных</param>
        /// <param name="name">Имя атрибута</param>
        /// <param name="value">Значение атрибута</param>
        /// <returns>Обновленный объект данных</returns>
        [IsDesignScriptCompatible]
        public static PDataObject SetAttributeAsObjectByObj(
            PDataObject obj,
            string name,
            object value)
        {
            return SetAttributeAsObject(obj.Id, name, value);
        }
    }
}
