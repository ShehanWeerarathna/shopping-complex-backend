using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetStoresAsync(string? searchTerm, int? categoryId);
        Task<Store> GetStoreByIdAsync(int id);
        Task<Store> CreateStoreAsync(Store store);
        Task<Store> UpdateStoreAsync(Store store);
        Task<int> DeleteStoreAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task<Store> GetStoreByLeaseAgreementIdAsync(int id);
        Task<Store> GetStoreByMaintenanceContractIdAsync(int id);
    }
}
