using System;
using System.Collections.Generic;
using System.Text;

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


        public void AddCardToDeck(Card card)
        {
            DeckList.Add(card);
        }

        // Used to add the generated card to the deck list used by gameloop.


    }
}
