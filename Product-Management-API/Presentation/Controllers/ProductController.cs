﻿using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;

namespace Presentation.Controllers
{
    [Route("api/Products")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager  _repository;
        public ProductController(IRepositoryManager repository)
        {
            _repository = repository;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _repository.Product.GetAllProductsAsync(trackChanges: false, cancellationToken: default);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("Id:int", Name = "ProductById")]
        [Authorize]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _repository.Product.GetByIdsAsync(id, trackChanges: false, cancellationToken: default);

            return Ok(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreationDto company)
        {
            if (company is null)
                return BadRequest("Product object is null");
            var createdProduct = await _repository.Product.CreateProductAsync(company, cancellationToken: default);
            return Ok(createdProduct);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Manager")]    
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            await _repository.Product.DeleteProductAsync(Id, trackChanges: false, cancellationToken: default);

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateProduct")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto productUpdate)
        {
            if (productUpdate is null)
                return BadRequest("Product object is null");
            await _repository.Product.UpdateProductAsync(id, productUpdate, trackChanges: false, cancellationToken: default);

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "DisableProduct")]
        [Authorize]
        public async Task<IActionResult> DisableProduct(int id)
        {

            await _repository.Product.DisableProductAsync(id, trackChanges: false, cancellationToken: default);

            return NoContent();
        }

        [HttpGet("DisabledProduct")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetDisabledProducts ()
        {
            var DisabledProducts = await _repository.Product.GetAllDisabledProductAsync(cancellationToken: default);
            return Ok(DisabledProducts);
        }

        [HttpGet("SumeofPrce")]
        [Authorize]
        public async Task<IActionResult> GetSumOfPrice()
        {
            var sum = await _repository.Product.GetPriceSumOfProducts(cancellationToken: default);
            return Ok(sum);
        }
    }
}