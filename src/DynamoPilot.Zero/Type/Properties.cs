using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Type
{
    /// <summary>
    /// Ноды для получения свойств типов объектов в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает уникальный идентификатор типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Уникальный идентификатор типа</returns>
        [IsDesignScriptCompatible]
        public static int GetId(PType pilotType)
        {
            return pilotType.Id;
        }

        /// <summary>
        /// Получает системное имя типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Системное имя типа</returns>
        [IsDesignScriptCompatible]
        public static string GetName(PType pilotType)
        {
            return pilotType.Name;
        }

        /// <summary>
        /// Получает отображаемое имя типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Отображаемое имя типа</returns>
        [IsDesignScriptCompatible]
        public static string GetTitle(PType pilotType)
        {
            return pilotType.Title;
        }

        /// <summary>
        /// Получает порядковый номер для сортировки типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Порядковый номер для сортировки</returns>
        [IsDesignScriptCompatible]
        public static int GetSort(PType pilotType)
        {
            return pilotType.Sort;
        }

        /// <summary>
        /// Проверяет, может ли тип содержать файлы
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>True, если тип может содержать файлы</returns>
        [IsDesignScriptCompatible]
        public static bool GetHasFiles(PType pilotType)
        {
            return pilotType.HasFiles;
        }

        /// <summary>
        /// Получает список дочерних типов
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Коллекция идентификаторов дочерних типов</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(PType pilotType)
        {
            return pilotType.Children;
        }

        /// <summary>
        /// Получает список атрибутов типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Коллекция атрибутов типа</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PAttribute> GetAttributes(PType pilotType)
        {
            return pilotType.Attributes;
        }

        /// <summary>
        /// Получает список отображаемых атрибутов типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Коллекция отображаемых атрибутов</returns>
        [IsDesignScriptCompatible]
        public static IEnumerable<PAttribute> GetDisplayAttributes(PType pilotType)
        {
            return pilotType.DisplayAttributes;
        }

        /// <summary>
        /// Получает SVG иконку типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Байтовый массив SVG иконки</returns>
        [IsDesignScriptCompatible]
        public static byte[] GetSvgIcon(PType pilotType)
        {
            return pilotType.SvgIcon;
        }

        /// <summary>
        /// Проверяет, можно ли монтировать тип
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>True, если тип можно монтировать</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsMountable(PType pilotType)
        {
            return pilotType.IsMountable;
        }

        /// <summary>
        /// Получает вид типа
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>Вид типа</returns>
        [IsDesignScriptCompatible]
        public static TypeKind GetKind(PType pilotType)
        {
            return pilotType.Kind;
        }

        /// <summary>
        /// Проверяет, удален ли тип
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>True, если тип удален</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PType pilotType)
        {
            return pilotType.IsDeleted;
        }

        /// <summary>
        /// Проверяет, является ли тип служебным
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>True, если тип служебный</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsService(PType pilotType)
        {
            return pilotType.IsService;
        }

        /// <summary>
        /// Проверяет, является ли тип проектным
        /// </summary>
        /// <param name="pilotType">Тип объекта Pilot</param>
        /// <returns>True, если тип проектный</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsProject(PType pilotType)
        {
            return pilotType.IsProject;
        }
    }
}

