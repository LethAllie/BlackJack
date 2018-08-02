using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System;

// Going into this I understand that there are easier ways to do this, but the point was just to practice with objects. This does that in a potentially convoluted manner....! 
namespace BasicBlackJack
{
    class Program  // it's a main program! I wonder what it does! It's an intro, generate, and game loop. That's what it does. 
    {
        static void Main(string[] args)
        {
            GameSystem gameSystem = new GameSystem();


        }
    }
    class GameSystem
    {
        public GameSystem()
        {
            currentGame = new Game();
            currentGame.Intro();
            int DecksToPlay = currentGame.DecksToPlay;
            GenerateDeck DeckToUse = new GenerateDeck(DecksToPlay);


            while (!currentGame.isFinished)
            {
                currentGame.GameLoop();
            }
            ExitGame();
        }

        public Game currentGame { get; set; }

        private void ExitGame()
        {
            Console.WriteLine("Thank you for playing! Your score is " + currentGame.Wins + "wins and + " + currentGame.Losses + "losses");

        }
    }



    class DealCards
    {
        public Card DealCardOut<Card>(List<Card> UsedDeck, int DeckCountToUse)
        {

            int n = UsedDeck.Count;
            {
                Card CardToDeal = UsedDeck[0];
                return CardToDeal;

            }

        }
    }

    //I'm not gonna lie, I got lazy doing this last part. It's more duct tapped together than other parts with less flexibility and more hard coding. But this all the gameMechanics used.

