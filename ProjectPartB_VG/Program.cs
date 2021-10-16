using System;

namespace ProjectPartB_B2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a new instence of DeckOfCards.
            DeckOfCards myDeck = new DeckOfCards();

            #region Printing, Sorting and Shuffleing the deck
            //Calling upon a method that will initiate myDeck with a fresh deck of cards.
            myDeck.CreateFreshDeck();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Sort the deck.
            myDeck.Sort();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Shuffle the deck.
            myDeck.Shuffle();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);
            #endregion

            PokerHand player = new PokerHand();
            while (myDeck.Count > 5)
            {
                //Your code to Give 5 cards to the player and determine the rank
                //Continue for as long as the deck has at least 5 cards

                //Deal the player 5 cards from the deck.
                Deal(myDeck, player);
                
                //Sorting the card's in the player's hand.(Importent! To make the method's work right!) 
                player.Sort();

                //Print the card's the player is holding.
                Console.WriteLine($"Player's hand: {player}");

                //Todo Print the rank value, and highest card.
                
                //Print out how many card's are left in the deck.
                Console.WriteLine($"Deck has now {myDeck.Count} card's\n");

                //Clear's the hand from old card's.
                player.Clear();
            }
        }

        private static void Deal(DeckOfCards myDeck, HandOfCards player)
        {
            //As many times as amount of card's to give
            for (int i = 0; i < 5; i++)
            {
                //Give one card from the top of the deck to eatch player.
                player.Add(myDeck.RemoveTopCard());
            }
        }
        //Done
    }
}
