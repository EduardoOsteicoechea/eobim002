using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Windows.Controls;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public static class AvailableViewsOptions
	{
		public static AvailableViewsOption Home { get; } = new AvailableViewsOption("   Home  ", "AI Tools for efficient BIM Management", new HomePage());
		public static AvailableViewsOption Assistant { get; } = new AvailableViewsOption("Assitant", "Chat with eduardoos AI Assistant", new AIAssistantPage());
		public static AvailableViewsOption Contact { get; } = new AvailableViewsOption(" Contact ", "Let's Talk", new ContactPage());
	}

	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class AvailableViewsOption 
	{
		public string ViewName { get; }
		public string ViewMessage { get; }
		public UserControl View { get; }
		public AvailableViewsOption(string a, string b, UserControl c) 
		{
			ViewName = a; ViewMessage = b; View = c;
		}
	}
}