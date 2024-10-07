using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_14.Exceptions
{
    internal class InvalidAccountException:ApplicationException
    {
        public InvalidAccountException() { }

        public InvalidAccountException(string message)
            : base(message) { }

        public InvalidAccountException(string message, Exception inner)
            : base(message, inner) { }
    }
}
