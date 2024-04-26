using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeProdutos.Data;
using CadastroDeProdutos.Data.Dtos;
using CadastroDeProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeProdutos.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDataContext _context;
        public ProductRepository(ApplicationDataContext context){
            _context = context;
        }

        public async Task<bool> Add(ProductDto request)
        {
            var product = new Product{
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };
            _context.Product.Add(product);
            _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _context.Product.FindAsync(id);
            if(result == null) return false;
            _context.Product.Remove(result);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var result = await _context.Product.ToListAsync();
            return result.Select( x => new ProductDto{
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();    
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Product.FindAsync(id);        
        }

        public async Task<bool> Update(ProductDto request)
        {
            var result = await _context.Product.FindAsync(request.Id);
            if(result == null) return false;
            result.Description = request.Description;
            result.Price = request.Price;
            result.Stock = request.Stock;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}