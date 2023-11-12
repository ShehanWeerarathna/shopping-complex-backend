using AutoMapper;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using ShoppingComplex.Domain.Entities;
using ShoppingComplex.Application.Services.Extensions;

namespace ShoppingComplex.Application.Services
{
    public class LeasePaymentService : ILeasePaymentService
    {
        private readonly ILeasePaymentRepository _leasePaymentRepository;
        private readonly IMapper _mapper;

        public LeasePaymentService(ILeasePaymentRepository leasePaymentRepository, IMapper mapper)
        {
            _leasePaymentRepository = leasePaymentRepository;
            _mapper = mapper;
        }

        public async Task<LeasePaymentDto> CreateLeasePaymentAsync(LeasePaymentDto leasePayment)
        {
            try
            {
                LeasePayment newLeasePayment = _mapper.Map<LeasePayment>(leasePayment);
                var createdLeasePayment = await _leasePaymentRepository.CreateLeasePaymentAsync(newLeasePayment);
                return _mapper.Map<LeasePaymentDto>(createdLeasePayment);
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
                var response = await _leasePaymentRepository.DeleteLeasePaymentAsync(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LeasePaymentDto> GetLeasePaymentByIdAsync(int id)
        {
            var leasePayment = await _leasePaymentRepository.GetLeasePaymentByIdAsync(id);
            if(id == 0)
            {
                return new LeasePaymentDto {
                    LeasePaymentId = 0,
                    Amount = 0,
                    PaymentDate = DateTime.Now,
                    LeaseAgreementId = 0
                };
            }
            else
            {
                return _mapper.Map<LeasePaymentDto>(leasePayment);
            }
            
        }

        public async Task<PagedDataResponse<LeasePaymentDto>> GetLeasePaymentsAsync( int? currentPage, int? pageSize, int? leaseAgreementId)
        {
            try
            {
                var leasePayments = await _leasePaymentRepository.GetLeasePaymentsAsync(leaseAgreementId);
                var leasePaymentDtos = _mapper.Map<List<LeasePaymentDto>>(leasePayments);
                var pagedLeasePayments = leasePaymentDtos.GetPaged(currentPage, pageSize);

                return pagedLeasePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LeasePaymentDto>> GetLeasePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var leasePayments = await _leasePaymentRepository.GetLeasePaymentsByDateRange(startDate, endDate);
            return _mapper.Map<List<LeasePaymentDto>>(leasePayments);
        }

        public async Task<LeasePaymentDto> UpdateLeasePaymentAsync(LeasePaymentDto leasePayment)
        {
            var dbLeasePayment = await _leasePaymentRepository.GetLeasePaymentByIdAsync(leasePayment.LeasePaymentId);
            if (dbLeasePayment == null)
            {
                throw new Exception("Lease Payment not found");
            }
            else
            {
                dbLeasePayment.PaymentDate = leasePayment.PaymentDate;
                dbLeasePayment.Amount = leasePayment.Amount;
                var updatedLeasePayment = await _leasePaymentRepository.UpdateLeasePaymentAsync(dbLeasePayment);
                return _mapper.Map<LeasePaymentDto>(updatedLeasePayment);
            }
        }

        public async Task<PagedDataResponse<LeasePaymentDto>> GetPagedLeasePaymentsByDateRange(DateTime startDate, DateTime endDate, int? currentPage, int? pageSize)
        {
            try
            {
                var leasePayments = await _leasePaymentRepository.GetLeasePaymentsByDateRange(startDate, endDate);
                var leasePaymentDtos = _mapper.Map<List<LeasePaymentDto>>(leasePayments);
                var pagedLeasePayments = leasePaymentDtos.GetPaged(currentPage, pageSize);

                return pagedLeasePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
