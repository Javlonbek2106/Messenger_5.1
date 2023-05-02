using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public  interface IContactService
    {
        public Task<IEnumerable<Contact>> GetAllAsync();

        public Task<Contact> GetByIdAsync(Guid ContactId);

        public Task AddAsync(Contact entity);

        public Task UpdateAsync(Contact entity);
        public Task DeleteAsync(Guid ContactId);

    }
}
