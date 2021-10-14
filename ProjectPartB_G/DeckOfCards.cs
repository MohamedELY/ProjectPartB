using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => cards[idx];

        public int Count => NrOfCards();
        public int NrOfCards()
        {
            //Go thrue the deck...
            int counter = 0;
            for (int i = 0; i < MaxNrOfCards; i++)
            {
                //if the Card in the deck in not null...
                if (cards[i] != null)
                {
                    //Add one too counter
                    counter++;
                }
            }//retuen counter
            return counter;
        }
        #endregion
        //Done

        #region ToString() related
        public override string ToString()
        {
            //The Spacer for the string.
            int spacer = 0;
            //The returning string.
            string sRet = "";
            //Go thrue the deck...
            for (int i = 0; i < Count; i++)
            {            
                //If the card is not null...
                if (cards[i] != null)
                {
                    //Add the card to the string thats going to be returnd
                    sRet += String.Format("{0,-10}", cards[i].ToString());
                    spacer++;

                    //If spacer is 13, insert a \n to the string
                    if(spacer == 13)                    
                    {
                        sRet += "\n";
                        //reset spacer
                        spacer = 0;
                    }
                } 

            }//Return string
            return sRet;
        }//Done
        #endregion
        //Done 
        
        #region Shuffle and Sorting
        public void Shuffle2(int times = 1)
        {
            // Create pseudo random number generator
            Random rand = new Random();

            for (; times > 0; times--)
                // Loop through all cards in the deck
                for (int i = 0; i < MaxNrOfCards; i++)
                {
                    // Save the current card in a temp var
                    var tempCard = this.cards[i];
                    // Generate a random number in the decks range
                    int index = rand.Next(0, MaxNrOfCards);
                    // Swap the card at the current spot with the randomly picked one
                    this.cards[i] = cards[index];
                    // Swap card at the randly generated spot with the one we saved
                    this.cards[index] = tempCard;
                }
        }//Done
        public void Shuffle()
        {
            // Creating a randome Varible that i call "rng", i also create two ints that will hold a randome value in the loop
            var rng = new Random();
            int index1, index2;

            // Creating a Playincard varible that will hold the information of one of the cards while they are being replaced.
            PlayingCard card;

            // Loop 1000 Times...
            for (int i = 0; i < 1000; i++)
            {
                // Inisiate index1 and index 2 with a randome number betwen 0 and 52.
                index1 = rng.Next(0, 52);
                index2 = rng.Next(0, 52);

                // Replace the location of the two cards with each other.
                card = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = card;
            }
        }//Done
        public void Sort()
        {
           this.cards = cards.OrderBy(c => c.Value).ToList();
        }//Done
        #endregion
        //Done

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }//Done
        public void CreateFreshDeck()
        {

            //Creating a whole deck...
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    //Creata a new Card with the value chosen and create it 4 times with diffrent color values, inert the card in to the List.
                    cards.Add(new PlayingCard((PlayingCardValue)j, (PlayingCardColor)i));
                }
            }
        }//Done
        #endregion
        //Done

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            // Return the Top card of the deck and reduce the nr of cards in the deck
            PlayingCard tempCard;
            for (int i = 0; i < MaxNrOfCards; i++)
            {
                if (cards[i] != null)
                {
                    tempCard = cards[i];
                    cards[i] = null;
                    return tempCard;
                }
            }
            Console.WriteLine("No card left in the deck!");
            return null;
        }//Done
        #endregion
        //Done
    }
}
