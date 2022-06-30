namespace Core.Domain.Models.CommissionModel
{
    public class Commission
    {
        public Guid PolicyId { get; set; }
        public decimal CommissionPaid { get; set; }
        public decimal ExpectedCommission { get; set; }
        public Guid PaymentType { get; set; }
        public Guid PaymentModel { get; set; }
        public string? Details { get; set; }
    }
}
