using Domein.Entities;
using Domein.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class MessageRepository :IMessageRepository
    {
        private readonly MessengerDBContext _dbContext;
        public MessageRepository(MessengerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAsync(Message entity) => _dbContext.Add(entity);

        public void DeleteAsync(Message message)=> _dbContext.Remove(message);

        public async Task<IEnumerable<Message>> GetAllAsync() => await _dbContext.Messages.ToListAsync();
        
        public async Task<Message> GetByIdAsync(Guid id)=> await _dbContext.Messages.FirstAsync(x=>x.MessageId== id);   
        
        public   void UpdateAsync(Message entity) =>  _dbContext.Update(entity);
        
    }
}
