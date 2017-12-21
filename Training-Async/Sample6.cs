using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Training_Async
{
    class Sample6
    {
		static void Main()
		{
			Directory.GetFiles(@"C:\Task\", "*.txt").ToList().ForEach(x => File.Delete(x));
			Caller();
		}

		static async void Caller()
		{
			var file = @"C:\Task\Text{0}.txt";
			for (int i = 0; i < 10; i++)
			{
				//Task<int> task = CreateFile(string.Format(file, i));
				//Task<int> task = WriteX(string.Format(file, i));
				//WriteCharacters(string.Format(file, i));
			}
		}

		

		static async void WriteCharacters(string path)
		{
			using (StreamWriter writer = File.CreateText(path))
			{
				await writer.WriteAsync("Example text as string");
				if (true)
				{

				}
			}
		}

		static async Task<int> WriteX(string file)
		{
			int length = 0;

			Console.WriteLine(" File reading is stating" + file);
			using (StreamWriter reader = new StreamWriter(file))
			{
				await reader.WriteAsync("asdasdasd");

				if (true)
				{

				}
				//Random r = new Random();
				//int rInt = r.Next(0, 20000);
				//Thread.Sleep(rInt);

			}
			Console.WriteLine(" File reading is completed");
		
			return length;
		}

		//static async Task<int> CreateFile(string local)
		//{
		//	int length = 0;

		//	//using (FileStream stream = new FileStream(local, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))

		//	using (StreamWriter writer = new StreamWriter(local))
		//	{
		//		await writer.WriteLineAsync("I G O R");
		//		Thread.Sleep(3000);
		//	}

		//	return length;
		//}
	}
}
