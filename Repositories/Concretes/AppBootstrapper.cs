using FirstsStepsRUI.ViewModels;
using FirstsStepsRUI.Views;
using ReactiveUI;
using Splat;

namespace FirstsStepsRUI.Repositories
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; private set; }

        public AppBootstrapper()
        {
            // View "StackTrace"
            Router = new RoutingState();
            // This is our main window host
            Locator.CurrentMutable.RegisterLazySingleton(() => this, typeof(IScreen));
            // Repositories
            Locator.CurrentMutable.Register(() => new StubUserRepository(), typeof(IUserRepository));
            // ViewModels
            Locator.CurrentMutable.RegisterLazySingleton(() => new ShellViewModel(
                Locator.Current.GetService<IScreen>(),
                Locator.Current.GetService<IUserRepository>()
                ), typeof(ShellViewModel));
            // Views
            Locator.CurrentMutable.RegisterLazySingleton(() => new ShellView(Locator.Current.GetService<ShellViewModel>()), typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(() => new MenuView(), typeof(IViewFor<MenuViewModel>));
            Locator.CurrentMutable.Register(() => new PlaceHolderView(), typeof(IViewFor<PlaceHolderViewModel>));
            Locator.CurrentMutable.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            Locator.CurrentMutable.Register(() => new UserView(), typeof(IViewFor<UserViewModel>));
            // This is our main window
            ((ShellView)Locator.Current.GetService<IViewFor<ShellViewModel>>()).Show();
        }
    }
}
