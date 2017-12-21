using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training_Async
{
	class Sample4
	{
		static void Main()
		{
			//CreateTextFileSync();
			//CreateTextFileAsync().GetAwaiter().GetResult();
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Start " + i);
				Process1(i);
			}
			Console.Read();
		}

		public static void CreateTextFileSync()
		{
			var folder = @"C:\Task\Text{0}.txt";

			try
			{
				for (int i = 0; i < 10; i++)
				{
					var fileName = string.Format(folder, i);
					System.IO.File.WriteAllText(fileName, "Igor");
					Thread.Sleep(6000);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static async Task CreateTextFileAsync()
		{
			var folder = @"C:\Task\Text{0}.txt";

			try
			{
				for (int i = 0; i < 10; i++)
				{
					Task.Run(() =>
					{
						var fileName = string.Format(folder, i);
						File.WriteAllText(fileName, "Igor");
						Thread.Sleep(6000);
					});
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static async Task Process1(int fromIndex)
		{
			var folder = @"C:\Task\Text{0}.txt";

			await Task.Run(() =>
			{
				for (int i = 0; i < 2; i++) { 
					var fileName = string.Format(folder, i);
					File.WriteAllText(fileName, "From indexer: " + fromIndex);
				}
			});
		}
	}
}
