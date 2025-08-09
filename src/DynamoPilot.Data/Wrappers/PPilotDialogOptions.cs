using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Data.Wrappers
{
    public class PPilotDialogOptions : IWrapper
    {
        private IPilotDialogOptions _pilotDialogOptions;
        public PPilotDialogOptions(IPilotDialogOptions pilotDialogOptions)
        {
            _pilotDialogOptions = pilotDialogOptions;
        }
        public object Unwrap()
        {
            return _pilotDialogOptions;
        }

        public PPilotDialogOptions WithAllowChecking(bool allowChecking)
        {
            _pilotDialogOptions.WithAllowChecking(allowChecking);
            return this;
        }

        public PPilotDialogOptions WithAllowMultiSelect(bool allowMultiSelect)
        {
            _pilotDialogOptions.WithAllowMultiSelect(allowMultiSelect);
            return this;
        }

        public PPilotDialogOptions WithCaption(string caption)
        {
            _pilotDialogOptions.WithCaption(caption);
            return this;
        }

        public PPilotDialogOptions WithCheckedNodes(IEnumerable<object> nodes)
        {
            _pilotDialogOptions.WithCheckedNodes(nodes);
            return this;
        }

        public PPilotDialogOptions WithInfoMessage(string infoMessage)
        {
            _pilotDialogOptions.WithInfoMessage(infoMessage);
            return this;
        }

        public PPilotDialogOptions WithOkButtonCaption(string okButtonCaption)
        {
            _pilotDialogOptions.WithOkButtonCaption(okButtonCaption);
            return this;
        }

        public PPilotDialogOptions WithParentWindow(IntPtr parentWindow)
        {
            _pilotDialogOptions.WithParentWindow(parentWindow);
            return this;
        }
    }
}
