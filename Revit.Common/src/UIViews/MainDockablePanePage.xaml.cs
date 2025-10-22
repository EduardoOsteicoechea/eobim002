using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public partial class MainDockablePanePage : Page
	{
        public MainDockablePanePage()
        {
            InitializeComponent();
            DataContext = new HomePageViewModel();
        }
    }
}