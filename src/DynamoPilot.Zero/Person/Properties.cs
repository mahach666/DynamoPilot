using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Person
{
    /// <summary>
    /// Ноды для получения свойств пользователей в системе Pilot
    /// </summary>
    public static class Properties
    {
        /// <summary>
        /// Получает идентификатор пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Идентификатор пользователя</returns>
        [IsDesignScriptCompatible]
        public static int GetId(PPerson pPerson) => pPerson.Id;

        /// <summary>
        /// Получает логин пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Логин пользователя</returns>
        [IsDesignScriptCompatible]
        public static string GetLogin(PPerson pPerson) => pPerson.Login;

        /// <summary>
        /// Получает отображаемое имя пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Отображаемое имя пользователя</returns>
        [IsDesignScriptCompatible]
        public static string GetDisplayName(PPerson pPerson) => pPerson.DisplayName;

        /// <summary>
        /// Получает список должностей пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Коллекция должностей</returns>
        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PPosition> GetPositions(PPerson pPerson)
            => new ReadOnlyCollection<PPosition>(pPerson.Positions.Select(i => new PPosition(i)).ToList());

        /// <summary>
        /// Получает основную должность пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Основная должность</returns>
        [IsDesignScriptCompatible]
        public static PPosition GetMainPosition(PPerson pPerson) => new(pPerson.MainPosition);

        /// <summary>
        /// Получает комментарий к пользователю
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Комментарий</returns>
        [IsDesignScriptCompatible]
        public static string GetComment(PPerson pPerson) => pPerson.Comment;

        /// <summary>
        /// Получает служебную информацию о пользователе
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Служебная информация</returns>
        [IsDesignScriptCompatible]
        public static string GetServiceInfo(PPerson pPerson) => pPerson.ServiceInfo;

        /// <summary>
        /// Получает SID (идентификатор безопасности) пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>SID пользователя</returns>
        [IsDesignScriptCompatible]
        public static string GetSid(PPerson pPerson) => pPerson.Sid;

        /// <summary>
        /// Проверяет, удален ли пользователь
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>True, если пользователь удален</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PPerson pPerson) => pPerson.IsDeleted;

        /// <summary>
        /// Проверяет, является ли пользователь администратором
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>True, если пользователь администратор</returns>
        [IsDesignScriptCompatible]
        public static bool GetIsAdmin(PPerson pPerson) => pPerson.IsAdmin;

        /// <summary>
        /// Получает фактическое имя пользователя
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Фактическое имя</returns>
        [IsDesignScriptCompatible]
        public static string GetActualName(PPerson pPerson) => pPerson.ActualName;

        /// <summary>
        /// Получает дату создания пользователя в UTC
        /// </summary>
        /// <param name="pPerson">Пользователь</param>
        /// <returns>Дата создания в UTC</returns>
        [IsDesignScriptCompatible]
        public static DateTime GetCreatedUtc(PPerson pPerson) => pPerson.CreatedUtc;
    }
}
