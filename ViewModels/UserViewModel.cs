using FirstsStepsRUI.Models;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class UserViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "User"; } }
        public IScreen HostScreen { get; protected set; }

        private User _user;
        public User User
        {
            get { return _user; }
            set { this.RaiseAndSetIfChanged(ref _user, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { this.RaiseAndSetIfChanged(ref _message, value); }
        }

        public UserViewModel(IScreen screen, User user)
        {
            HostScreen = screen;
            User = user;
        }
    }
}
