using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IMaintenanceContractService
    {
        Task<MaintenanceContractDto> CreateMaintenanceContractAsync(MaintenanceContractDto maintenanceContract);
        Task<int> DeleteMaintenanceContractAsync(int id);
        Task<MaintenanceContractDto> GetMaintenanceContractByIdAsync(int id);
        Task<PagedDataResponse<MaintenanceContractDto>> GetMaintenanceContractsAsync(int? currentPage, int? pageSize, int? storeId);
        Task<MaintenanceContractDto> UpdateMaintenanceContractAsync(MaintenanceContractDto maintenanceContract);
        Task<MaintenanceContractDto> GetMaintenanceContractByStoreIdAsync(int storeId);
    }
}
