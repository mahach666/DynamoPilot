using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Menu;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.ViewModels;
using DynamoPilot.App.Configuration;
using DynamoPilot.App.Models;
using DynamoPilot.Data;
using DynamoPilot.Data.Wrappers;
using System;
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


        [ImportingConstructor]
        public App(IObjectsRepository objectsRepository)
        {
            StaticMetadata.ObjectsRepository = new PilotObjectsRepository(objectsRepository);
        }

        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            var item = builder.AddItem("DynamoPilot", 1).WithHeader("DynamoPilot");
            item.WithSubmenu().AddItem("DynamoPilot", 0).WithHeader("DynamoPilot");
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            InitDynamoModel();

            if (_view != null)
            {
                _view.Focus();
                return;
            }

            var stubWatch = new NullWatch3DViewModel(_model);

            var vm = DynamoViewModel.Start(
                new DynamoViewModel.StartConfiguration
                {
                    DynamoModel = _model,
                    Watch3DViewModel = stubWatch,
                    ShowLogin = false
                });

            _view = new DynamoView(vm)
            {
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            _view.Closed += (_, __) => _view = null;
            _view.Show();
        }

        private void InitDynamoModel()
        {
            if (_model != null) return;

            var culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var pluginDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //var nodesDir = Path.Combine(pluginDir, "nodes");
            var pkgsDir = Path.Combine(pluginDir, "packages");
            //PackageDeployer.CopyPackageFolder(pkgsDir);

            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            var cfg = new DynamoModel.DefaultStartConfiguration
            {
                DynamoCorePath = Path.Combine(baseDir, "Dynamo"),
                DynamoHostPath = Assembly.GetExecutingAssembly().Location,
                GeometryFactoryPath = Path.Combine(baseDir, "Dynamo", "libG_223"),
                Context = "Pilot " + Assembly.GetExecutingAssembly().GetName().Version,
                PathResolver = new PilotPathResolver(pluginDir),
            };

            _model = DynamoModel.Start(cfg);
        }


        //private static Assembly? ResolveFromCoreDir(object? s, ResolveEventArgs e)
        //{
        //    var dll = new AssemblyName(e.Name).Name + ".dll";
        //    var candidate = Path.Combine(coreDir, dll);
        //    return File.Exists(candidate) ? Assembly.LoadFrom(candidate) : null;
        //}
    }
}
