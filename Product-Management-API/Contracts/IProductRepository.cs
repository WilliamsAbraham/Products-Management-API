using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllProductsAsync(bool trackChanges, CancellationToken cancellationToken);
        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company,CancellationToken cancellationToken);
        Task DeleteCompanyAsync(Guid companyId, bool trackChanges, CancellationToken cancellationToken);
        Task UpdateCompanyAsync(Guid companyid, CompanyForUpdateDto companyForUpdate,bool trackChanges, CancellationToken cancellationToken);
    }
}
