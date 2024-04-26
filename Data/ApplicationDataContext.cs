using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeProdutos.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options):base(options){

        }
        public DbSet<Product> Product {get; set;}
    }
}