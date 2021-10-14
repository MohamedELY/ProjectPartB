using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B2
{
    interface IDeckOfCards
    {
         /// <summary>
         /// The card at a particular position in the deck.
         /// </summary>
         /// <param name="idx">0 based position in the deck</param>
         /// <returns>The card at [idx] position</returns>
        public PlayingCard this[int idx] { get; }
        
        /// <summary>
        /// Number of Cards in the deck
        /// </summary>
        public int Count { get; }

        //Should be overriden and implemented to print out the complete deck in short card notation
        public string ToString();

        /// <summary>
        /// Shuffles the deck of cards
        /// </summary>
        public void Shuffle();
        
        /// <summary>
        /// Sort the deck of cards using List<T> Sort()>
        /// </summary>
        public void Sort();

        /// <summary>
        /// Empties the deck of cards so no cards in the deck
        /// </summary>
        public void Clear();

        /// <summary>
        /// Initialize a fresh deck consisting of 52 cards. 
        /// Added in order Clubs (Two..Ace), Diamonds (Two..Ace), Hearts (Two..Ace), Spades (Two..Ace) 
        /// </summary>
        public void CreateFreshDeck();

        /// <summary>
        /// Removes the top card of the deck and reduces the number of cards in the deck with one.
        /// </summary>
        /// <returns>The removed card</returns>
        public PlayingCard RemoveTopCard();
    }
}
