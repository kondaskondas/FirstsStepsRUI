using System;
using FirstsStepsRUI.Models;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class UserViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get { return "User"; } }
        public IScreen HostScreen { get; protected set; }

        private User _model;
        public User Model
        {
            get { return _model; }
            set { this.RaiseAndSetIfChanged(ref _model, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { this.RaiseAndSetIfChanged(ref _message, value); }
        }

        private UserGroup _group;
        public UserGroup Group
        {
            get { return _group; }
            set { this.RaiseAndSetIfChanged(ref _group, value); }
        }

        public UserViewModel(IScreen screen, User model)
        {
            HostScreen = screen;
            Model = model;
            this.WhenAnyValue(e => e.Group).Subscribe(group => Model.Group = group);
        }
    }
}
