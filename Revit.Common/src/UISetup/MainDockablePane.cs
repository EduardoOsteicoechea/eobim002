
using Autodesk.Revit.UI;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class MainDockablePaneProvider : IDockablePaneProvider
	{
		public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.VisibleByDefault = false;

            data.InitialState = new DockablePaneState()
            {
                DockPosition = DockPosition.Tabbed,
				TabBehind = DockablePanes.BuiltInDockablePanes.PropertiesPalette
			};

            data.FrameworkElement = new MainDockablePanePage();
        }
	}
}