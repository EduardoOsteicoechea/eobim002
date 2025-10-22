

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Eduardoos.RevitApi
{
	[Transaction(TransactionMode.Manual)]
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class LaunchMainDockablePaneContactView : Autodesk.Revit.UI.IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			try
			{
				var eventAggregator = EventAggregator.Instance;

				eventAggregator.Publish(new ChangeViewMessage
				{
					TargetViewModelType = typeof(string),
					Message = "Contact",
					StatusBarMessage = "Let's Talk"
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