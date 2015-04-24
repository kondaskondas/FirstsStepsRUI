using System;
using System.Linq;
using System.Reactive.Linq;
using FirstsStepsRUI.Models;
using FirstsStepsRUI.Repositories;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class ShellViewModel : ReactiveObject, IRoutableViewModel
    {
        // Services
        private readonly IUserRepository _userRepository;
        // Properties
        public string UrlPathSegment { get { return "Shell"; } }
        public IScreen HostScreen { get; protected set; }
        public ReactiveCommand<object> LoadUser { get; protected set; }
        private User _user;
        public User User
        {
            get { return _user; }
            set { this.RaiseAndSetIfChanged(ref _user, value); }
        }
        // ViewModels
        public MenuViewModel MenuViewModel { get; set; }
        // Might as well be a dialog
        public LoginViewModel LoginViewModel { get; set; }
        

        public ShellViewModel(IScreen screen, IUserRepository userRepository)
        {
            HostScreen = screen;
            _userRepository = userRepository;
            MenuViewModel = new MenuViewModel(_userRepository);
            LoginViewModel = new LoginViewModel(HostScreen, _userRepository);
            SetInterfaceByUser();
            SetInterface();
            HostScreen.Router.Navigate.Execute(LoginViewModel);
            this.WhenAnyValue(vm => vm.LoginViewModel.User).Subscribe(user => User = user);
        }

        private void SetInterfaceByUser()
        {
            // Set the Menu user to have an updated option list
            this.WhenAnyValue(vm => vm.User).Subscribe(user => MenuViewModel.User = user);
        }

        private void SetInterface()
        {
            // We own the object so we control it's lifecycle, no problem on subscribing here, i hope so.
            this.WhenAny(vm => vm.MenuViewModel.SelectedOption, mvm => mvm.Value).Where(e => e != null).Subscribe(e =>
            {
                if (e.Model.Option.ToString() == HostScreen.Router.NavigationStack.Last().UrlPathSegment)
                    return;
                switch (e.Model.Option)
                {
                    case MenuOption.Login:
                        HostScreen.Router.Navigate.Execute(LoginViewModel);
                        break;
                    case MenuOption.User:
                        HostScreen.Router.Navigate.Execute(new UserViewModel(HostScreen, User, _userRepository));
                        break;
                    case MenuOption.Placeholder:
                        HostScreen.Router.Navigate.Execute(new PlaceHolderViewModel(HostScreen));
                        break;
                }
            });
        }
    }
}
