using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Eduardoos.RevitApi
{
	public class ActivityBarViewModel : INotifyPropertyChanged
	{
		private EventAggregator _eventAggregator;

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ICommand ChangeToHomeViewCommand { get; }
		public ICommand ChangeToSettingsViewCommand { get; }


		public ActivityBarViewModel()
		{
			_eventAggregator = EventAggregator.Instance;
			ChangeToHomeViewCommand = new RelayCommand(ExecuteChangeToHomeView);
			ChangeToSettingsViewCommand = new RelayCommand(ExecuteChangeToSettingsView);
		}

		public void ExecuteChangeToHomeView()
		{
			_eventAggregator.Publish(new ChangeViewMessage 
				{ 
					TargetViewModelType = typeof(string), 
					Message = "Home",
					StatusBarMessage = "Eduardoos App Home" 
				});
		}

		public void ExecuteChangeToSettingsView()
		{
			_eventAggregator.Publish(new ChangeViewMessage
			{
				TargetViewModelType = typeof(string),
				Message = "Settings",
				StatusBarMessage = "Configure the application"
			});
		}
	}
}