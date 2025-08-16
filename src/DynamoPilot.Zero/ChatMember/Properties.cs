using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace ChatMember
{
    public static class Properties
    {
        /// <summary>
        /// Получает идентификатор чата
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>Идентификатор чата</returns>

        [IsDesignScriptCompatible]
        public static Guid ChatId(PChatMember chatMember) => chatMember.ChatId;
        /// <summary>
        /// Получает идентификатор участника
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>Идентификатор участника</returns>

        [IsDesignScriptCompatible]
        public static int PersonId(PChatMember chatMember) => chatMember.PersonId;
        /// <summary>
        /// Проверяет, является ли участник администратором
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>True, если участник является администратором</returns>

        [IsDesignScriptCompatible]
        public static bool IsAdmin(PChatMember chatMember) => chatMember.IsAdmin;
        /// <summary>
        /// Проверяет, удален ли участник
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>True, если участник удален</returns>

        [IsDesignScriptCompatible]
        public static bool IsDeleted(PChatMember chatMember) => chatMember.IsDeleted;
        /// <summary>
        /// Проверяет, получает ли участник уведомления
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>True, если участник получает уведомления</returns>

        [IsDesignScriptCompatible]
        public static bool IsNotifiable(PChatMember chatMember) => chatMember.IsNotifiable;
        /// <summary>
        /// Получает дату последнего обновления участника
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>Дата последнего обновления в формате UTC</returns>

        [IsDesignScriptCompatible]
        public static DateTime DateUpdatedUtc(PChatMember chatMember) => chatMember.DateUpdatedUtc;

        /// <summary>
        /// Проверяет, является ли участник только наблюдателем
        /// </summary>
        /// <param name="chatMember">Участник чата</param>
        /// <returns>True, если участник только просматривает</returns>
        [IsDesignScriptCompatible]
        public static bool IsViewerOnly(PChatMember chatMember) => chatMember.IsViewerOnly;
    }
}
