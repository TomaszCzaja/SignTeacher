using System;
using System.Windows;
using System.Windows.Threading;
using Autofac;
using SignTeacher.UI.Startup;

namespace SignTeacher.UI
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            AutoMapperConfig.RegisterMappings();

            var bootstraper = new Bootstrapper();
            var container = bootstraper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Something went wrong. Message: " + Environment.NewLine + e.Exception.Message);

            e.Handled = true;
        }
    }
}
