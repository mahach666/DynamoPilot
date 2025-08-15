using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace DialogOptions
{
    /// <summary>
    /// Ноды для создания настроек диалогов в системе Pilot
    /// </summary>
    public static class Create
    {
        /// <summary>
        /// Создает настройки диалога выбора объектов Pilot
        /// </summary>
        /// <param name="nodes">Список узлов для отображения</param>
        /// <param name="allowChecking">Разрешить выбор флажков</param>
        /// <param name="allowMultiSelect">Разрешить множественный выбор</param>
        /// <param name="caption">Заголовок диалога</param>
        /// <param name="infoMessage">Информационное сообщение</param>
        /// <param name="okButtonCaption">Текст кнопки OK</param>
        /// <returns>Настройки диалога Pilot</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static PPilotDialogOptions CreatePilotDialogOptions(
            List<object> nodes,
            bool allowChecking = false,
            bool allowMultiSelect = false,
            string caption = "",
            string infoMessage = "",
            string okButtonCaption = "")
        {
            var dialogOptions = StaticMetadata.PilotDialogService.NewOptions();

            dialogOptions.WithAllowChecking(allowChecking);
            dialogOptions.WithAllowMultiSelect(allowMultiSelect);

            if (!string.IsNullOrWhiteSpace(caption)) dialogOptions.WithCaption(caption);
            if (nodes != null && nodes.Any()) dialogOptions.WithCheckedNodes(nodes);
            if (!string.IsNullOrWhiteSpace(infoMessage)) dialogOptions.WithInfoMessage(infoMessage);
            if (!string.IsNullOrWhiteSpace(okButtonCaption)) dialogOptions.WithOkButtonCaption(okButtonCaption);

            return dialogOptions;
        }

        /// <summary>
        /// Создает настройки диалога выбора позиций/должностей
        /// </summary>
        /// <param name="allowChecking">Разрешить выбор флажков</param>
        /// <param name="allowMultiSelect">Разрешить множественный выбор</param>
        /// <param name="allowDepartmentChecking">Разрешить выбор подразделений</param>
        /// <param name="caption">Заголовок диалога</param>
        /// <param name="okButtonCaption">Текст кнопки OK</param>
        /// <param name="checkedOrgUnits">Предварительно выбранные организационные единицы</param>
        /// <returns>Настройки диалога позиций</returns>
        [IsDesignScriptCompatible]
        [IsVisibleInDynamoLibrary(false)]
        public static PPositionDialogOptions CreatePositionDialogOptions(
            bool allowChecking = false,
            bool allowMultiSelect = false,
            bool allowDepartmentChecking = false,
            string caption = null,
            string okButtonCaption = null,
            IEnumerable<int> checkedOrgUnits = null)
        {
            var dialogOptions = StaticMetadata.PilotDialogService.NewPositionOptions();

            dialogOptions.WithAllowChecking(allowChecking);
            dialogOptions.WithAllowMultiSelect(allowMultiSelect);
            dialogOptions.WithAllowDepartmentChecking(allowDepartmentChecking);

            if (caption != null) dialogOptions.WithCaption(caption);
            if (okButtonCaption != null) dialogOptions.WithOkButtonCaption(okButtonCaption);
            if (checkedOrgUnits != null) dialogOptions.WithCheckedOrgUnits(checkedOrgUnits);

            return dialogOptions;
        }
    }
}
