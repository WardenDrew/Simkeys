using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simkeys
{
	public class ClearModifiersMiddleware
	{
		public bool LEFT_CONTROL { get; private set; }
		public bool RIGHT_CONTROL { get; private set; }
		public bool LEFT_ALT { get; private set; }
		public bool RIGHT_ALT { get; private set; }
		public bool LEFT_SHIFT { get; private set; }
		public bool RIGHT_SHIFT { get; private set; }

		public ClearModifiersMiddleware()
		{
			LEFT_CONTROL = Keyboard.IsKeyDown(Key.LeftCtrl);
			RIGHT_CONTROL = Keyboard.IsKeyDown(Key.RightCtrl);
			LEFT_ALT = Keyboard.IsKeyDown(Key.LeftAlt);
			RIGHT_ALT = Keyboard.IsKeyDown(Key.RightAlt);
			LEFT_SHIFT = Keyboard.IsKeyDown(Key.LeftShift);
			RIGHT_SHIFT = Keyboard.IsKeyDown(Key.RightShift);
		}

		public async Task ExecuteAsync(bool clearModifiers, Action action)
		{
			if (clearModifiers)
			{
				if (LEFT_CONTROL)
				{
					await LowLevelSendInput.SendAsync(Key.LeftCtrl, LowLevelSendInput.KeyAction.Up);
				}

				if (RIGHT_CONTROL)
				{
					await LowLevelSendInput.SendAsync(Key.RightCtrl, LowLevelSendInput.KeyAction.Up);
				}

				if (LEFT_ALT)
				{
					await LowLevelSendInput.SendAsync(Key.LeftAlt, LowLevelSendInput.KeyAction.Up);
				}

				if (RIGHT_ALT)
				{
					await LowLevelSendInput.SendAsync(Key.RightAlt, LowLevelSendInput.KeyAction.Up);
				}

				if (LEFT_SHIFT)
				{
					await LowLevelSendInput.SendAsync(Key.LeftShift, LowLevelSendInput.KeyAction.Up);
				}

				if (RIGHT_SHIFT)
				{
					await LowLevelSendInput.SendAsync(Key.RightShift, LowLevelSendInput.KeyAction.Up);
				}
			}

			action.Invoke();

			if (clearModifiers)
			{
				if (LEFT_CONTROL)
				{
					await LowLevelSendInput.SendAsync(Key.LeftCtrl, LowLevelSendInput.KeyAction.Down);
				}

				if (RIGHT_CONTROL)
				{
					await LowLevelSendInput.SendAsync(Key.RightCtrl, LowLevelSendInput.KeyAction.Down);
				}

				if (LEFT_ALT)
				{
					await LowLevelSendInput.SendAsync(Key.LeftAlt, LowLevelSendInput.KeyAction.Down);
				}

				if (RIGHT_ALT)
				{
					await LowLevelSendInput.SendAsync(Key.RightAlt, LowLevelSendInput.KeyAction.Down);
				}

				if (LEFT_SHIFT)
				{
					await LowLevelSendInput.SendAsync(Key.LeftShift, LowLevelSendInput.KeyAction.Down);
				}

				if (RIGHT_SHIFT)
				{
					await LowLevelSendInput.SendAsync(Key.RightShift, LowLevelSendInput.KeyAction.Down);
				}
			}
		}
	}
}
