using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;

namespace Attributes
{
    /// <summary>
    /// Ноды для сборки набора атрибутов (<see cref="PAttributeSet"/>) — надёжной альтернативы
    /// словарям Dynamo при передаче атрибутов в ноды создания/редактирования объектов Pilot.
    /// <para>
    /// В отличие от <c>Dictionary&lt;string,object&gt;</c>, набор передаётся между нодами как
    /// обычный объект (по ссылке) и не страдает от поломанного маршалинга ключей/значений Dynamo.
    /// </para>
    /// </summary>
    public static class AttributeSet
    {
        private static PAttributeSet Ensure(PAttributeSet set) => (set ?? new PAttributeSet()).Clone();

        /// <summary>
        /// Создаёт пустой набор атрибутов.
        /// </summary>
        /// <returns>Пустой набор атрибутов</returns>
        [IsDesignScriptCompatible]
        public static PAttributeSet Create() => new PAttributeSet();

        /// <summary>
        /// Создаёт набор атрибутов из параллельных списков имён и значений.
        /// </summary>
        /// <param name="keys">Список имён атрибутов</param>
        /// <param name="values">Список значений (по позициям соответствуют именам)</param>
        /// <returns>Набор атрибутов</returns>
        [IsDesignScriptCompatible]
        public static PAttributeSet ByKeysValues(IList<string> keys, IList<object> values)
        {
            var set = new PAttributeSet();
            if (keys == null || values == null) return set;

            var count = Math.Min(keys.Count, values.Count);
            for (var i = 0; i < count; i++)
                set.Set(keys[i], values[i]);
            return set;
        }

        /// <summary>
        /// Создаёт набор атрибутов из нативного словаря Dynamo (Dictionary).
        /// Это самый удобный путь для тех, кто уже строит словарь в графе.
        /// </summary>
        /// <param name="dictionary">Словарь Dynamo (имя → значение)</param>
        /// <returns>Набор атрибутов</returns>
        [IsDesignScriptCompatible]
        public static PAttributeSet ByDictionary(DesignScript.Builtin.Dictionary dictionary)
        {
            var set = new PAttributeSet();
            if (dictionary == null) return set;

            foreach (var key in dictionary.Keys)
                set.Set(key, dictionary.ValueAtKey(key));
            return set;
        }

        /// <summary>
        /// Добавляет/перезаписывает строковый атрибут.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetString(PAttributeSet attributeSet, string name, string value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Добавляет/перезаписывает целочисленный атрибут.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetInt(PAttributeSet attributeSet, string name, long value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Добавляет/перезаписывает вещественный атрибут.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetDouble(PAttributeSet attributeSet, string name, double value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Добавляет/перезаписывает атрибут-десятичное число.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetDecimal(PAttributeSet attributeSet, string name, double value)
            => Ensure(attributeSet).Set(name, (decimal)value);

        /// <summary>
        /// Добавляет/перезаписывает атрибут-дату.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetDateTime(PAttributeSet attributeSet, string name, DateTime value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Добавляет/перезаписывает логический атрибут.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetBool(PAttributeSet attributeSet, string name, bool value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Добавляет/перезаписывает атрибут-GUID (значение передаётся строкой).
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetGuid(PAttributeSet attributeSet, string name, string value)
        {
            object stored = Guid.TryParse(value, out var g) ? g : (object)value;
            return Ensure(attributeSet).Set(name, stored);
        }

        /// <summary>
        /// Добавляет/перезаписывает атрибут-массив целых чисел.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetIntArray(PAttributeSet attributeSet, string name, IList<int> values)
            => Ensure(attributeSet).Set(name, values == null ? new int[0] : new List<int>(values).ToArray());

        /// <summary>
        /// Добавляет/перезаписывает атрибут-массив строк.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetStringArray(PAttributeSet attributeSet, string name, IList<string> values)
            => Ensure(attributeSet).Set(name, values == null ? new string[0] : new List<string>(values).ToArray());

        /// <summary>
        /// Добавляет/перезаписывает атрибут произвольного типа (значение приводится при применении).
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet SetValue(PAttributeSet attributeSet, string name, object value)
            => Ensure(attributeSet).Set(name, value);

        /// <summary>
        /// Удаляет атрибут из набора по имени.
        /// </summary>
        [IsDesignScriptCompatible]
        public static PAttributeSet RemoveKey(PAttributeSet attributeSet, string name)
            => Ensure(attributeSet).Remove(name);

        /// <summary>
        /// Возвращает имена атрибутов набора.
        /// </summary>
        [IsDesignScriptCompatible]
        public static IList<string> Keys(PAttributeSet attributeSet)
            => attributeSet == null ? new List<string>() : new List<string>(attributeSet.Keys);

        /// <summary>
        /// Количество атрибутов в наборе.
        /// </summary>
        [IsDesignScriptCompatible]
        public static int Count(PAttributeSet attributeSet)
            => attributeSet?.Count ?? 0;

        /// <summary>
        /// Представляет набор в виде обычного словаря (для просмотра в графе).
        /// </summary>
        [IsDesignScriptCompatible]
        public static IDictionary<string, object> ToDictionary(PAttributeSet attributeSet)
            => attributeSet == null ? new Dictionary<string, object>() : attributeSet.ToDictionary();
    }
}
