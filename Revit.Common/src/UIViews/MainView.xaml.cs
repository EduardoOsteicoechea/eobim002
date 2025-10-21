using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class MainView : UserControl
	{
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewViewModel();
        }
    }
}