    class Game
    {
        public Game()
        {
            Dealer = new Dealer();
            Player = new Player();
            DeckInUse = new List<Card>();
            DecksToPlay = new int();
            Wins = new int();
            Losses = new int();
            aceInPlay = new bool();


        }
        public Dealer Dealer { get; private set; }
        public Player Player { get; private set; }
        public List<Card> DeckInUse { get; private set; }
        public int DecksToPlay { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public bool isFinished { get; private set; }
        public bool aceInPlay { get; set; }

        // sets up deck and starting position
        public void Intro()
        {

            Console.WriteLine("Welcome to BlackJack! Please enter your name!");
            Player.Name = Console.ReadLine();
            Console.WriteLine("How many decks would you like to use for this game?");
            DeckCountInput DCI = new DeckCountInput();
            int DecksToPlay = DCI.TestForNumber();
            GenerateDeck generateDeck = new GenerateDeck(DecksToPlay);
            DeckInUse = generateDeck.DeckUsed.DeckList;


        }

        // starting position of hand.
        private void InitialDealToHand(List<Card> HandInPlay)
        {

            HandInPlay.Add(DeckInUse[0]);
            DeckInUse.RemoveAt(0);
            HandInPlay.Add(DeckInUse[0]);
            DeckInUse.RemoveAt(0);

        }
        // Sets all the targeted hand to empty.
        private void ClearHand(List<Card> SelectedHand)
        {
            while (SelectedHand.Count > 0)
            {
                SelectedHand.RemoveAt(0);
            }
        }
        // Initial Setup for dealer and player.
        private void SetupHands()
        {
            Player.isBust = false;
            Dealer.isBust = false;
            Dealer.Draw = true;
            Player.Draw = true;
            ClearHand(Dealer.Hand);
            ClearHand(Player.Hand);
            InitialDealToHand(Player.Hand);
            InitialDealToHand(Dealer.Hand);
        }

        // I really should have added these to a list like the cards then just cycled through them... Hard coding is the worst.

        // Prints out the players hand to console. 
        private void DisplayPlayerHand()
        {
            if (aceInPlay == false)
            {
                int playersValue = calcHandValue(Player.Hand);
                Console.Write("Your cards are ");
                for (int i = 0; i < Player.Hand.Count; i++)
                {
                    Console.Write(Player.Hand[i].Name + " of ");
                    Console.Write(Player.Hand[i].Suit);
                    if (i + 1 != Player.Hand.Count)
                    {
                        Console.Write(" and ");
                    }
                }

                Console.Write(" for a total value of " + playersValue);
            }
            if (aceInPlay == true)
            {
                List<int> acesAreDumb = calcHandValue(Player.Hand, aceInPlay);
                Console.Write("Your cards are ");
                for (int i = 0; i < Player.Hand.Count; i++)
                {
                    Console.Write(Player.Hand[i].Name + " of ");
                    Console.Write(Player.Hand[i].Suit);
                    if (i + 1 != Player.Hand.Count)
                    {
                        Console.Write(" and ");
                    }
                }
                if (acesAreDumb.Count == 1)
                {
                    Console.WriteLine("for a total value of " + acesAreDumb[0]);
                }

                if (acesAreDumb.Count == 2)
                {
                    Console.Write("for a total value of " + acesAreDumb[0] + " or " + acesAreDumb[1]);
                }
            }


        }
        // mechanics behind drawing a car and removing it from deck.
        private void DrawCard(List<Card> HandToDrawTo)
        {
            HandToDrawTo.Add(DeckInUse[0]);
            DeckInUse.RemoveAt(0);
        }
        // Mechanics behind hitting or staying during play for player.
        private void HitOrStay(List<Card> HandToHitOrStay, Player selectedPlayer)
        {
            Console.WriteLine("");
            Console.WriteLine("Would you like to hit or stay?");
            string HitOrStay = Console.ReadLine();

            if (HitOrStay.Equals("hit"))
            {
                DrawCard(HandToHitOrStay);
                DisplayPlayerHand();
                return;
            }
            else if (HitOrStay.Equals("stay"))
            {
                selectedPlayer.Draw = false;
                return;
            }
            {
                Console.WriteLine("Unrecognized Command, please try again");
            }
        }

        // Determines when dealer should draw or not
        private int DealerAI(List<Card> DealerHand)
        {
            int DealerTotal = 0;
            while (DealerTotal <= 17)
            {
                DrawCard(DealerHand);
                DealerTotal = calcHandValue(DealerHand);
            }
            DealerTotal = calcHandValue(DealerHand);
            return DealerTotal;
        }
        private void displayDealerHand()
        {
            int dealerHandValue = calcHandValue(Dealer.Hand);
            Console.WriteLine("The dealer's cards are");
            foreach (Card card in Dealer.Hand)
            {
                Console.WriteLine(card.Name + " of " + card.Suit);
            }
            Console.WriteLine(" for a total value of " + dealerHandValue);
        }

        // Checks if any card is an Ace, if one is it sets hasAce flag to true which causes it to take the higher[but <= 21] value of the aceTotal[+10 to value for Ace, taking value from 1 to 11] or RunningTotal
        int calcHandValue(List<Card> handToCount)
        {
            int runningTotal = 0;
            int aceTotal = 10;
            bool hasAce = false;
            List<Card> CountingTo21 = new List<Card>();
            foreach (Card card in handToCount)
            {
                runningTotal += card.Value;
                if (card.IsAce == true)
                {
                    hasAce = true;
                }
            }
            if (hasAce == true)
            {
                aceTotal += runningTotal;
                if (aceTotal > 21)
                    return runningTotal;
                if (aceTotal <= 21)
                    return aceTotal;
            }
            else
            {
                return runningTotal;
            }
            return runningTotal;
        }

        List<int> calcHandValue(List<Card> handToCount, bool aceInPlay)
        {
            List<int> twoValues = new List<int>();
            int runningTotal = 0;
            int aceTotal = 10;
            List<Card> CountingTo21 = new List<Card>();
            foreach (Card card in handToCount)
            {
                runningTotal += card.Value;
                aceTotal += runningTotal;
            }
            if (aceTotal <= 21)
            {
                twoValues.Add(aceTotal);
                twoValues.Add(runningTotal);
                return twoValues;
            }
            if (aceTotal > 21)
            {
                twoValues.Add(runningTotal);
                return twoValues;
            }
            Console.WriteLine("Something went wrong with calculating this value");
            return null;

        }
        // Test for bust or not, set isBust to true if busted.
        void Bust(List<Card> hand, Player selectedPlayer)
        {
            int bust = calcHandValue(hand);
            if (bust > 21)
            {
                Console.WriteLine("");
                Console.WriteLine(selectedPlayer.Name + " Bust!");
                selectedPlayer.isBust = true;
                selectedPlayer.Draw = false;
            }

        }

        // Drawing cards for the dealer from the main loop 
        void DealerDraw(List<Card> dealerHand, Player SelectedDealer)
        {
            int dealerValue = calcHandValue(dealerHand);
            if (dealerValue <= 17)
                SelectedDealer.Draw = true;
            while (SelectedDealer.Draw)
            {
                int DealerBust = 0;
                foreach (Card card in SelectedDealer.Hand)
                {
                    DealerBust += card.Value;
                }
                if (DealerBust >= 17)
                {
                    SelectedDealer.Draw = false;
                }
            }
        }

        public void determineWinner(List<Card> playerHand, List<Card> dealerHand)
        {
            int playersHand, dealersHand;
            playersHand = calcHandValue(playerHand);
            dealersHand = calcHandValue(dealerHand);
            if (playersHand > dealersHand && !Player.isBust || Dealer.isBust && !Player.isBust)
            {
                Console.WriteLine("Congratulations, you won the hand");
                Wins++;
                return;
            }
            if (playersHand < dealersHand && !Dealer.isBust || !Player.isBust)
            {
                Console.WriteLine("You lose");
                Losses++;
                return;
            }
            if (playersHand == dealersHand)
            {
                if (playerHand.Count > dealerHand.Count)
                {
                    Console.WriteLine("You lose due to draw rules");
                    Losses++;
                }
                if (playerHand.Count < dealerHand.Count)
                {
                    Console.WriteLine("Congratulations, you won the hand!");
                    Wins++;
                }
                if (playerHand.Count == dealerHand.Count)
                {
                    Console.WriteLine("It's a draw");
                }
            }
        }
        private void playAgain()
        {
            string playAgain;
            bool isValid = false;
            Console.WriteLine("Would you like to play again? Y/N");
            while (!isValid)
            {
                playAgain = Console.ReadLine();
                if (playAgain == "Y" || playAgain == "yes")
                {
                    Console.WriteLine("Next Hand!");
                    break;
                }
                if (playAgain == "N" || playAgain == "No")
                {
                    isFinished = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid command");
                }
            }

        }
        // The main game loop
        public void GameLoop()
        {
            SetupHands();
            DisplayPlayerHand();
            while (Player.Draw)
            {
                HitOrStay(Player.Hand, Player);
                Bust(Player.Hand, Player);
            }
            while (Dealer.Draw)
            {
                DrawCard(Dealer.Hand);
                Bust(Dealer.Hand, Dealer);
            }
            displayDealerHand();
            determineWinner(Player.Hand, Dealer.Hand);
            playAgain();

        }

    }
    class Player
    {
        public Player()
        {
            Hand = new List<Card>();
            isBust = false;
            Draw = true;
        }
        public bool isBust { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public bool Draw { get; set; }
    }


    class Dealer : Player
    {
        public Dealer()

        {
            Name = "Dealer";
            Hand = new List<Card>();

        }



    }
}
