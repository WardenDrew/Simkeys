using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simkeys
{
	public class KeyMacroEvent : IMacroEvent
	{
		public Key Key { get; private set; }
		public KeyMacroType Type { get; private set; }

		public KeyMacroEvent(Key key, KeyMacroType type = KeyMacroType.DownAndUp)
		{
			Key = key;
			Type = type;
		}

		public async Task ExecuteAsync()
		{
			if (Type == KeyMacroType.Down || Type == KeyMacroType.DownAndUp)
			{
				await LowLevelSendInput.SendAsync(Key, LowLevelSendInput.KeyAction.Down);
			}

			if (Type == KeyMacroType.Up || Type == KeyMacroType.DownAndUp)
			{
				await LowLevelSendInput.SendAsync(Key, LowLevelSendInput.KeyAction.Up);
			}
		}

		public enum KeyMacroType
		{
			Down,
			Up,
			DownAndUp
		}
	}
}
