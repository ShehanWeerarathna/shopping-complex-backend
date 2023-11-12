using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class LeasePaymentDto
    {
        public int LeasePaymentId { get; set; }
        public int LeaseAgreementId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public LeaseAgreementDto? LeaseAgreement { get; set; }

    }
}
