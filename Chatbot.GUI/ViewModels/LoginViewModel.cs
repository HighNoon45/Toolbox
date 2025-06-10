using Chatbot.GUI.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Toolbox.Infrastructure.Repositories;
using Toolbox.Infrastructure.Security;

namespace Chatbot.GUI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepository = new();
        private readonly PasswordHandler _passwordHandler = new();

        private string _username = "";
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password { get; set; } = "";

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin()
        {
            var user = _userRepository.GetByUsername(Username);
            if (user == null)
            {
                MessageBox.Show("Benutzername existiert nicht.");
                return;
            }

            var inputHash = _passwordHandler.HashPassword(Password, user.PasswordSalt);
            if (inputHash == user.PasswordHash)
            {
                MessageBox.Show("Login erfolgreich.");
                // TODO: Fenster schließen / MainWindow öffnen
            }
            else
            {
                MessageBox.Show("Falsches Passwort.");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
