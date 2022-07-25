using Shared.ProductDtos;
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
        Task<ProductCreationDto> CreateCompanyAsync(ProductCreationDto company,CancellationToken cancellationToken);
        Task DeleteCompanyAsync(int productId, bool trackChanges, CancellationToken cancellationToken);
        Task UpdateCompanyAsync(int productId, ProductUpdateDto companyForUpdate,bool trackChanges, CancellationToken cancellationToken);
    }
}
