using Chatbot.GUI.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Chatbot.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }

}
