using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B2
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => null;
        public int Count => 0;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            return "Should be deck of cards in short notation";
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        { }
        public void Sort()
        { }
        #endregion

        #region Creating a fresh Deck
        public virtual void Clear()
        { }
        public void CreateFreshDeck()
        { }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            return null;
        }
        #endregion
    }
}
