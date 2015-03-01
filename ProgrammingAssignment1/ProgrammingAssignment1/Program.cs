using System;

namespace ProgrammingAssignment1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("This Application will calculate the max height of a shell and the distance it travels across the ground");
			Console.WriteLine ("What angle did you launch the shell?");
			float theta = float.Parse (Console.ReadLine ());
			Console.WriteLine("How fast did you launch the shell?");
			float speed = float.Parse (Console.ReadLine ());
		}
	}
}
