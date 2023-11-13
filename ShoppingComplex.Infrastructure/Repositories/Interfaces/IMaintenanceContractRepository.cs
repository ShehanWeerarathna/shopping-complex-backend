using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IMaintenanceContractRepository
    {
        Task<List<MaintenanceContract>> GetMaintenanceContractsAsync(int? storeId);
        Task<MaintenanceContract?> GetMaintenanceContractByIdAsync(int id);
        Task<MaintenanceContract> CreateMaintenanceContractAsync(MaintenanceContract maintenanceContract);
        Task<MaintenanceContract> UpdateMaintenanceContractAsync(MaintenanceContract maintenanceContract);
        Task<int> DeleteMaintenanceContractAsync(int id);
        Task<MaintenanceContract?> GetMaintenanceContractByStoreIdAsync(int storeId);
    }
}
