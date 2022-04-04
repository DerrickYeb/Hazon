using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazon.DAL.Domain.Models.PolicyModels
{
    public class PolicyBaseEntity:BaseEntity
    {
        public Guid InsurerId { get; set; }
        public string? PolicyNumber { get; set; }
        public string? Chassis { get; set; }
        public DateTime CommemorateDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal SumInsured { get; set; }
        public decimal Discount { get; set; }
        public decimal FleetDiscount { get; set; }
        public string? DocumentNumber { get; set; }
        public decimal Tppdl { get; set; }
        public bool Excess { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleColor { get; set; }
        public int VehicleYearMake { get; set; }
        public int VehicleYearRegistered { get; set; }
        public string? VehicleRegistrationNo { get; set; }
        public string? IdTypeId { get; set; }
        public string? IdNumber { get; set; }
        public decimal StickerFee { get; set; }
        public decimal Premium { get; set; }
    }
}
