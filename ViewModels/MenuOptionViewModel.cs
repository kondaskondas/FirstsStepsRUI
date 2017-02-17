using System.Reactive;
using System.Reactive.Linq;
using FirstsStepsRUI.Models;
using ReactiveUI;

namespace FirstsStepsRUI.ViewModels
{
    public class MenuOptionViewModel : ReactiveObject
    {
        public Menu Model { get; protected set; }
        public ReactiveCommand<Unit, Menu> SelectedOption { get; protected set; }

        public MenuOptionViewModel(Menu model)
        {
            Model = model;
            SelectedOption = ReactiveCommand.CreateFromObservable(() => Observable.Return(Model));
        }

        public override string ToString()
        {
            return Model.ToString();
        }
    }
}
