using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IMaintenancePaymentService
    {
        Task<MaintenancePaymentDto> CreateMaintenancePaymentAsync(MaintenancePaymentDto maintenancePayment);
        Task<int> DeleteMaintenancePaymentAsync(int id);
        Task<MaintenancePaymentDto> GetMaintenancePaymentByIdAsync(int id);
        Task<PagedDataResponse<MaintenancePaymentDto>> GetMaintenancePaymentsAsync(int? currentPage, int? pageSize, int? maintenanceContractId);
        Task<List<MaintenancePaymentDto>> GetMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate);
        Task<MaintenancePaymentDto> UpdateMaintenancePaymentAsync(MaintenancePaymentDto maintenancePayment);
        Task<PagedDataResponse<MaintenancePaymentDto>> GetPagedMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate, int? currentPage, int? pageSize);
    }
}
