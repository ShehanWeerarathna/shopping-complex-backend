using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IFinancialReportService
    {
        Task<FinancialReportDto> GetFinancialReportAsync(DateTime startDate, DateTime endDate);
    }
}
