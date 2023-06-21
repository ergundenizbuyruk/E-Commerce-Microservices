using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;
using ECommerce.Shared.Dtos;

namespace ECommerce.Services.Inventory.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<ResponseDto<List<CatalogDto>>> GetAllAsync();
        Task<ResponseDto<CatalogDto>> GetAsync(int id);
        Task<ResponseDto<CatalogDto>> AddAsync(CatalogCreateDto catalog);
        Task<ResponseDto<NoContentDto>> DeleteAsync(int id);
        Task<ResponseDto<CatalogDto>> UpdateAsync(CatalogUpdateDto catalogDto);
    }
}
