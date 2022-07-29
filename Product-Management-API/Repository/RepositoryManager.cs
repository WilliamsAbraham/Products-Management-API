using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly UserManager<AppAdmin> _userManager;
        private readonly SignInManager<AppAdmin> _singInManagerManager;
        private readonly IConfiguration _configuration;
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;
        private readonly Lazy<IAppAdminRepository> _appAdminRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        public RepositoryManager(RepositoryContext context,IMapper mapper, UserManager<AppAdmin> userManager, IConfiguration configuration, SignInManager<AppAdmin> signInManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _singInManagerManager = signInManager;
            _configuration = configuration;
            // Initializing each repository classes when they'er needed using the Lazy class initializer
            _appAdminRepository = new Lazy<IAppAdminRepository>(() => new AppAdminRepository(_context, mapper, _userManager, _configuration,signInManager));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context,_mapper));   

        }
        // parsing the productRepository and appadminRepostory values to the Product and AppAdmin properties respectively
        public IProductRepository? Product => _productRepository.Value;

        public IAppAdminRepository? AppAdmin => _appAdminRepository.Value;

        async Task IRepositoryManager.Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
