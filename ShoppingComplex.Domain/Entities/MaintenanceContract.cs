using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.Entities
{
    public class MaintenanceContract
    {
        public int MaintenanceContractId { get; set; }
        public int StoreId { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal ContractAmount { get; set; }
        public string? Description { get; set; }

        // Navigation property
        public Store Store { get; set; }
        public ICollection<MaintenancePayment> MaintenancePayments { get; set; }
    }
}
