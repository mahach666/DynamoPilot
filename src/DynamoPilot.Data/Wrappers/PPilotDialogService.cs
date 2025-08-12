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

        public PPilotDialogOptions NewOptions()
        {
            return new(_pilotDialogService.NewOptions());
        }

        public PPositionDialogOptions NewPositionOptions()
        {
            return new(_pilotDialogService.NewPositionOptions());
        }

        public void ShowBalloon(string title, string message, PilotBalloonIcon icon)
        {
            _pilotDialogService.ShowBalloon(title, message, icon);
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorByObjectTypeDialog(IEnumerable<int> objectTypeIds,
            PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowDocumentsSelectorByObjectTypeDialog(objectTypeIds, pilotDialogOptions)
                .Select(i=>new PDataObject(i));
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorByObjectTypeDialogAndNavigate(IEnumerable<int> objectTypeIds,
            Guid parentId, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowDocumentsSelectorByObjectTypeDialogAndNavigate(objectTypeIds, parentId, pilotDialogOptions)
                .Select(i => new PDataObject(i)); ;
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorDialog(PPilotDialogOptions options = null)
        {
            // Если опции не переданы, используем перегрузку без параметров,
            // так как передача null в перегрузку с IPilotDialogOptions может
            // вести себя иначе в некоторых версиях SDK
            if (options == null)
            {
                return _pilotDialogService
                    .ShowDocumentsSelectorDialog()
                    .Select(i => new PDataObject(i));
            }

            var pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService
                .ShowDocumentsSelectorDialog(pilotDialogOptions)
                .Select(i => new PDataObject(i));
        }

        public IEnumerable<PDataObject> ShowDocumentsSelectorDialogAndNavigate(Guid parentId, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowDocumentsSelectorDialogAndNavigate(parentId, pilotDialogOptions)
                .Select(i => new PDataObject(i)); ;
        }

        public void ShowEditObjectDialog(Guid id, bool showDocumentPreview)
        {
            _pilotDialogService.ShowEditObjectDialog(id, showDocumentPreview);
        }

        public void ShowEditTaskDialog(Guid taskId, bool isReadonly, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            _pilotDialogService.ShowEditTaskDialog(taskId, isReadonly, pilotDialogOptions);
        }

        public IEnumerable<PDataObject> ShowElementBookDialog(string elementBookConfiguration, string serializationId = null,
            PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowElementBookDialog(elementBookConfiguration, serializationId, pilotDialogOptions)
                .Select(i => new PDataObject(i)); ;
        }

        //public void ShowNewTasksDialog(TaskTemplate template, IPilotDialogOptions options = null)
        //{
        //    _pilotDialogService.ShowNewTasksDialog( template,  options );
        //}

        public void ShowObjectDialog(Guid parentId, int objectTypeId, PObjectModifier modifier, bool showDocumentPreview)
        {
            _pilotDialogService.ShowObjectDialog(parentId, objectTypeId, (IObjectModifier)modifier.Unwrap(), showDocumentPreview);
        }

        public IEnumerable<IOrganisationUnit> ShowPositionSelectorDialog(PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowPositionSelectorDialog(pilotDialogOptions);
        }

        public IEnumerable<IOrganisationUnit> ShowPositionSelectorDialogWithOptions(PPositionDialogOptions positionOption)
        {
            return _pilotDialogService.ShowPositionSelectorDialogWithOptions((IPositionDialogOptions)positionOption.Unwrap());
        }

        public IEnumerable<PDataObject> ShowReferenceBookDialog(string referenceBookConfiguration, string serializationId = null,
            PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowReferenceBookDialog(referenceBookConfiguration, serializationId, pilotDialogOptions)
                .Select(i => new PDataObject(i)); ;
        }

        public void ShowSharingSettingsDialog(IEnumerable<Guid> objectIds, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            _pilotDialogService.ShowSharingSettingsDialog(objectIds, pilotDialogOptions);
        }

        public void ShowTaskDialog(int taskTypeId, PObjectModifier modifier, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            _pilotDialogService.ShowTaskDialog(taskTypeId, (IObjectModifier)modifier.Unwrap(), pilotDialogOptions);
        }

        //public IEnumerable<ITaskObject> ShowTasksSelectorDialog(IPilotDialogOptions options = null)
        //{
        //    _pilotDialogService.ShowTasksSelectorDialog( options);
        //}

        public IEnumerable<PDataObject> ShowTasksSelectorDialog2(PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            return _pilotDialogService.ShowTasksSelectorDialog2(pilotDialogOptions).Select(i => new PDataObject(i)); ;
        }

        public void ShowWorkflowDialog(int workflowTypeId, PObjectModifier modifier, PPilotDialogOptions options = null)
        {
            IPilotDialogOptions pilotDialogOptions = null;
            if (options != null) pilotDialogOptions = (IPilotDialogOptions)options.Unwrap();
            _pilotDialogService.ShowWorkflowDialog(workflowTypeId, (IObjectModifier)modifier.Unwrap(), pilotDialogOptions);
        }

        public object Unwrap()
        {
            return _pilotDialogService;
        }
    }
}
