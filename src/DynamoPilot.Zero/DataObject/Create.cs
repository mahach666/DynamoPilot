using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Attributes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

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

        // ---------------------------------------------------------------------
        //  Создание с атрибутами через надёжный набор PAttributeSet
        //  (рекомендуемый путь — см. ноды Attributes.AttributeSet)
        // ---------------------------------------------------------------------

        /// <summary>
        /// Создает объект и сразу заполняет атрибуты из набора <see cref="PAttributeSet"/>.
        /// </summary>
        /// <param name="parent">Родительский объект</param>
        /// <param name="type">Тип создаваемого объекта</param>
        /// <param name="attributes">Набор атрибутов (см. ноды AttributeSet)</param>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithAttributeSet(PDataObject parent, PType type, PAttributeSet attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create((IDataObject)parent.Unwrap(), (IType)type.Unwrap());
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        /// <summary>
        /// Создает объект по Guid родителя и заполняет атрибуты из набора <see cref="PAttributeSet"/>.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByParentIdWithAttributeSet(Guid parentId, PType type, PAttributeSet attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create(parentId, (IType)type.Unwrap());
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        /// <summary>
        /// Создает объект по строковому Guid родителя и заполняет атрибуты из набора <see cref="PAttributeSet"/>.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PDataObject CreateByStrParentIdWithAttributeSet(string parentId, PType type, PAttributeSet attributes)
        {
            var builder = StaticMetadata.ObjectModifier.Create(new Guid(parentId), (IType)type.Unwrap());
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        /// <summary>
        /// Создает объект с заданными Guid объекта и родителя и заполняет атрибуты из набора <see cref="PAttributeSet"/>.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithIdAndAttributeSet(Guid id, Guid parentId, PType type, PAttributeSet attributes)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(id, parentId, (IType)type.Unwrap());
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        /// <summary>
        /// Создает объект с заданными строковыми Id объекта и родителя и заполняет атрибуты из набора <see cref="PAttributeSet"/>.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PDataObject CreateWithStrIdAndAttributeSet(string id, string parentId, PType type, PAttributeSet attributes)
        {
            var builder = StaticMetadata.ObjectModifier.CreateById(new Guid(id), new Guid(parentId), (IType)type.Unwrap());
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        // ---------------------------------------------------------------------
        //  Перегрузки со словарём оставлены для обратной совместимости.
        //  Теперь они проходят через тот же type-aware конвертер, что и PAttributeSet,
        //  поэтому массивы / Guid / bool обрабатываются корректно.
        // ---------------------------------------------------------------------

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
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
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
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
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
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
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
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
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
            Fill(builder, type, attributes);
            return ApplyAndGet(builder);
        }

        // ---------------------------------------------------------------------

        private static void Fill(PObjectBuilder builder, PType type, PAttributeSet attributes)
            => AttributeApplier.Apply(builder, type == null ? null : (IType)type.Unwrap(), attributes?.Entries);

        private static void Fill(PObjectBuilder builder, PType type, IDictionary<string, object> attributes)
            => AttributeApplier.Apply(builder, type == null ? null : (IType)type.Unwrap(), attributes);

        private static PDataObject ApplyAndGet(PObjectBuilder builder)
        {
            StaticMetadata.ObjectModifier.Apply();
            StaticMetadata.ObjectModifier.Clear();
            return Get.GetByGuid(builder.DataObject.Id);
        }
    }
}
