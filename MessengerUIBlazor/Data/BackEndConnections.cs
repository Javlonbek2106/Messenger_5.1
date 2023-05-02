using Domein.Repositories;
using Persistence.Repositories;
using Persistence;
using Service.Abstractions;
using Services.Abstractions;
using Services;

namespace MessengerUIBlazor.Data
{
    public class BackEndConnections
    {
        internal IAccountService _accountService;
        internal IContactService _contactService;
        internal IMessageService _messageService;
        internal IBunchOfAccountService _bunchOfAccountService;
        internal IUnitOfWork _unitOfWork;
        internal static readonly string CurrentAccountIdPath = @"..\Messanger_5.0\CurrentAccountId.txt";

        public BackEndConnections()
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
