using Domein.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
     public interface IMessageService
    {
        public Task<IEnumerable<Message>> GetAllAsync();

        public Task<Message> GetByIdAsync(Guid MessageId);

        public Task AddAsync(Message entity);

        public Task UpdateAsync(Message entity);
        public Task DeleteAsync(Guid MessageId);

    }
}
