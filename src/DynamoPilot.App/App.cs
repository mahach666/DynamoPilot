using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Menu;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.Graph.Workspaces;
using Dynamo.ViewModels;
using DynamoPilot.App.Configuration;
using DynamoPilot.App.Models;
using DynamoPilot.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace DynamoPilot.App
{
    [Export(typeof(IMenu<MainViewContext>))]
    public class App : IMenu<MainViewContext>
    {
        private DynamoModel _model;
        private DynamoView _view;
        private const bool ForceManualRun = true;
        private static readonly HashSet<Guid> ManualRunWiredWorkspaces = new();

        private static string _pluginDir;

        [ImportingConstructor]
        public App(IObjectsRepository objectsRepository,
            IObjectModifier objectModifier,
            ISearchService searchService,
            IPilotDialogService pilotDialogService,
            IMessagesRepository messagesRepository,
            IFileProvider fileProvider)
        {
            _pluginDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            StaticMetadata.ObjectsRepository = new(objectsRepository);
            StaticMetadata.ObjectModifier = new(objectModifier);
            StaticMetadata.SearchService = new(searchService);
            StaticMetadata.PilotDialogService = new(pilotDialogService);
            StaticMetadata.MessagesRepository = new(messagesRepository);
            StaticMetadata.FileProvider = new(fileProvider);
        }

        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            var item = builder.AddItem("DynamoPilot", 1).WithHeader("DynamoPilot");
            item.WithSubmenu().AddItem("DynamoPilot", 0).WithHeader("DynamoPilot");
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            if (_view != null)
            {
                _view.Focus();
                return;
            }

            InitDynamoModel();

            var stubWatch = new NullWatch3DViewModel(_model);

            var vm = DynamoViewModel.Start(
                new DynamoViewModel.StartConfiguration
                {
                    DynamoModel = _model,
                    Watch3DViewModel = stubWatch,
                    ShowLogin = false,
                });
            ApplyDefaultPreferences(vm);

            _view = new DynamoView(vm)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            _view.Closed += OnViewClosed;
            _view.Show();
        }

        private void OnViewClosed(object sender, EventArgs e)
        {
            if (_view != null)
            {
                _view.Closed -= OnViewClosed;
                _view = null;
            }

            if (_model != null)
            {
                try
                {
                    _model.Dispose();
                }
                catch { }
                finally
                {
                    _model = null;
                }
            }
        }

        private void InitDynamoModel()
        {
            if (_model != null) return;

            var culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            PackageDeployer.CopyPackageFolder(Path.Combine(_pluginDir, "packages"));

            var cfg = new DynamoModel.DefaultStartConfiguration
            {
                PathResolver = new PilotPathResolver(_pluginDir),
                DynamoCorePath = _pluginDir,
                DynamoHostPath = Assembly.GetExecutingAssembly().Location,
                GeometryFactoryPath = Path.Combine(_pluginDir, "libg_228_0_0"),
                Context = "Pilot " + Assembly.GetExecutingAssembly().GetName().Version,
            };

            _model = DynamoModel.Start(cfg);
            ApplyManualRunSettings(_model.CurrentWorkspace);
            _model.WorkspaceAdded += ApplyManualRunSettings;
            _model.WorkspaceOpened += ApplyManualRunSettings;
        }

        private static void ApplyDefaultPreferences(DynamoViewModel viewModel)
        {
            var preferences = viewModel?.PreferenceSettings;
            if (preferences == null)
                return;

            preferences.DefaultRunType = RunType.Manual;
            if (ForceManualRun)
                preferences.OpenFileInManualExecutionMode = true;
        }

        private static void ApplyManualRunSettings(WorkspaceModel workspace)
        {
            if (workspace is not HomeWorkspaceModel homeWorkspace)
                return;

            var settings = homeWorkspace.RunSettings;
            if (settings == null)
                return;

            settings.RunType = RunType.Manual;
            if (ForceManualRun)
                settings.RunTypesEnabled = false;

            lock (ManualRunWiredWorkspaces)
            {
                if (!ManualRunWiredWorkspaces.Add(homeWorkspace.Guid))
                    return;
            }

            settings.PropertyChanged += (_, args) =>
            {
                if (args == null || string.IsNullOrEmpty(args.PropertyName) ||
                    args.PropertyName == nameof(RunSettings.RunType))
                {
                    if (settings.RunType != RunType.Manual)
                        settings.RunType = RunType.Manual;
                }

                if (ForceManualRun &&
                    (args == null || string.IsNullOrEmpty(args.PropertyName) ||
                     args.PropertyName == nameof(RunSettings.RunTypesEnabled)))
                {
                    if (settings.RunTypesEnabled)
                        settings.RunTypesEnabled = false;
                }
            };
        }
    }
}
