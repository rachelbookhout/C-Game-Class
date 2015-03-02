using System;

namespace ProgrammingAssignment1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("This Application will calculate the max height of a shell and the distance it travels across the ground");
			Console.WriteLine ("What angle did you launch the shell?");
			double theta =  Math.PI/ 180 * double.Parse (Console.ReadLine ());
			Console.WriteLine("How fast did you launch the shell?");
			double speed = double.Parse (Console.ReadLine ());
			double vox = speed * Math.Cos (theta); 
			double voy = speed * Math.Sin (theta);
			double g = 9.8;
			double t = voy / g;
			double height = voy * voy / (2 * g);
			double dx = vox * 2 * t;    
			Console.WriteLine("Height of Shell at apex is:" + Math.Round(height,3) +". Distance Shell Traveled is:" + Math.Round(dx,3));

		}
	}
}
