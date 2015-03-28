using System;
using ConsoleCards;

namespace Lab12
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Deck deck = new Deck();
			Card[] hand = new Card[5];
			deck.Shuffle();
			//Take a card from the top of the deck and add it to element 0 in the array.
			hand[0] = deck.TakeTopCard();
			//Flip the card at element 0 of the array over.
				hand[0].FlipOver();
			//Print the card at element 0 of the array.
			hand[0].Print();
			//Take a card from the top of the deck and add it to element 1 in the array.
			hand[1] = deck.TakeTopCard();
			//Flip the card at element 1 of the array over.
			hand[1].FlipOver();
			//Print the cards at elements 0 and 1 of the array
			hand[0].Print();
			hand[1].Print();
		}
	}
}

