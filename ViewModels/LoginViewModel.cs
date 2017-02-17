using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using FirstsStepsRUI.Models;
using FirstsStepsRUI.Repositories;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; protected set; }

        public string UrlPathSegment
        {
            get { return "Login"; }
        }

        private readonly IUserRepository _userRepository;
        public ReactiveCommand<Unit, User> Login { get; protected set; }
        private User _user;
        public User User
        {
            get { return _user; }
            set { this.RaiseAndSetIfChanged(ref _user, value); }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }
        
        private PasswordBox _password;
        public PasswordBox Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }
        public LoginViewModel(IScreen screen, IUserRepository userRepository)
        {
            HostScreen = screen;
            _userRepository = userRepository;
            var canSubmit = this.WhenAny(m => m.UserName, m => m.Password, (user, password) => user.Value.IsValid());
            // We use "_" because we don't use the parameter
            Login = ReactiveCommand.CreateFromTask(async () => await _userRepository.Login(UserName, Password.Password), canSubmit);
            Login.ObserveOn(RxApp.MainThreadScheduler).Subscribe(user =>
            {
                User = user; 
                HostScreen.Router.Navigate.Execute(new UserViewModel(HostScreen, user, _userRepository));
            });
            // TODO use UserError.RegisterHandler
            Login.ThrownExceptions.Subscribe(e => MessageBox.Show(e.Message));
        }
    }
}
