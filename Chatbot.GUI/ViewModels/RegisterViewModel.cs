using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Toolbox.Infrastructure.Repositories;
using Toolbox.Infrastructure.Security;
using Toolbox.Infrastructure.Entities;
using Chatbot.GUI.Helpers;

namespace Chatbot.GUI.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly UserRepository _repo = new();
        private readonly PasswordHandler _passwordHandler = new();

        private string _username = "";
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password { get; set; } = "";
        public string RepeatPassword { get; set; } = "";

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            if (!IsInputValid())
                return;

            if (_repo.ExistsByUsername(Username))
            {
                MessageBox.Show("Dieser Benutzername ist bereits vergeben.");
                return;
            }

            string salt = _passwordHandler.GenerateSalt();
            string hash = _passwordHandler.HashPassword(Password, salt);

            var user = new User
            {
                Username = Username,
                PasswordSalt = salt,
                PasswordHash = hash
            };

            _repo.Create(user);
            MessageBox.Show("Benutzer erfolgreich registriert.");
            ClearFields();
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("Benutzername darf nicht leer sein.");
                return false;
            }

            if (!Regex.IsMatch(Username, @"^[a-zA-Z0-9]{4,20}$"))
            {
                MessageBox.Show("Benutzername muss 4–20 Zeichen lang sein und darf nur Buchstaben/Zahlen enthalten.");
                return false;
            }

            if (Password.Length < 6 || !Password.Any(char.IsDigit))
            {
                MessageBox.Show("Passwort muss mindestens 6 Zeichen lang sein und eine Zahl enthalten.");
                return false;
            }

            if (Password != RepeatPassword)
            {
                MessageBox.Show("Passwörter stimmen nicht überein.");
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            Username = "";
            Password = "";
            RepeatPassword = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
