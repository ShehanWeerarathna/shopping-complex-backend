using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Extensions
{
    internal static class MaintenanceContractExtension
    {
        // Filter by StoreId
        public static IQueryable<MaintenanceContract> FilterMaintenanceContractByStoreId(this IQueryable<MaintenanceContract> maintenanceContracts, int? storeId)
        {
            if (storeId.HasValue && storeId != 0)
                return maintenanceContracts.Where(m => m.StoreId == storeId);

            return maintenanceContracts;
        }
    }
}
