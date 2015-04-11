using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab14
{
	class Program
	{
		static void Main(string[] args)
		{
			// define a list of inputs
			List<int> inputs = new List<int>();

			int number = 0; // Initialize
			while (number != -1) // Test
			{
				Console.WriteLine("Enter a non-negative number (or -1 to end the list): ");
				number = int.Parse(Console.ReadLine());  // Modify
				if (number >= 0) inputs.Add(number);  // number is valid so add number to list
				else if (number == -1) {;} // this will exit from the loop
				else Console.WriteLine("Not a negative number");
			}

			int sum = 0;
			int max = 0; // all numbers must be non-negative
			Console.WriteLine("\nNumbers Entered");
			foreach (int item in inputs)
			{
				Console.WriteLine(item);
				sum += item;
				if (item > max) max = item;
			}
			Console.WriteLine("\nMaximum:  " + max);

			double average = ((double) sum) / ((double) inputs.Count);
			Console.WriteLine("Average:  " + average);

			Console.ReadLine();
		}
	}
}