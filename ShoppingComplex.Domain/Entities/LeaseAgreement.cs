using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.Entities
{
    public class LeaseAgreement
    {
        public int LeaseAgreementId { get; set; }
        public int StoreId { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public decimal LeaseAmount { get; set; }

        // Navigation property
        public Store Store { get; set; }
        public ICollection<LeasePayment> LeasePayments { get; set; }
    }
}
