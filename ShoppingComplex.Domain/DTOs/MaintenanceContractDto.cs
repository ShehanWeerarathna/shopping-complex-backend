using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class MaintenanceContractDto
    {
        public int MaintenanceContractId { get; set; }
        public int StoreId { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal ContractAmount { get; set; }
        public string? Description { get; set; }
        public StoreDto? Store { get; set; }
        public virtual List<MaintenancePaymentDto> Payments { get; set; } = new List<MaintenancePaymentDto>();
    }
}
