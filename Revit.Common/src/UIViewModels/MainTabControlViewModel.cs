using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eduardoos.RevitApi
{


	public class ChangeTabMessage
	{
		public Type TargetViewModelType { get; set; }
	}

	// A base class for any ViewModel that can be a tab page
	public abstract class TabViewModelBase : INotifyPropertyChanged
	{
		public string Header { get; }

		protected TabViewModelBase(string header)
		{
			Header = header;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

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
				new ContactPage()
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
			else
			{
				SelectedTab = Tabs[1];
			}
		}
	}
}