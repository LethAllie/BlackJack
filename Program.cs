using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Going into this I understaand that there are easier ways to do this, but the point was just to practice with objects. This does that! 
namespace BasicBlackJack
{
    class GameSystem
    {
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

        //Generates the  enums for cards and suits. NOTE: Jack/QUeen/King values will not add correctly. Fix that. 

        public GameSystem()
        {

            DeckUsed = new DeckContainer();
            foreach (Suits suit in SuitList)
            {

                foreach (Cards card in cardList)

                {
                    int something = (int)Cards.Ten;
                    Console.WriteLine(something);
                    if (!card.Equals(1))
                    {
                        DeckUsed.AddCardToDeck(new Card { Name = card, Suit = suit, flag = true, isAce = false });
                        Console.WriteLine(card.ToString()+suit.ToString());

                        continue;
                        


                    }
                    if (card.Equals(1))
                    {
                        DeckUsed.AddCardToDeck(new Card { Name = card, Suit = suit, flag = true, isAce = true });
                        continue;

                    }
                    
                    {
                        Console.WriteLine("Something went wrong generating this deck");
                    }
                }

            }

        }
        // Creates a deck by cycling through each suit and generating the cards for it. Adds each card to a list of objects of cards.

        public DeckContainer DeckUsed { get; private set; }
    }



    
    class Card
    {
        public Enum Name { get; set; }
        public Enum Suit { get; set; }
        public int Value { get; set; }
        public bool flag { get; set; }
        public bool isAce { get; set; }
    }
    //Contains the values the card holds


    class DeckContainer
    {
        public DeckContainer()
        {
            DeckList = new List<Card>();
        }
        // this is the list of objects for cards

        public List<Card> DeckList { get; private set; }

        public void CheatingCardList()
        {
            Console.WriteLine("Remaining Cards");

            foreach (var card in DeckList)
            {
                Console.WriteLine(card.Name + " " + card.Suit);
            }

            // TODO make this work


        }
        public void AddCardToDeck(Card card)
        {
            DeckList.Add(card);
        }

        // Used in generating the card


    }
    class Program  // it's a main program! I wonder what it does!
    {
        static void Main(string[] args)
        {
            GameSystem gameSystem = new GameSystem();
            Console.ReadLine();

        }
    }
}
