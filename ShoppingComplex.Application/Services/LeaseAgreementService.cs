using AutoMapper;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Domain.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using ShoppingComplex.Application.Services.Extensions;

namespace ShoppingComplex.Application.Services
{
    public class LeaseAgreementService : ILeaseAgreementService
    {
        private readonly ILeaseAgreementRepository _leaseAgreementRepository;
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;

        public LeaseAgreementService(ILeaseAgreementRepository leaseAgreementRepository, IMapper mapper, IStoreRepository storeRepository)
        {
            _leaseAgreementRepository = leaseAgreementRepository;
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        public async Task<LeaseAgreementDto> CreateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement)
        {
            try
            {
                LeaseAgreement newLeaseAgreement = _mapper.Map<LeaseAgreement>(leaseAgreement);
                var createdLeaseAgreement = await _leaseAgreementRepository.CreateLeaseAgreementAsync(newLeaseAgreement);
                // update store lease agreement id
                var store = await _storeRepository.GetStoreByIdAsync(leaseAgreement.StoreId);
                store.LeaseAgreementId = createdLeaseAgreement.LeaseAgreementId;
                await _storeRepository.UpdateStoreAsync(store);
                return _mapper.Map<LeaseAgreementDto>(createdLeaseAgreement);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteLeaseAgreementAsync(int id)
        {
            try
            {
                // update store lease agreement id
                var store = await _storeRepository.GetStoreByLeaseAgreementIdAsync(id);
                store.LeaseAgreementId = null;
                await _storeRepository.UpdateStoreAsync(store);
                var response = await _leaseAgreementRepository.DeleteLeaseAgreementAsync(id);
               
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LeaseAgreementDto> GetLeaseAgreementByIdAsync(int id)
        {
            var leaseAgreement = await _leaseAgreementRepository.GetLeaseAgreementByIdAsync(id);
            return _mapper.Map<LeaseAgreementDto>(leaseAgreement);
        }

        public async Task<PagedDataResponse<LeaseAgreementDto>> GetLeaseAgreementsAsync(int? currentPage, int? pageSize, int? storeId)
        {
            try
            {
                var leaseAgreements = await _leaseAgreementRepository.GetLeaseAgreementsAsync(storeId);
                var leaseAgreementDtos = _mapper.Map<List<LeaseAgreementDto>>(leaseAgreements);
                var pagedLeaseAgreements = leaseAgreementDtos.GetPaged(currentPage, pageSize);

                return pagedLeaseAgreements;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LeaseAgreementDto> UpdateLeaseAgreementAsync(LeaseAgreementDto leaseAgreement)
        {
            var dbLeaseAgreement = await _leaseAgreementRepository.GetLeaseAgreementByIdAsync(leaseAgreement.LeaseAgreementId);
            if (dbLeaseAgreement == null)
            {
                throw new Exception("Lease Agreement not found");
            }
            else
            {
                dbLeaseAgreement.LeaseStartDate = leaseAgreement.LeaseStartDate;
                dbLeaseAgreement.LeaseEndDate = leaseAgreement.LeaseEndDate;
                dbLeaseAgreement.LeaseAmount = leaseAgreement.LeaseAmount;
                var updatedLeaseAgreement = await _leaseAgreementRepository.UpdateLeaseAgreementAsync(dbLeaseAgreement);
                // update store lease agreement id
                var store = await _storeRepository.GetStoreByIdAsync(leaseAgreement.StoreId);
                store.LeaseAgreementId = updatedLeaseAgreement.LeaseAgreementId;
                await _storeRepository.UpdateStoreAsync(store);
                return _mapper.Map<LeaseAgreementDto>(updatedLeaseAgreement);
            }
        }

        public async Task<LeaseAgreementDto> GetLeaseAgreementByStoreIdAsync(int storeId)
        {
            var leaseAgreement = await _leaseAgreementRepository.GetLeaseAgreementByStoreIdAsync(storeId);
            if(leaseAgreement == null)
            {
                return new LeaseAgreementDto
                {
                    LeaseAgreementId = 0,
                    LeaseStartDate = DateTime.Now,
                    LeaseEndDate = DateTime.Now,
                    LeaseAmount = 0,
                    StoreId = storeId
                };
            }
            else
            {
                return _mapper.Map<LeaseAgreementDto>(leaseAgreement);
            }
        }

    }

}
