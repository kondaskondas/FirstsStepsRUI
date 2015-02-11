using System.Windows;
using System.Windows.Controls;
using FirstsStepsRUI.ViewModels;
using ReactiveUI;

namespace FirstsStepsRUI.Views
{
    public partial class MenuView : UserControl, IViewFor<MenuViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof (MenuViewModel), typeof (MenuView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MenuViewModel) value; }
        }

        public MenuViewModel ViewModel
        {
            get { return (MenuViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public MenuView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Menu, v => v.SideMenu.ItemsSource);
            this.Bind(ViewModel, vm => vm.SelectedOption, v => v.SideMenu.SelectedValue);
        }
    }
}
