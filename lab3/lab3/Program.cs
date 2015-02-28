using System;

namespace lab3
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			float org_temp_in_f = 32;
			float temp_in_c = (float)(org_temp_in_f - 32) / 9 * 5;
			float fin_temp_in_f = temp_in_c * 9 / 5 + 32;
				Console.WriteLine ( org_temp_in_f + " degrees Fahrenheit is" + temp_in_c + " degrees Celsius");
			Console.WriteLine( temp_in_c + " degrees Celsius is" + fin_temp_in_f +  " degrees Fahrenheit");
		}
	}
}



