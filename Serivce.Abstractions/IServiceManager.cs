using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IServiceManager
    {
        IAccountService _accountService { get; }
        IContactService _contactService { get; }
        IMessageService _messageService { get; }
        IBunchOfAccountService _bunchOfAccountService { get; }

    }
}
