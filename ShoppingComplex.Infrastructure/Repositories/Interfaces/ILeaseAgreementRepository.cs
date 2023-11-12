using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface ILeaseAgreementRepository
    {
        Task<List<LeaseAgreement>> GetLeaseAgreementsAsync(int? storeId);
        Task<LeaseAgreement?> GetLeaseAgreementByIdAsync(int id);
        Task<LeaseAgreement> CreateLeaseAgreementAsync(LeaseAgreement leaseAgreement);
        Task<LeaseAgreement> UpdateLeaseAgreementAsync(LeaseAgreement leaseAgreement);
        Task<int> DeleteLeaseAgreementAsync(int id);
        Task<LeaseAgreement?> GetLeaseAgreementByStoreIdAsync(int storeId);
    }
}
