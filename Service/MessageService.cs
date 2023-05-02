using Domein.Entities;
using Domein.Exceptions;
using Domein.Repositories;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class MessageService : IMessageService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MessageService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async  Task AddAsync(Message entity)=> _repositoryManager._messageRepository.AddAsync(entity);
     
        public async Task DeleteAsync(Guid MessageId)
        {
             var message = await _repositoryManager._messageRepository.GetByIdAsync(MessageId);
            if (message is null) throw new MessageNotFoundedException();
            _repositoryManager._messageRepository.DeleteAsync(message);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()=>
            await _repositoryManager._messageRepository.GetAllAsync();

        public async Task<Message> GetByIdAsync(Guid MessageId)
        {
            var message = await _repositoryManager._messageRepository.GetByIdAsync(MessageId);
            if (message is null) throw new MessageNotFoundedException();
            return message;
        }

        public async Task UpdateAsync(Message entity)
        {
            var message = await _repositoryManager._messageRepository.GetByIdAsync(entity.MessageId);
            if (message is null) throw new MessageNotFoundedException();
            _repositoryManager._messageRepository.UpdateAsync(message);
        }
    }
}
