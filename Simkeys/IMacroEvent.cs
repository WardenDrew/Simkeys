using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simkeys
{
	public interface IMacroEvent
	{
		public Task ExecuteAsync();
	}
}
