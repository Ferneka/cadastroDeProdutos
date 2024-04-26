using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeProdutos.Data.Dtos;
using CadastroDeProdutos.Model.ViewModel;
using CadastroDeProdutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository){
            _productRepository = productRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel request){
            var productDto = new ProductDto {
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };
            var result = await _productRepository.Add(productDto);
            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpGet]
        public async Task<List<ProductDto>> GetAll(){
            return await _productRepository.GetAll();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var result = await _productRepository.Delete(id);
            if(!result) return NotFound();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id){
            var request = await _productRepository.GetById(id);
            if(request == null) return BadRequest();
            var result = new ProductDto{
                Id = request.Id,
                Description =  request.Description,
                Price = request.Price,
                Stock = request.Stock
            };
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductViewModel request){
            var result = await _productRepository.Update(
                new ProductDto{
                    Description = request.Description,
                    Price = request.Price,
                    Stock = request.Stock
                });
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}