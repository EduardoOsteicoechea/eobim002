using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eduardoos.RevitApi
{
	public class MainTabControlViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ObservableCollection<UserControl> Tabs { get; }

		private UserControl _selectedTab;
		public UserControl SelectedTab
		{
			get => _selectedTab;
			set
			{
				_selectedTab = value;
				OnPropertyChanged();
			}
		}

		public MainTabControlViewModel()
		{
			Tabs = new ObservableCollection<UserControl>
			{
				new HomePage(),
				new AIAssistantPage(),
				new ContactPage(),
			};

			SelectedTab = Tabs.FirstOrDefault();

			EventAggregator.Instance.Subscribe<ChangeViewMessage>(HandleChangeViewMessage);
		}

		private void HandleChangeViewMessage(ChangeViewMessage item)
		{
			if(item.Message.Equals("Home"))
			{
				SelectedTab = Tabs[0];
			}
			else if (item.Message.Equals("Assistant"))
			{
				SelectedTab = Tabs[1];
			}
			else
			{
				SelectedTab = Tabs[2];
			}
		}
	}
}