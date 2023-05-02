using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public abstract class InvalidInputException : Exception
    {
        public InvalidInputException(string Message) : base(Message) 
        {
            
        }
    }
}
