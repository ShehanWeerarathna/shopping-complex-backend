﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<LeasePayment>> GetLeasePaymentsAsync(int? leaseAgreementId)
        {
            IQueryable<LeasePayment> query = _context.LeasePayments.FilterByLeaseAgreementId(leaseAgreementId);
            List<LeasePayment> leasePayments = await query.Include(lp => lp.LeaseAgreement).ToListAsync();
            return leasePayments;
        }

        public async Task<LeasePayment> GetLeasePaymentByIdAsync(int id)
        {
            try
            {
                var leasePayment = await _context.LeasePayments
                    .Include(lp => lp.LeaseAgreement)
                    .FirstOrDefaultAsync(lp => lp.LeasePaymentId == id);
                return leasePayment;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

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
    }

}