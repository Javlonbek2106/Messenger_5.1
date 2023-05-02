using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBunchOfAccountService
    {
        public Task<IEnumerable<BunchOfAccount>> GetAllAsync();

        public Task<BunchOfAccount> GetByIdAsync(Guid AccountId);

        public Task AddAsync(BunchOfAccount entity);

        public Task UpdateAsync(BunchOfAccount entity);
        public Task DeleteAsync(Guid AccountId);
    }
}
