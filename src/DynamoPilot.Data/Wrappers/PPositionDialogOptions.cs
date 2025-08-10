using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;

namespace DynamoPilot.Data.Wrappers
{
    public class PPositionDialogOptions :  IWrapper
    {
        private IPositionDialogOptions _positionDialogOptions;
        public PPositionDialogOptions(IPositionDialogOptions positionDialogOptions)
        {
            _positionDialogOptions = positionDialogOptions;
        }
        public object Unwrap()
        {
            return _positionDialogOptions;
        }

        public PPositionDialogOptions WithAllowChecking(bool allowChecking)
        {
            _positionDialogOptions.WithAllowChecking(allowChecking);
            return this;
        }

        public PPositionDialogOptions WithAllowDepartmentChecking(bool allowDepartmentChecking)
        {
            _positionDialogOptions.WithAllowDepartmentChecking(allowDepartmentChecking);
            return this;
        }

        public PPositionDialogOptions WithAllowMultiSelect(bool allowMultiSelect)
        {
            _positionDialogOptions.WithAllowMultiSelect(allowMultiSelect);
            return this;
        }

        public PPositionDialogOptions WithCaption(string caption)
        {
            _positionDialogOptions.WithCaption(caption);
            return this;
        }

        public PPositionDialogOptions WithCheckedOrgUnits(IEnumerable<int> checkedOrgUnits)
        {
            _positionDialogOptions.WithCheckedOrgUnits(checkedOrgUnits);
            return this;
        }

        public PPositionDialogOptions WithOkButtonCaption(string okButtonCaption)
        {
            _positionDialogOptions.WithOkButtonCaption(okButtonCaption);
            return this;
        }

        public PPositionDialogOptions WithParentWindow(IntPtr parentWindow)
        {
            _positionDialogOptions.WithParentWindow(parentWindow);
            return this;
        }
    }
}
