using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeaseAgreementController : ControllerBase
    {
        private readonly ILeaseAgreementService _leaseAgreementService;

        public LeaseAgreementController(ILeaseAgreementService leaseAgreementService)
        {
            _leaseAgreementService = leaseAgreementService;
        }

        // Get all lease agreements
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<LeaseAgreementDto>>> GetLeaseAgreementsAsync(int? currentPage, int? pageSize, int? storeId)
        {
            var leaseAgreements = await _leaseAgreementService.GetLeaseAgreementsAsync(currentPage, pageSize, storeId);
            return Ok(leaseAgreements);
        }

        // Get lease agreement by id
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaseAgreementDto>> GetLeaseAgreementByIdAsync(int id)
        {
            var leaseAgreement = await _leaseAgreementService.GetLeaseAgreementByIdAsync(id);
            if (leaseAgreement == null)
            {
                return NotFound();
            }
            return Ok(leaseAgreement);
        }

        // Create a new lease agreement
        [HttpPost]
        public async Task<ActionResult<LeaseAgreementDto>> CreateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement)
        {
            var createdLeaseAgreement = await _leaseAgreementService.CreateLeaseAgreementAsync(leaseAgreement);
            return createdLeaseAgreement;
        }

        // Update lease agreement
        [HttpPut("{id}")]
        public async Task<ActionResult<LeaseAgreementDto>> UpdateLeaseAgreementAsync(int id, LeaseAgreementDto leaseAgreement)
        {
            if (id != leaseAgreement.LeaseAgreementId)
            {
                return BadRequest();
            }

            var updatedLeaseAgreement = await _leaseAgreementService.UpdateLeaseAgreementAsync(leaseAgreement);
            return Ok(updatedLeaseAgreement);
        }

        // Delete lease agreement
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteLeaseAgreementAsync(int id)
        {
            var deletedLeaseAgreementId = await _leaseAgreementService.DeleteLeaseAgreementAsync(id);
            if (deletedLeaseAgreementId == 0)
            {
                return NotFound();
            }
            return Ok(deletedLeaseAgreementId);
        }

        // Get lease agreement by store id
        [HttpGet("{storeId}")]
        public async Task<ActionResult<LeaseAgreementDto>> GetLeaseAgreementByStoreIdAsync(int storeId)
        {
            var leaseAgreement = await _leaseAgreementService.GetLeaseAgreementByStoreIdAsync(storeId);
            if (leaseAgreement == null)
            {
                return NotFound();
            }
            return Ok(leaseAgreement);
        }
    }

}
