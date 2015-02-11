using System.Windows;
using System.Windows.Controls;
using FirstsStepsRUI.ViewModels;
using ReactiveUI;

namespace FirstsStepsRUI.Views
{
    public partial class UserView : UserControl, IViewFor<UserViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof (UserViewModel), typeof (UserView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (UserViewModel) value; }
        }

        public UserViewModel ViewModel
        {
            get { return (UserViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public UserView()
        {
            InitializeComponent();
            this.Bind(ViewModel, vm => vm.User.Code, v => v.User.Text);
            this.Bind(ViewModel, vm => vm.Message, v => v.Write.Text);
        }
    }
}
