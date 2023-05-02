using Domein.Entities;
using Domein.Exceptions;
using Domein.Repositories;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ContactService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task AddAsync(Contact entity)
        {
            var owner = from contact in await _repositoryManager._contactRepository.GetAllAsync()
                        where contact.OwnerAccountId==entity.OwnerAccountId && contact.InContactId==entity.InContactId
                        select contact;
            if(owner.Count()!=0 )
            {
                throw new AlreadHasInContactsException();
            }
             _repositoryManager._contactRepository.AddAsync(entity);
        }


        public async Task DeleteAsync(Guid ContactId)
        {
            var contact = await _repositoryManager._contactRepository.GetByIdAsync(ContactId);
            if(contact is null)
            {
                throw new ContactNotFoundException();
            }
            _repositoryManager._contactRepository.DeleteAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()=>
        await _repositoryManager._contactRepository.GetAllAsync();

        public async Task<Contact> GetByIdAsync(Guid ContactId)
        {
            var contact = await _repositoryManager._contactRepository.GetByIdAsync(ContactId);

            if (contact is null)
            {
                throw new ContactNotFoundException();
            }
            return contact;
        }

        public async Task UpdateAsync(Contact entity)
        {
            var contact = _repositoryManager._contactRepository.GetByIdAsync(entity.ContactId);
            if(contact is null)
            {
                throw new ContactNotFoundException();
            }
             _repositoryManager._contactRepository.UpdateAsync(entity);
        }
    }
}
