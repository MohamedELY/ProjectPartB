using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B2
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public virtual void Add(PlayingCard card)
        { }
        #endregion

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
    }
}
