using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeProdutos.Model;
using CadastroDeProdutos.Data.Dtos;

namespace CadastroDeProdutos.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAll();
        Task<bool> Add(ProductDto request);
        Task<bool> Delete(int id);
        Task<bool> Update(ProductDto request);
        Task<Product> GetById(int id);
    }
}