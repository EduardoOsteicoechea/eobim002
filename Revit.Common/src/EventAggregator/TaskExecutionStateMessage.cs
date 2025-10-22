using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Eduardoos.RevitApi
{
	public class TaskExecutionStateMessage
	{
		public Type TargetViewModelType { get; set; }
		public string TaskName { get; set; }
		public string StatusMessage { get; set; }
		public double Progress { get; set; }
	}
}