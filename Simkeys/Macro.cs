using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simkeys
{
	public class Macro
	{
		public static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
		
		public List<IMacroEvent> Events { get; set; }
		public bool ClearModifiersDuring { get; set; }

		public Macro()
		{
			Events = new();
			ClearModifiersDuring = true;
		}

		public void Execute()
		{
			ExecuteAsync().Wait();
		}

		public async Task ExecuteAsync(CancellationToken cancellationToken = default)
		{
			if (Events.Count == 0)
			{
				return;
			}

			bool acquiredLock = await semaphore.WaitAsync(30000, cancellationToken);
			if (!acquiredLock)
			{
				return;
			}

			try
			{
				ClearModifiersMiddleware cmMiddleware = new();

				await cmMiddleware.ExecuteAsync(ClearModifiersDuring, async () =>
				{
					foreach (IMacroEvent macroEvent in Events)
					{
						await macroEvent.ExecuteAsync();
					}
				});
			}
			finally
			{
				semaphore.Release();
			}
		}
	}
}
