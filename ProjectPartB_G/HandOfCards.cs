using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        protected const int MaxCardsInHand = 5;
        protected List<PlayingCard> CardsInHand = new List<PlayingCard>(MaxCardsInHand);

        #region Count Properte and Clear Method
        /// <summary>
        /// Returns a number that represents how many elements the list has.
        /// </summary>
        /// <value>
        /// int number.
        /// </value>      
        public override int Count => CardsInHand.Count;

        public override void Clear()
        {
            CardsInHand.Clear();
        }//Done 
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
                if (CardsInHand[i] != null)
                {
                    //Add the card to the string thats going to be returnd
                    sRet += String.Format("{0,-10}", CardsInHand[i].ToString());
                }

            }//Return string
            return sRet;
        }//Done 
        #endregion
        //Done

        #region Pick and Add related
        public void Add(PlayingCard card)
        {
            CardsInHand.Add(card);
        }

        // todo Fix so the hand gets the card
        #endregion
        //Done

        #region Highest Card related
        public PlayingCard Highest
        {
            get
            {
               return null;
            }
         }
        public PlayingCard Lowest
        {
            get
            {
               return null;
            }
        }
        #endregion
        // ! Not Done
    }
}
