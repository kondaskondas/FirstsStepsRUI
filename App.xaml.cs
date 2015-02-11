using System.Windows;
using FirstsStepsRUI.Repositories;

namespace FirstsStepsRUI
{
    public partial class App : Application
    {
        public static AppBootstrapper Bootstrapper;
        public App()
        {
            Bootstrapper = new AppBootstrapper();
        }
    }
}
