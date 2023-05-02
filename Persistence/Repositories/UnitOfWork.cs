using Domein.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MessengerDBContext _dbContext;
        public UnitOfWork(MessengerDBContext dbContext) => _dbContext = dbContext;
        public Task<int> SaveChangesAsync() =>
            _dbContext.SaveChangesAsync();
    }
}
