using System;

namespace Lab8
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//Read in a string from the user in the following format:
			//<pyramid slot number>,<block letter>,<whether or not the block should be lit>
			//Example:
			//15,M,true 
			Console.WriteLine ("Tell us your slot number, block letter, and if it should be lit  (number,letter, true or false)");
			//extract the pyramid slot number from the string and store it in a variable.
			//Print the pyramid slot number.
			string answer = Console.ReadLine ();
			int commaLocation = answer.IndexOf(',');
			float slot = float.Parse (answer.Substring(0,commaLocation));
			Console.WriteLine ("Slot number is " + slot);
			//Extract the block letter from the string and store it in a variable.
			//Print the block letter.
			string second_string = answer.Substring (commaLocation + 1);
			int second_comma = second_string.IndexOf (',');

			string letter = second_string.Substring (0, second_comma); 
			Console.WriteLine ("Block letter is " + letter);
			//Extract whether or not the block should be lit from the string and store it in a variable.
			//Print whether or not the block should be lit.
			string lit = second_string.Substring (second_comma + 1);
			Console.WriteLine ("Is block is lit?: " + lit);
		}
	}
}
