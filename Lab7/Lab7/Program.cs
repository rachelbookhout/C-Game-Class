using System;

namespace Lab7
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("What month were you born?");
			string birthmonth = Console.ReadLine ();
			Console.Write("What day were you born?");
			int birthdate = int.Parse (Console.ReadLine ());
			Console.Write ("You were born " + birthmonth + " " + birthdate );
		}
	}
}
