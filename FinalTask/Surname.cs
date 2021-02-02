using System;
using System.Linq;

namespace FinalTask
{
	class Surname
	{
		public delegate void DisplayDelegate(string[] L);
		public event DisplayDelegate DisplayEvent;

		private string[] SurnameList;

		public Surname(params string[] args)
		{
			SurnameList = new string[args.Length];
			Array.Copy(args, SurnameList, args.Length);
		}

		public void Ordering(int order)
		{
			switch (order)
			{
				case 1:
					Array.Sort(SurnameList);
					DisplayMe();
					break;
				case 2:
					Array.Sort(SurnameList);
					Array.Reverse(SurnameList);
					DisplayMe();
					break;
			}
		}

		protected virtual void DisplayMe()
		{
			DisplayEvent?.Invoke(SurnameList);
		}
	}
}
