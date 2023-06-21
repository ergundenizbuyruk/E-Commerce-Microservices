using ECommerce.Services.Inventory.Dtos;
using ECommerce.Shared.Dtos;

namespace ECommerce.Services.Inventory.Services.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductDto>>> GetAllAsync();
        Task<ResponseDto<ProductDto>> GetAsync(int id);
        Task<ResponseDto<List<ProductDto>>> GetProductsInCatalogAsync(int id);
        Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto product);
        Task<ResponseDto<NoContentDto>> DeleteAsync(int id);
        Task<ResponseDto<ProductDto>> UpdateAsync(ProductUpdateDto productDto);
    }
}
