using Core.Application.Abstractions.Services.Setups;
using Core.Application.Repositories;
using Core.Domain.Models;
using Core.Domain.Models.SetupModels;

namespace Core.Application.Services.Setups;

public class ClientTypeService:IClientTypeService
{
    private readonly IRepository<ClientType> _repository;

    public ClientTypeService(IRepository<ClientType> repository)
    {
        _repository = repository;
    }

    public async Task<ClientType> CreateClientType(ClientType clientType)
    {
        var exist = await _repository.ExistAsync<ClientType>(c => c.Name == clientType.Name);
        if(exist != null) throw new Exception("Client type with such name already exist");

       var type = await _repository?.CreateAsync(clientType)!;
       return type;
    }

    public async Task<ClientType> GetClientTypeById(Guid clientTypeId)
    {
        if (clientTypeId == null) throw new Exception("Client id is empty");

        var client = await _repository.GetByIdAsync<ClientType>(clientTypeId);
        return client;
    }

    public async Task<string> UpdateClientTypeName(Guid clientTypeId, string clientTypeName)
    {
        var existAsync = await _repository.ExistAsync<ClientType>(c => c.Id == clientTypeId);
        if (existAsync is null) throw new Exception("Client type id does not exist");
        existAsync.Name = clientTypeName;
        var result =await _repository.UpdateAsync(existAsync);
        return result.Name;
    }

    public async Task<string> UpdateClientTypeDescription(Guid clientTypeId, string description)
    {
        var exist = await _repository.GetByIdAsync<ClientType>(clientTypeId);
        if (exist is null) throw new Exception("Client type Id does not exist.Failed to update description");

        exist.Description = description;
        var result = await _repository.UpdateAsync(exist);
        return result.Description;
    }

    public async Task<bool> DeleteClientType(Guid clientTypeId)
    {
        var check = await _repository.ExistAsync<ClientType>(c => c.Id == clientTypeId);
        if (check is null) throw new Exception("Client type id does not exist");
        return await _repository.RemoveByIdAsync<ClientType>(clientTypeId);
    }

    public async Task<IEnumerable<LovModel>> ClientTypeLov()
    {
        var result = await _repository.GetAllAsync<ClientType>();

        return result.Select(type => new LovModel() { Value = type.Id, Name = type.Name, Description = type.Description }).ToList();
    }
}