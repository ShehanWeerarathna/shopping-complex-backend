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

        // Get all maintenance contracts
        public async Task<List<MaintenanceContract>> GetMaintenanceContractsAsync(int? storeId)
        {
            IQueryable<MaintenanceContract> query = _context.MaintenanceContracts.FilterMaintenanceContractByStoreId(storeId);
            List<MaintenanceContract> maintenanceContracts = await query.Include(m => m.Store).ToListAsync();
            return maintenanceContracts;
        }

        // Get maintenance contract by id
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

        // Create maintenance contract
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

        // Update maintenance contract
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

        // Delete maintenance contract
        public async Task<int> DeleteMaintenanceContractAsync(int id)
        {
            try
            {
                var maintenanceContract = _context.MaintenanceContracts.
                    Include(m => m.MaintenancePayments)
                    .FirstOrDefault(m => m.MaintenanceContractId == id);
                if (maintenanceContract != null)
                {
                    _context.MaintenanceContracts.Remove(maintenanceContract);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get maintenance contract by storeId
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

        public async Task<bool> GetOngoingContractsAvailabilityByStoreId(int storeId)
        {
            bool ongoingContractsAvailability = await _context.MaintenanceContracts.AnyAsync(m => m.StoreId == storeId && m.ContractEndDate > DateTime.);
            return ongoingContractsAvailability;
        }
    }

}
