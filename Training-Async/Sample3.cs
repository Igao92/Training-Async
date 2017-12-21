using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

//Habilita os métodos da diretiva 'System.Console'_
//para que não seja necessário escrever o nome da classe "Console" antes do Método "WriteLine", por exemplo:
//-> WriteLine('abc') ao invés de Console.WriteLine('abc');
//using static System.Console; 

//Adicionando um 'alias a diretiva 'System.Console';
using IgorConsole = System.Console; 

namespace Training_Async
{
	class Sample3
    {
		static void Main()
		{
			Task task = new Task(CallMethod);
			task.Start();
			task.Wait();
			IgorConsole.ReadLine();
		}

		static async void CallMethod()
		{
			string filePath =  @"C:\Task\big\big.txt";
			string filePath1 = @"C:\Task\big\big1.txt";
			string filePath2 = @"C:\Task\big\big2.txt";

			Task<int> task = ReadFile(filePath);
			Task<int> task1 = ReadFile(filePath1);
			Task<int> task2 = ReadFile(filePath2);

			IgorConsole.WriteLine(" Other Work 1");
			IgorConsole.WriteLine(" Other Work 2");
			IgorConsole.WriteLine(" Other Work 3");

			int length = await task;

			IgorConsole.WriteLine(" Total length: " + length);

			IgorConsole.WriteLine(" After work 1");
			IgorConsole.WriteLine(" After work 2");
		}

		static async Task<int> ReadFile(string file)
		{
			int length = 0;

			IgorConsole.WriteLine(" File reading is stating" + file);
			var sw = Stopwatch.StartNew();
			using (StreamReader reader = new StreamReader(file))
			{
				string s = await reader.ReadToEndAsync();

				length = s.Length;

				Random r = new Random();
				int rInt = r.Next(0, 20000);
				Thread.Sleep(rInt);

				//File.CreateText(file+"i");
			}
			IgorConsole.WriteLine("File reading is completed");
			sw.Stop();
			IgorConsole.WriteLine($"Elapsed time:{sw.Elapsed} - {file}");
			return length;
		}
	}
}
