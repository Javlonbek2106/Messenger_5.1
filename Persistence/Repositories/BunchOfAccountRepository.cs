using Domein.Entities;
using Domein.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class BunchOfAccountRepository : IBunchOfAccountRepository
    {
        private readonly MessengerDBContext _dbContext;
        public BunchOfAccountRepository(MessengerDBContext dbContext) => _dbContext = dbContext;
        public void AddAsync(BunchOfAccount entity) => _dbContext.Add(entity);

        public void DeleteAsync(BunchOfAccount entity) => _dbContext.Remove(entity);

        public async Task<IEnumerable<BunchOfAccount>> GetAllAsync() => await _dbContext.BunchOfAccounts.ToListAsync();

        public async Task<BunchOfAccount> GetByIdAsync(Guid id) => await _dbContext.BunchOfAccounts.FirstAsync(x => x.BunchOfAccountsId == id);

        public void UpdateAsync(BunchOfAccount entity) => _dbContext.Update(entity);

    }
}
