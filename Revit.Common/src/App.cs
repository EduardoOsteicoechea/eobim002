

using Autodesk.Revit.UI;
using System.Reflection;

namespace Eduardoos.RevitApi
{
    ///////////////////////////
    // This decorator comes from the DynamoVisualProgramming.DynamoServices Nuget Package
    ///////////////////////////
    [Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
    public class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                GlobalVariables.SetAssemblyLocation();

                application.RegisterDockablePane(
                    GlobalVariables.DockablePaneId,
                    GlobalVariables.ApplicationName,
                    new MainDockablePaneProvider()
                );

                application.CreateRibbonTab(GlobalVariables.ApplicationName);

                RibbonPanel ribbonPanel = application.CreateRibbonPanel(GlobalVariables.ApplicationName, GlobalVariables.MainCommandUIName);

                PushButtonData buttonData = new PushButtonData(
                    GlobalVariables.ApplicationName,
                    GlobalVariables.MainCommandUIName,
					Assembly.GetExecutingAssembly().Location,
                    $"{GlobalVariables.MainNamespace}.{GlobalVariables.MainCommandInternalName}");

                PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

                pushButton.ToolTip = GlobalVariables.MainCommandToolTipText;

                return Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
                return Result.Failed;
            }
        }

        public Autodesk.Revit.UI.Result OnShutdown(Autodesk.Revit.UI.UIControlledApplication application)
        {
            try
            {
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}");
                return Autodesk.Revit.UI.Result.Failed;
            }
        }
    }
}