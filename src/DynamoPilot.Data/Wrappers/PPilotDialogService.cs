using Ascon.Pilot.SDK;
using Ascon.Pilot.Themes;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamoPilot.Data.Wrappers
{
    public class PPilotDialogService : IWrapper
    {
        private readonly IPilotDialogService _pilotDialogService;
        public PPilotDialogService(IPilotDialogService pilotDialogService)
        {
            _pilotDialogService = pilotDialogService;
        }
        public string AccentColor => _pilotDialogService.AccentColor;

        public ThemeNames Theme => _pilotDialogService.Theme;

        //public void Dispose()
        //{
        //    _pilotDialogService.Dispose;
        //}

        public IPilotDialogOptions NewOptions()
        {
            return _pilotDialogService.NewOptions();
        }

        public IPositionDialogOptions NewPositionOptions()
        {
            return _pilotDialogService.NewPositionOptions();
        }

        public void ShowBalloon(string title, string message, PilotBalloonIcon icon)
        {
            _pilotDialogService.ShowBalloon(title, message, icon);
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorByObjectTypeDialog(IEnumerable<int> objectTypeIds, IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowDocumentsSelectorByObjectTypeDialog(objectTypeIds, options).Select(i=>new PDataObject(i));
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorByObjectTypeDialogAndNavigate(IEnumerable<int> objectTypeIds, Guid parentId, IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowDocumentsSelectorByObjectTypeDialogAndNavigate(objectTypeIds, parentId, options).Select(i => new PDataObject(i)); ;
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorDialog(IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowDocumentsSelectorDialog(options).Select(i => new PDataObject(i)); ;
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorDialogAndNavigate(Guid parentId, IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowDocumentsSelectorDialogAndNavigate(parentId, options).Select(i => new PDataObject(i)); ;
        }

        public void ShowEditObjectDialog(Guid id, bool showDocumentPreview)
        {
            _pilotDialogService.ShowEditObjectDialog(id, showDocumentPreview);
        }

        public void ShowEditTaskDialog(Guid taskId, bool isReadonly, IPilotDialogOptions options = null)
        {
            _pilotDialogService.ShowEditTaskDialog(taskId, isReadonly, options);
        }

        public IEnumerable<PDataObject> ShowElementBookDialog(string elementBookConfiguration, string serializationId = null, IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowElementBookDialog(elementBookConfiguration, serializationId, options).Select(i => new PDataObject(i)); ;
        }

        //public void ShowNewTasksDialog(TaskTemplate template, IPilotDialogOptions options = null)
        //{
        //    _pilotDialogService.ShowNewTasksDialog( template,  options );
        //}

        public void ShowObjectDialog(Guid parentId, int objectTypeId, IObjectModifier modifier, bool showDocumentPreview)
        {
            _pilotDialogService.ShowObjectDialog(parentId, objectTypeId, modifier, showDocumentPreview);
        }

        public IEnumerable<IOrganisationUnit> ShowPositionSelectorDialog(IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowPositionSelectorDialog(options);
        }

        public IEnumerable<IOrganisationUnit> ShowPositionSelectorDialogWithOptions(IPositionDialogOptions positionOption)
        {
            return _pilotDialogService.ShowPositionSelectorDialogWithOptions(positionOption);
        }

        public IEnumerable<PDataObject> ShowReferenceBookDialog(string referenceBookConfiguration, string serializationId = null, IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowReferenceBookDialog(referenceBookConfiguration, serializationId, options).Select(i => new PDataObject(i)); ;
        }

        public void ShowSharingSettingsDialog(IEnumerable<Guid> objectIds, IPilotDialogOptions options = null)
        {
            _pilotDialogService.ShowSharingSettingsDialog(objectIds, options);
        }

        public void ShowTaskDialog(int taskTypeId, IObjectModifier modifier, IPilotDialogOptions options = null)
        {
            _pilotDialogService.ShowTaskDialog(taskTypeId, modifier, options);
        }

        //public IEnumerable<ITaskObject> ShowTasksSelectorDialog(IPilotDialogOptions options = null)
        //{
        //    _pilotDialogService.ShowTasksSelectorDialog( options);
        //}

        public IEnumerable<PDataObject> ShowTasksSelectorDialog2(IPilotDialogOptions options = null)
        {
            return _pilotDialogService.ShowTasksSelectorDialog2(options).Select(i => new PDataObject(i)); ;
        }

        public void ShowWorkflowDialog(int workflowTypeId, IObjectModifier modifier, IPilotDialogOptions options = null)
        {
            _pilotDialogService.ShowWorkflowDialog(workflowTypeId, modifier, options);
        }

        public object Unwrap()
        {
            return _pilotDialogService;
        }
    }
}
