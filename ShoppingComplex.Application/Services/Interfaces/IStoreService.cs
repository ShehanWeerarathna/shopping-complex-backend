using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingComplex.Domain.Entities;

namespace ShoppingComplex.Application.Services.Interfaces
{
    public interface IStoreService
    {
        Task<PagedDataResponse<StoreDto>> GetStoresAsync(string? searchTerm, int? currentPage, int? pageSize, int? categoryId);
        Task<StoreDto> GetStoreByIdAsync(int id);
        Task<StoreDto> CreateStoreAsync(StoreDto store);
        Task<StoreDto> UpdateStoreAsync(StoreDto store);
        Task<int> DeleteStoreAsync(int id);
        Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
