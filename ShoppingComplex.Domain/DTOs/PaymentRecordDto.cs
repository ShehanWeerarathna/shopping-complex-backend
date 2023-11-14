using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class PaymentRecordDto
    {
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }
        public bool IsCredit { get; set; }
    }
}
