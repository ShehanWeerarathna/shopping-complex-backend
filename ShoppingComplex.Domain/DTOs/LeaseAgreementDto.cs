using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class LeaseAgreementDto
    {
        public int LeaseAgreementId { get; set; }
        public int StoreId { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public decimal LeaseAmount { get; set; }
        public string? Description { get; set; }
        public StoreDto? Store { get; set; }
        public virtual List<LeasePaymentDto> Payments { get; set; } = new List<LeasePaymentDto>();
    }
}
