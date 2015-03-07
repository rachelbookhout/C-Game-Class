using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
	/// <summary>
	/// Demonstrates classes and objects
	/// </summary>
	class Program
	{
		/// <summary>
		/// Demonstrates use of Deck and Card objects
		/// </summary>
		/// <param name="args">command-line args</param>
		static void Main(string[] args)
		{
			Deck deck = new Deck();

		

			deck.Print();
			deck.Shuffle();
			deck.Print ();
		
			Console.WriteLine();
			Console.WriteLine();

			deck.TakeTopCard();
			Card card = deck.TakeTopCard();
			Console.WriteLine(card.Rank + " of " + card.Suit);
			Card card2 = deck.TakeTopCard ();
			Console.WriteLine (card2.Rank + " of " + card2.Suit); 
		

		}
	}
}
