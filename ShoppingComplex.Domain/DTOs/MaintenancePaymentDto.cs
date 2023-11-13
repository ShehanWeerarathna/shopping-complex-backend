using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class MaintenancePaymentDto
    {
        public int MaintenancePaymentId { get; set; }
        public int MaintenanceContractId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public MaintenanceContractDto? MaintenanceContract { get; set; }
    }
}
