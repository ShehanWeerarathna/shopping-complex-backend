using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface ILeasePaymentService
    {
        Task<PagedDataResponse<LeasePaymentDto>> GetLeasePaymentsAsync(int? currentPage, int? pageSize, int? leaseAgreementId);
        Task<LeasePaymentDto> GetLeasePaymentByIdAsync(int id);
        Task<LeasePaymentDto> CreateLeasePaymentAsync(LeasePaymentDto leasePayment);
        Task<LeasePaymentDto> UpdateLeasePaymentAsync(LeasePaymentDto leasePayment);
        Task<int> DeleteLeasePaymentAsync(int id);
    }
}
