using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.Entities
{
    public class MaintenancePayment
    {
        public int MaintenancePaymentId { get; set; }
        public int MaintenanceContractId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        public MaintenanceContract MaintenanceContract { get; set; }
    }
}
