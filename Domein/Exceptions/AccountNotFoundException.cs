using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public sealed class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string Message) :base(Message)
        {
        }
    }
}
