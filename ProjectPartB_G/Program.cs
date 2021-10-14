using System;

namespace ProjectPartB_B1
{
    class Program
    {
        //Bool that is going to be used to exit the main if user dose not wish to play no more.
        public static bool KeepGoing = true;

        static void Main(string[] args)
        {
            //Creating a new instence of DeckOfCards.
            DeckOfCards myDeck = new DeckOfCards();

            //Calling upon a method that will initiate myDeck with a fresh deck of cards.
            myDeck.CreateFreshDeck();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Sort the deck.
            myDeck.Sort();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Shuffle the deck.
            myDeck.Shuffle();
            //Print out the cards and the amount of cards.
            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            //Creating 2 instances of the HandOfCards Class.
            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            //todo Your code to play the game comes here.
            Console.WriteLine("\nLet's play a game of highest card with two players.");
            //Creating two int's that will hold the value of the user unput  
            int amountOfCards = 0;
            int amountOfRounds = 0;
            //Check if the method's succeded in getting a valid number from the user. 
            KeepGoing = TryReadNrOfCards(out amountOfCards) &&
                        TryReadNrOfRounds(out amountOfRounds);

            // If user did not inputing a valid number -> exit program.
            if (!KeepGoing)            
                return;

            //Clear the screen.
            Console.Clear();

            //Play for amount of rounds the user chose..
            for (int i = 0; i < amountOfRounds; i++)
            {
                //Informing the user what round is being played.
                Console.WriteLine($"Playing round {i + 1} out of {amountOfRounds}\n------------------------");

                //Deal the cards from the top of the deck to the player's hand's.
                Deal(myDeck, amountOfCards, player1, player2);
                
                //print the amount of card's given and cards left int the deck
                Console.WriteLine($"Gave {amountOfCards} card's each to the player's from the top deck. Deck has now {myDeck.Count} card's\n");

                //Print the card info the player is holding.
                Console.WriteLine($"Player1's hand with {amountOfCards} card's");
                // todo Type players highest and lowest card
                Console.WriteLine(player1 + "\n");

                //Print the card info the player is holding.
                Console.WriteLine($"Player2's hand with {amountOfCards} card's");
                // todo Type players highest and lowest card
                Console.WriteLine(player2 + "\n");

                //check which player won the round.
                DetermineWinner(player1, player2);

                //Clear's the hand from old card's
                player1.Clear();
                player2.Clear();
            }

        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            NrOfCards = 0;
            string sInput;
            do
            {
                Console.WriteLine("Cards per round (1-5 or Q to quit)?");
                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfCards) && NrOfCards >= 1 && NrOfCards <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((sInput != "Q" && sInput != "q"));
            return false;
        }
        //Done

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            NrOfRounds = 0;
            string sInput;
            do
            {
                Console.WriteLine("\nAmount of round's (1-5 or Q to quit)?");
                sInput = Console.ReadLine();
                if (int.TryParse(sInput, out NrOfRounds) && NrOfRounds >= 1 && NrOfRounds <= 5)
                {
                    return true;
                }
                else if (sInput != "Q" && sInput != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((sInput != "Q" && sInput != "q"));
            return false;
        }
        //Done

        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            //As many times as amount of card's to give
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                //Give one card from the top of the deck to eatch player.
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }        
        }
        //Done

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        { 
            // todo Snart vi är klara brääääääää
        }
    }
}
