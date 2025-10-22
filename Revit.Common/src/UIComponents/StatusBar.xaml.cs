using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            DataContext = new StatusBarViewModel();
        }
    }
}