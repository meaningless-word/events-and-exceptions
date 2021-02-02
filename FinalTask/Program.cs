using System;
using System.Collections;
using System.IO;

namespace FinalTask
{
	/// Задание 1
	/// 1. Создайте свой тип исключения.
	/// 2. Сделайте массив из пяти различных видов исключений, включая собственный тип исключения.
	/// Реализуйте конструкцию TryCatchFinally, в которой будет итерация на каждый тип исключения (блок finally по желанию).
	/// 3. В блоке catch выведите в консольном сообщении текст исключения.
	/// 
	/// Задание 2
	/// Создайте консольное приложение, в котором будет происходить сортировка списка фамилий из пяти человек.
	/// Сортировка должна происходить при помощи события. 
	/// Сортировка происходит при введении пользователем либо числа 1 (сортировка А-Я), либо числа 2 (сортировка Я-А).
	/// Дополнительно реализуйте проверку введённых данных от пользователя через конструкцию TryCatchFinally с использованием собственного типа исключения.

	class Program
	{
		static void Main(string[] args)
		{
			//запрос признака сортировки
			OneTwoReader order = new OneTwoReader("сортировка А-Я", "сортировка Я-А");
			try
			{
				order.Read();
			}
			catch (NoOneTwoException ex)
			{
				Console.WriteLine("ошибка \"{0}\" вызвана вводом значения {1}", ex.Message, ex.Value);
			}

			/// еще в начале XXI века составили сборник 500 самых частых фамилий в России, и лидерами тогда были:
			Surname families = new Surname("Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов");
			families.DisplayEvent += ShowArray; //делегату присвоим метод
			families.Ordering(order.OneTwo);

			Console.WriteLine();
			Console.WriteLine("А теперь исключения...");

			Exception[] excs = { new NoOneTwoException("Вымышленное исключение", "0"), new DivideByZeroException(), new FileNotFoundException(), new IndexOutOfRangeException(), new TimeoutException() };
			foreach (Exception e in excs)
			{
				try
				{
					throw e;
				}
				catch (NoOneTwoException pex)
				{
					Console.WriteLine("Произошло собственное исключение: \"{0}\"", pex.Message);
					if (pex.Data.Count > 0)
					{
						foreach (DictionaryEntry de in pex.Data)
						{
							Console.WriteLine("{0}: {1}", de.Key, de.Value);
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Прооизошло одно из системных исключений: \"{0}\"", ex.Message);
				}
				finally
				{
					Console.WriteLine("Спокойно, исключение перехвачено");
				}
			}
		}

		static void ShowArray(string[] list)
		{
			for (int i = 0; i < list.Length; i++)
			{
				Console.WriteLine(list[i]);
			}
		}
	}
}
