using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.Entities
{
    public class LeasePayment
    {
        public int LeasePaymentId { get; set; }
        public int LeaseAgreementId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        public LeaseAgreement LeaseAgreement { get; set; }

    }
}
