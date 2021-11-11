using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes.Exceptions
{
    class WrongPassException : Exception
    {
        public WrongPassException(string message) : base(message) { }
    }
}
