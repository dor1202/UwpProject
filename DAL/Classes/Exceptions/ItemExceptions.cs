using System;

namespace DAL.Classes.Exceptions
{
    public class ItemExceptions : Exception
    {
        public ItemExceptions(string message) : base(message) { }
    }
}
