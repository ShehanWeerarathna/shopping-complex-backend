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

        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<LeaseAgreementDto>>> GetLeaseAgreementsAsync(int? currentPage, int? pageSize, int? storeId)
        {
            var leaseAgreements = await _leaseAgreementService.GetLeaseAgreementsAsync(currentPage, pageSize, storeId);
            return Ok(leaseAgreements);
        }

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

        [HttpPost]
        public async Task<ActionResult<LeaseAgreementDto>> CreateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement)
        {
            var createdLeaseAgreement = await _leaseAgreementService.CreateLeaseAgreementAsync(leaseAgreement);
            return createdLeaseAgreement;
        }

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
