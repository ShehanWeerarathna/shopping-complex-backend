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
    public class MaintenanceContractRepository : IMaintenanceContractRepository
    {
        private readonly AppDbContext _context;

        public MaintenanceContractRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaintenanceContract>> GetMaintenanceContractsAsync(int? storeId)
        {
            IQueryable<MaintenanceContract> query = _context.MaintenanceContracts.FilterMaintenanceContractByStoreId(storeId);
            List<MaintenanceContract> maintenanceContracts = await query.Include(m => m.Store).ToListAsync();
            return maintenanceContracts;
        }

        public async Task<MaintenanceContract?> GetMaintenanceContractByIdAsync(int id)
        {
            try
            {
                var maintenanceContract = await _context.MaintenanceContracts
                    .Include(m => m.Store)
                    .FirstOrDefaultAsync(m => m.MaintenanceContractId == id);
                return maintenanceContract;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MaintenanceContract> CreateMaintenanceContractAsync(MaintenanceContract maintenanceContract)
        {
            try
            {
                // check available contract for storeId 
                var maintenanceContractAvailable = _context.MaintenanceContracts.Any(m => m.StoreId == maintenanceContract.StoreId);

                if (maintenanceContractAvailable)
                {
                    throw new Exception("This store already has a maintenance contract");
                }
                else
                {
                    _context.MaintenanceContracts.Add(maintenanceContract);
                    await _context.SaveChangesAsync();
                    return maintenanceContract;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MaintenanceContract> UpdateMaintenanceContractAsync(MaintenanceContract maintenanceContract)
        {
            try
            {
                _context.MaintenanceContracts.Update(maintenanceContract);
                await _context.SaveChangesAsync();
                return maintenanceContract;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteMaintenanceContractAsync(int id)
        {
            try
            {
                var maintenanceContract = _context.MaintenanceContracts.
                    Include(m => m.MaintenancePayments)
                    .FirstOrDefault(m => m.MaintenanceContractId == id);
                if (maintenanceContract != null && maintenanceContract.MaintenancePayments.Count == 0)
                {
                    _context.MaintenanceContracts.Remove(maintenanceContract);
                    return await _context.SaveChangesAsync();
                }
                throw new Exception("This maintenance contract has payments");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MaintenanceContract?> GetMaintenanceContractByStoreIdAsync(int storeId)
        {
            try
            {
                var maintenanceContract = await _context.MaintenanceContracts
                    .Include(m => m.Store)
                    .FirstOrDefaultAsync(m => m.StoreId == storeId);
                return maintenanceContract;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
