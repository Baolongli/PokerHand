using System;
namespace PokerHand.Exceptions
{
    public class InvalidHandException : Exception
    {
        public InvalidHandException()
        {
        }
        public InvalidHandException(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
