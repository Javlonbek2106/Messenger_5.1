using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public sealed class AlreadyInAccountsException : Exception
    {
        public AlreadyInAccountsException() : base("this account is already exists in your accounts list. ") 
        { 
        
        }
    }
}
