using DynamoPilot.Data.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    /// <summary>
    /// Контейнер атрибутов «имя → значение» для передачи в ноды создания/редактирования объектов Pilot.
    /// <para>
    /// Создан, чтобы обойти ненадёжный маршалинг словарей Dynamo (<c>DesignScript.Builtin.Dictionary</c>
    /// ⇄ <c>System.Collections.Generic.Dictionary&lt;,&gt;</c>). Как обычный CLR-объект <see cref="PAttributeSet"/>
    /// ходит по портам Dynamo по ссылке, без покалеченной конвертации ключей и значений.
    /// Порядок добавления сохраняется; повторная установка имени перезаписывает значение.
    /// </para>
    /// </summary>
    public class PAttributeSet : DynamoPilot.Data.Contracts.IWrapper
    {
        private readonly List<string> _order;
        private readonly Dictionary<string, object> _values;

        public PAttributeSet()
        {
            _order = new List<string>();
            _values = new Dictionary<string, object>(StringComparer.Ordinal);
        }

        public PAttributeSet(IEnumerable<KeyValuePair<string, object>> items) : this()
        {
            if (items == null) return;
            foreach (var kvp in items)
                Set(kvp.Key, kvp.Value);
        }

        /// <summary>Количество атрибутов в наборе.</summary>
        public int Count => _order.Count;

        /// <summary>Имена атрибутов в порядке добавления.</summary>
        public IReadOnlyList<string> Keys => _order;

        /// <summary>Пары «имя → значение» в порядке добавления.</summary>
        public IEnumerable<KeyValuePair<string, object>> Entries
            => _order.Select(k => new KeyValuePair<string, object>(k, _values[k]));

        /// <summary>Устанавливает (или перезаписывает) значение атрибута. Пустые имена игнорируются.</summary>
        public PAttributeSet Set(string name, object value)
        {
            if (string.IsNullOrEmpty(name)) return this;
            if (!_values.ContainsKey(name)) _order.Add(name);
            _values[name] = value;
            return this;
        }

        /// <summary>Удаляет атрибут по имени.</summary>
        public PAttributeSet Remove(string name)
        {
            if (name != null && _values.Remove(name)) _order.Remove(name);
            return this;
        }

        public bool ContainsKey(string name) => name != null && _values.ContainsKey(name);

        public bool TryGetValue(string name, out object value)
        {
            if (name != null) return _values.TryGetValue(name, out value);
            value = null;
            return false;
        }

        /// <summary>Глубокая (по парам) копия набора — для неизменяемого, «функционального» стиля в графе.</summary>
        public PAttributeSet Clone()
        {
            var copy = new PAttributeSet();
            foreach (var k in _order) copy.Set(k, _values[k]);
            return copy;
        }

        /// <summary>Представление в виде обычного словаря (для просмотра в Dynamo).</summary>
        public IDictionary<string, object> ToDictionary()
            => _order.ToDictionary(k => k, k => _values[k], StringComparer.Ordinal);

        public override string ToString()
        {
            var preview = string.Join(", ", _order.Take(8)
                .Select(k => $"{k}={AttributeValueConverter.ToStr(_values[k]) ?? "null"}"));
            var tail = _order.Count > 8 ? ", …" : string.Empty;
            return $"AttributeSet[{Count}]: {{{preview}{tail}}}";
        }

        public object Unwrap() => ToDictionary();
    }
}
