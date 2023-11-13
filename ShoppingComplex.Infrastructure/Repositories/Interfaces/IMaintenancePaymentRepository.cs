using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IMaintenancePaymentRepository
    {
        Task<List<MaintenancePayment>> GetMaintenancePaymentsAsync(int? maintenanceContractId);
        Task<MaintenancePayment> GetMaintenancePaymentByIdAsync(int id);
        Task<MaintenancePayment> CreateMaintenancePaymentAsync(MaintenancePayment maintenancePayment);
        Task<MaintenancePayment> UpdateMaintenancePaymentAsync(MaintenancePayment maintenancePayment);
        Task<int> DeleteMaintenancePaymentAsync(int id);
        Task<List<MaintenancePayment>> GetMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate);
    }
}
