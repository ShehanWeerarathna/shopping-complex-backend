using Microsoft.EntityFrameworkCore;
using ShoppingComplex.Domain.Entities;
using ShoppingComplex.Infrastructure.Data;
using ShoppingComplex.Infrastructure.Repositories.Extensions;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all stores
        public async Task<List<Store>> GetStoresAsync(string? searchTerm, int? categoryId)
        {
            IQueryable<Store> query = _context.Stores.SearchStore(searchTerm);

            if (categoryId.HasValue && categoryId != 0)
            {
                query = query.Where(s => s.CategoryId == categoryId);
            }

            List<Store> stores = await query.Include(s => s.Category).ToListAsync();
            return stores;
        }

        // Get store by id
        public async Task<Store?> GetStoreByIdAsync(int id)
        {
            try
            {
                var store = await _context.Stores
                    .Include(s => s.Category)
                    .FirstOrDefaultAsync(s => s.StoreId == id);
                return store;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Create store
        public async Task<Store> CreateStoreAsync(Store store)
        {
            try
            {
                _context.Stores.Add(store);
                await _context.SaveChangesAsync();
                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update store
        public async Task<Store> UpdateStoreAsync(Store store)
        {
            try
            {
                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
                return store;

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete store
        public async Task<int> DeleteStoreAsync(int id)
        {
            try
            {
               // Delete Store with its expired lease agreements maintence contracts and payments
                var store = await _context.Stores
                    .Include(s => s.LeaseAgreement)
                    .ThenInclude(l => l.LeasePayments)
                    .Include(s => s.MaintenanceContract)
                    .ThenInclude(m => m.MaintenancePayments)
                    .FirstOrDefaultAsync(s => s.StoreId == id);

                if (store != null)
                {
                    _context.Stores.Remove(store);
                    await _context.SaveChangesAsync();
                    return store.StoreId;
                }
                else
                {
                    throw new Exception("Store not found");
                }
            
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get categories
        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get store by lease agreement id
        public async Task<Store> GetStoreByLeaseAgreementIdAsync(int id)
        {
            try
            {
                var store = await _context.Stores.FirstOrDefaultAsync(s => s.LeaseAgreementId == id);
                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get store by maintenance contract id
        public async Task<Store> GetStoreByMaintenanceContractIdAsync(int id)
        {
            try
            {
                var store = await _context.Stores.FirstOrDefaultAsync(s => s.MaintenanceContractId == id);
                return store;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
