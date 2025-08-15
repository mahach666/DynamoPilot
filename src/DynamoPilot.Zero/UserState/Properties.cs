using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace UserState
{
    /// <summary>
    /// Ноды для получения свойств состояний пользователей в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает уникальный идентификатор состояния
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>Уникальный идентификатор</returns>
        [IsDesignScriptCompatible]
        public static Guid GetId(PUserState pUserState) => pUserState.Id;

        /// <summary>
        /// Получает системное имя состояния
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>Системное имя состояния</returns>
        [IsDesignScriptCompatible]
        public static string GetName(PUserState pUserState) => pUserState.Name;

        /// <summary>
        /// Получает отображаемое название состояния
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>Отображаемое название</returns>
        [IsDesignScriptCompatible]
        public static  string GetTitle(PUserState pUserState) => pUserState.Title;

        /// <summary>
        /// Получает иконку состояния
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>Байтовый массив иконки</returns>
        [IsDesignScriptCompatible]
        public static byte[] GetIcon(PUserState pUserState) => pUserState.Icon;

        /// <summary>
        /// Получает цвет состояния
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>Цвет состояния</returns>
        [IsDesignScriptCompatible]
        public static UserStateColorNames GetColor(PUserState pUserState) => pUserState.Color;

        /// <summary>
        /// Проверяет, удалено ли состояние
        /// </summary>
        /// <param name="pUserState">Состояние пользователя</param>
        /// <returns>True, если состояние удалено</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PUserState pUserState) => pUserState.IsDeleted;
    }
}
