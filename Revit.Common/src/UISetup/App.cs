

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

                RibbonPanel ribbonPanel = application.CreateRibbonPanel(GlobalVariables.ApplicationName, "Application");

                new CreateTabPanelPushButton(
                    ribbonPanel,
					"Home",
					"Home",
					"LaunchMainDockablePaneHomeView",
					"Open the home view"
					);

				ribbonPanel.AddSeparator();

				new CreateTabPanelPushButton(
					ribbonPanel,
					"Assistant",
					"Assistant",
					"LaunchMainDockablePaneAssistantView",
					"Open the contact view"
					);

				ribbonPanel.AddSeparator();

				new CreateTabPanelPushButton(
					ribbonPanel,
					"Contact",
					"Contact",
					"LaunchMainDockablePaneContactView",
					"Open the contact view"
					);

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