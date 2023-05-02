using Domein.Repositories;
using Service.Abstractions;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<IContactService> _lazyContactService;
        private readonly Lazy<IMessageService> _lazyMessageService;
        private readonly Lazy<IBunchOfAccountService> _lazyBunchOfAccountService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager));
            _lazyContactService = new Lazy<IContactService>(() => new ContactService(repositoryManager));
            _lazyMessageService = new Lazy<IMessageService>(() => new MessageService(repositoryManager));
            _lazyBunchOfAccountService = new Lazy<IBunchOfAccountService>(() => new BunchOfAccountService(repositoryManager));
        }

        public IAccountService _accountService =>_lazyAccountService.Value;

        public IContactService _contactService => _lazyContactService.Value;

        public IMessageService _messageService => _lazyMessageService.Value;

        public IBunchOfAccountService _bunchOfAccountService => _lazyBunchOfAccountService.Value;
    }
}
