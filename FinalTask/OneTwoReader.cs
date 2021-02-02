using System;

namespace FinalTask
{
	public class OneTwoReader
	{
		public int OneTwo;
		private string whatForOne;
		private string whatForTwo;

		public OneTwoReader(string oneIs, string twoIs)
		{
			whatForOne = oneIs;
			whatForTwo = twoIs;
		}

		public void Read()
		{
			Console.WriteLine();
			Console.WriteLine("Введите 1 ({0}), либо 2 ({1})", whatForOne, whatForTwo);
			string askingFor = Console.ReadLine();
			try
			{
				OneTwo = Convert.ToInt32(askingFor);
				if (OneTwo != 1 && OneTwo != 2) throw new NoOneTwoException("Выход за рамки запрашиваемого диапазона", askingFor);
			}
			catch (FormatException)
			{
				throw new NoOneTwoException("Невозможно преобразовать в целое число", askingFor);
			}
		}

	}
}
