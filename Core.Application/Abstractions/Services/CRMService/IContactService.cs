using Core.Application.Services;
using Core.Domain.Models;

namespace Core.Application.Abstractions.Services.CRMService
{
    public interface IContactService:ITransient
    {
        Task<ClientDetailsModel> CreateContact(ClientDetailsModel contact);
        Task<bool> DeleteContact(Guid contactId);
        Task<Guid> UpdateContactDetails(ClientDetailsModel contact);
        Task<ClientDetailsModel> GetContact(Guid contactId);
        Task<ClientDetailsModel> MoveContactToBusiness(Guid contactId, ClientDetailsModel contact);
        Task<IEnumerable<ClientDetailsModel>> GetAllContacts();
    }
}