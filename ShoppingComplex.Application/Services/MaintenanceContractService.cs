using AutoMapper;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingComplex.Application.Services.Extensions;
using ShoppingComplex.Domain.Entities;

namespace ShoppingComplex.Application.Services
{
    public class MaintenanceContractService : IMaintenanceContractService
    {
        private readonly IMaintenanceContractRepository _maintenanceContractRepository;
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;

        public MaintenanceContractService(IMaintenanceContractRepository maintenanceContractRepository, IMapper mapper, IStoreRepository storeRepository)
        {
            _maintenanceContractRepository = maintenanceContractRepository;
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        // Create Maintenance Contract
        public async Task<MaintenanceContractDto> CreateMaintenanceContractAsync(MaintenanceContractDto maintenanceContract)
        {
            try
            {
                MaintenanceContract newMaintenanceContract = _mapper.Map<MaintenanceContract>(maintenanceContract);
                var createdMaintenanceContract = await _maintenanceContractRepository.CreateMaintenanceContractAsync(newMaintenanceContract);
                // update store maintenance contract id
                var store = await _storeRepository.GetStoreByIdAsync(maintenanceContract.StoreId);
                store.MaintenanceContractId = createdMaintenanceContract.MaintenanceContractId;
                await _storeRepository.UpdateStoreAsync(store);
                return _mapper.Map<MaintenanceContractDto>(createdMaintenanceContract);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete Maintenance Contract
        public async Task<int> DeleteMaintenanceContractAsync(int id)
        {
            try
            {
                var response = await _maintenanceContractRepository.DeleteMaintenanceContractAsync(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get Maintenance Contract by id
        public async Task<MaintenanceContractDto> GetMaintenanceContractByIdAsync(int id)
        {
            var maintenanceContract = await _maintenanceContractRepository.GetMaintenanceContractByIdAsync(id);
            return _mapper.Map<MaintenanceContractDto>(maintenanceContract);
        }

        // Get all Maintenance Contracts
        public async Task<PagedDataResponse<MaintenanceContractDto>> GetMaintenanceContractsAsync(int? currentPage, int? pageSize, int? storeId)
        {
            try
            {
                var maintenanceContracts = await _maintenanceContractRepository.GetMaintenanceContractsAsync(storeId);
                var maintenanceContractDtos = _mapper.Map<List<MaintenanceContractDto>>(maintenanceContracts);
                var pagedMaintenanceContracts = maintenanceContractDtos.GetPaged(currentPage, pageSize);

                return pagedMaintenanceContracts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update Maintenance Contract

        public async Task<MaintenanceContractDto> UpdateMaintenanceContractAsync(MaintenanceContractDto maintenanceContract)
        {
            var dbMaintenanceContract = await _maintenanceContractRepository.GetMaintenanceContractByIdAsync(maintenanceContract.MaintenanceContractId);
            if (dbMaintenanceContract == null)
            {
                throw new Exception("Maintenance Contract not found");
            }
            else
            {
                dbMaintenanceContract.ContractStartDate = maintenanceContract.ContractStartDate;
                dbMaintenanceContract.ContractEndDate = maintenanceContract.ContractEndDate;
                dbMaintenanceContract.ContractAmount = maintenanceContract.ContractAmount;
                dbMaintenanceContract.Description = maintenanceContract.Description;
                var updatedMaintenanceContract = await _maintenanceContractRepository.UpdateMaintenanceContractAsync(dbMaintenanceContract);
                // update store maintenance contract id
                var store = await _storeRepository.GetStoreByIdAsync(maintenanceContract.StoreId);
                store.MaintenanceContractId = updatedMaintenanceContract.MaintenanceContractId;
                await _storeRepository.UpdateStoreAsync(store);
                return _mapper.Map<MaintenanceContractDto>(updatedMaintenanceContract);
            }
        }

        // Get Maintenance Contract by storeId
        public async Task<MaintenanceContractDto> GetMaintenanceContractByStoreIdAsync(int storeId)
        {
            var maintenanceContract = await _maintenanceContractRepository.GetMaintenanceContractByStoreIdAsync(storeId);
            if (maintenanceContract == null)
            {
                return new MaintenanceContractDto
                {
                    MaintenanceContractId = 0,
                    ContractStartDate = DateTime.Now,
                    ContractEndDate = DateTime.Now,
                    ContractAmount = 0,
                    StoreId = storeId
                };
            }
            else
            {
                return _mapper.Map<MaintenanceContractDto>(maintenanceContract);
            }
        }
    }

}
