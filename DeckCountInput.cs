using System;
using System.Linq;
// Going into this I understand that there are easier ways to do this, but the point was just to practice with objects. This does that! 
namespace BasicBlackJack
{
    class DeckCountInput
    {
        int testNumber;  // Test number as in tested number not as in "Testing if this works, number"
        public int TestForNumber()
        {
            bool breakloop = false;   // Intro text loop to demand a number, continues looping as long as there isn't a valid number put in. This loop also checks the validty of inputs, only breaking when it finds a valid one. 
            while (!breakloop)
            {

                string enteredNumber = Console.ReadLine();
                if (enteredNumber.All(char.IsDigit) && enteredNumber != null)  // Check if string is a number, if true try to parse in next step.
                {
                    if (Int32.TryParse(enteredNumber, out testNumber))  // try to parse nunmber, returns true if it can be placed into int32.
                    {
                        int deckCountInt = Convert.ToInt32(enteredNumber);  
                        if(testNumber != 0)
                        {
                            breakloop = true;                // if this is a number AND it fits in to int32 AND it's not a 0, return true to break loop.
                        }
                        else
                        {
                            Console.WriteLine("Is 0 between 1-2,147,483,647? No. It's not. Don't be cheeky. Lets try that again.");
                        }


                    }
                    else
                    {
                        Console.WriteLine("I assume you meant to type something, lets try again.");

                    }
                }
                else
                {
                    Console.WriteLine("That's not even a number! Try again.");
                }
            }
            return testNumber;

            // TODO probably make this not awful. But it works and as I'm writing this there are parts of the project that don't exist... so... priorities. 
        }
    }

}
