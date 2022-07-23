using Core.Domain.Contracts;

namespace Core.Domain.Models.CommissionModel
{
    public class Commission:AuditableEntity,IMustHaveTenant
    {
        public Guid PolicyId { get; set; }
        public decimal CommissionPaid { get; set; }
        public decimal ExpectedCommission { get; set; }
        public Guid PaymentType { get; set; }
        public Guid PaymentModel { get; set; }
        public string? Details { get; set; }
        public string TenantKey { get; set; }
    }
}
