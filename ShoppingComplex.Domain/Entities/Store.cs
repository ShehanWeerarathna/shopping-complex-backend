using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.Entities
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public Category Category { get; set; }
        public int? LeaseAgreementId { get; set; }
        public int? MaintenanceContractId { get; set; }
        public LeaseAgreement? LeaseAgreement { get; set; }
        public MaintenanceContract? MaintenanceContract { get; set; }
    }
}
