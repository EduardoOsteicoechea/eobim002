using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ICommand ChangeView { get; }
        public HomePageViewModel()
        {
            ChangeView = new RelayCommand(ExecuteChangeView);
        }


		private void ExecuteChangeView()
		{
			if (ActiveView is HomePage)
			{
				ActiveView = new ContactPage();
			}
			else
			{
				ActiveView = new HomePage();
			}
		}


		private FrameworkElement _activeView { get; set; } = new HomePage();
        public FrameworkElement ActiveView
        {
            get
            {
                return _activeView;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
				_activeView = value;
				OnPropertyChanged();
            }
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