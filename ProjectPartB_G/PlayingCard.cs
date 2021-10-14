using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard:IComparable<PlayingCard>, IPlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		#region IComparable Implementation
		//Need only to compare value in the project
		public int CompareTo(PlayingCard card)
        {
            int result = 0;

            if(Value < card.Value)
            {
                result = -1;
            }
            if(Value > card.Value)
            {
                result = 1;
            }

            return result;
        }
        //My Constructer 
        public PlayingCard(PlayingCardValue aValue, PlayingCardColor aColor)
        {
            Value = aValue;
            Color = aColor;
        }
        #endregion
        //Done

        #region ToString() related
        string ShortDescription 
        {
            get
            {   //Switch case that will give the corresponding sign to the card
                string sRet = Color switch
                {
                    PlayingCardColor.Clubs => "\x2663",
                    PlayingCardColor.Diamonds => "\x2666",
                    PlayingCardColor.Hearts => "\x2665",
                    PlayingCardColor.Spades => "\x2660",
                    _ => throw new NotImplementedException(),
                };
                //Adding the value to the string
                sRet += ($" {Value}");
                //return the value
                return sRet;  
            }
        }

        public override string ToString() => ShortDescription;
        #endregion
        //Done
    }
}
