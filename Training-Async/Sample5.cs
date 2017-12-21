using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training_Async
{
	class Sample5
	{
		static void Main()
		{
			CallerAsync();
			Console.Read();
		}

		static async Task CallerAsync()
		{
			//var filePath = @"C:\Task\Text{0}.txt";

			//for (int i = 0; i < 10; i++)
			//{
			//	Task.Run(() => { await FileWriteAsync(string.Format(filePath, i), "Igor", false); });
			//}
		}

		//static async Task CallMethodAsync()
		//{
		//	string UserDirectory = @"C:\Task\";

		//	//using (StreamReader SourceReader = File.OpenText(UserDirectory + "big.txt"))
		//	//{
		//		using (StreamWriter DestinationWriter = File.CreateText(UserDirectory + "CopiedFile.txt"))
		//		{
		//			await CopyFilesAsync(SourceReader, DestinationWriter);
		//		}
		//	//}
		//}

		//static async Task CopyFilesAsync(StreamReader Source, StreamWriter Destination)
		//{
		//	try
		//	{
		//		char[] buffer = new char[0x1000];
		//		int numRead;
		//		while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0)
		//		{
		//			await Destination.WriteAsync(buffer, 0, numRead);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		public static async Task FileWriteAsync(string filePath, string messaage, bool append = true)
		{
			using (FileStream stream = new FileStream(filePath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
			using (StreamWriter sw = new StreamWriter(stream))
			{
				Thread.Sleep(6000);
				sw.WriteLineAsync(messaage);
			}
		}
	}
}
