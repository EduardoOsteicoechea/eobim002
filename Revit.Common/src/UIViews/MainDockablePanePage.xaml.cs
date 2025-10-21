using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class MainDockablePanePage : UserControl
	{
        public MainDockablePanePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
        }
    }
}