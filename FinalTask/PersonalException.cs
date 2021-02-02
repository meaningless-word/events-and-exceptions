using System;

namespace FinalTask
{
	class NoOneTwoException : ArgumentOutOfRangeException
	{
		public string Value { get; }
		public NoOneTwoException(string message, string value) :base("", message)
		{
			Value = value;
			this.Data.Add("Создано", DateTime.Now);
		}
	}
}
