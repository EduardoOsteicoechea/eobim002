using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class MainDockablePanePage : Page
	{
        public MainDockablePanePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
        }
    }
}