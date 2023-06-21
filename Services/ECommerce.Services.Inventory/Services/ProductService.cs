using AutoMapper;
using ECommerce.Services.Inventory.Data;
using ECommerce.Services.Inventory.Dtos;
using ECommerce.Services.Inventory.Models;
using ECommerce.Services.Inventory.Services.Interfaces;
using ECommerce.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Inventory.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> AddAsync(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<ResponseDto<NoContentDto>> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return ResponseDto<NoContentDto>.Fail("Product cannot find", 404, true);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(200);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<ResponseDto<ProductDto>> GetAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return ResponseDto<ProductDto>.Fail("Product cannot find", 404, true);
            }

            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<ResponseDto<List<ProductDto>>> GetProductsInCatalogAsync(int id)
        {
            var products = await _context.Products.Where(p => p.CatalogId == id).ToListAsync();
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<ResponseDto<ProductDto>> UpdateAsync(ProductUpdateDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productDto.Id);

            if (product == null)
            {
                return ResponseDto<ProductDto>.Fail("Product cannot find", 404, true);
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.ProductPrice = productDto.ProductPrice;
            product.NumberOfProducts = productDto.NumberOfProducts;
            product.CatalogId = productDto.CatalogId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }
    }
}
