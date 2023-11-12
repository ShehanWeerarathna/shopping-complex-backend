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

        public async Task<Store> GetStoreByIdAsync(int id)
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

        public async Task<int> DeleteStoreAsync(int id)
        {
            try
            {
                var store = _context.Stores.FirstOrDefault(s => s.StoreId == id);
                if (store != null)
                {
                    _context.Stores.Remove(store);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

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
    }

}
