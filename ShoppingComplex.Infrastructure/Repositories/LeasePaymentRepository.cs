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
    public class LeasePaymentRepository : ILeasePaymentRepository
    {
        private readonly AppDbContext _context;

        public LeasePaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all LeasePayments
        public async Task<List<LeasePayment>> GetLeasePaymentsAsync(int? leaseAgreementId)
        {
            IQueryable<LeasePayment> query = _context.LeasePayments.FilterByLeaseAgreementId(leaseAgreementId);
            List<LeasePayment> leasePayments = await query.Include(lp => lp.LeaseAgreement).ToListAsync();
            return leasePayments;
        }

        // Get LeasePayment by id
        public async Task<LeasePayment> GetLeasePaymentByIdAsync(int id)
        {
            try
            {
                var leasePayment = await _context.LeasePayments
                    .Include(lp => lp.LeaseAgreement)
                    .ThenInclude(la => la.Store)
                    .FirstOrDefaultAsync(lp => lp.LeasePaymentId == id);
                return leasePayment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Create LeasePayment
        public async Task<LeasePayment> CreateLeasePaymentAsync(LeasePayment leasePayment)
        {
            try
            {
                _context.LeasePayments.Add(leasePayment);
                await _context.SaveChangesAsync();
                return leasePayment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update LeasePayment
        public async Task<LeasePayment> UpdateLeasePaymentAsync(LeasePayment leasePayment)
        {
            try
            {
                _context.LeasePayments.Update(leasePayment);
                await _context.SaveChangesAsync();
                return leasePayment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete LeasePayment
        public async Task<int> DeleteLeasePaymentAsync(int id)
        {
            try
            {
                var leasePayment = _context.LeasePayments.FirstOrDefault(lp => lp.LeasePaymentId == id);
                if (leasePayment != null)
                {
                    _context.LeasePayments.Remove(leasePayment);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get LeasePayments by storeId
        public async Task<List<LeasePayment>> GetLeasePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var leasePayments = await _context.LeasePayments
                    .Include(lp => lp.LeaseAgreement)
                    .ThenInclude(la => la.Store)
                    .Where(lp => lp.PaymentDate >= startDate && lp.PaymentDate <= endDate)
                    .ToListAsync();
                return leasePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
