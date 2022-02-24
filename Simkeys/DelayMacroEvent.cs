using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simkeys
{
	public class DelayMacroEvent : IMacroEvent
	{
		public int Delay { get; private set; }

		public DelayMacroEvent(int delay)
		{
			Delay = delay;
		}

		public Task ExecuteAsync()
		{
			return Task.Delay(Delay);
		}
	}
}
