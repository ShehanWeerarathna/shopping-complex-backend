using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface ILeaseAgreementService
    {
        Task<PagedDataResponse<LeaseAgreementDto>> GetLeaseAgreementsAsync(int? currentPage, int? pageSize, int? storeId);
        Task<LeaseAgreementDto> GetLeaseAgreementByIdAsync(int id);
        Task<LeaseAgreementDto> CreateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement);
        Task<LeaseAgreementDto> UpdateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement);
        Task<int> DeleteLeaseAgreementAsync(int id);
        Task<LeaseAgreementDto> GetLeaseAgreementByStoreIdAsync(int storeId);
    }
}
