using AutoMapper;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using ShoppingComplex.Domain.Entities;
using ShoppingComplex.Infrastructure.Repositories.Interfaces;
using ShoppingComplex.Application.Services.Extensions;
using System.Reflection.Metadata.Ecma335;

namespace ShoppingComplex.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        // Create a new store
        public async Task<StoreDto> CreateStoreAsync(StoreDto store)
        {
            try
            {
                Store newStore = _mapper.Map<Store>(store);
                var createdStore = await _storeRepository.CreateStoreAsync(newStore);
                var storeDto =  _mapper.Map<StoreDto>(createdStore);
                return storeDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete store
        public async Task<int> DeleteStoreAsync(int id)
        {
            try
            {
                var response = await _storeRepository.DeleteStoreAsync(id);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get store by id
        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _storeRepository.GetCategoriesAsync();
                return _mapper.Map<List<CategoryDto>>(categories);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get store by id
        public async Task<StoreDto> GetStoreByIdAsync(int id)
        {
            if(id == 0)
            {
                return new StoreDto
                {
                    StoreId = 0,
                    StoreName = "",
                    CategoryId = 0,
                    LeaseAgreementId = null
                };
            }
            var store = await _storeRepository.GetStoreByIdAsync(id);
            return _mapper.Map<StoreDto>(store);
        }

        // Get all stores
        public async Task<PagedDataResponse<StoreDto>> GetStoresAsync(string? searchTerm, int? currentPage, int? pageSize, int? categoryId)
        {
            try
            {
                var stores = await _storeRepository.GetStoresAsync(searchTerm, categoryId);
                var storeDtos = _mapper.Map<List<StoreDto>>(stores);
                var pagedStores = storeDtos.GetPaged(currentPage, pageSize);

                return pagedStores;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update store
        public async Task<StoreDto> UpdateStoreAsync(StoreDto store)
        {
            var dbStore = await _storeRepository.GetStoreByIdAsync(store.StoreId);
            if (dbStore == null)
            {
                throw new Exception("Store not found");
            }
            else
            {
                dbStore.StoreName = store.StoreName;
                dbStore.CategoryId = store.CategoryId;
                dbStore.LeaseAgreementId = store.LeaseAgreementId; // Adjust as needed
                var updatedStore = await _storeRepository.UpdateStoreAsync(dbStore);
                return _mapper.Map<StoreDto>(updatedStore);
            }
        }
    }

}
