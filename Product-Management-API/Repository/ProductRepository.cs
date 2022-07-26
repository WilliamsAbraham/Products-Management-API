using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository :RepositoryBase <Product>, IProductRepository
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _Mapper;
        public ProductRepository(RepositoryContext context, IMapper Mapper):base(context)
        {
            _context = context; 
            _Mapper = Mapper;
        }
        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync (bool trackChanges, CancellationToken cancellationToken)
        {
            var products = await FindAll(trackChanges).OrderBy(x => x.ProductName).ToListAsync();
            var productsDto = _Mapper.Map<IEnumerable<ProductResponseDto>>(products);
            return productsDto;

        }
        public async Task<ProductResponseDto> GetByIdsAsync (int  productId, bool trackChanges)
        {
            var product = await FindByCondition(x => x.Id == productId, trackChanges).FirstOrDefaultAsync();
            var productDto = _Mapper.Map<ProductResponseDto>(product);
            return productDto;
        }
        public async Task<ProductResponseDto> CreateProductAsync(ProductCreationDto product, CancellationToken cancellationToken)
        {
          var productEntity = _Mapper.Map<Product>(product);
            Create(productEntity);
            await _context.SaveChangesAsync();
            var productToReturn = _Mapper.Map<ProductResponseDto>(productEntity);
            return productToReturn;

        }

        public async Task DeleteProductAsync(int productId, bool trackChanges, CancellationToken cancellationToken)
        {
            var Product = await GetByIdsAsync(productId, trackChanges);
            var productEntity = _Mapper.Map<Product>(Product);
            Delete(productEntity);
            _context.SaveChanges();
        }

        public async Task UpdateProductAsync(int productId, ProductUpdateDto productForUpdate, bool trackChanges, CancellationToken cancellationToken)
        {
            var Product = await GetByIdsAsync(productId, trackChanges);
            _Mapper.Map(Product, productForUpdate);
            _context.SaveChanges();

        }

        public async Task DisableProductAsync(int productId, bool trackChanges, CancellationToken cancellationToken)
        {
           var product = await GetByIdsAsync(productId, trackChanges);
           var productEntity = _Mapper.Map<Product>(product);
            productEntity.Enabled = true;
            Update(productEntity);
        }
    }
}
