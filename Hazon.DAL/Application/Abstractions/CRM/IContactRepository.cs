using Hazon.DAL.Domain.Models;

namespace Hazon.DAL.Application.Abstractions.CRM
{
    public interface IContactRepository:ITransient
    {
        Task<ClientDetailsModel> CreateContact(ClientDetailsModel contact);
        Task<bool> DeleteContact(Guid contactId);
        Task<Guid> UpdateContactDetails(ClientDetailsModel contact);
        Task<ClientDetailsModel> GetContact(Guid contactId);
        Task<ClientDetailsModel> MoveContactToBusiness(Guid contactId, ClientDetailsModel contact);
        Task<IEnumerable<ClientDetailsModel>> GetAllContacts();
    }
}