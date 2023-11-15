using Microsoft.AspNetCore.Mvc;
using ShoppingComplex.Application.Services.Interfaces;
using ShoppingComplex.Domain.DTOs.ResponseDtos;
using ShoppingComplex.Domain.DTOs;

namespace ShoppingComplex.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // Get all stores
        [HttpGet]
        public async Task<ActionResult<PagedDataResponse<StoreDto>>> GetStoresAsync(string? searchTerm, int? currentPage, int? pageSize, int? categoryId)
        {
            var stores = await _storeService.GetStoresAsync(searchTerm, currentPage, pageSize, categoryId);
            return Ok(stores);
        }

        // Get store by id
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetStoreByIdAsync(int id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        // Create store
        [HttpPost]
        public async Task<ActionResult<StoreDto>> CreateStoreAsync(StoreDto store)
        {
            var createdStore = await _storeService.CreateStoreAsync(store);
            return createdStore;
        }

        // Update store
        [HttpPut("{id}")]
        public async Task<ActionResult<StoreDto>> UpdateStoreAsync(int id, StoreDto store)
        {
            if (id != store.StoreId)
            {
                return BadRequest();
            }

            var updatedStore = await _storeService.UpdateStoreAsync(store);
            return Ok(updatedStore);
        }

        // Delete store
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteStoreAsync(int id)
        {
            var deletedStoreId = await _storeService.DeleteStoreAsync(id);
            if (deletedStoreId == 0)
            {
                return NotFound();
            }
            return Ok(deletedStoreId);
        }

        // Get all categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _storeService.GetCategoriesAsync();
            return Ok(categories);
        }
    }

}
