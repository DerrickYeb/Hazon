using Core.Application.Abstractions.Services.Setups;
using Core.Application.Repositories;
using Core.Domain.Models.SetupModels;

namespace Core.Application.Services.Setups;

public class PolicyTypeService:IPolicyTypeService
{
    private readonly IRepository<PolicyType> _repository;

    public PolicyTypeService(IRepository<PolicyType> repository)
    {
        _repository = repository;
    }

    private async Task<string> ExistAsync(PolicyType policyType)
    {
        var exist = await _repository.ExistAsync<PolicyType>(p => p.Name.ToLowerInvariant().Trim() ==
            policyType.Name.ToLowerInvariant().Trim() && p.TenantKey == policyType.TenantKey);
        return $"Policy type with such name {policyType.Name} already exist";
    }
    public async Task<PolicyType> CreatePolicyType(PolicyType policyType)
    {
        try
        {
            await ExistAsync(policyType);
            var data = await _repository.CreateAsync(policyType);
            await _repository.SaveChangesAsync();
            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PolicyType> GetPolicyTypeById(Guid policyTypeId)
    {
        try
        {
            var type = await _repository.GetByIdAsync<PolicyType>(policyTypeId);
            return type;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IAsyncEnumerable<PolicyType>> GetAllPolicyType()
    {
        return await _repository.GetListByYield<PolicyType>();
    }

    public async Task<bool> DeletePolicyType(Guid policyTypeId)
    {
        return await _repository.RemoveByIdAsync<PolicyType>(policyTypeId);
    }

    public async Task<string> UpdatePolicyTypeName(string policyType)
    {
        var newName = new PolicyType()
        {
            Name = policyType
        };
        return await _repository.UpdateAsync<>(newName);
    }

    public async Task<string> UpdatePolicyTypeDescription(string description)
    {
        var newDescription = new PolicyType()
        {
            Description = description
        };
        return await _repository.UpdateAsync<>(newDescription);
    }

    public async Task<double> UpdatePolicyTypeRate(decimal rate)
    {
        var newRate = new PolicyType()
        {
            Commission = rate
        };
        return await _repository.UpdateAsync<>(newRate);
    }
}