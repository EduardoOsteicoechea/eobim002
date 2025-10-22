using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Eduardoos.RevitApi
{
	[Autodesk.DesignScript.Runtime.IsVisibleInDynamoLibrary(false)]
	public class ChangeViewMessage
	{
		public Type TargetViewModelType { get; set; }
		public string Message { get; set; }
		public string StatusBarMessage { get; set; }
		public double StatusBarProgressBarValue { get; set; }
	}
}