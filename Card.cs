using System;
using System.Text;
using System.Collections.Generic;


namespace BasicBlackJack
{
    struct Card
    {
        public Enum Name { get; set; }
        public Enum Suit { get; set; }
        public int Value { get; set; }
        public bool Flag { get; set; }
        public bool IsAce { get; set; }
    }
    // Contains the values the cards use. 

}
