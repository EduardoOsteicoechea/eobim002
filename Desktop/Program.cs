using System.Windows;

namespace Eduardoos.RevitApi
{
	public class DesktopApp
	{
		[STAThread]
		public static void Main()
		{
			var window = new MainWindow();

			try
			{
				var app = new Application();

				app.Run(window);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
			}
		}
	}
}