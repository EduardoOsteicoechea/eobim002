

using Autodesk.Revit.UI;
using System.Reflection;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class CreateTabPanelPushButton
	{
		public CreateTabPanelPushButton
		(
			RibbonPanel ribbonPanel,
			string buttonName,
			string buttonText,
			string commandInternalName,
			string tooltip
		)
		{
			var buttonData = new PushButtonData(
				buttonName,
				buttonText,
				Assembly.GetExecutingAssembly().Location,
				$"{GlobalVariables.MainNamespace}.{commandInternalName}"
				);

			var pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

			if (pushButton != null)
			{
				pushButton.ToolTip = tooltip;
			}
		}
	}
}