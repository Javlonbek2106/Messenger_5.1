using Domein.Entities;
using Domein.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class AccountRepository : IAccountRepository
    {
        private readonly MessengerDBContext _dbContext;
        public AccountRepository(MessengerDBContext dbContext) => _dbContext = dbContext;

        public void AddAsync(Account entity) => _dbContext.Add(entity);


        public void DeleteAsync(Account entity) => _dbContext.Remove(entity);
       

        public async Task<IEnumerable<Account>> GetAllAsync()=> await _dbContext.Accounts.ToListAsync();


        public async Task<Account> GetByIdAsync(Guid id) => await _dbContext.Accounts.FirstAsync(x => x.AccountId == id);
     
        public void UpdateAsync(Account entity) => _dbContext.Update(entity);
    }
}
