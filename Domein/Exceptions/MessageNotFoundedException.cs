using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public sealed class MessageNotFoundedException : Exception
    {
        public MessageNotFoundedException() : base ("Message didn't founded. ")
        { 
        
        }
    }
}
