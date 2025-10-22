using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public static class GlobalVariables
	{
		private static string _assemblyFullPath { get; set; }
		private static string _assemblyDirectoryPath { get; set; }
		public static string AssemblyDirectoryPath
		{
			get
			{
				return _assemblyDirectoryPath;
			}
		}

		public static void SetAssemblyLocation()
		{
			_assemblyFullPath = Assembly.GetExecutingAssembly().Location;
			_assemblyDirectoryPath = Path.GetDirectoryName(_assemblyFullPath);
		}

		public static System.Guid DockablePaneGUID { get; } = Guid.Parse("A2AE9622-9A46-4B81-933C-ACB2D60082DA");
		public static DockablePaneId DockablePaneId { get; } = new DockablePaneId(DockablePaneGUID);
		public static DockablePane MainDockablePane { get; set; }


		public static string ApplicationName { get; } = "eduardoos";
		public static string MainNamespace { get; } = MethodBase.GetCurrentMethod().DeclaringType.Namespace;

	}
}