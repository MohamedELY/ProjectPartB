using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        //Creating a array of Playingcards 
        protected const int MaxCardsInHand = 5;
        protected List<PlayingCard> cardsInHand = new List<PlayingCard>(MaxCardsInHand);

        #region Count, Clear and Sort 
        /// <summary>
        /// Returns a number that represents how many elements the list has.
        /// </summary>
        /// <value>
        /// int number.
        /// </value>      
        public override int Count => cardsInHand.Count;
        public override void Sort()
        {
            cardsInHand = cardsInHand.OrderBy(c => c.Color).ToList();
            cardsInHand = cardsInHand.OrderBy(v => v.Value).ToList();

        }
        public override void Clear()
        {
            cardsInHand.Clear();
        }
        #endregion
        //Done

        #region String related
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            //The returning string.
            string sRet = "";
            //Go thrue the deck...
            for (int i = 0; i < Count; i++)
            {
                //If the card is not null...
                if (cardsInHand[i] != null)
                {
                    //Add the card to the string thats going to be returnd
                    sRet += String.Format("{0,-10}", cardsInHand[i].ToString());
                }

            }//Return string
            return sRet;
        }
        #endregion
        //Done

        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            cardsInHand.Add(card);
        }
        #endregion
        //Done

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
                cardsInHand.Sort();
                return cardsInHand[cardsInHand.Count - 1];
            }
        }
        public PlayingCard Lowest
        {
            get
            {
                cardsInHand.Sort();
                return cardsInHand[0];
            }
        }
        #endregion
        //Done
    }
}
