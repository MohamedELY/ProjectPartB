using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B2
{
    /// <summary>
    /// Enum type to represent a poker rank considering Color (suit) and value
    /// https://www.poker.org/poker-hands-ranking-chart/
    /// </summary>
    public enum PokerRank { Unknown, HighCard, Pair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush }
    
    interface IPokerHand
    {
        //Override Clear in DeckOfCards to also clear rank
        public void Clear();

        //Override Add in HandOfCards to also clear rank
        public void Add(PlayingCard card); 

        /// <summary>
        /// The rank of the pokerhand determined using DetermineRank().
        /// </summary>
        public PokerRank Rank { get; }

        /// <summary>
        /// The highest card in a rank when rank. 
        /// Null when rank is PokerRank.Undefined
        /// </summary>
        public PlayingCard RankHiCard { get; }

        /// <summary>
        /// The highest card in the first pair when rank is PokerRank.TwoPair, otherwise null
        /// </summary>
        public PlayingCard RankHiCardPair1 { get; }

        /// <summary>
        /// The highest card in the second pair when rank is PokerRank.TwoPair, otherwise null
        /// </summary>
        public PlayingCard RankHiCardPair2 { get; }

        /// <summary>
        /// Got through a 5 card hand and determine the Rank according to
        /// https://www.poker.org/poker-hands-ranking-chart/
        /// After determination properties Rank and RankHiCard can be read.
        /// In case Rank is PokerRank.TwoPair, RankHiCardPair1 and RankHiCardPair2 
        /// are set and RankHiCard is set to higest of RankHiCardPair1 and RankHiCardPair2
        /// </summary>
        /// <returns>The pokerhand rank. PokerRank.Undefined in case Hand is not 5 cards</returns>
        public PokerRank DetermineRank();
    }
}
