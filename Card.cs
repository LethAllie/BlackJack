using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBlackJack
{
    class Card
    {
        public Enum Name { get; set; }
        public Enum Suit { get; set; }
        public int Value { get; set; }
        public bool flag { get; set; }
        public bool isAce { get; set; }
    }
    //Contains the values the card holds
}
