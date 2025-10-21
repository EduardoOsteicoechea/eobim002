using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Eduardoos.RevitApi
{
    public class StatusBarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _messengerStateMessage { get; set; } = "Initial";
        public string MessengerStateMessage
        {
            get => _messengerStateMessage;
            set
            {
                if (value is null || value.Equals(_messengerStateMessage))
                {
                    return;
                }

                _messengerStateMessage = value;
            }
        }

        private string _availableActionText { get; set; } = "Cancel";
        public string AvailableActionText
        {
            get => _availableActionText;
            set
            {
                if (value is null || value.Equals(_availableActionText))
                {
                    return;
                }

                _availableActionText = value;
            }
        }

        private double _currentTaskProgress { get; set; } = 10;
        public double CurrentTaskProgress
        {
            get => _currentTaskProgress;
            set
            {
                if (value.Equals(_currentTaskProgress))
                {
                    return;
                }

                if (value < 0)
                {
                    _currentTaskProgress = 0;
                }

                if (value > 100)
                {
                    _currentTaskProgress = 100;
                }

                _currentTaskProgress = value;
            }
        }


    }
}