using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hazon.DAL.Application.Abstractions.CRM;
using Hazon.DAL.Application.Repositories;
using Hazon.DAL.Domain.Models;

namespace Hazon.DAL.Application.Services.Contact
{
    public class ContactRepository:IContactRepository
    {
        private readonly IRepository _repository;

        public ContactRepository(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClientDetailsModel> CreateContact(ClientDetailsModel contact)
        {
            var exist = await _repository.ExistAsync<ClientDetailsModel>(a => a.Email == contact.Email);
            if (exist is not null) throw new Exception("Contact already exist");
            var result = await _repository.CreateAsync(contact);
            return result;
        }

        public Task<bool> DeleteContact(Guid contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateContactDetails(ClientDetailsModel contact)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDetailsModel> GetContact(Guid contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDetailsModel> MoveContactToBusiness(Guid contactId, ClientDetailsModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
