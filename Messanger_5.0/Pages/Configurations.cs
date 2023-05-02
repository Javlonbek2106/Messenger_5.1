using Domein.Repositories;
using Persistence.Repositories;
using Persistence;
using Service.Abstractions;
using Services.Abstractions;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger_5._0
{
    internal sealed partial class MessengerUI
    {

        internal IAccountService _accountService;
        internal IContactService _contactService;
        internal IMessageService _messageService;
        internal IBunchOfAccountService _bunchOfAccountService;
        internal IUnitOfWork _unitOfWork;
        static readonly string CurrentAccountIdPath = "..\\..\\..\\CurrentAccountId.txt";

        public MessengerUI()
        {
            MessengerDBContext context = new();
            IRepositoryManager _repository = new RepositoryManager(context);
            this._accountService = new AccountService(_repository);
            this._contactService = new ContactService(_repository);
            this._messageService = new MessageService(_repository);
            this._bunchOfAccountService = new BunchOfAccountService(_repository);
            _unitOfWork = new UnitOfWork(context);
        }

    }
}
