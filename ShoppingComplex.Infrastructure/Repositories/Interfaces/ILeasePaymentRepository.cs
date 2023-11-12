using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface ILeasePaymentRepository
    {
        Task<List<LeasePayment>> GetLeasePaymentsAsync(int? leaseAgreementId);
        Task<LeasePayment> GetLeasePaymentByIdAsync(int id);
        Task<LeasePayment> CreateLeasePaymentAsync(LeasePayment leasePayment);
        Task<LeasePayment> UpdateLeasePaymentAsync(LeasePayment leasePayment);
        Task<int> DeleteLeasePaymentAsync(int id);
        Task<List<LeasePayment>> GetLeasePaymentsByDateRange(DateTime startDate, DateTime endDate);
    }
}
