using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Toolbox
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private readonly OllamaService _ollamaService;
        private string _prompt;
        private string _response;

        public ChatViewModel(OllamaService ollamaService)
        {
            _ollamaService = ollamaService;
            SendCommand = new RelayCommand(async () => await SendPromptAsync());
        }

        public string Prompt
        {
            get => _prompt;
            set { _prompt = value; OnPropertyChanged(); }
        }

        public string Response
        {
            get => _response;
            set { _response = value; OnPropertyChanged(); }
        }

        public ICommand SendCommand { get; }

        private async Task SendPromptAsync()
        {
            if (string.IsNullOrWhiteSpace(Prompt)) return;

            var chat = await _ollamaService.SendPromptAsync(Prompt, userId: 1);
            Response = chat.Response.ResponseText;
            Prompt = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}