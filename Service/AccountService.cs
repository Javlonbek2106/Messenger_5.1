using Domein.Entities;
using Domein.Exceptions;
using Domein.Repositories;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async  Task AddAsync(Account entity)=>  _repositoryManager._accountRepository.AddAsync(entity);   

        public async  Task DeleteAsync(Guid AccountId)
        {
            var account = await _repositoryManager._accountRepository.GetByIdAsync(AccountId);
            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
            _repositoryManager._accountRepository.DeleteAsync(account);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()=>
         await _repositoryManager._accountRepository.GetAllAsync();

        public async Task<Account> GetByIdAsync(Guid AccountId)
        {
            var account = await _repositoryManager._accountRepository.GetByIdAsync(AccountId);

            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
            return account;
        }

        public async Task UpdateAsync(Account entity)
        {
            var account = await _repositoryManager._accountRepository.GetByIdAsync(entity.AccountId);
            if (account is null)
            {
                throw new AccountNotFoundException("there is no matched account. ");
            }
             _repositoryManager._accountRepository.UpdateAsync(entity);
        }
    }
}
