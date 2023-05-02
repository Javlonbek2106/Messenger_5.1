using Domein.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IContactRepository> _lazyContactRepository;
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IMessageRepository> _lazyMessageRepository;
        private readonly Lazy<IBunchOfAccountRepository> _lazyBunchOfAccountRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(MessengerDBContext dbContext)
        {
            _lazyContactRepository = new Lazy<IContactRepository>(() => new ContactRepository(dbContext));
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(dbContext));
            _lazyMessageRepository = new Lazy<IMessageRepository>(() => new MessageRepository(dbContext));
            _lazyBunchOfAccountRepository = new Lazy<IBunchOfAccountRepository>(() => new BunchOfAccountRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }
        public IAccountRepository _accountRepository => _lazyAccountRepository.Value;

        public IContactRepository _contactRepository => _lazyContactRepository.Value;

        public IMessageRepository _messageRepository => _lazyMessageRepository.Value;
        public IBunchOfAccountRepository _bunchOfAccountRepository => _lazyBunchOfAccountRepository.Value;
        public IUnitOfWork _unitOfWork => _lazyUnitOfWork.Value;
    }
}
