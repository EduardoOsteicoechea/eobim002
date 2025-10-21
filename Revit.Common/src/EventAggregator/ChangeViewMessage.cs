using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Eduardoos.RevitApi
{
	public class ChangeViewMessage
	{
		public Type TargetViewModelType { get; set; }
		public string Message { get; set; }
	}
}