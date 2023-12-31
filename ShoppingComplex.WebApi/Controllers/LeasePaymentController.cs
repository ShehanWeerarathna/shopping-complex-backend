﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LeasePaymentController : ControllerBase
    {
        private readonly ILeasePaymentService _leasePaymentService;

        public LeasePaymentController(ILeasePaymentService leasePaymentService)
        {
            _leasePaymentService = leasePaymentService;
        }

        // Get all lease payments
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<LeasePaymentDto>>> GetLeasePaymentsAsync(int? currentPage, int? pageSize, int? leaseAgreementId)
        {
            var leasePayments = await _leasePaymentService.GetLeasePaymentsAsync(currentPage, pageSize, leaseAgreementId);
            return Ok(leasePayments);
        }

        // Get lease payment by id
        [HttpGet("{id}")]
        public async Task<ActionResult<LeasePaymentDto>> GetLeasePaymentByIdAsync(int id)
        {
            var leasePayment = await _leasePaymentService.GetLeasePaymentByIdAsync(id);
            if (leasePayment == null)
            {
                return NotFound();
            }
            return Ok(leasePayment);
        }

        // Create a new lease payment
        [HttpPost]
        public async Task<ActionResult<LeasePaymentDto>> CreateLeasePaymentAsync(LeasePaymentDto leasePayment)
        {
            var createdLeasePayment = await _leasePaymentService.CreateLeasePaymentAsync(leasePayment);
            return createdLeasePayment;
        }

        // Update lease payment
        [HttpPut("{id}")]
        public async Task<ActionResult<LeasePaymentDto>> UpdateLeasePaymentAsync(int id, LeasePaymentDto leasePayment)
        {
            if (id != leasePayment.LeasePaymentId)
            {
                return BadRequest();
            }

            var updatedLeasePayment = await _leasePaymentService.UpdateLeasePaymentAsync(leasePayment);
            return Ok(updatedLeasePayment);
        }

        // Delete lease payment
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteLeasePaymentAsync(int id)
        {
            var deletedLeasePaymentId = await _leasePaymentService.DeleteLeasePaymentAsync(id);
            if (deletedLeasePaymentId == 0)
            {
                return NotFound();
            }
            return Ok(deletedLeasePaymentId);
        }

        // Get lease payments by date range
        [HttpGet]
        public async Task<ActionResult<List<LeasePaymentDto>>> GetLeasePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var leasePayments = await _leasePaymentService.GetLeasePaymentsByDateRange(startDate, endDate);
            return Ok(leasePayments);
        }

        // Get paged lease payments by date range
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<LeasePaymentDto>>> GetPagedLeasePaymentsByDateRange(DateTime startDate, DateTime endDate, int? currentPage, int? pageSize)
        {
            var leasePayments = await _leasePaymentService.GetPagedLeasePaymentsByDateRange(startDate, endDate, currentPage, pageSize);
            return Ok(leasePayments);
        }
    }

}
