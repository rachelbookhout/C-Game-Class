using System;
using System.Collections.Generic;
using ConsoleCards;

namespace Lab13
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Deck deck = new Deck();
			List <Card> hand = new List <Card> ();
			deck.Shuffle ();

				for (int i = 1; i <= 5; i++)
				{
				hand.Add (deck.TakeTopCard ());
				}
			for (int i = 4; i > -1; i--)
			{
				hand[i].FlipOver();
			}

			foreach (Card card in hand)
			{
				card.Print();
			}
		
		}
	}
}
