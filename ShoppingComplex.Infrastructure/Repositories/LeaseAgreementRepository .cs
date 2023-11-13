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
    public class LeaseAgreementRepository : ILeaseAgreementRepository
    {
        private readonly AppDbContext _context;

        public LeaseAgreementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaseAgreement>> GetLeaseAgreementsAsync(int? storeId)
        {
            IQueryable<LeaseAgreement> query = _context.LeaseAgreements.FilterLeaseAgreementByStoreId(storeId);
            List<LeaseAgreement> leaseAgreements = await query.Include(l => l.Store).ToListAsync();
            return leaseAgreements;
        }

        public async Task<LeaseAgreement?> GetLeaseAgreementByIdAsync(int id)
        {
            try
            {
                var leaseAgreement = await _context.LeaseAgreements
                    .Include(l => l.Store)
                    .FirstOrDefaultAsync(l => l.LeaseAgreementId == id);
                return leaseAgreement;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<LeaseAgreement> CreateLeaseAgreementAsync(LeaseAgreement leaseAgreement)
        {
            try
            {
                // check available agreement for storeId 
                var leaseAgreementAvailable = _context.LeaseAgreements.Any(l => l.StoreId == leaseAgreement.StoreId);

                if (leaseAgreementAvailable)
                {
                    throw new Exception("This store already has an agreement");
                }
                else
                {
                    _context.LeaseAgreements.Add(leaseAgreement);
                    await _context.SaveChangesAsync();
                    return leaseAgreement;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LeaseAgreement> UpdateLeaseAgreementAsync(LeaseAgreement leaseAgreement)
        {
            try
            {
                _context.LeaseAgreements.Update(leaseAgreement);
                await _context.SaveChangesAsync();
                return leaseAgreement;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteLeaseAgreementAsync(int id)
        {
            try
            {
                var leaseAgreement = _context.LeaseAgreements.FirstOrDefault(l => l.LeaseAgreementId == id);
                if (leaseAgreement != null)
                {
                    _context.LeaseAgreements.Remove(leaseAgreement);
                    return await _context.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<LeaseAgreement?> GetLeaseAgreementByStoreIdAsync(int storeId)
        {
            try
            {
                var leaseAgreement = await _context.LeaseAgreements
                    .Include(l => l.Store)
                    .FirstOrDefaultAsync(l => l.StoreId == storeId);
                return leaseAgreement;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
