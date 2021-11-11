using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes.Exceptions
{
    class ItemExceptions : Exception
    {
        public ItemExceptions(string message) : base(message) { }
    }
}
