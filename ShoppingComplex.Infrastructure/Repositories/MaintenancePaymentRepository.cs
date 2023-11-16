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
    public class MaintenancePaymentRepository : IMaintenancePaymentRepository
    {
        private readonly AppDbContext _context;

        public MaintenancePaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all MaintenancePayments
        public async Task<List<MaintenancePayment>> GetMaintenancePaymentsAsync(int? maintenanceContractId)
        {
            IQueryable<MaintenancePayment> query = _context.MaintenancePayments.FilterByMaintenanceContractId(maintenanceContractId);
            List<MaintenancePayment> maintenancePayments = await query.Include(mp => mp.MaintenanceContract).ToListAsync();
            return maintenancePayments;
        }

        // Get MaintenancePayment by id
        public async Task<MaintenancePayment> GetMaintenancePaymentByIdAsync(int id)
        {
            try
            {
                var maintenancePayment = await _context.MaintenancePayments
                    .Include(mp => mp.MaintenanceContract)
                    .ThenInclude(mc => mc.Store)
                    .FirstOrDefaultAsync(mp => mp.MaintenancePaymentId == id);
                return maintenancePayment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Create MaintenancePayment
        public async Task<MaintenancePayment> CreateMaintenancePaymentAsync(MaintenancePayment maintenancePayment)
        {
            try
            {
                _context.MaintenancePayments.Add(maintenancePayment);
                await _context.SaveChangesAsync();
                return maintenancePayment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update MaintenancePayment
        public async Task<MaintenancePayment> UpdateMaintenancePaymentAsync(MaintenancePayment maintenancePayment)
        {
            try
            {
                _context.MaintenancePayments.Update(maintenancePayment);
                await _context.SaveChangesAsync();
                return maintenancePayment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete MaintenancePayment
        public async Task<int> DeleteMaintenancePaymentAsync(int id)
        {
            try
            {
                var maintenancePayment = _context.MaintenancePayments.FirstOrDefault(mp => mp.MaintenancePaymentId == id);
                if (maintenancePayment != null)
                {
                    _context.MaintenancePayments.Remove(maintenancePayment);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get MaintenancePayments by storeId
        public async Task<List<MaintenancePayment>> GetMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var maintenancePayments = await _context.MaintenancePayments
                    .Include(mp => mp.MaintenanceContract)
                    .ThenInclude(mc => mc.Store)
                    .Where(mp => mp.PaymentDate >= startDate && mp.PaymentDate <= endDate)
                    .OrderBy(mp => mp.PaymentDate)
                    .ToListAsync();
                return maintenancePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
