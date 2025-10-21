using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
    public partial class ActivityBar : UserControl
    {
        public ActivityBar()
        {
            InitializeComponent();
            DataContext = new ActivityBarViewModel();
        }
    }
}