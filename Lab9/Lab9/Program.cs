using System;

namespace Lab9
{
	class MainClass
	{

		public static void Main (string[] args)
		{

			Console.WriteLine ("**************");
			Console.WriteLine ("Menu:");
			Console.WriteLine ("1 – New Game");
			Console.WriteLine ("2 – Load Game");
			Console.WriteLine ("3 – Options");
			Console.WriteLine ("4 – Quit");
			Console.WriteLine ("**************");
			Console.WriteLine ();
			Console.WriteLine ();
			Console.WriteLine ("Where do you want to do?");
			int choice = int.Parse(Console.ReadLine());
			switch (choice) {
			case 1:
				Console.WriteLine ("Welcome to your new game!");
				break;
			case 2:
				Console.WriteLine ("Loading Game....");
				break;
			case 3:
				Console.WriteLine ("1 - Volume \n 2 - Brightness \n 3 - Display");
				break;
			case 4:
				Console.WriteLine ("Goodbye!");
				break;
			default:
				Console.WriteLine ("Pick a value between 1 - 4");
				break;
			};
		}
	}
}
