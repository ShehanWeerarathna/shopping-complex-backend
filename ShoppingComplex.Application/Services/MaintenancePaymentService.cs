using AutoMapper;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Domain.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingComplex.Application.Services.Extensions;

namespace ShoppingComplex.Application.Services
{
    public class MaintenancePaymentService : IMaintenancePaymentService
    {
        private readonly IMaintenancePaymentRepository _maintenancePaymentRepository;
        private readonly IMapper _mapper;

        public MaintenancePaymentService(IMaintenancePaymentRepository maintenancePaymentRepository, IMapper mapper)
        {
            _maintenancePaymentRepository = maintenancePaymentRepository;
            _mapper = mapper;
        }

        // Create Maintenance Payment
        public async Task<MaintenancePaymentDto> CreateMaintenancePaymentAsync(MaintenancePaymentDto maintenancePayment)
        {
            try
            {
                MaintenancePayment newMaintenancePayment = _mapper.Map<MaintenancePayment>(maintenancePayment);
                var createdMaintenancePayment = await _maintenancePaymentRepository.CreateMaintenancePaymentAsync(newMaintenancePayment);
                return _mapper.Map<MaintenancePaymentDto>(createdMaintenancePayment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete Maintenance Payment
        public async Task<int> DeleteMaintenancePaymentAsync(int id)
        {
            try
            {
                var response = await _maintenancePaymentRepository.DeleteMaintenancePaymentAsync(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get Maintenance Payment by id
        public async Task<MaintenancePaymentDto> GetMaintenancePaymentByIdAsync(int id)
        {
            var maintenancePayment = await _maintenancePaymentRepository.GetMaintenancePaymentByIdAsync(id);
            if (id == 0)
            {
                return new MaintenancePaymentDto
                {
                    MaintenancePaymentId = 0,
                    Amount = 0,
                    PaymentDate = DateTime.Now,
                    MaintenanceContractId = 0
                };
            }
            else
            {
                return _mapper.Map<MaintenancePaymentDto>(maintenancePayment);
            }
        }

        // Get all Maintenance Payments
        public async Task<PagedDataResponse<MaintenancePaymentDto>> GetMaintenancePaymentsAsync(int? currentPage, int? pageSize, int? maintenanceContractId)
        {
            try
            {
                var maintenancePayments = await _maintenancePaymentRepository.GetMaintenancePaymentsAsync(maintenanceContractId);
                var maintenancePaymentDtos = _mapper.Map<List<MaintenancePaymentDto>>(maintenancePayments);
                var pagedMaintenancePayments = maintenancePaymentDtos.GetPaged(currentPage, pageSize);

                return pagedMaintenancePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get Maintenance Payments by storeId
        public async Task<List<MaintenancePaymentDto>> GetMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            var maintenancePayments = await _maintenancePaymentRepository.GetMaintenancePaymentsByDateRange(startDate, endDate);
            return _mapper.Map<List<MaintenancePaymentDto>>(maintenancePayments);
        }

        // Update Maintenance Payment
        public async Task<MaintenancePaymentDto> UpdateMaintenancePaymentAsync(MaintenancePaymentDto maintenancePayment)
        {
            var dbMaintenancePayment = await _maintenancePaymentRepository.GetMaintenancePaymentByIdAsync(maintenancePayment.MaintenancePaymentId);
            if (dbMaintenancePayment == null)
            {
                throw new Exception("Maintenance Payment not found");
            }
            else
            {
                dbMaintenancePayment.PaymentDate = maintenancePayment.PaymentDate;
                dbMaintenancePayment.Amount = maintenancePayment.Amount;
                var updatedMaintenancePayment = await _maintenancePaymentRepository.UpdateMaintenancePaymentAsync(dbMaintenancePayment);
                return _mapper.Map<MaintenancePaymentDto>(updatedMaintenancePayment);
            }
        }

        // Get Maintenance Payments by storeId
        public async Task<PagedDataResponse<MaintenancePaymentDto>> GetPagedMaintenancePaymentsByDateRange(DateTime startDate, DateTime endDate, int? currentPage, int? pageSize)
        {
            try
            {
                var maintenancePayments = await _maintenancePaymentRepository.GetMaintenancePaymentsByDateRange(startDate, endDate);
                var maintenancePaymentDtos = _mapper.Map<List<MaintenancePaymentDto>>(maintenancePayments);
                var pagedMaintenancePayments = maintenancePaymentDtos.GetPaged(currentPage, pageSize);

                return pagedMaintenancePayments;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
