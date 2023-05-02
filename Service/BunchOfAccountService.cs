using Domein.Entities;
using Domein.Exceptions;
using Domein.Repositories;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class BunchOfAccountService : IBunchOfAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BunchOfAccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task AddAsync(BunchOfAccount entity)
        {
            var inneraccount = from account in await _repositoryManager._bunchOfAccountRepository.GetAllAsync()
                               where account.InnerAccountId == entity.InnerAccountId
                               select account;
            if (inneraccount.ToList().Count()!=0)
            {
                throw new AlreadyInAccountsException();
            }
            _repositoryManager._bunchOfAccountRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid AccountId)
        {
            var account = await _repositoryManager._bunchOfAccountRepository.GetByIdAsync(AccountId);
            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
            _repositoryManager._bunchOfAccountRepository.DeleteAsync(account);
        }

        public async Task<IEnumerable<BunchOfAccount>> GetAllAsync()=>
        await _repositoryManager._bunchOfAccountRepository.GetAllAsync();

        public async Task<BunchOfAccount> GetByIdAsync(Guid AccountId)
        {
            var account = await _repositoryManager._bunchOfAccountRepository.GetByIdAsync(AccountId);

            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
            return account;
        }

        public async Task UpdateAsync(BunchOfAccount entity)
        {
            var account = await _repositoryManager._bunchOfAccountRepository.GetByIdAsync(entity.BunchOfAccountsId);
            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
            _repositoryManager._bunchOfAccountRepository.UpdateAsync(entity);
        }
    }
}
