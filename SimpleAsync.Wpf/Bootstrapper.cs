using Microsoft.Practices.Unity;
using Prism.Unity;
using SimpleAsync.Wpf.Views;
using System.Windows;

namespace SimpleAsync.Wpf
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
