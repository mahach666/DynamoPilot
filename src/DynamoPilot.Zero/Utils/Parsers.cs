using Ascon.Pilot.SDK;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using System;

namespace Utils
{
    /// <summary>
    /// Ноды для парсинга строковых значений в перечисления Pilot
    /// </summary>
    public static class Parsers
    {
        /// <summary>
        /// Парсит строковое значение в состояние объекта
        /// </summary>
        /// <param name="stateString">Строковое представление состояния</param>
        /// <returns>Состояние объекта</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static ObjectState ParseObjectState(string stateString)
        {
            if (Enum.TryParse<ObjectState>(stateString, out var result))
            {
                return result;
            }
            return ObjectState.Alive;
        }

        /// <summary>
        /// Парсит строковое значение в режим поиска
        /// </summary>
        /// <param name="stateString">Строковое представление режима</param>
        /// <returns>Режим поиска</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static SearchMode ParseSearchMode(string stateString)
        {
            if (Enum.TryParse<SearchMode>(stateString, out var result))
            {
                return result;
            }
            return SearchMode.Files;
        }

        /// <summary>
        /// Парсит строковое значение в тип связи объекта
        /// </summary>
        /// <param name="stateString">Строковое представление типа связи</param>
        /// <returns>Тип связи объекта</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static ObjectRelationType ParseRelationType(string stateString)
        {
            if (Enum.TryParse<ObjectRelationType>(stateString, out var result))
            {
                return result;
            }
            return ObjectRelationType.Custom;
        }
    }
}
