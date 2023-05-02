using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public interface IAccountService
    {
        public Task<IEnumerable<Account>> GetAllAsync();

        public Task<Account> GetByIdAsync(Guid AccountId);

        public Task AddAsync(Account entity);

        public Task UpdateAsync(Account entity);
        public Task DeleteAsync(Guid AccountId);

    }
}
