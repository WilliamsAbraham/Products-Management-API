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
        public async Task<ProductResponseDto> GetByIdsAsync (int  productId, bool trackChanges, CancellationToken cancellationToken)
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
            var Product = await GetByIdsAsync(productId, trackChanges, cancellationToken:default);
            var productEntity = _Mapper.Map<Product>(Product);
            Delete(productEntity);
            _context.SaveChanges();
        }

        public async Task UpdateProductAsync(int productId, ProductUpdateDto productForUpdate, bool trackChanges, CancellationToken cancellationToken)
        {
            var Product = await GetByIdsAsync(productId, trackChanges, cancellationToken:default);
            _Mapper.Map(Product, productForUpdate);
            _context.SaveChanges();

        }

        public async Task DisableProductAsync(int productId, bool trackChanges, CancellationToken cancellationToken)
        {
           var product = await GetByIdsAsync(productId, trackChanges, cancellationToken:default);
           var productEntity = _Mapper.Map<Product>(product);
            productEntity.IsEnabled = false;
            Update(productEntity);
        }
        public async Task<IEnumerable<ProductResponseDto>> GetAllDisabledProductAsync( CancellationToken cancellationToken)
        {
            var Products = await GetAllProductsAsync(trackChanges:false, cancellationToken: default);

            var DisabledProducts = Products.Where(x => x.IsEnabled == false).OrderByDescending(x => x.CreatedDate).ToList();
            return DisabledProducts;
        }
        public async Task<decimal> GetPriceSumOfProducts(CancellationToken cancellationToken)
        {
            var startDate = DateTime.Now.AddDays(-7);
            var sumOfProductsWithinSevenDays = 0.0m;
            var products = await GetAllProductsAsync(trackChanges:false,cancellationToken:default);
            var productsWithinSevenDays = products.Where(x =>x.CreatedDate >= startDate).ToList();
           
            foreach (var product in products)
            {
                sumOfProductsWithinSevenDays += (decimal)product.Price;
            }
            return sumOfProductsWithinSevenDays;


        }
    }
}
