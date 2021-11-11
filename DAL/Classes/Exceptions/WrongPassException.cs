using System;

namespace DAL.Classes.Exceptions
{
    public class WrongPassException : Exception
    {
        public WrongPassException(string message) : base(message) { }
    }
}
