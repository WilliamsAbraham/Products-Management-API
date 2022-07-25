using Shared.AppAdminDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAppAdminRepository
    {
        Task<AdminCreationDto> CreateCompanyAsync(AdminCreationDto admin, CancellationToken cancellationToken);
    }
}
