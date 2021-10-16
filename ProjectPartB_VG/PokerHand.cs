using System;
using System.Collections.Generic;

namespace ProjectPartB_B2
{
    class PokerHand : HandOfCards, IPokerHand
    {       

        #region Remove and Add related
        public override void Add(PlayingCard card)
        {
            cardsInHand.Add(card);
        }
        public override void Clear()
        {
            cardsInHand.Clear();
        }
        #endregion
        //Done

        #region Poker Rank related
        //https://www.poker.org/poker-hands-ranking-chart/

        //Hint: using backing fields
        private PokerRank _rank = PokerRank.Unknown;
        private PlayingCard _rankHigh = null;
        private PlayingCard _rankHighPair1 = null;
        private PlayingCard _rankHighPair2 = null;

        public PokerRank Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;
        public PlayingCard RankHiCardPair1 => _rankHighPair1;
        public PlayingCard RankHiCardPair2 => _rankHighPair2;

        //Worker Methods to examine a sorted hand
        private int NrSameValue(int firstValueIdx, out int lastValueIdx, out PlayingCard HighCard) 
        {
            lastValueIdx = 0;
            HighCard = null;
            return 0; 
        }
        private bool IsSameColor()
        {
            //Go true all the card's in hand
            for (int i = 0; i < 5; i++)
            {
                //If one card dose not have the same color as the rest..
                if(cardsInHand[i].Color != cardsInHand[4].Color)
                {//return fals.
                    return false;
                }
            }//return true.
            return true;
        }//Done
        private bool IsConsecutive()
        {
            //Go true the cards in the player's hand...
            for (int i = 0; i < 4; i++)
            {
                //If the current index value plus 1 is not the same as the card right to it...
                if ((int)cardsInHand[i].Value + 1 != (int)cardsInHand[i + 1].Value)
                {
                    //Return false.
                    return false;
                }
            }//If every card was Consecutive return true.
            return true;
        }//Done

        //Worker Properties to examine each rank
        private bool IsRoyalFlush
        {
            get
            {
                //If the card in hand is Consecutive and all cards has same color return true, else return false)
                bool colorAndValue = IsConsecutive() & IsSameColor();
                return colorAndValue;
            }
        }//Done
        private bool IsStraightFlush => false;
        private bool IsFourOfAKind => false;
        private bool IsFullHouse => false;
        private bool IsFlush => false;
        private bool IsStraight => false;
        private bool IsThreeOfAKind
        {
            get
            {
                //The counter that will count the amount of card's  with the same value exist. 
                int sameValue = 0;

                //The two forloops take turns comparing one card to all the other card's.
                for (int i = 0; i < 5; i++)
                {
                    //If the cards have the the same value..
                    for (int j = 0; j < 5; j++)
                    {
                        //If cards have the same value..
                        if(cardsInHand[i].Value == cardsInHand[j].Value)
                        {
                            //Add to the same value counter.
                            sameValue++;
                        }
                    }
                    //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                    sameValue--;

                    //If There was 2 cards with the same value as the index card..
                    if(sameValue == 2)
                    {//return true.
                        return true;
                    }

                    //Reset the sameValue counter for the next card.
                    sameValue = 0;
                }
                //If no of the 3 card's hade the same value return fals.
                return false;
            }
        }//Done
        private bool IsTwoPair
        {
            get
            {
                //The counter that will count the amount of pair's exist. 
                int pairCounter = 0;

                //The two forloops take turns comparing one card to all the other card's.
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //If the cards have the the same value..
                        if(cardsInHand[i].Value == cardsInHand[j].Value)
                        {
                            //Add 1 to Pair counter
                            pairCounter++;
                        }
                    }
                    //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                    pairCounter--;
                }
                //If there is 2 matching numbers twice in the deck.
                if(pairCounter == 2)
                {
                    //Return true
                    return true;
                }//Else.. Return fals.
                return false;
            }
        }//Done
        private bool IsPair
        {
            get
            {
                //The counter that will count the amount of pair's exist. 
                int pairCounter = 0;

                //The two forloops take turns comparing one card to all the other card's.
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        //If the cards have the the same value..
                        if (cardsInHand[i].Value == cardsInHand[j].Value)
                        {
                            //Add 1 to Pair counter
                            pairCounter++;
                        }
                    }
                    //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                    pairCounter--;
                }
                //If there is 2 matching numbers in the deck.
                if (pairCounter == 1)
                {
                    //Return true
                    return true;
                }//Else.. Return fals.
                return false;
            }
        }//Done

        public PokerRank DetermineRank()
        {
            ClearRank();
            return PokerRank.Unknown;
        }

        //Hint: Clear rank
        private void ClearRank()
        {
            _rankHigh = null;
            _rankHighPair1 = null;
            _rankHighPair2 = null;
            _rank = PokerRank.Unknown;
        }
        #endregion
    }
}
