using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenancePaymentController : ControllerBase
    {
        private readonly IMaintenancePaymentService _maintenancePaymentService;

        public MaintenancePaymentController(IMaintenancePaymentService maintenancePaymentService)
        {
            _maintenancePaymentService = maintenancePaymentService;
        }

        // Get all maintenance payments
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<MaintenancePaymentDto>>> GetMaintenancePaymentsAsync(int? currentPage, int? pageSize, int? maintenanceContractId)
        {
            var maintenancePayments = await _maintenancePaymentService.GetMaintenancePaymentsAsync(currentPage, pageSize, maintenanceContractId);
            return Ok(maintenancePayments);
        }

        // Get maintenance payment by id
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenancePaymentDto>> GetMaintenancePaymentByIdAsync(int id)
        {
            var maintenancePayment = await _maintenancePaymentService.GetMaintenancePaymentByIdAsync(id);
            if (maintenancePayment == null)
            {
                return NotFound();
            }
            return Ok(maintenancePayment);
        }

        // Create a new maintenance payment
        [HttpPost]
        public async Task<ActionResult<MaintenancePaymentDto>> CreateMaintenancePaymentAsync(MaintenancePaymentDto maintenancePayment)
        {
            var createdMaintenancePayment = await _maintenancePaymentService.CreateMaintenancePaymentAsync(maintenancePayment);
            return createdMaintenancePayment;
        }

        // Update maintenance payment
        [HttpPut("{id}")]
        public async Task<ActionResult<MaintenancePaymentDto>> UpdateMaintenancePaymentAsync(int id, MaintenancePaymentDto maintenancePayment)
        {
            if (id != maintenancePayment.MaintenancePaymentId)
            {
                return BadRequest();
            }

            var updatedMaintenancePayment = await _maintenancePaymentService.UpdateMaintenancePaymentAsync(maintenancePayment);
            return Ok(updatedMaintenancePayment);
        }

        // Delete maintenance payment
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteMaintenancePaymentAsync(int id)
        {
            var deletedMaintenancePaymentId = await _maintenancePaymentService.DeleteMaintenancePaymentAsync(id);
            if (deletedMaintenancePaymentId == 0)
            {
                return NotFound();
            }
            return Ok(deletedMaintenancePaymentId);
        }

        // Get maintenance payments by date range
        [HttpGet]
        public async Task<ActionResult<List<MaintenancePaymentDto>>> GetMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var maintenancePayments = await _maintenancePaymentService.GetMaintenancePaymentsByDateRange(startDate, endDate);
            return Ok(maintenancePayments);
        }

        // Get paged maintenance payments by date range
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<MaintenancePaymentDto>>> GetPagedMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate, int? currentPage, int? pageSize)
        {
            var maintenancePayments = await _maintenancePaymentService.GetPagedMaintenancePaymentsByDateRange(startDate, endDate, currentPage, pageSize);
            return Ok(maintenancePayments);
        }
    }

}
