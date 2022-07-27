using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/Products")]
    [ApiController]

    public class ProductController:ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public ProductController(IRepositoryManager repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public async Task <IActionResult> GetProducts()
        {
            try
            {
                var products = await _repository.Product.GetAllProductsAsync(trackChanges: false,cancellationToken:default);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }

        }
        [HttpGet("Id:int", Name = "ProductById")]
        public async Task <IActionResult> GetProductById(int id)
        {
            var products = await _repository.Product.GetByIdsAsync(id,trackChanges: false, cancellationToken:default);
            
                return Ok (products);

        }

    }
}
