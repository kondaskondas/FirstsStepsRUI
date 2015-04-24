using System.Windows;
using FirstsStepsRUI.Repositories;
using FirstsStepsRUI.ViewModels;
using FirstsStepsRUI.Views;
using ReactiveUI;
using Splat;

namespace FirstsStepsRUI
{
    public partial class App : Application
    {
        public static AppBootstrapper Bootstrapper;
        public static ShellView ShellView;

        public App()
        {
            Bootstrapper = new AppBootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShellView = (ShellView)Locator.Current.GetService<IViewFor<ShellViewModel>>();
            ShellView.Show();
        }
    }
}
