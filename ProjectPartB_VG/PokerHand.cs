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


        public PokerRank Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;

        //Worker Methods to examine a sorted hand
        private int NrSameValue(out int pairCounter, out PlayingCard HighCard) 
        {
            HighCard = null;

            //The counter that will count the amount of pair's exist. 
            pairCounter = 0;

            //The two forloops take turns comparing one card to all the other card's.
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //If the cards have the the same value..
                    if (cardsInHand[i].Value == cardsInHand[j].Value)
                    {

                        HighCard = cardsInHand[i];
                        //Add 1 to Pair counter
                        pairCounter++;
                    }
                }
                //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                pairCounter--;
            }

            return pairCounter; 
        }//Done
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
                //If the card in hand is Consecutive, all cards has same color, and the highest card is a Ace return true, else return false.
                if (IsConsecutive() & IsSameColor() & cardsInHand[4].Value == PlayingCardValue.Ace)
                {
                    //Saves the card as the highest card.
                    _rank = PokerRank.RoyalFlush; 
                    _rankHigh = cardsInHand[4];
                    return true;
                }
                return false;
            }
        }//Done
        private bool IsStraightFlush
        {
            get
            {
                //If the card in hand is Consecutive and all cards has the same color return true, else return false.
                if(IsConsecutive() & IsSameColor())
                {
                    //Saves the card as the highest card.
                    _rankHigh = cardsInHand[4];
                    _rank = PokerRank.StraightFlush;
                    return true;
                }
                return false;
            }
        }//Done
        private bool IsFourOfAKind
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
                        if (cardsInHand[i].Value == cardsInHand[j].Value)
                        {
                            //Saves the card as highest card.
                            _rankHigh = cardsInHand[i];
                            //Add to the same value counter.
                            sameValue++;
                        }
                    }
                    //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                    sameValue--;

                    //If There was 3 cards with the same value as the index card..
                    if (sameValue == 3)
                    {//return true.
                        _rank = PokerRank.FourOfAKind;
                        return true;
                    }

                    //Reset the sameValue counter for the next card.
                    sameValue = 0;
                }
                //If no of the 3 card's hade the same value return fals.
                return false;
            }
        }//Done
        private bool IsFullHouse
        {
            get
            {
                //a int that will hold the amount of pairs the hand has
                int amountOfPair;
                PlayingCard temp1 = null;
                PlayingCard temp2 = null;
                //I will check with this method there is only one pair.
                NrSameValue(out amountOfPair, out temp1);


                //The counter that will count the amount of card's  with the same value exist. 
                int sameValue = 0;

                if (amountOfPair == 1)
                {
                    //The two forloops take turns comparing one card to all the other card's.
                    for (int i = 0; i < 5; i++)
                    {
                        //If the cards have the the same value..
                        for (int j = 0; j < 5; j++)
                        {
                            //If cards have the same value..
                            if (cardsInHand[i].Value == cardsInHand[j].Value)
                            {
                                //Add to the same value counter.
                                sameValue++;

                                //Save the card as highest card.
                                temp2 = cardsInHand[i];
                            }
                        }
                        //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                        sameValue--;

                        //If There was 2 cards with the same value as the index card..
                        if (sameValue == 2)
                        {
                            _rank = PokerRank.FullHouse;
                            //If temp1 value is lower then temp2 value..   
                            if (temp1.Value < temp2.Value)
                            {//Assigne high card as temp2, return true.
                                _rankHigh = temp2;
                                return true;
                            }//Assigne high card as temp1, return true.
                            _rankHigh = temp1;
                            return true;
                        }

                        //Reset the sameValue counter for the next card.
                        sameValue = 0;
                    }
                    //If no of the 3 card's hade the same value return fals.
                    return false;

                }
                return false;
            }
        }//Done
        private bool IsFlush
        {
            get
            {
                //If all cards have the same color...
                if (IsSameColor())
                {   //Saves the card as the higest card.
                    _rankHigh = cardsInHand[4];

                    _rank = PokerRank.Flush;

                    //return true.
                    return true;
                }
                //return fals.
                return false;
            }
        }//Done
        private bool IsStraight
        {
            get
            {
                //If the cards in hand are Consecutive...
                if (IsConsecutive())
                {
                    //Save the card as highest card.
                    _rankHigh = cardsInHand[4];

                    _rank = PokerRank.Straight;

                    //Return true.
                    return true;
                }
                //else return false
                return false;

            }
        }//Done
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
                            //Save the card as highest card.
                            _rankHigh = cardsInHand[i];
                            //Add to the same value counter.
                            sameValue++;
                        }
                    }
                    //Becuse the card will compare with itself one time we decreased the value by one after every loop.
                    sameValue--;

                    //If There was 2 cards with the same value as the index card..
                    if(sameValue == 2)
                    {
                        _rank = PokerRank.ThreeOfAKind;
                        //return true.
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
                int pairCounter = 0;

                //Calling uppon the method that will check how many pairs exist in the card's.
                NrSameValue(out pairCounter, out _rankHigh);

                //If there is 2 matching numbers twice in the deck.
                if (pairCounter == 2)
                {
                    _rank = PokerRank.TwoPair;

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
                int pairCounter = 0;

                //Calling uppon the method that will check how many pairs exist in the card's.
                NrSameValue(out pairCounter,out _rankHigh);

                if (pairCounter == 1)
                {
                    _rank = PokerRank.Pair;
                    //Return true
                    return true;
                }//Else.. Return fals.
                return false;
            }
        }//Todo

        public PokerRank DetermineRank()
        {
            if (IsRoyalFlush)
            {
                return PokerRank.RoyalFlush;
            }
            else if (IsStraightFlush)
            {
                return PokerRank.StraightFlush;
            }
            else if (IsFourOfAKind)
            {
                return PokerRank.FourOfAKind;
            }
            else if (IsFullHouse)
            {
                return PokerRank.FullHouse;
            }
            else if (IsFlush)
            {
                return PokerRank.Flush;
            }
            else if (IsStraight)
            {
                return PokerRank.Straight;
            }
            else if (IsThreeOfAKind)
            {
                return PokerRank.ThreeOfAKind;
            }
            else if (IsTwoPair)
            {
                return PokerRank.TwoPair;
            }
            else if (IsPair)
            {
                return PokerRank.Pair;
            }
            else
            {
                return PokerRank.Unknown;
            }
        }

        //Clear rank
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
