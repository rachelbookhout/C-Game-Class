using System;

namespace Lab2
{
	class MainClass
	{
		static void Main (string[] args)
		{
			int score= 88;
			const int MAX_SCORE = 100;
			float percent = score%MAX_SCORE;
			
			Console.WriteLine( percent + "%"); 

		}
	}
}

