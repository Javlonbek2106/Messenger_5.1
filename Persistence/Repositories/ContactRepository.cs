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
    internal sealed class ContactRepository : IContactRepository
    {
        private readonly MessengerDBContext _dbContext;
        public ContactRepository(MessengerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  void AddAsync(Contact entity) =>  _dbContext.Add(entity);


        public void DeleteAsync(Contact entity) => _dbContext.Remove(entity);

        public async Task<IEnumerable<Contact>> GetAllAsync() => await _dbContext.Contacts.ToListAsync();

        public async Task<Contact> GetByIdAsync(Guid id) => await _dbContext.Contacts.FirstAsync(x => x.ContactId == id);
        
        public  void UpdateAsync(Contact entity) => _dbContext.Update(entity);
        
    }
}
