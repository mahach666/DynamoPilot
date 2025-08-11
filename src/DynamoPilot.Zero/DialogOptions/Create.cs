using Dynamo.Graph.Nodes;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;

namespace DynamoPilot.Zero.DialogOptions
{
    public static class Create
    {
        [IsDesignScriptCompatible]
        public static PPilotDialogOptions CreatePilotDialogOptions(bool allowChecking = false,
            bool allowMultiSelect = false,
            string caption = null,
            IEnumerable<object> nodes = null,
            string infoMessage = null,
            string okButtonCaption = null)
        {
            var dialogOptions = StaticMetadata.PilotDialogService.NewOptions();

            dialogOptions.WithAllowChecking(allowChecking);
            dialogOptions.WithAllowMultiSelect(allowMultiSelect);

            if (caption != null) dialogOptions.WithCaption(caption);
            if (nodes != null) dialogOptions.WithCheckedNodes(nodes);
            if (infoMessage != null) dialogOptions.WithInfoMessage(infoMessage);
            if (okButtonCaption != null) dialogOptions.WithOkButtonCaption(okButtonCaption);

            return dialogOptions;
        }

        [IsDesignScriptCompatible]
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
