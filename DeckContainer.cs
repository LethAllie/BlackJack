using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBlackJack
{
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
}
