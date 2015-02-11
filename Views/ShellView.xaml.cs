using System.Windows;
using FirstsStepsRUI.ViewModels;
using ReactiveUI;

namespace FirstsStepsRUI.Views
{
    public partial class ShellView : Window, IViewFor<ShellViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof (ShellViewModel), typeof (ShellView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ShellViewModel) value; }
        }

        public ShellViewModel ViewModel
        {
            get { return (ShellViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public ShellView(ShellViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            this.OneWayBind(ViewModel, vm => vm.MenuViewModel, v => v.Menu.ViewModel);
            this.Bind(ViewModel, vm => vm.HostScreen.Router, v => v.ContentView.Router);
        }
    }
}
