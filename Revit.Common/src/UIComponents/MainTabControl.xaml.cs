using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public partial class MainTabControl : UserControl
	{
        public MainTabControl()
        {
            InitializeComponent();
            DataContext = new MainTabControlViewModel();
        }
    }
}