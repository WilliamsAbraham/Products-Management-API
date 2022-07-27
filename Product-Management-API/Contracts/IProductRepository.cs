
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync(bool trackChanges, CancellationToken cancellationToken);
        Task<ProductResponseDto> GetByIdsAsync(int productId, bool trackChanges, CancellationToken cancellationToken);
        Task<ProductResponseDto> CreateProductAsync(ProductCreationDto product,CancellationToken cancellationToken);
        Task DeleteProductAsync(int productId, bool trackChanges, CancellationToken cancellationToken);
        Task UpdateProductAsync(int productId, ProductUpdateDto companyForUpdate,bool trackChanges, CancellationToken cancellationToken);
        Task DisableProductAsync(int productId, bool trackChanges, CancellationToken cancellationToken);
        Task<IEnumerable<ProductResponseDto>> GetAllDisabledProductAsync(CancellationToken cancellationToken);
        Task<decimal> GetPriceSumOfProducts(CancellationToken cancellationToken);
    }
}
