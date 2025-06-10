using System.Windows;
using System.Windows.Controls;
using Chatbot.GUI.ViewModels;

namespace Chatbot.GUI.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginViewModel _viewModel = new();

        public LoginView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = PasswordBox.Password;
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
        }
    }
}
