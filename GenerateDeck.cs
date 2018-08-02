using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBlackJack
{
    class GenerateDeck
    {
        public GenerateDeck(int deckCount)
        {

            DeckUsed = new DeckContainer();
            shuffledDeck(deckCount);
            DeckUsed.DeckList.Shuffle();

        }
        static Random randomCard = new Random();
        enum Suits { Hearts, Diamonds, Clubs, Spades }
        List<Suits> SuitList = new List<Suits>
        {
            Suits.Hearts,
            Suits.Diamonds,
            Suits.Clubs,
            Suits.Spades
        };
        enum Cards { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack = 10, Queen = 10, King = 10}
        List<Cards> cardList = new List<Cards>
        {
            Cards.Ace,
            Cards.Two,
            Cards.Three,
            Cards.Four,
            Cards.Five,
            Cards.Six,
            Cards.Seven,
            Cards.Eight,
            Cards.Nine,
            Cards.Ten,
            Cards.Jack,
            Cards.Queen,
            Cards.King,
        };

        //Generates the  enums for cards and suits. NOTE: Jack/QUeen/King values will not add correctly. Keep in mind later.
        void shuffledDeck(int deckCount)
        {
            for (int i = deckCount; i != 0; i--)   // pulls the variable from readline after asking how many decks to use. 
            {
                foreach (Suits suit in SuitList)
                {
                    foreach (Cards card in cardList)

                    {
                        if (!card.Equals(1))    // puts the ace flag on the four specific ace cards for ease of use when doing math for Ace[1 or 11]
                        {
                            DeckUsed.AddCardToDeck(new Card { Name = card, Value = (int)card, Suit = suit, Flag = true, IsAce = false });
                            continue;
                        }
                        if (card.Equals(1))
                        {
                            DeckUsed.AddCardToDeck(new Card { Name = card, Suit = suit, Flag = true, IsAce = true });
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong generating this deck");
                        }
                    }
                }
            }
        }
        // Creates a deck by cycling through each suit and generating the cards for it. Adds each card to a list of objects of cards.
        public DeckContainer DeckUsed { get; private set; }
    }
}
