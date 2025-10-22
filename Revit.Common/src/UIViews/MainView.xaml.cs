using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public partial class MainView : UserControl
	{
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewViewModel();
        }
    }
}