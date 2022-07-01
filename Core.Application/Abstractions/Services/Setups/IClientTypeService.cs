using Core.Application.Services;
using Core.Domain.Models;
using Core.Domain.Models.SetupModels;
using MassTransit.Futures.Contracts;

namespace Core.Application.Abstractions.Services.Setups;

public interface IClientTypeService:ITransient
{
    Task<ClientType> CreateClientType(ClientType clientType);
    Task<ClientType> GetClientTypeById(Guid clientTypeId);
    Task<string> UpdateClientTypeName(Guid clientTypeId, string clientTypeName);
    Task<string> UpdateClientTypeDescription(Guid clientTypeId, string description);
    Task<bool> DeleteClientType(Guid clientTypeId);
    Task<IEnumerable<LovModel>> ClientTypeLov();
}