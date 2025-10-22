using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows;

namespace Eduardoos.RevitApiActions
{
    public static class Greetings
    {
        public static void Simple()
        {
            try
            {
                System.Windows.MessageBox.Show("Working From Library");
                TaskDialog.Show("aa","aaaaa");
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}