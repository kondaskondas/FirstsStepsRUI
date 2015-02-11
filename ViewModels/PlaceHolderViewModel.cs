using System.Reactive;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class PlaceHolderViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; protected set; }

        public string UrlPathSegment
        {
            get { return "Placeholder"; }
        }

        public ReactiveCommand<Unit> ChangeView { get; protected set; }

        public PlaceHolderViewModel(IScreen screen)
        {
            HostScreen = screen;
            ChangeView = ReactiveCommand.CreateAsyncObservable(_ => HostScreen.Router.NavigateBack.ExecuteAsync());
        }
    }
}
