using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Exceptions
{
    public  sealed class AlreadHasInContactsException: Exception
    {
        public AlreadHasInContactsException(): base("this contact is already exists within this user's contacts list. ")
        {

        }

    }
}
