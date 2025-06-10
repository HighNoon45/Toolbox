using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using Toolbox.Infrastructure;
using Toolbox.Infrastructure.Entities;

namespace Chatbot.GUI.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Bitte Benutzername und Passwort eingeben.");
                return;
            }

            using (var db = new ToolboxDbContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Benutzername existiert bereits.");
                    return;
                }

                var salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                    rng.GetBytes(salt);

                var hash = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256).GetBytes(32);

                var user = new User
                {
                    Username = username,
                    PasswordHash = Convert.ToBase64String(hash),
                    PasswordSalt = Convert.ToBase64String(salt)
                };

                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Benutzer erfolgreich erstellt!");
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;

            using (var db = new ToolboxDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    MessageBox.Show("Benutzer nicht gefunden.");
                    return;
                }

                var salt = Convert.FromBase64String(user.PasswordSalt);
                var hash = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256).GetBytes(32);

                if (Convert.ToBase64String(hash) == user.PasswordHash)
                {
                    MessageBox.Show("Login erfolgreich!");
                    // Weiterleitung zur Hauptanwendung
                }
                else
                {
                    MessageBox.Show("Falsches Passwort.");
                }
            }
        }
    }
}