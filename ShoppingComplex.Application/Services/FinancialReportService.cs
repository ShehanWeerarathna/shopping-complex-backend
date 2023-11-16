using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly ILeasePaymentRepository _leasePaymentRepository;
        private readonly IMaintenancePaymentRepository maintenancePaymentRepository;

        public FinancialReportService(ILeasePaymentRepository leasePaymentRepository, IMaintenancePaymentRepository maintenancePaymentRepository)
        {
            _leasePaymentRepository = leasePaymentRepository;
            this.maintenancePaymentRepository = maintenancePaymentRepository;
        }



        // Get Financial Report
        public async Task<FinancialReportDto> GetFinancialReportAsync(DateTime startDate, DateTime endDate)
        {
            var leasePayments = await _leasePaymentRepository.GetLeasePaymentsByDateRange(startDate, endDate);
            var maintenancePayments = await maintenancePaymentRepository.GetMaintenancePaymentsByDateRange(startDate, endDate);

            var financialReport = new FinancialReportDto
            {
                Transactions = new List<PaymentRecordDto>()
            };
            foreach (var payment in leasePayments)
            {
                financialReport.Transactions.Add(new PaymentRecordDto
                {
                    Amount = payment.Amount,
                    IsCredit = false,
                    PaymentDate = payment.PaymentDate,
                    Description = $"Lease Payment for {payment.LeaseAgreement?.Store?.StoreName}"

                });
            }
            foreach (var payment in maintenancePayments)
            {
                financialReport.Transactions.Add(new PaymentRecordDto
                {
                    Amount = payment.Amount,
                    IsCredit = true,
                    PaymentDate = payment.PaymentDate,
                    Description = $"Maintenance Payment for {payment.MaintenanceContract?.Store?.StoreName}"

                });
            }
            return financialReport;

        }
    }
}
