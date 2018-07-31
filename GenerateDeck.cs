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
        enum Cards { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
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

        void shuffledDeck (int deckCount)
        {
            for (int i = deckCount; i != 0 ; i++)
                {

                }
            {

            }

            foreach (Suits suit in SuitList)
            {

                foreach (Cards card in cardList)

                {
                    if (!card.Equals(1))
                    {
                        DeckUsed.AddCardToDeck(new Card { Name = card, Suit = suit, flag = true, isAce = false });
                        Console.WriteLine(card.ToString() + suit.ToString());

                        continue;



                    }
                    if (card.Equals(1))
                    {
                        DeckUsed.AddCardToDeck(new Card { Name = card, Suit = suit, flag = true, isAce = true });
                        continue;

                    }
                    else
                    {
                        Console.WriteLine("Something went wrong generating this deck");
                    }
                }

            }


        }
        // Creates a deck by cycling through each suit and generating the cards for it. Adds each card to a list of objects of cards.


        public DeckContainer DeckUsed { get; private set; }
    }
}
