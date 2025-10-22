using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows;

[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
[Transaction(TransactionMode.Manual)]
public class TestExternalCommand : Autodesk.Revit.UI.IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            System.Windows.MessageBox.Show("Working");
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        catch (System.Exception ex)
        {
            System.Windows.MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
            return Autodesk.Revit.UI.Result.Failed;
        }
    }
}