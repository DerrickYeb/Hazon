namespace Core.Application.Abstractions.Services.Setups
{
    public interface IDynamicSetupService : ITransient
    {
        Task<PolicyType> CreateDynamicServiceType(PolicyType policyType);
        Task<PolicyType> GetDynamicServiceTypeById(Guid policyTypeId);
        Task<IAsyncEnumerable<PolicyType>> GetAllDynamicServiceType();
        Task<bool> DeleteDynamicServiceType(Guid policyTypeId);
        Task<string> UpdateDynamciServiceTypeName(string policyType);
        Task<string> UpdateDynamicServiceTypeDescription(string description);
        Task<double> UpdateDynamicServiceTypeRate(decimal rate);
        Task<string> ExistAsync(PolicyType policyType);
    }
}