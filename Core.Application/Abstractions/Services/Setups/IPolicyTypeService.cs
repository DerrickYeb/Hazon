using Core.Application.Abstractions.Services.General;
using Core.Application.Repositories;
using Core.Application.Services;
using Core.Domain.Models.SetupModels;

namespace Core.Application.Abstractions.Services.Setups;

public interface IPolicyTypeService:IScopedService
{
    Task<PolicyType> CreatePolicyType(PolicyType policyType);
    Task<PolicyType> GetPolicyTypeById(Guid policyTypeId);
    Task<IAsyncEnumerable<PolicyType>> GetAllPolicyType();
    Task<bool> DeletePolicyType(Guid policyTypeId);
    Task<string> UpdatePolicyTypeName(string policyType);
    Task<string> UpdatePolicyTypeDescription(string description);
    Task<double> UpdatePolicyTypeRate(decimal rate);
    Task<string> ExistAsync(PolicyType policyType);
}