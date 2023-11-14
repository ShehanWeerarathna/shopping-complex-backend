using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs
{
    public class FinancialReportDto
    {
        public List<PaymentRecordDto> Transactions { get; set; }
        public decimal TotalCredit
        {
            get
            {
                return Transactions.Where(t => t.IsCredit).Sum(t => t.Amount);
            }
        }

        public decimal TotalDebit
        {
            get
            {
                return Transactions.Where(t => !t.IsCredit).Sum(t => t.Amount);
            }
        }

        public decimal Balance
        {
            get
            {
                return TotalCredit - TotalDebit;
            }
        }
    }
}
