using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class StatusBar : UserControl
    {
        public StatusBar()
        {
            InitializeComponent();
            DataContext = new StatusBarViewModel();
        }
    }
}