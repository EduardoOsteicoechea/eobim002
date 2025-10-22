

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Eduardoos.RevitApiActions;

namespace Eduardoos.RevitApi
{
	[Transaction(TransactionMode.Manual)]
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class LaunchMainDockablePaneAssistantView : Autodesk.Revit.UI.IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
                Greetings.Simple();
                
				EventAggregator.Instance.Publish(new ChangeViewMessage
				{
					TargetViewModelType = typeof(string),
					Message = AvailableViewsOptions.Assistant.ViewName,
					StatusBarMessage = AvailableViewsOptions.Assistant.ViewMessage,
					StatusBarProgressBarValue = 60
				});

				GlobalVariables.MainDockablePane = commandData.Application.GetDockablePane(GlobalVariables.DockablePaneId);

				GlobalVariables.MainDockablePane.Show();

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