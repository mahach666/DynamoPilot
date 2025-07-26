using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Menu;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.ViewModels;
using Dynamo.Wpf.ViewModels.Watch3D;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.Windows;

namespace DynamoPilot
{
    [Export(typeof(IMenu<MainViewContext>))]
    public class App : IMenu<MainViewContext>
    {
        IObjectsRepository _objectsRepository;

        private DynamoModel _model;
        private DynamoView _view;

        [ImportingConstructor]
        public App(IObjectsRepository objectsRepository)
        {
            _objectsRepository = objectsRepository;
        }
        public void Build(IMenuBuilder builder, MainViewContext context)
        {
            var item = builder.AddItem("DynamoPilot", 1).WithHeader("DynamoPilot");
            //item.WithSubmenu().AddItem("DynamoPilot", 0).WithHeader("DynamoPilot");
            //item.WithSubmenu().AddItem("LookDB", 1).WithHeader("LookDB");
            //item.WithSubmenu().AddItem("Search", 2).WithHeader("Search");
        }

        public void OnMenuItemClick(string name, MainViewContext context)
        {
            InitDynamoModel();               // убеждаемся, что ядро готово

            if (_view != null)               // уже открыто
            {
                _view.Focus();
                return;
            }

            var vm = DynamoViewModel.Start(
                new DynamoViewModel.StartConfiguration
                {
                    DynamoModel = _model,
                    // подключаем 3‑D‑превью, без него окно не откроется
                    Watch3DViewModel = HelixWatch3DViewModel.TryCreateHelixWatch3DViewModel(
                                            null,
                                            new Watch3DViewModelStartupParams(_model),
                                            _model.Logger),
                    ShowLogin = false
                });

            _view = new DynamoView(vm)
            {
                Owner = Application.Current.MainWindow,   // чтобы окно вело себя как дочернее
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            _view.Closed += (_, __) => _view = null;      // очистим ссылку при закрытии
            _view.Show();
        }

        private void InitDynamoModel()
        {
            if (_model != null) return; // уже инициализировано

            var corePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dynamo");
            //var config = DynamoModel.Start();

            //// минимальный набор путей
            //config.DynamoCorePath = corePath;
            //config.DynamoHostPath = Assembly.GetExecutingAssembly().Location;
            //config.GeometryFactoryPath = Path.Combine(corePath, "libG_223"); // ваша версия libG / ASM
            //config.Context = "PilotICE " + Assembly.GetExecutingAssembly().GetName().Version;

            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var cfg = new DynamoModel.DefaultStartConfiguration
            {
                DynamoCorePath = Path.Combine(baseDir, "Dynamo"),            // \bin
                DynamoHostPath = Assembly.GetExecutingAssembly().Location,   // ваша DLL
                GeometryFactoryPath = Path.Combine(baseDir, "Dynamo", "libG_223"),// ASM/libG
                Context = "Pilot‑ICE " + Assembly.GetExecutingAssembly().GetName().Version
                // при необходимости задайте другие свойства:
                // UserDataRootFolder, SchedulerThread, ProcessMode …
            };


            _model = DynamoModel.Start(cfg);     // создаём ядро Dynamo
        }
    }
}
