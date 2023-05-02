using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Repositories
{
    public interface IRepositoryManager
    {
        IAccountRepository _accountRepository { get; }
        IContactRepository _contactRepository { get; }
        IMessageRepository _messageRepository { get; }
        IBunchOfAccountRepository _bunchOfAccountRepository { get; }
        IUnitOfWork _unitOfWork { get; }
    }
}
