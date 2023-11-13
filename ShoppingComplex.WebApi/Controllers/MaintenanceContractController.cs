using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaintenanceContractController : ControllerBase
    {
        private readonly IMaintenanceContractService _maintenanceContractService;

        public MaintenanceContractController(IMaintenanceContractService maintenanceContractService)
        {
            _maintenanceContractService = maintenanceContractService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<MaintenanceContractDto>>> GetMaintenanceContractsAsync(int? currentPage, int? pageSize, int? storeId)
        {
            var maintenanceContracts = await _maintenanceContractService.GetMaintenanceContractsAsync(currentPage, pageSize, storeId);
            return Ok(maintenanceContracts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceContractDto>> GetMaintenanceContractByIdAsync(int id)
        {
            var maintenanceContract = await _maintenanceContractService.GetMaintenanceContractByIdAsync(id);
            if (maintenanceContract == null)
            {
                return NotFound();
            }
            return Ok(maintenanceContract);
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceContractDto>> CreateMaintenanceContractAsync(MaintenanceContractDto maintenanceContract)
        {
            var createdMaintenanceContract = await _maintenanceContractService.CreateMaintenanceContractAsync(maintenanceContract);
            return createdMaintenanceContract;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MaintenanceContractDto>> UpdateMaintenanceContractAsync(int id, MaintenanceContractDto maintenanceContract)
        {
            if (id != maintenanceContract.MaintenanceContractId)
            {
                return BadRequest();
            }

            var updatedMaintenanceContract = await _maintenanceContractService.UpdateMaintenanceContractAsync(maintenanceContract);
            return Ok(updatedMaintenanceContract);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteMaintenanceContractAsync(int id)
        {
            var deletedMaintenanceContractId = await _maintenanceContractService.DeleteMaintenanceContractAsync(id);
            if (deletedMaintenanceContractId == 0)
            {
                return NotFound();
            }
            return Ok(deletedMaintenanceContractId);
        }

        [HttpGet("{storeId}")]
        public async Task<ActionResult<MaintenanceContractDto>> GetMaintenanceContractByStoreIdAsync(int storeId)
        {
            var maintenanceContract = await _maintenanceContractService.GetMaintenanceContractByStoreIdAsync(storeId);
            if (maintenanceContract == null)
            {
                return NotFound();
            }
            return Ok(maintenanceContract);
        }
    }

}
