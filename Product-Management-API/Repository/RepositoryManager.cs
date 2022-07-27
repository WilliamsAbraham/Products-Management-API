using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly UserManager<AppAdmin> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;
        private readonly Lazy<IAppAdminRepository> _appAdminRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        public RepositoryManager(RepositoryContext context,IMapper mapper, UserManager<AppAdmin> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _appAdminRepository = new Lazy<IAppAdminRepository>(() => new AppAdminRepository(_context, mapper, _userManager, _configuration));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context,_mapper));   

        }
        public IProductRepository? Product => _productRepository.Value;

        public IAppAdminRepository? AppAdmin => _appAdminRepository.Value;

        async Task IRepositoryManager.Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
