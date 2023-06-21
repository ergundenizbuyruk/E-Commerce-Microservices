using AutoMapper;
using ECommerce.Services.Inventory.Data;
using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;
using ECommerce.Services.Inventory.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Inventory.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CatalogService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<CatalogDto>> AddAsync(CatalogCreateDto catalogDto)
        {
            var catalog = _mapper.Map<Catalog>(catalogDto);
            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();
            return ResponseDto<CatalogDto>.Success(_mapper.Map<CatalogDto>(catalog), 200);
        }

        public async Task<ResponseDto<NoContentDto>> DeleteAsync(int id)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x => x.Id == id);

            if (catalog == null)
            {
                return ResponseDto<NoContentDto>.Fail("Catalog cannot find", 404, true);
            }

            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(200);
        }

        public async Task<ResponseDto<List<CatalogDto>>> GetAllAsync()
        {
            var catalogs = await _context.Catalogs.ToListAsync();
            return ResponseDto<List<CatalogDto>>.Success(_mapper.Map<List<CatalogDto>>(catalogs), 200);
        }

        public async Task<ResponseDto<CatalogDto>> GetAsync(int id)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x => x.Id == id);

            if (catalog == null)
            {
                return ResponseDto<CatalogDto>.Fail("Catalog cannot find", 404, true);
            }

            return ResponseDto<CatalogDto>.Success(_mapper.Map<CatalogDto>(catalog), 200);
        }

        public async Task<ResponseDto<CatalogDto>> UpdateAsync(CatalogUpdateDto catalogDto)
        {
            var catalog = await _context.Catalogs.FirstOrDefaultAsync(x => x.Id == catalogDto.Id);

            if (catalog == null)
            {
                return ResponseDto<CatalogDto>.Fail("Catalog cannot find", 404, true);
            }

            catalog.Name = catalogDto.Name;
            catalog.Description = catalogDto.Description;
            _context.Catalogs.Update(catalog);
            await _context.SaveChangesAsync();

            return ResponseDto<CatalogDto>.Success(_mapper.Map<CatalogDto>(catalog), 200);
        }
    }
}
