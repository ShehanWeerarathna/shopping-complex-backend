using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public int? LeaseAgreementId { get; set; }
        public int? MaintenanceContractId { get; set; }
        public LeaseAgreementDto? LeaseAgreement { get; set; }
        public MaintenanceContractDto? MaintenanceContract { get; set; }
    }
}
