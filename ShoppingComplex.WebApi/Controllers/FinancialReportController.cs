using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet]
        public async Task<ActionResult<FinancialReportDto>> GetFinancialReportAsync(DateTime startDate, DateTime endDate)
        {
            var financialReport = await _financialReportService.GetFinancialReportAsync(startDate, endDate);
            return Ok(financialReport);
        }
    }
}
