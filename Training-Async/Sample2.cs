using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Training_Async
{
	/// <summary>
	/// Notas:
	/// 
	/// 1-> A instrução "await" garante que o resultado da "Task<>" seja retornado sem bloquear_
	/// a thread principal. Dessa maneira a thread principal é liberada para processar novas requisições;
	/// 
	/// 2-> "await" exige que o método possua o modificador "async";
	/// 
	/// </summary>
	class Sample2
    {
		static void Main(string[] args)
		{
			CallMethod();
			Console.ReadKey();
		}

		public static async void CallMethod()
		{
			Task<int> task = Method1();

			Method2();

			//await-> Garante que a task terá seu resultado processado_
			//antes de chamar o "Method3(...)"
			int count = await task; 

			Method3(count);
		}

		public static async Task<int> Method1()
		{
			int count = 0;

			await Task.Run(() =>
			{
				for (int i = 0; i < 100; i++)
				{
					Console.WriteLine("Method 1");
					count += 1;
				}
			});

			return count;
		}

		public static void Method2()
		{
			for (int i = 0; i < 25; i++)
				Console.WriteLine(" Method 2");
		}

		public static void Method3(int count)
		{
			Console.WriteLine("Total count is " + count);
		}
	}
}
