using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Eduardoos.RevitApi
{
	public static class AvailableViewsOptions
	{
		public static KeyValuePair<string, string> Home { get; } = new KeyValuePair<string, string> ("Home", "AI Tools for efficient BIM Management");
		public static KeyValuePair<string, string> Assitant { get; } = new KeyValuePair<string, string> ("Assitant", "Chat with eduardoos AI Assistant");
		public static KeyValuePair<string, string> Contact { get; } = new KeyValuePair<string, string> ("Contact", "Let's Talk");
	}
}