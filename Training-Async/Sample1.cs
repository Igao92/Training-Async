using System;
using System.Threading.Tasks;

namespace Training_Async
{
    class Sample1
    {
        static void Main(string[] args)
        {
			//Process1().GetAwaiter().GetResult();
			Process1();
			Process2();
			Console.ReadKey();
		}

		public static async Task Process1()
		{
			await Task.Run(() =>
			{
				for (int i = 0; i < 300; i++)
					Console.WriteLine("Process 1");
			});
		}

		public static void Process2()
		{
			for (int i = 0; i < 80; i++)
				Console.WriteLine("Process 2");
		}
	}
}
