using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class MainTabControl : UserControl
	{
        public MainTabControl()
        {
            InitializeComponent();
            DataContext = new MainTabControlViewModel();
        }
    }
}